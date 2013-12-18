#define HSM
#undef HSM

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using HANDLE = System.IntPtr;

#if HSM
    using HSM.Embedded.Decoding;
    using HSM.Embedded.Camera;
    using HSM.Embedded.Utility;
    using HSM.Embedded.Wireless;
    using HSM.Embedded.Wireless.Network;
    using HSM.Embedded.WirelessAssembly;
#else
    using DecodeAssemblyITC;
    using CameraAssembly;
    using ITC.Embedded.WirelessAssembly;
    using MS.Wireless.Network;  //cloned HSM.Embedded.Network code
    using MS.Embedded.Utility;  //cloned HSM.Embedded.Utility
#endif

using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Battery_Test_itc
{
    public partial class batteryTestfrm : Form
    {
        public batteryTestfrm()
        {
            InitializeComponent();
        }

        [DllImport("coredll.dll")]
        static extern void SystemIdleTimerReset();

        [DllImport("coredll.dll")]
        static extern bool SetSystemPowerState(IntPtr pwdSystemState, UInt32 StateFlags, UInt32 Options);

        const UInt32 POWER_STATE_ON = (0x00010000);        // on state

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        public static extern HANDLE CreateEvent(HANDLE lpEventAttributes, [In, MarshalAs(UnmanagedType.Bool)] bool bManualReset, [In, MarshalAs(UnmanagedType.Bool)] bool bIntialState, [In, MarshalAs(UnmanagedType.BStr)] string lpName);

        [DllImport("coredll.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(HANDLE hObject);


        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EventModify(HANDLE hEvent, [In, MarshalAs(UnmanagedType.U4)] int dEvent);
        public enum EventFlags
        {
            PULSE = 1,
            RESET = 2,
            SET = 3
        }

        private static bool SetEvent(HANDLE hEvent)
        {
            return EventModify(hEvent, (int)EventFlags.SET);
        }


        [DllImport("CoreDLL.dll")]
        public static extern int CeRunAppAtTime(string application, SystemTime startTime);

        [DllImport("CoreDLL.dll")]
        public static extern int FileTimeToSystemTime(ref long lpFileTime, SystemTime lpSystemTime);

        [DllImport("CoreDLL.dll")]
        public static extern int FileTimeToLocalFileTime(ref long lpFileTime, ref long lpLocalFileTime);

        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        // The application is build around a state machine, in order to separate the various tests where needed
        // There are several tests which can be done:
        // - scan at certain interval
        // - take picture at certain interval
        // - send data at certain interval
        // - take gps at certain interval
        // - send data at end of test cycle
        //
        // On the Dolphin 70e the scanner and camera can not operate at the same time, so these tasks need to be planned in squence
        // The various tasks are triggered by individual timers, they change the task state from IDLE to PLAN, or skip when it was not IDLE yet again
        // The state machine loop then changes it from PLAN to EXEC, based upon mutual exclusion rules
        // Once the job is done, the state is changed from EXEC to DONE
        // The state machine loop then changes it from DONE to IDLE, allowing the individual timer to raise the flag next time again

        private enum TaskTestState
        {
            IDLE,
            PLAN,
            EXEC,
            DONE
        }

        // Trans-o-flex defined two types of tests:
        // - Belade
        // - Tour
        // These tests use different intervals and different cycles
        // The type is relevant for the state machine to know whether it has to perform the final bulk data trasfer or not

        private enum TestPlanType
        {
            NONE,
            BELADE_PLAN,
            BELADE_EXEC,
            TOUR_PLAN,
            TOUR_EXEC,
            RUHE_PLAN,
            RUHE_EXEC,
            DONE
        }
        
        private string logFile;
        private DateTime startTime;
        private TimeSpan timeSpan;
        private TimeSpan testSpan; 
        private int testHours;
        private int startLevel;
        private int lastLevel;
        private TestPlanType testPlanType; // V1.3.2
        // private DateTime nextTime;
        private int numScanBarcodes;
        private int numSnapPhotos;
        private int numFTPSessions;
        private int numTotalDataBytes;
        private int numSendDataBytes;
        private int numFTPSuccess;
        private int numTourCycles;
        private TaskTestState stateGPSPosition;
        private TaskTestState stateScanBarcode;
        private TaskTestState stateSnapPhoto;
        private TaskTestState stateFTPSession;
        private TaskTestState stateTourCycle;
        private int numTourCycleScanBarcodes;
        private bool stopTest = false;

        private bool skipPhase = false;

        private int timeoutScanBarcode;
        private int timeoutSnapPhoto;
        private GPS gps = null;
        private string gps_location = string.Empty;

        private bool deviceInUnattended = false;
        private bool complained = false;

#if HSM
        private DecodeAssembly da = new DecodeAssembly();
        private CameraAssembly ca = new CameraAssembly();
        private WirelessManager wim = new WirelessManager();
        private ConnMgr cmr = new ConnMgr();
#else
        DecodeAssembly da = new DecodeAssembly(); //Intermec.DataCollection.BarcodeReader bcr;
        CameraAssembly.CameraAssembly ca = new CameraAssembly.CameraAssembly();
        private WirelessManager wim = new WirelessManager();
        private ConnMgr cmr = new ConnMgr();
#endif

        public const int UNATTENDED_ON = 1;
        public const int POWER_FORCE = 0x1000;
        public const int UNATTENDED_OFF = 0;

        public enum PowerMode
        {
            ReevaluateStat = 0x0001,
            PowerChange = 0x0002,
            UnattendedMode = 0x0003,
            SuspendKeyOrPwrButtonPressed = 0x0004,
            SuspendKeyReleased = 0x0005,
            AppButtonPressed = 0x0006
        }

        [DllImport("CoreDll.dll")]
        public static extern int PowerPolicyNotify(PowerMode powerMode, int flags);

        public enum DeviceState : int
        {
            Unspecified = -1,
            FullOn = 0,
            LowOn,
            StandBy,
            Sleep,
            Off,
            Maximum
        }

        [DllImport("CoreDll.DLL")]
        public static extern IntPtr SetPowerRequirement(String pvDevice, int DeviceState, int DeviceFlags, IntPtr pvSystemState, int StateFlags);

        [DllImport("CoreDll.DLL")]
        public static extern uint ReleasePowerRequirement(IntPtr hPowerReq);

        private void Form1_Load(object sender, EventArgs e)
        {
            this.doPresetBelade1();
            this.doPresetTour1();

            this.testPlanType = TestPlanType.NONE;
            bool state = false;
            WirelessManager.GetWLANState(ref state);
            this.checkBoxTestWLAN.Checked = state;

            WirelessManager.GetWWANState(ref state);
            this.checkBoxTestWWAN.Checked = state;

            // this.textBoxDataServer.Text = dd;
            this.textBoxDataServer.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPServer", @"127.0.0.1");
            this.textBoxDataBenutzer.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPUsername", @"ftp");
            this.textBoxDataKennwort.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPPassword", @"ftp");
            
            // V1.4.0
            this.radioButtonPassive.Checked = ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPPassive", true.ToString())==true.ToString());
            this.doSetActivePassive();
            

            try
            { // disconnect in case the assembly autoconnects are create instance
                this.da.Disconnect();
            }
            catch
            {
            }

            try
            { // disconnect in case the assembly autoconnects are create instance
                this.ca.Disconnect();
            }
            catch
            {
            }
            this.da.DecodeEvent += new DecodeAssembly.DecodeEventHandler(da_DecodeEvent);
            this.ca.CameraEvent += new CameraAssembly.CameraAssembly.CameraEventHandler(ca_CameraEvent);
        }

        void ca_CameraEvent(object sender, CameraAssembly.CameraEventArgs e)
        {
            this.doLog("Photo snapped " + e.TaskCode.ToString());
            if (e.TaskCode == CameraAssembly.CameraTaskCodes.ImageCaptureComplete)
            {
                this.stateSnapPhoto = TaskTestState.DONE;
            }
            else
            {
                this.stateSnapPhoto = TaskTestState.DONE;
            }
        }

        void da_DecodeEvent(object sender, DecodeEventArgs e)
        {
            this.stateScanBarcode = TaskTestState.DONE;
        }


        private void doRefreshOutputStatusDisplay()
        {
            int akkuLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.labelStartzeit.Text = this.startTime.ToString("HH:mm:ss");
            this.labelTestdauer.Text = this.timeSpan.ToString().Split('.')[0];
            this.labelAnzahlBarcodeScans.Text = this.numScanBarcodes.ToString();
            this.labelAnzahlPhotosSnapped.Text = this.numSnapPhotos.ToString();
            this.labelFTPBytesSent.Text = this.numTotalDataBytes.ToString();
            this.labelFTPSessions.Text = this.numFTPSuccess.ToString() + " / " + this.numFTPSessions.ToString();
            this.labelAkkulevel.Text = akkuLevel.ToString();
            if (akkuLevel != this.lastLevel)
            {
                this.doLog("Akku " + akkuLevel.ToString() + "%");
                this.lastLevel = akkuLevel;
            }
        }

        private void doStartRuhe()
        {
            batteryTestfrm.SystemIdleTimerReset();
            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

            // V 1.5.3
            this.complained = false;

            this.startTime = DateTime.Now;
            this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.5.1
            this.logFile = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + "-Ruhe.log";
            this.textBoxLog.Text = string.Empty;

            WirelessManager.SetWWANState(false);
            WirelessManager.SetWLANState(false);

            this.startLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.lastLevel = this.startLevel;
            this.numTotalDataBytes = 0;

            this.testHours = (int)(this.numericUpDownRuheLaufzeitStunden.Value); // V1.3.0 use global var
            // V1.5.2
            this.testSpan = new TimeSpan(this.testHours, (int)(this.numericUpDownRuheLaufzeitMinuten.Value), 0);
            this.doLog("Testdauer Ruhephase: " + this.testHours.ToString() + " Stunde(n)");
            this.doLog("Akku " + this.startLevel.ToString() + "%");

            this.doLog("Test Ruhe gestart");
            this.testPlanType = TestPlanType.RUHE_EXEC;

            // V1.5.2
            if (this.radioButtonRuheSuspend.Checked)
            {
                // if we use real suspend, we disable auto timeouts because we will control it
                this.doSetTimeouts(0, 0, 0, 0, 0, 0);
            }
            else
            {
                // if we use Pseudo-suspend (unattended mode) device will go into suspend after 60 seconds
                this.doSetTimeouts(0, 0, 0, 0, 0, 0);
                deviceInUnattended = false;
            }
        }

        // Initiate the "Belade" Test

        private void doStartBelade()
        {
            batteryTestfrm.SystemIdleTimerReset();
            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

            // V 1.5.3
            this.complained = false;

            // V1.5.2
            // devide should not go into suspend, but just in case
            bool result = (PowerPolicyNotify(PowerMode.UnattendedMode, UNATTENDED_ON) != 0);


            this.startTime = DateTime.Now;
            this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.5.1
            this.logFile = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + "-Belade.log";
            this.textBoxLog.Text = string.Empty;

            // V1.5.4 swapped, used wrong 
            WirelessManager.SetWWANState(this.radioButtonBeladeGPRS.Checked);
            WirelessManager.SetWLANState(this.radioButtonBeladeWIFI.Checked);

            if (this.radioButtonBeladeGPRS.Checked)
            {
                this.textBoxLog.Text = "Attaching to GPRS ...";
                Application.DoEvents();
                if (!this.cmr.Connected)
                {
                    this.cmr.Connect(this.textBoxGPRSEntry.Text,
                        ConnMgr.ConnectionMode.Asynchronous,
                        this.textBoxGPRSBenutzer.Text,
                        this.textBoxGPRSKennwort.Text,
                        this.textBoxGPRSAPN.Text);

                    int maxWait = 30;
                    while (!cmr.Connected && maxWait-- > 0)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }


            this.startLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.lastLevel = this.startLevel;
            this.numTotalDataBytes = 0;

            this.testHours = (int)(this.numericUpDownBeladeLaufzeitStunden.Value); // V1.3.0 use global var
            // V1.5.2
            this.testSpan = new TimeSpan(this.testHours, 0, 0);
            this.doLog("Testdauer Beladephase: " + this.testHours.ToString() + " Stunde(n)");
            this.doLog("Akku " + this.startLevel.ToString() + "%");

            if (this.testHours > 0)
            {
                if ((int)(this.numericUpDownBeladeScanBarcodes.Value) > 0)
                {
                    int secondsNextScan = this.testHours * 3600 / (int)(this.numericUpDownBeladeScanBarcodes.Value);
                    this.timerPlanScan.Interval = secondsNextScan * 1000;
                    this.doLog("Scan jede " + secondsNextScan.ToString() + " Sekunde(n)");
                    this.timeoutScanBarcode = (int)(this.numericUpDownBeladeScanBarcodeDurationSekunden.Value) * 1000;
                }

                if ((int)(this.numericUpDownBeladeSnapPhotos.Value) > 0)
                {
                    int secondsNextPhoto = this.testHours * 3600 / (int)(this.numericUpDownBeladeSnapPhotos.Value);
                    this.timerPlanPhoto.Interval = secondsNextPhoto * 1000;
                    this.timeoutSnapPhoto = (int)(this.numericUpDownBeladeSnapPhotoDurationSekunden.Value) * 1000;
                    this.timerExecPhoto.Interval = this.timeoutSnapPhoto;
                    this.doLog("Photo jede " + secondsNextPhoto.ToString() + " Sekunde(n)");
                }

                if ((int)(this.numericUpDownBeladeFTPSessions.Value) > 0)
                {
                    int secondsNextData = this.testHours * 3600 / (int)(this.numericUpDownBeladeFTPSessions.Value);
                    this.numSendDataBytes = (int)(this.numericUpDownBeladeFTPSessionSize.Value);  // V1.2.0
                    this.timerPlanData.Interval = secondsNextData * 1000;
                    this.doLog("Data jede " + secondsNextData.ToString() + " Sekunde(n)");
                }
            }

            this.doLog("Test Belade gestart");
            this.testPlanType = TestPlanType.BELADE_EXEC; // V1.5.0

            this.numScanBarcodes = 0;
            this.numSnapPhotos = 0;
            this.numFTPSessions = 0;
            this.numFTPSuccess = 0;
            this.numTourCycles = 0;
            this.stateScanBarcode = TaskTestState.IDLE;
            this.stateSnapPhoto = TaskTestState.IDLE;
            this.stateFTPSession = TaskTestState.IDLE;
            this.stateTourCycle = TaskTestState.IDLE;
            this.stateGPSPosition = TaskTestState.IDLE; // V1.3.0

            // this.timerLoopSecond.Enabled = true; // V1.5.0
            if (this.testHours > 0)
            {
                this.timerPlanScan.Enabled = ((int)(this.numericUpDownBeladeScanBarcodes.Value) > 0);
                this.timerPlanPhoto.Enabled = ((int)(this.numericUpDownBeladeSnapPhotos.Value) > 0);
                this.timerPlanData.Enabled = ((int)(this.numericUpDownBeladeFTPSessions.Value) > 0);
                this.timerPlanGPS.Enabled = false; // V1.3.0
                this.timerPlanTourCycle.Enabled = false; // V1.3.0
            }


            // V1.5.0 done at global test start
            // this.buttonStop.Enabled = true;
        }


        private void doStartTour()
        {
            batteryTestfrm.SystemIdleTimerReset();
            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

            // V 1.5.3
            this.complained = false;

            // V1.5.2
            bool result = (PowerPolicyNotify(PowerMode.UnattendedMode, UNATTENDED_ON) != 0);


            this.startTime = DateTime.Now;
            this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.5.1
            this.logFile = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + "-Tour.log";
            this.textBoxLog.Text = string.Empty;

            WirelessManager.SetWLANState(false);
            WirelessManager.SetWWANState(true);

            this.textBoxLog.Text = "Attaching to GPRS ...";
            Application.DoEvents();
            if (!this.cmr.Connected)
            {
                this.cmr.Connect(this.textBoxGPRSEntry.Text,
                    ConnMgr.ConnectionMode.Asynchronous,
                    this.textBoxGPRSBenutzer.Text,
                    this.textBoxGPRSKennwort.Text,
                    this.textBoxGPRSAPN.Text);

                int maxWait = 30;
                while (!cmr.Connected && maxWait-- > 0)
                {
                    Thread.Sleep(1000);
                }
            }

            this.startLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.lastLevel = this.startLevel;
            this.numTotalDataBytes = 0;

            this.testHours = (int)(this.numericUpDownTourLaufzeitStunden.Value); // V1.3.0 use global var
            // V1.5.2
            this.testSpan = new TimeSpan(this.testHours, 0, 0);
            this.doLog("Testdauer Tourphase: " + this.testHours.ToString() + " Stunde(n)");
            this.doLog("Akku " + this.startLevel.ToString() + "%");

            this.gps_location = "-/-";
            this.gps = new GPS("SWI6:", 4800);
            // this.gps.OpenComPort();
            this.gps.OnGPSDateEventHandler += new GPS.GPSDateEventHandler(gps_OnGPSDateEventHandler);

            if (this.testHours > 0)
            {
                if ((int)(this.numericUpDownTourCycleIntervalMinuten.Value) > 0)
                {
                    int secondsNextScan = (int)(this.numericUpDownTourCycleIntervalMinuten.Value) * 60;
                    this.timerPlanTourCycle.Interval = secondsNextScan * 1000;
                    this.doLog("Interval jede " + secondsNextScan.ToString() + " Sekunde(n)");
                    this.timeoutScanBarcode = (int)(this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value) * 1000;

                    int secondsDisplayOn = (int)(this.numericUpDownTourCycleDisplayAn.Value) * 60;
                    // V1.5.2
                    this.doSetTimeouts(0, 0, 0, 0, 0, 0);

                    // V1.5.2
                    this.timerManageUnattended.Interval = secondsDisplayOn * 1000;
                    this.timerManageUnattended.Enabled = true;

                    this.doLog("Display an " + secondsDisplayOn.ToString() + " Sekunde(n)");

                }

                if ((int)(this.numericUpDownTourSnapPhotos.Value) > 0)
                {
                    int secondsNextPhoto = this.testHours * 3600 / (int)(this.numericUpDownTourSnapPhotos.Value);
                    this.timerPlanPhoto.Interval = secondsNextPhoto * 1000;
                    this.timeoutSnapPhoto = (int)(this.numericUpDownTourSnapPhotoDurationSekunden.Value) * 1000;
                    this.timerExecPhoto.Interval = this.timeoutSnapPhoto;
                    this.doLog("Photo jede " + secondsNextPhoto.ToString() + " Sekunde(n)");
                }

                if ((int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value) > 0)
                {
                    int secondsNextData = (int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value);
                    this.numSendDataBytes = (int)(this.numericUpDownTourFTPSessionSize.Value); // V1.2.0
                    this.timerPlanData.Interval = secondsNextData * 1000;
                    this.doLog("Data jede " + secondsNextData.ToString() + " Sekunde(n)");
                }

                // V1.3.0
                if ((int)(this.numericUpDownTourGPSIntervalSekunden.Value) > 0)
                {
                    int secondsNextGPS = (int)(this.numericUpDownTourGPSIntervalSekunden.Value);
                    this.timerPlanGPS.Interval = secondsNextGPS * 1000;
                    this.doLog("GPS jede " + secondsNextGPS.ToString() + " Sekunde(n)");
                }
            }
            this.doLog("Test Tour gestart");
            this.testPlanType = TestPlanType.TOUR_EXEC; // V1.5.0

            this.numScanBarcodes = 0;
            this.numSnapPhotos = 0;
            this.numFTPSessions = 0;
            this.numFTPSuccess = 0;
            this.numTourCycles = 0;
            this.stateScanBarcode = TaskTestState.IDLE;
            this.stateSnapPhoto = TaskTestState.IDLE;
            this.stateFTPSession = TaskTestState.IDLE;
            this.stateTourCycle = TaskTestState.IDLE;
            this.stateGPSPosition = TaskTestState.IDLE; // V1.3.0

            if (this.testHours > 0)
            {
                this.timerPlanScan.Enabled = false; // V1.3.0
                this.timerPlanTourCycle.Enabled = ((int)(this.numericUpDownTourCycleIntervalMinuten.Value) > 0);
                this.timerPlanPhoto.Enabled = ((int)(this.numericUpDownTourSnapPhotos.Value) > 0);
                this.timerPlanData.Enabled = ((int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value) > 0);
                this.timerPlanGPS.Enabled = ((int)(this.numericUpDownTourGPSIntervalSekunden.Value) > 0); // V1.3.0
            }

        }

        private void doSetTimeouts(int BacklightBatteryTimeout, int BacklightACTimeout, int PowerBattUserIdle, int PowerACUserIdle, int PowerBattSuspendTimeout, int PowerACSuspendTimeout)
        {
            // this.doLog("Timeouts BT: BKL=" + BacklightBatteryTimeout.ToString() + " IDL=" + PowerBattUserIdle.ToString() + " SUS=" + PowerBattSuspendTimeout.ToString());
            // this.doLog("Timeouts AC: BKL=" + BacklightACTimeout.ToString() + " IDL=" + PowerACUserIdle.ToString() + " SUS=" + PowerACSuspendTimeout.ToString());

            // set backlight timeouts, ACTimeout==USBTimeout and for some reason both must be set, AC1Timeout is dock AC
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"BatteryTimeout", BacklightBatteryTimeout, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"ACTimeout", BacklightACTimeout, RegistryValueKind.DWord); // USB
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"USBTimeout", BacklightACTimeout, RegistryValueKind.DWord); // USB
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"AC1Timeout", BacklightACTimeout, RegistryValueKind.DWord); // AC

            // V1.5.2 a positive value must reside in either the plain or the Unchecked parameter, otherwise the system will revert the plain to a default
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"BatteryTimeoutUnchecked", (BacklightBatteryTimeout == 0) ? 60 : 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"ACTimeoutUnchecked", (BacklightACTimeout == 0) ? 60 : 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"USBTimeoutUnchecked", (BacklightACTimeout == 0) ? 60 : 0, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_CURRENT_USER\ControlPanel\BackLight", @"AC1TimeoutUnchecked", (BacklightACTimeout == 0) ? 60 : 0, RegistryValueKind.DWord);

            IntPtr p1 = CreateEvent(HANDLE.Zero, false, true, @"BackLightChangeEvent");
            SetEvent(p1);
            CloseHandle(p1);

            // set useridle (screen-off) timeouts
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "BattUserIdle", PowerBattUserIdle, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "ACUserIdle", PowerACUserIdle, RegistryValueKind.DWord);
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "USBUserIdle", PowerACUserIdle, RegistryValueKind.DWord); // undocumented, is this the right key?? 

            // set suspend timeouts
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "BattSuspendTimeout", PowerBattSuspendTimeout, RegistryValueKind.DWord);
            // V1.5.2 D70e has also USB power settings and ACSuspendTimeout==USB_Timeout, for some unknown reason both need to be set
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "AC_Timeout", PowerACSuspendTimeout, RegistryValueKind.DWord); // dock AC
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "USB_Timeout", PowerACSuspendTimeout, RegistryValueKind.DWord); // USB AC
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Power\Timeouts", "ACSuspendTimeout", PowerACSuspendTimeout, RegistryValueKind.DWord); // USB AC

            IntPtr p2 = CreateEvent(HANDLE.Zero, false, true, @"PowerManager/ReloadActivityTimeouts");
            SetEvent(p2);
            CloseHandle(p2);
        }

        private void doStartTest()
        {
            this.testPlanType = TestPlanType.BELADE_PLAN; // V1.5.0

            // V1.5.2
            this.startTime = DateTime.Now;

            this.doSetTimeouts(0, 0, 0, 0, 0, 0);

            this.menuItemStart.Enabled = false;
            this.stopTest = false;
            this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
            this.menuItemExit.Enabled = false;
            this.buttonStop.Enabled = true;
            this.buttonSkipPhase.Enabled = true;

            this.timerStateMachine.Interval = 1000; // V1.5.2 go in speed mode
            this.timerStateMachine.Enabled = true;


        }

        void gps_OnGPSDateEventHandler(object sender, GPSData e)
        {
            this.gps_location = e.GotPosition.ToString() + " (" + e.NumberOfSatellites.ToString() + ") " + e.LongitudeD + "/" + e.LatitudeD;
            if (e.GotPosition && this.stateGPSPosition == TaskTestState.EXEC)
            {
                this.timerExecGPS.Enabled = false;
                this.stateGPSPosition = TaskTestState.DONE;
                this.Invoke(new invoked_log(this.doLog), "GPS: " + this.gps_location);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.stopTest = true;

            this.timerPlanScan.Enabled = false;
            this.timerPlanPhoto.Enabled = false;
            this.timerPlanData.Enabled = false;
            this.timerPlanTourCycle.Enabled = false;
            this.timerPlanGPS.Enabled = false;
            this.timerExecGPS.Enabled = false;

            this.timeSpan = DateTime.Now.Subtract(this.startTime);
            this.doLog("Test abbrechen ...");

            this.timerStateMachine.Interval = 1000;
            this.timerStateMachine.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonSkipPhase.Enabled = false;

        }
        
        // This is the main State Machine Loop
        // It will activate, based up certain sequence and mutual exclusion rules, any Task which was set to from IDLE to PLAN by the timers
        // It will also initiate certain cleanup when a Task is DONE and revert it back to IDLE

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            this.timeSpan = DateTime.Now.Subtract(this.startTime);

            this.doRefreshOutputStatusDisplay();

            if (this.stopTest) // V1.3.0 interrupt any plans is we are supposed to stop
            {
                if (this.stateFTPSession == TaskTestState.PLAN)
                {
                    this.stateFTPSession = TaskTestState.IDLE;
                }
                if (this.stateScanBarcode == TaskTestState.PLAN)
                {
                    this.stateScanBarcode = TaskTestState.IDLE;
                }
                if (this.stateSnapPhoto == TaskTestState.PLAN)
                {
                    this.stateSnapPhoto = TaskTestState.IDLE;
                }
                if (this.stateTourCycle == TaskTestState.PLAN)
                {
                    this.stateTourCycle = TaskTestState.IDLE;
                }
                if (this.stateGPSPosition != TaskTestState.IDLE)
                {
                    this.stateGPSPosition = TaskTestState.DONE;
                }
                // V1.5.2
                bool result = (PowerPolicyNotify(PowerMode.UnattendedMode, UNATTENDED_OFF) != 0);

            }

            switch (this.testPlanType)
            {
                case TestPlanType.BELADE_PLAN:
                    if (this.checkBoxIncludeBeladePhase.Checked)
                    {
                        this.timerStateMachine.Enabled = false;
                        this.timerStateMachine.Interval = 5000; // V1.5.2 go in relax mode
                        this.doStartBelade();
                        this.timerStateMachine.Enabled = true;

                    }
                    else
                    {
                        this.doLog("Test: skip Belade ...");
                        this.testPlanType = TestPlanType.TOUR_PLAN;
                    }
                    break;

                case TestPlanType.TOUR_PLAN:
                    if (this.checkBoxIncludeTourPhase.Checked)
                    {
                        this.timerStateMachine.Enabled = false;
                        this.timerStateMachine.Interval = 5000; // V1.5.2 go in relax mode
                        this.doStartTour();
                        this.timerStateMachine.Enabled = true;
                    }
                    else
                    {
                        this.doLog("Test: skip Tour ...");
                        this.testPlanType = TestPlanType.RUHE_PLAN;
                    }
                    break;

                case TestPlanType.RUHE_PLAN:
                    if (this.checkBoxIncludeRuhePhase.Checked)
                    {
                        this.timerStateMachine.Enabled = false;
                        this.timerStateMachine.Interval = 20000; // V1.5.2 go in relax mode
                        this.doStartRuhe();
                        this.timerStateMachine.Enabled = true;

                    }
                    else
                    {
                        this.doLog("Test: skip Ruhe ...");
                        this.testPlanType = TestPlanType.DONE;
                    }
                    break;

                case TestPlanType.RUHE_EXEC:

                    if (!stopTest && !skipPhase)
                    {
                        // this.doLog("Ruhephase ping");
                        if (this.radioButtonRuheSuspend.Checked)
                        {
                            this.timerStateMachine.Enabled = false; // temp disable the looper because we get dual entry after resume

                            // V1.5.2
                            // long fileStartTime = DateTime.Now.AddHours((double)this.numericUpDownRuheLaufzeitStunden.Value).AddMinutes((double)this.numericUpDownRuheLaufzeitMinuten.Value).ToFileTime();
                            long fileStartTime = this.startTime.AddHours((double)this.numericUpDownRuheLaufzeitStunden.Value).AddMinutes((double)this.numericUpDownRuheLaufzeitMinuten.Value).ToFileTime();

                            // V1.5.2 wakeup every hour to log battery , so let's see which interval is shorter
                            long fileStartTime2 = DateTime.Now.AddHours((double)1.0).ToFileTime();
                            // long fileStartTime2 = DateTime.Now.AddMinutes((double)2.0).ToFileTime();
                            if (fileStartTime2 < fileStartTime)
                            {
                                fileStartTime = fileStartTime2;
                            }

                            long localFileStartTime = 0;
                            FileTimeToLocalFileTime(ref fileStartTime, ref localFileStartTime);

                            SystemTime systemStartTime = new SystemTime();
                            FileTimeToSystemTime(ref localFileStartTime, systemStartTime);
                            // we plan to be woken up after a few hours
                            string myappname = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                            CeRunAppAtTime(myappname, systemStartTime);

                            this.doLog("Suspend für " + this.numericUpDownRuheLaufzeitStunden.Value.ToString() + "h" + this.numericUpDownRuheLaufzeitMinuten.Value.ToString() + "m");

                            // V1.5.2
                            UtilMethods.SuspendDevice();
                            // PowerPolicyNotify(PowerMode.SuspendKeyOrPwrButtonPressed, 0);  

                            this.timeSpan = DateTime.Now.Subtract(this.startTime); // V1.5.0
                            this.doLog("Wakeup nach: " + this.timeSpan.ToString().Split('.')[0]);

                            // V2.5.2
                            this.lastLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
                            this.doLog("Akku " + this.lastLevel.ToString() + "%");

                            this.timerStateMachine.Enabled = true;
                        }
                        else if (!this.deviceInUnattended)
                        {
                            // V1.5.2
                            this.timerManageUnattended.Interval = 1000;
                            this.timerManageUnattended.Enabled = true;
                        }
                        this.timeSpan = DateTime.Now.Subtract(this.startTime); // V1.5.0

                        // if (timeSpan.Hours >= this.testHours) // V1.3.0 use global var
                        if (timeSpan.CompareTo(this.testSpan) > 0) // V1.5.2
                        {
                            this.doLog("Ruhephase ending");
                            batteryTestfrm.SystemIdleTimerReset();
                            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

                            this.timerManageUnattended.Enabled = false;
                            this.deviceInUnattended = false;

                            this.testPlanType = TestPlanType.DONE;

                            this.doLog("Test beendet nach: " + this.timeSpan.ToString().Split('.')[0]);
                            this.testPlanType = TestPlanType.DONE;
                        } // if we were woken up earlier, then we look back into this

                    }
                    else
                    {
                        this.testPlanType = TestPlanType.DONE;
                    }
                    break;

                case TestPlanType.BELADE_EXEC:
                case TestPlanType.TOUR_EXEC:
                case TestPlanType.DONE:

                    if (this.stateGPSPosition == TaskTestState.DONE)
                    {
                        this.timerExecGPS.Enabled = false;
                        this.stateGPSPosition = TaskTestState.IDLE;
                        Thread t = new Thread(new ThreadStart(this.threadedCloseGPS));
                        t.Start();
                    }

                    // GPS .. this may need to be reviewed
                    // Currently the GPS is opened every time on test demand and closed after Fix or Timeout
                    // The event handler waits for a Fix-position or else the Close timer will end
                    // Not sure there is time enough for fix, although Windows should also have the GPS open
                    // Alternatively, the GPS needs to be opened at the start of the Test and closed at the End and at test interval we simply take the current status immediately

                    if (this.stateGPSPosition == TaskTestState.PLAN)
                    {
                        try
                        {
                            this.doLog("GPS: obtain location ...");
                            if (this.gps.OpenComPort() == 0)
                            { // V1.3.0
                                this.stateGPSPosition = TaskTestState.EXEC;
                                this.timerExecGPS.Enabled = true;
                            }
                            else
                            {
                                this.stateGPSPosition = TaskTestState.IDLE;
                                this.doLog("GPS: fail to open GPS");
                            }
                        }
                        catch
                        {
                            this.stateGPSPosition = TaskTestState.IDLE;
                        }
                    }


                    if (this.stateTourCycle == TaskTestState.PLAN && (this.stateSnapPhoto == TaskTestState.IDLE || this.stateSnapPhoto == TaskTestState.PLAN))
                    {
                        this.numTourCycles++;
                        this.stateTourCycle = TaskTestState.EXEC;
                        this.numTourCycleScanBarcodes = (int)(this.numericUpDownTourCycleScanBarcodes.Value);
                    }
                    if (this.stateTourCycle == TaskTestState.EXEC && this.numTourCycleScanBarcodes > 0 && this.stateScanBarcode == TaskTestState.IDLE)
                    {
                        this.numTourCycleScanBarcodes--;
                        this.stateScanBarcode = TaskTestState.PLAN;
                    }
                    if (this.stateTourCycle == TaskTestState.EXEC && this.numTourCycleScanBarcodes == 0)
                    {
                        if (this.textBoxDataServer.Text != string.Empty && (int)(this.numericUpDownTourCycleFTPSessionSize.Value) > 0)
                        {
                            this.numFTPSessions++;
                            this.doLog("Interval Data #" + this.numTourCycles.ToString() + ": (" + this.numericUpDownTourCycleFTPSessionSize.Value.ToString() + ")");
                            try
                            {
                                OpenNETCF.Net.Ftp.FTP client = new OpenNETCF.Net.Ftp.FTP(this.textBoxDataServer.Text);
                                if (client != null)
                                {
                                    client.BeginConnect(this.textBoxDataBenutzer.Text, this.textBoxDataKennwort.Text);
                                    int numWait = 50;
                                    while (!client.IsConnected && numWait-- > 0)
                                    {
                                        Thread.Sleep(100);
                                    }
                                    if (client.IsConnected)
                                    {
                                        client.TransferType = OpenNETCF.Net.Ftp.FTPTransferType.Binary;
                                        this.numTotalDataBytes += (int)(this.numericUpDownTourCycleFTPSessionSize.Value);
                                        client.SendBytes((int)this.numericUpDownTourCycleFTPSessionSize.Value);
                                        client.Disconnect();
                                        client = null;
                                        this.numFTPSuccess++;
                                    }
                                    else
                                    {
                                        this.doLog("FTP nicht geöffnet");
                                    }
                                }
                                else
                                {
                                    this.doLog("FTP nicht geöffnet");
                                }
                            }
                            catch (Exception ee)
                            {
                                this.doLog(this.textBoxDataBenutzer.Text + ":" + this.textBoxDataKennwort.Text + "@" + this.textBoxDataServer.Text + " -> " + ee.Message);
                            }
                        }
                        this.stateTourCycle = TaskTestState.DONE;
                    }

                    if (this.stateTourCycle == TaskTestState.DONE)
                    {
                        this.stateTourCycle = TaskTestState.IDLE;
                    }

                    if (this.stateScanBarcode == TaskTestState.PLAN && (this.stateSnapPhoto == TaskTestState.IDLE || this.stateSnapPhoto == TaskTestState.PLAN))
                    {
                        this.numScanBarcodes++;
                        this.doLog("Scan #" + this.numScanBarcodes.ToString());
                        this.stateScanBarcode = TaskTestState.EXEC;
                        this.da.Connect();
                        this.da.ScanTimeout = this.timeoutScanBarcode;
                        this.da.ScanBarcode();
                    }

                    if (this.stateScanBarcode == TaskTestState.DONE)
                    {
                        this.da.Disconnect();
                        this.stateScanBarcode = TaskTestState.IDLE;
                    }

                    if (this.stateSnapPhoto == TaskTestState.PLAN && this.stateScanBarcode == TaskTestState.IDLE && this.stateTourCycle == TaskTestState.IDLE)
                    {
                        this.numSnapPhotos++;
                        this.doLog("Photo #" + this.numSnapPhotos.ToString());
                        this.stateSnapPhoto = TaskTestState.EXEC;
                        try
                        {
#if HSM
                            this.ca.Connect(this.pictureBox1.Handle, null, null);
#else
                            this.ca.Connect(ref this.pictureBox1, null, null);
#endif
                            long resolutionSetting;
                            this.ca.GetResolutionCount(out resolutionSetting);
                            this.ca.SetResolution((uint)(resolutionSetting - 1));
                            this.ca.SetProperty(CameraProperty.Illumination, 1, PropertyMode.Manual);
                            this.ca.SetProperty(CameraProperty.ColorEnable, 1, PropertyMode.Manual);
                            this.ca.StartPreview();
                            this.timerExecPhoto.Enabled = true;
                        }
                        catch (Exception ee)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception: "+ee.Message);
                        }
                    }

                    if (this.stateSnapPhoto == TaskTestState.DONE)
                    {
                        try
                        {
                            this.ca.StopPreview();
                            this.ca.Disconnect();
                        }
                        catch
                        {
                        }
                        this.stateSnapPhoto = TaskTestState.IDLE;
                    }

                    if (this.stateFTPSession == TaskTestState.PLAN)
                    {
                        this.numFTPSessions++;
                        this.doLog("Data #" + this.numFTPSessions.ToString() + ": (" + this.numSendDataBytes.ToString() + ") ");
                        this.stateFTPSession = TaskTestState.EXEC;
                        if (this.textBoxDataServer.Text != string.Empty)
                        {
                            try
                            {
                                OpenNETCF.Net.Ftp.FTP client = new OpenNETCF.Net.Ftp.FTP(this.textBoxDataServer.Text);
                                if (client != null)
                                {
                                    client.BeginConnect(this.textBoxDataBenutzer.Text, this.textBoxDataKennwort.Text);
                                    int numWait = 50;
                                    while (!client.IsConnected && numWait-- > 0)
                                    {
                                        Thread.Sleep(100);
                                    }
                                    if (client.IsConnected)
                                    {
                                        client.TransferType = OpenNETCF.Net.Ftp.FTPTransferType.Binary;
                                        this.numTotalDataBytes += this.numSendDataBytes;
                                        client.SendBytes(this.numSendDataBytes);
                                        client.Disconnect();
                                        client = null;
                                        this.numFTPSuccess++;
                                    }
                                    else
                                    {
                                        this.doLog("FTP nicht geöffnet");
                                    }
                                }
                                else
                                {
                                    this.doLog("FTP nicht geöffnet");
                                }
                            }
                            catch (Exception ee)
                            {
                                this.doLog(this.textBoxDataBenutzer.Text + ":" + this.textBoxDataKennwort.Text + "@" + this.textBoxDataServer.Text + " -> " + ee.Message);
                            }
                        }
                        this.stateFTPSession = TaskTestState.DONE;
                    }

                    if (this.stateFTPSession == TaskTestState.DONE)
                    {
                        this.stateFTPSession = TaskTestState.IDLE;
                    }

                    if ((this.stopTest || this.skipPhase || timeSpan.CompareTo(this.testSpan) > 0) &&
                        (this.stateFTPSession != TaskTestState.IDLE || this.stateSnapPhoto != TaskTestState.IDLE || this.stateScanBarcode != TaskTestState.IDLE || this.stateGPSPosition != TaskTestState.IDLE))
                    {
                        // do nothing yet, wait until substates are finised
                        if (!complained)
                        {
                            // V1.5.3
                            this.timerPlanScan.Enabled = false;
                            this.timerPlanPhoto.Enabled = false;
                            this.timerPlanData.Enabled = false;
                            this.timerPlanTourCycle.Enabled = false;
                            this.timerPlanGPS.Enabled = false;

                            complained = true;
                            this.doLog("waiting for sub test to complete");
                        }
                    }
                    else

                        // V1.5.2
                        // if (!this.stopTest && (this.skipPhase || timeSpan.Hours >= this.testHours || this.testPlanType == TestPlanType.DONE)) // V1.3.0 use global var
                        if (!this.stopTest && (this.skipPhase || timeSpan.CompareTo(this.testSpan) > 0 || this.testPlanType == TestPlanType.DONE)) // V1.3.0 use global var
                        {
                            // V1.3.0
                            this.timerPlanScan.Enabled = false;
                            this.timerPlanPhoto.Enabled = false;
                            this.timerPlanData.Enabled = false;
                            this.timerPlanTourCycle.Enabled = false;
                            this.timerPlanGPS.Enabled = false;
                            // V1.5.3
                            // this.timerExecGPS.Enabled = false;
                            this.doLog("Test beenden ...");

                            // V1.3.2 test for TestType
                            if (!this.skipPhase && this.testPlanType == TestPlanType.BELADE_EXEC && (int)(this.numericUpDownBeladeFTPBulkSize.Value) > 0)
                            {
                                this.numFTPSessions++;
                                this.doLog("Bulk #" + this.numFTPSessions.ToString() + ": (" + this.numericUpDownBeladeFTPBulkSize.Value.ToString() + ") ");
                                if (this.textBoxDataServer.Text != string.Empty)
                                {
                                    try
                                    {
                                        OpenNETCF.Net.Ftp.FTP client = new OpenNETCF.Net.Ftp.FTP(this.textBoxDataServer.Text);
                                        if (client != null)
                                        {
                                            client.BeginConnect(this.textBoxDataBenutzer.Text, this.textBoxDataKennwort.Text);
                                            int numWait = 50;
                                            while (!client.IsConnected && numWait-- > 0)
                                            {
                                                Thread.Sleep(100);
                                            }
                                            if (client.IsConnected)
                                            {
                                                client.TransferType = OpenNETCF.Net.Ftp.FTPTransferType.Binary;
                                                this.numTotalDataBytes += (int)(this.numericUpDownBeladeFTPBulkSize.Value) * 1024 * 1024;
                                                client.SendBytes((int)this.numericUpDownBeladeFTPBulkSize.Value * 1024 * 1024);
                                                client.Disconnect();
                                                client = null;
                                                this.numFTPSuccess++;
                                            }
                                            else
                                            {
                                                this.doLog("FTP nicht geöffnet");
                                            }
                                        }
                                        else
                                        {
                                            this.doLog("FTP nicht geöffnet");
                                        }
                                    }
                                    catch (Exception ee)
                                    {
                                        this.doLog(this.textBoxDataBenutzer.Text + ":" + this.textBoxDataKennwort.Text + "@" + this.textBoxDataServer.Text + " -> " + ee.Message);
                                    }
                                }
                                // V1.5.2
                                bool result = (PowerPolicyNotify(PowerMode.UnattendedMode, UNATTENDED_OFF) != 0);

                            }

                            this.doLog("Akku " + HSM.Embedded.Utility.SystemNotification.GetBatteryLife().ToString() + "%");

                            // this.timerSecond.Enabled = false; // V1.3.0 
                            // V1.5.0 jump to next major test
                            switch (this.testPlanType)
                            {
                                case TestPlanType.BELADE_EXEC:
                                    this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.5.0
                                    this.doLog("Test beendet nach: " + this.timeSpan.ToString().Split('.')[0]);
                                    this.testPlanType = TestPlanType.TOUR_PLAN;
                                    break;
                                case TestPlanType.TOUR_EXEC:
                                    this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.5.0
                                    this.doLog("Test beendet nach: " + this.timeSpan.ToString().Split('.')[0]);
                                    this.testPlanType = TestPlanType.RUHE_PLAN;
                                    //Thread t = new Thread(new ThreadStart(this.threadedCloseGPS));
                                    //t.Start();
                                    break;
                                case TestPlanType.DONE:
                                    this.stopTest = true; // V1.3.0 
                                    this.buttonSkipPhase.Enabled = false;
                                    this.buttonStop.Enabled = false; // V1.3.2
                                    // this.testPlanType = TestPlanType.NONE;
                                    break;
                                default: // can't be here ...
                                    break;
                            }
                            this.skipPhase = false;
                        }

                    if (this.stopTest && this.stateFTPSession == TaskTestState.IDLE && this.stateSnapPhoto == TaskTestState.IDLE && this.stateScanBarcode == TaskTestState.IDLE && this.stateGPSPosition == TaskTestState.IDLE)
                    {
                        batteryTestfrm.SystemIdleTimerReset();
                        batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

                        // V1.5.3
                        this.timerPlanScan.Enabled = false; // V1.3.0 
                        this.timerPlanPhoto.Enabled = false; // V1.3.0 
                        this.timerPlanData.Enabled = false; // V1.3.0 
                        this.timerPlanTourCycle.Enabled = false; // V1.3.0 
                        this.timerPlanGPS.Enabled = false; // V1.3.0 

                        this.timerManageUnattended.Enabled = false;
                        this.timerStateMachine.Enabled = false;
                        this.timerStateMachine.Interval = 1000; // V1.5.2 go back in speed mode next time
                        this.menuItemExit.Enabled = true;
                        this.menuItemStart.Enabled = true;
                        this.testPlanType = TestPlanType.NONE;

                        this.gps = null;

                        // V1.5.2
                        this.doSetTimeouts(3 * 60, 0, 0, 0, 5 * 60, 0);
                    }

                    this.doRefreshOutputStatusDisplay();
                    break;

                default: // IDLE, DONE
                    this.doLog("Default? : " + this.testPlanType.ToString());
                    this.timerStateMachine.Enabled = false;
                    break;
            }
        }

        // we close the GPS in separate thread because otherwise it may lockup due to thread implementation in .NET

        private void threadedCloseGPS()
        {
            try
            {
                if (this.gps != null)
                {
                    this.gps.CloseComPort();
                    // this.gps = null; // V1.3.0
                }
            }
            catch
            {
            }
            this.stateGPSPosition = TaskTestState.IDLE;
        }


        // Preset Belade 1

        private void buttonPreset1_Click(object sender, EventArgs e)
        {
            this.doPresetBelade1();
        }

        private void doPresetBelade1()
        {
#if DEBUG
            this.numericUpDownBeladeLaufzeitStunden.Value = 1;
            this.numericUpDownBeladeScanBarcodes.Value = 200;
            this.numericUpDownBeladeSnapPhotos.Value = 200;
            this.numericUpDownBeladeFTPSessions.Value = 0;
#else
            this.numericUpDownBeladeLaufzeitStunden.Value = 3;

            this.numericUpDownBeladeScanBarcodes.Value = 200;

            this.numericUpDownBeladeSnapPhotos.Value = 10;

            this.numericUpDownBeladeFTPSessions.Value = 50;

            this.numericUpDownBeladeFTPBulkSize.Value = 10;
#endif
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Value = 5;
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Value = 10;
            this.numericUpDownBeladeFTPSessionSize.Value = 1024;
        }


        // Preset Belade 2

        private void buttonPreset2_Click(object sender, EventArgs e)
        {
            this.doPresetBelade2();
        }

        private void doPresetBelade2()
        {
            this.numericUpDownBeladeLaufzeitStunden.Value = 2;

            this.numericUpDownBeladeScanBarcodes.Value = 100;
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Value = 5;

            this.numericUpDownBeladeSnapPhotos.Value = 5;
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Value = 10;

            this.numericUpDownBeladeFTPSessions.Value = 25;
            this.numericUpDownBeladeFTPSessionSize.Value = 250;

            this.numericUpDownBeladeFTPBulkSize.Value = 10;

        }

        // Preset Tour 1

        private void buttonPresetTour1_Click(object sender, EventArgs e)
        {
            this.doPresetTour1();
        }

        private void doPresetTour1()
        {
            this.numericUpDownTourLaufzeitStunden.Value = 10;
            this.numericUpDownTourCycleIntervalMinuten.Value = 6;
            this.numericUpDownTourCycleScanBarcodes.Value = 2;
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value = 5;
            this.numericUpDownTourFTPSessionIntervalSekunden.Value = 10 * 60 / 5;
            this.numericUpDownTourFTPSessionSize.Value = 250;
            this.numericUpDownTourCycleFTPSessionSize.Value = 2048;
            this.numericUpDownTourSnapPhotos.Value = 10;
            this.numericUpDownTourSnapPhotoDurationSekunden.Value = 10;
            this.numericUpDownTourGPSIntervalSekunden.Value = 60;
        }

        // Preset Tour 2

        private void buttonPresetTour2_Click(object sender, EventArgs e)
        {
            this.doPresetTour2(); //V1.3.1
        }

        private void doPresetTour2()
        {
            this.numericUpDownTourLaufzeitStunden.Value = 10;
            this.numericUpDownTourCycleIntervalMinuten.Value = 12;
            this.numericUpDownTourCycleScanBarcodes.Value = 2;
            this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value = 5;
            this.numericUpDownTourFTPSessionIntervalSekunden.Value = 10 * 60 / 5;
            this.numericUpDownTourFTPSessionSize.Value = 250;
            this.numericUpDownTourCycleFTPSessionSize.Value = 2048;
            this.numericUpDownTourSnapPhotos.Value = 10;
            this.numericUpDownTourSnapPhotoDurationSekunden.Value = 10;
            this.numericUpDownTourGPSIntervalSekunden.Value = 60;
        }

        // Preset Belade 3 (Intern 1)

        private void buttonPresetBeladeIntern3_Click(object sender, EventArgs e)
        {
            this.doPresetIntern3();
        }

        private void doPresetIntern3()
        {
            this.numericUpDownBeladeLaufzeitStunden.Value = 8;

            this.numericUpDownBeladeScanBarcodes.Value = 8 * 3600 / 10;
            this.numericUpDownBeladeScanBarcodeDurationSekunden.Value = 2;

            this.numericUpDownBeladeSnapPhotos.Value = 50;
            this.numericUpDownBeladeSnapPhotoDurationSekunden.Value = 10;

            this.numericUpDownBeladeFTPSessions.Value = 8 * 60 / 5;
            this.numericUpDownBeladeFTPSessionSize.Value = 100 * 1024;

            this.numericUpDownBeladeFTPBulkSize.Value = 0;
        }


        private void menuItemExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stoppen?", "trans-o-flex", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
