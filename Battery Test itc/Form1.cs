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

#if HSM
    using HSM.Embedded.Decoding;
    using HSM.Embedded.Camera;
    using HSM.Embedded.Utility;
#else
    using DecodeAssemblyITC;
    using CameraAssembly;
#endif

using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Battery_Test_itc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("coredll.dll")]
        static extern void SystemIdleTimerReset();

        [DllImport("coredll.dll")]
        static extern bool SetSystemPowerState(IntPtr pwdSystemState, UInt32 StateFlags, UInt32 Options);

        const UInt32 POWER_STATE_ON = (0x00010000);        // on state

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
            BELADE,
            TOUR
        }

        private string logFile;
        private DateTime startTime;
        private TimeSpan timeSpan;
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
        private int timeoutScanBarcode;
        private int timeoutSnapPhoto;
        private GPS gps = null;
        private string gps_location = string.Empty;
#if HSM
        private DecodeAssembly da = new DecodeAssembly();
        private CameraAssembly ca = new CameraAssembly();
#else
        DecodeAssembly da = new DecodeAssembly(); //Intermec.DataCollection.BarcodeReader bcr;
        CameraAssembly.CameraAssembly ca = new CameraAssembly.CameraAssembly();
#endif

        private void Form1_Load(object sender, EventArgs e)
        {
            this.doPresetTour1();
            this.doPresetBelade1();

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

        // Initiate the "Belade" Test

        private void doStartBelade()
        {
            this.testPlanType = TestPlanType.BELADE; // V1.3.2
            this.menuItemStart.Enabled = false;
            this.stopTest = false;
            this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
            this.menuItemExit.Enabled = false;

            this.startTime = DateTime.Now;
            this.logFile = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            this.textBoxLog.Text = string.Empty;

            this.startLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.lastLevel = this.startLevel;
            this.numTotalDataBytes = 0;

            this.testHours = (int)(this.numericUpDownBeladeLaufzeitStunden.Value); // V1.3.0 use global var
            this.doLog("Testdauer " + this.testHours.ToString() + " Stunden");
            this.doLog("Akku " + this.startLevel.ToString() + "%");

            if (this.testHours > 0)
            {
                if ((int)(this.numericUpDownBeladeScanBarcodes.Value) > 0)
                {
                    int secondsNextScan = this.testHours * 3600 / (int)(this.numericUpDownBeladeScanBarcodes.Value);
                    this.timerScanBarcode.Interval = secondsNextScan * 1000;
                    this.doLog("Scan jede " + secondsNextScan.ToString() + " Sekunden");
                    this.timeoutScanBarcode = (int)(this.numericUpDownBeladeScanBarcodeDurationSekunden.Value) * 1000;
                }

                if ((int)(this.numericUpDownBeladeSnapPhotos.Value) > 0)
                {
                    int secondsNextPhoto = this.testHours * 3600 / (int)(this.numericUpDownBeladeSnapPhotos.Value);
                    this.timerSnapPhoto.Interval = secondsNextPhoto * 1000;
                    this.timeoutSnapPhoto = (int)(this.numericUpDownBeladeSnapPhotoDurationSekunden.Value) * 1000;
                    this.timerPhotoSnap.Interval = this.timeoutSnapPhoto;
                    this.doLog("Photo jede " + secondsNextPhoto.ToString() + " Sekunden");
                }

                if ((int)(this.numericUpDownBeladeFTPSessions.Value) > 0)
                {
                    int secondsNextData = this.testHours * 3600 / (int)(this.numericUpDownBeladeFTPSessions.Value);
                    this.numSendDataBytes = (int)(this.numericUpDownBeladeFTPSessionSize.Value);  // V1.2.0
                    this.timerFTPSession.Interval = secondsNextData * 1000;
                    this.doLog("Data jede " + secondsNextData.ToString() + " Sekunden");
                }
            }

            this.doLog("Test Belade gestart");

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

            this.timerLoopSecond.Enabled = true;
            if (this.testHours > 0)
            {
                this.timerScanBarcode.Enabled = ((int)(this.numericUpDownBeladeScanBarcodes.Value) > 0);
                this.timerSnapPhoto.Enabled = ((int)(this.numericUpDownBeladeSnapPhotos.Value) > 0);
                this.timerFTPSession.Enabled = ((int)(this.numericUpDownBeladeFTPSessions.Value) > 0);
                this.timerPositionGPS.Enabled = false; // V1.3.0
                this.timerCycleInterval.Enabled = false; // V1.3.0
            }

            this.buttonStop.Enabled = true;
        }

        // Initiate the "Tour" Test


        private void doStartTour()
        {
            this.testPlanType = TestPlanType.TOUR; // V1.3.2
            this.menuItemStart.Enabled = false;
            this.stopTest = false;
            this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
            this.menuItemExit.Enabled = false;

            this.startTime = DateTime.Now;
            this.logFile = @"\My Documents\trans-o-flex-" + this.startTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
            this.textBoxLog.Text = string.Empty;

            this.startLevel = HSM.Embedded.Utility.SystemNotification.GetBatteryLife();
            this.lastLevel = this.startLevel;
            this.numTotalDataBytes = 0;

            this.testHours = (int)(this.numericUpDownTourLaufzeitStunden.Value); // V1.3.0 use global var
            this.doLog("Testdauer " + this.testHours.ToString() + " Stunden");
            this.doLog("Akku " + this.startLevel.ToString() + "%");

            this.gps_location = "-/-";
            string sGPSport = GPS.GetGPSPort();
            this.gps = new GPS(sGPSport,4800);// ("SWI6:",4800);
            // this.gps.OpenComPort();
            this.gps.OnGPSDateEventHandler += new GPS.GPSDateEventHandler(gps_OnGPSDateEventHandler);

            if (this.testHours > 0)
            {
                if ((int)(this.numericUpDownTourCycleIntervalMinuten.Value) > 0)
                {
                    int secondsNextScan = (int)(this.numericUpDownTourCycleIntervalMinuten.Value) * 60;
                    this.timerCycleInterval.Interval = secondsNextScan * 1000;
                    this.doLog("Interval jede " + secondsNextScan.ToString() + " Sekunden");
                    this.timeoutScanBarcode = (int)(this.numericUpDownTourCycleScanBarcodeDurationSekunden.Value) * 1000;
                }

                if ((int)(this.numericUpDownTourSnapPhotos.Value) > 0)
                {
                    int secondsNextPhoto = this.testHours * 3600 / (int)(this.numericUpDownTourSnapPhotos.Value);
                    this.timerSnapPhoto.Interval = secondsNextPhoto * 1000;
                    this.timeoutSnapPhoto = (int)(this.numericUpDownTourSnapPhotoDurationSekunden.Value) * 1000;
                    this.timerPhotoSnap.Interval = this.timeoutSnapPhoto;
                    this.doLog("Photo jede " + secondsNextPhoto.ToString() + " Sekunden");
                }

                if ((int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value) > 0)
                {
                    int secondsNextData = (int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value);
                    this.numSendDataBytes = (int)(this.numericUpDownTourFTPSessionSize.Value); // V1.2.0
                    this.timerFTPSession.Interval = secondsNextData * 1000;
                    this.doLog("Data jede " + secondsNextData.ToString() + " Sekunden");
                }

                // V1.3.0
                if ((int)(this.numericUpDownTourGPSIntervalSekunden.Value) > 0)
                {
                    int secondsNextGPS = (int)(this.numericUpDownTourGPSIntervalSekunden.Value);
                    this.timerPositionGPS.Interval = secondsNextGPS * 1000;
                    this.doLog("GPS jede " + secondsNextGPS.ToString() + " Sekunden");
                }
            }
            this.doLog("Test Tour gestart");

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

            this.timerLoopSecond.Enabled = true;
            if (this.testHours > 0)
            {
                this.timerScanBarcode.Enabled = false; // V1.3.0
                this.timerCycleInterval.Enabled = ((int)(this.numericUpDownTourCycleIntervalMinuten.Value) > 0);
                this.timerSnapPhoto.Enabled = ((int)(this.numericUpDownTourSnapPhotos.Value) > 0);
                this.timerFTPSession.Enabled = ((int)(this.numericUpDownTourFTPSessionIntervalSekunden.Value) > 0);
                this.timerPositionGPS.Enabled = ((int)(this.numericUpDownTourGPSIntervalSekunden.Value) > 0); // V1.3.0
            }
            this.buttonStop.Enabled = true;
        }

        void gps_OnGPSDateEventHandler(object sender, GPSData e)
        {
            this.gps_location = e.GotPosition.ToString() + " (" + e.NumberOfSatellites.ToString() + ") " + e.LongitudeD + "/" + e.LatitudeD;
            if (e.GotPosition)
            {
                this.timerFixPositionGPS.Enabled = false;
                this.stateGPSPosition = TaskTestState.DONE;
                this.Invoke(new invoked_log(this.doLog), "GPS: " + this.gps_location);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.stopTest = true;

            this.timerScanBarcode.Enabled = false;
            this.timerSnapPhoto.Enabled = false;
            this.timerFTPSession.Enabled = false;
            this.timerCycleInterval.Enabled = false;
            this.timerPositionGPS.Enabled = false;
            this.timerFixPositionGPS.Enabled = false;

            this.timeSpan = DateTime.Now.Subtract(this.startTime);
            this.doLog("Test abbrechen ...");

            this.buttonStop.Enabled = false;

        }

        private void timerPhoto_Tick(object sender, EventArgs e)
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

        private void timerScan_Tick(object sender, EventArgs e)
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

        private void timerData_Tick(object sender, EventArgs e)
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
            }

            if (this.stateGPSPosition == TaskTestState.DONE)
            {
                this.timerFixPositionGPS.Enabled = false;
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
                    if (this.gps.OpenComPort()==0)
                    { // V1.3.0
                        this.stateGPSPosition = TaskTestState.EXEC;
                        this.timerFixPositionGPS.Enabled = true;
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
                    this.ca.Connect(this.pictureBox1, null, null);
#endif
                    long resolutionSetting;
                    this.ca.GetResolutionCount(out resolutionSetting);
                    this.ca.SetResolution((uint)(resolutionSetting - 1));
                    this.ca.SetProperty(CameraProperty.Illumination, 1, PropertyMode.Manual);
                    this.ca.SetProperty(CameraProperty.ColorEnable, 1, PropertyMode.Manual);
                    this.ca.StartPreview();
                    this.timerPhotoSnap.Enabled = true;
                }
                catch (Exception ee)
                {
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
//#endif

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

            if (!this.stopTest && timeSpan.Hours >= this.testHours) // V1.3.0 use global var
            {
                // this.timerSecond.Enabled = false; // V1.3.0 
                this.stopTest = true; // V1.3.0 
                this.buttonStop.Enabled = false; // V1.3.2

                this.timerScanBarcode.Enabled = false; // V1.3.0 
                this.timerSnapPhoto.Enabled = false; // V1.3.0 
                this.timerFTPSession.Enabled = false; // V1.3.0 
                this.timerCycleInterval.Enabled = false; // V1.3.0 
                this.timerPositionGPS.Enabled = false; // V1.3.0 
                this.timerFixPositionGPS.Enabled = false;
                this.doLog("Test beenden ...");

                // V1.3.2 test for TestType
                if (this.testPlanType==TestPlanType.BELADE && (int)(this.numericUpDownBeladeFTPBulkSize.Value) > 0)
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
                }
            }

            if (this.stopTest && this.stateFTPSession == TaskTestState.IDLE && this.stateSnapPhoto == TaskTestState.IDLE && this.stateScanBarcode == TaskTestState.IDLE && this.stateGPSPosition == TaskTestState.IDLE)
            {
                this.timeSpan = DateTime.Now.Subtract(this.startTime); //V1.3.2
                this.doLog("Test beendet nach: " + this.timeSpan.ToString().Split('.')[0]);
                this.timerLoopSecond.Enabled = false;
                this.menuItemExit.Enabled = true;
                this.menuItemStart.Enabled = true;

                this.gps = null;
            }

            this.doRefreshOutputStatusDisplay();
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

        private void timerSnapPhotoSnap_Tick(object sender, EventArgs e)
        {
            this.timerPhotoSnap.Enabled = false;
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
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.doStartBelade();
            }
            if (this.tabControl1.SelectedIndex == 2)
            {
                this.doStartTour();
            }
        }


        private void timerCycleInterval_Tick(object sender, EventArgs e)
        {
            Form1.SystemIdleTimerReset();
            Form1.SetSystemPowerState(IntPtr.Zero, Form1.POWER_STATE_ON, 0);

            if (this.stateTourCycle == TaskTestState.IDLE)
            {
                this.stateTourCycle = TaskTestState.PLAN;
            }
            else
            {
                this.doLog("Cycle skipped (" + this.stateTourCycle.ToString() + ")");
            }
        }

      

        private void timerPositionGPS_Tick(object sender, EventArgs e)
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

        private void timerFixPositionGPS_Tick(object sender, EventArgs e)
        {
            this.timerFixPositionGPS.Enabled = false;
            if (this.stateGPSPosition == TaskTestState.EXEC)
            {
                this.doLog("GPS no fix (" + this.gps_location + ")");
                this.stateGPSPosition = TaskTestState.DONE;
            }
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

        private void btnTestScanner_Click(object sender, EventArgs e)
        {
            da.Connect();
            da.DecodeEvent+=new DecodeAssembly.DecodeEventHandler(da_DecodeEvent1);
            da.ScanBarcode();
        }
        delegate void changeTextCallback(string s);
        void changeText(string s)
        {
            if (this.textBox1.InvokeRequired)
            {
                changeTextCallback d = new changeTextCallback(changeText);
                this.Invoke(d, new object[] { s });
            }
            else
            {
                textBox1.Text = s;
            }
        }
        void da_DecodeEvent1(object sender, DecodeEventArgs e)
        {
            changeText(e.sData);
        }

        private void btnTestCamera_Click(object sender, EventArgs e)
        {
            ca.Connect(pictureBox2, null, null);
            ca.CameraEvent += new CameraAssembly.CameraAssembly.CameraEventHandler(ca_CameraEvent1);
            ca.StartPreview();
        }

        void ca_CameraEvent1(object s, CameraEventArgs args)
        {
            
        }
    }
}