#if !HSM
                try
                {
                    da.Dispose();
                    da = null;
                }
                catch (Exception)
                {
                }
                try
                {
                    ca.Dispose();
                    ca = null;
                }
                catch (Exception)
                {
                }
#endif
                Application.Exit();
            }
        }

        private void timerExecPhoto_Tick(object sender, EventArgs e)
        {
            this.timerExecPhoto.Enabled = false;
            string filename = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + this.numSnapPhotos.ToString() + ".jpg";
            try
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            catch
            {
            }
#if HSM
            try
            {
                this.ca.SnapPicture(filename, JPGQuality.High);
            }
            catch (Exception ee)
            {
                ee = ee;
                this.doLog(ee.Message);
                this.stateSnapPhoto = TaskTestState.DONE; // V1.3.0 in case of exception, clear the state
            }
#endif
        }

        // ensure this is done in main thread, otherwise TextBox will throw Exception

        delegate void invoked_log(string text);

        private void doLog(string text)
        {
            if (this.textBoxLog.InvokeRequired)
            {
                invoked_log d = new invoked_log(doLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBoxLog.Text = text + "\r\n" + this.textBoxLog.Text;
                try
                {
                    using (StreamWriter sw = File.AppendText(this.logFile))
                    {
                        sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " " + text);
                    }
                }
                catch
                {
                }
            }
        }

        private void menuItemStart_Click(object sender, EventArgs e)
        {
            this.doStartTest();
            //if (this.tabControl1.SelectedIndex == 1)
            //{
            //    this.doStartBelade();
            //}
            //if (this.tabControl1.SelectedIndex == 2)
            //{
            //    this.doStartTour();
            //}
        }


        private void timerCycleInterval_Tick(object sender, EventArgs e)
        {
            batteryTestfrm.SystemIdleTimerReset();
            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

            if (this.stateTourCycle == TaskTestState.IDLE)
            {
                this.stateTourCycle = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Cycle skipped (" + this.stateTourCycle.ToString() + ")");
            }
        }

      

        // Update registry when values change, so next time app launches, user does not have to re-enter all data
        private void textBoxDataServer_LostFocus(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPServer", ((TextBox)sender).Text);
        }

        private void textBoxDataBenutzer_LostFocus(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPUsername", ((TextBox)sender).Text);
        }

        private void textBoxDataKennwort_LostFocus(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPPassword", ((TextBox)sender).Text);
        }

        private void buttonTestFTP_Click(object sender, EventArgs e)
        {
            this.doLog("Test FTP: (1) ");

            this.textBoxTestFTP.Text = "Setting radiostate ...";
            Application.DoEvents();

            WirelessManager.SetWLANState(this.checkBoxTestWLAN.Checked);

            WirelessManager.SetWWANState(this.checkBoxTestWWAN.Checked);

            if (this.checkBoxTestWWAN.Checked)
            {
                this.textBoxTestFTP.Text = "Attaching to GPRS ...";
                Application.DoEvents();
                if (!this.cmr.Connected)
                {
                    this.cmr.Connect(this.textBoxGPRSEntry.Text,
                        ConnMgr.ConnectionMode.Asynchronous,
                        this.textBoxGPRSBenutzer.Text,
                        this.textBoxGPRSKennwort.Text,
                        this.textBoxGPRSAPN.Text);

                    int maxWait = 30;
                    while (!cmr.Connected && maxWait-- > 0)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }

            try
            {
                this.textBoxTestFTP.Text = "Testing ...";
                Application.DoEvents();
                OpenNETCF.Net.Ftp.FTP client = new OpenNETCF.Net.Ftp.FTP(this.textBoxDataServer.Text);
                if (client != null)
                {
                    client.BeginConnect(this.textBoxDataBenutzer.Text, this.textBoxDataKennwort.Text);
                    int numWait = 50;
                    while (!client.IsConnected && numWait-- > 0)
                    {
                        Thread.Sleep(100);
                    }
                    if (client.IsConnected)
                    {
                        client.TransferType = OpenNETCF.Net.Ftp.FTPTransferType.Binary;
                        if (client.SendBytes((int)1) == 1)
                        {
                            this.textBoxTestFTP.Text = "FTP test succesful";
                        }
                        else
                        {
                            this.textBoxTestFTP.Text = "FTP test failed";
                        }
                        client.Disconnect();
                    }
                    else
                    {
                        this.textBoxTestFTP.Text = "FTP connect failed";
                    }
                    client = null;
                }
                else
                {
                    this.textBoxTestFTP.Text = "FTP nicht geöffnet";
                }
            }
            catch (Exception ee)
            {
                this.textBoxTestFTP.Text = ee.Message;
                this.doLog(this.textBoxDataBenutzer.Text + ":" + this.textBoxDataKennwort.Text + "@" + this.textBoxDataServer.Text + " -> " + ee.Message);
            }
        }

        private void checkBoxLogFTP_CheckStateChanged(object sender, EventArgs e)
        {
            OpenNETCF.Net.Ftp.FTP.LoggingEnabled = this.checkBoxLogFTP.Checked;
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            this.textBoxLog.Text = string.Empty;
        }

        // V1.4.0
        private void doSetActivePassive()
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Honeywell\Transoflex", "FTPPassive", (!this.radioButtonActive.Checked).ToString());
            OpenNETCF.Net.Ftp.FTP.TransferMode = this.radioButtonActive.Checked ? OpenNETCF.Net.Ftp.FTPMode.Active : OpenNETCF.Net.Ftp.FTPMode.Passive;
        }

        private void radioButtonPassive_CheckedChanged(object sender, EventArgs e)
        {
            this.doSetActivePassive();
        }

        private void radioButtonActive_CheckedChanged(object sender, EventArgs e)
        {
            // not neccesary to act here, this will be done by the other radiobutton going Checked = false
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        //private void btnTestScanner_Click(object sender, EventArgs e)
        //{
        //    ca.Disconnect();

        //    da.Disconnect();
        //    da.Connect();
        //    da.ScanTimeout = 15000; //15 seconds
        //    da.DecodeEvent+=new DecodeAssembly.DecodeEventHandler(da_DecodeEvent1);
        //    da.ScanBarcode();
        //}
        //delegate void changeTextCallback(string s);
        //void changeText(string s)
        //{
        //    if (this.textBox1.InvokeRequired)
        //    {
        //        changeTextCallback d = new changeTextCallback(changeText);
        //        this.Invoke(d, new object[] { s });
        //    }
        //    else
        //    {
        //        textBox1.Text = s;
        //    }
        //}
        //void da_DecodeEvent1(object sender, DecodeEventArgs e)
        //{
        //    changeText(e.sData);
        //}

        //private void btnTestCamera_Click(object sender, EventArgs e)
        //{
        //    da.Disconnect();

        //    ca.Disconnect();
        //    ca.CameraEvent -= ca_CameraEvent;
        //    ca.Dispose();
        //    ca = new CameraAssembly.CameraAssembly();
        //    ca.Connect(ref pictureBox2, null, null);
        //    ca.CameraEvent += new CameraAssembly.CameraAssembly.CameraEventHandler(ca_CameraEvent1);
        //    ca.StartPreview();
        //}

        void ca_CameraEvent1(object s, CameraEventArgs args)
        {
            
        }

        private void textBoxGPRSEntry_LostFocus(object sender, EventArgs e)
        {

        }

        private void textBoxGPRSKennwort_LostFocus(object sender, EventArgs e)
        {

        }

        private void textBoxGPRSBenutzer_LostFocus(object sender, EventArgs e)
        {

        }

        private void textBoxGPRSAPN_LostFocus(object sender, EventArgs e)
        {

        }

        private void timerPlanScan_Tick(object sender, EventArgs e)
        {
            if (this.stateScanBarcode == TaskTestState.IDLE)
            {
                this.stateScanBarcode = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Scan skipped (" + this.stateScanBarcode.ToString() + ")");
            }

        }

        private void timerPlanData_Tick(object sender, EventArgs e)
        {
            if (this.stateFTPSession == TaskTestState.IDLE)
            {
                this.stateFTPSession = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Data skipped (" + this.stateFTPSession.ToString() + ")");
            }

        }

        private void timerPlanPhoto_Tick(object sender, EventArgs e)
        {
            if (this.stateSnapPhoto == TaskTestState.IDLE)
            {
                this.stateSnapPhoto = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Photo skipped (" + this.stateSnapPhoto.ToString() + ")");
            }

        }

        private void timerPlanGPS_Tick(object sender, EventArgs e)
        {
            if (this.stateGPSPosition == TaskTestState.IDLE)
            {
                this.stateGPSPosition = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("GPS skipped (" + this.stateGPSPosition.ToString() + ")");
            }

        }

        private void timerPlanTourCycle_Tick(object sender, EventArgs e)
        {
            // V1.5.2
            this.timerManageUnattended.Enabled = false;

            batteryTestfrm.SystemIdleTimerReset();
            batteryTestfrm.SetSystemPowerState(IntPtr.Zero, batteryTestfrm.POWER_STATE_ON, 0);

            // V1.5.2
            int secondsDisplayOn = (int)(this.numericUpDownTourCycleDisplayAn.Value) * 60;
            this.timerManageUnattended.Interval = secondsDisplayOn * 1000;
            this.deviceInUnattended = false;
            this.timerManageUnattended.Enabled = true;


            if (this.stateTourCycle == TaskTestState.IDLE)
            {
                this.stateTourCycle = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Cycle skipped (" + this.stateTourCycle.ToString() + ")");
            }

        }

        private void timerRuheUnattended_Tick(object sender, EventArgs e)
        {
            if (this.deviceInUnattended)
            {
                // this.doLog("Keep Unattended Mode");
                batteryTestfrm.SystemIdleTimerReset();
            }
            else
            {
                this.doLog("Enter Unattended Mode");
                bool result = (PowerPolicyNotify(PowerMode.UnattendedMode, UNATTENDED_ON) != 0);
                this.timerManageUnattended.Interval = 60000;
                this.deviceInUnattended = true;
                PowerPolicyNotify(PowerMode.SuspendKeyOrPwrButtonPressed, 0);
            }

        }


        private void buttonSkipPhase_Click(object sender, EventArgs e)
        {
            this.skipPhase = true;
            this.timerStateMachine.Interval = 1000;
            this.timerStateMachine.Enabled = true;

        }

        private void timerExecGPS_Tick(object sender, EventArgs e)
        {
            this.timerExecGPS.Enabled = false;
            if (this.stateGPSPosition == TaskTestState.EXEC)
            {
                this.doLog("GPS no fix (" + this.gps_location + ")");
                this.stateGPSPosition = TaskTestState.DONE;
            }

        }

    }
}