using Microsoft.WindowsCE.Forms;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;

namespace MS.Wireless.Network
{
    /// <summary>
    /// Class to provide access to the Win32 ConnMgr API. 	
    /// </summary>
    public class ConnMgr:IDisposable
    {
        private const int MAX_STRING = 250;

        private const int WM_CONNMGREVENT = 51917;

        private const int CONNMGR_PARAM_GUIDDESTNET = 1;

        private const int CONNMGR_FLAG_PROXY_HTTP = 1;

        private const int CONNMGR_FLAG_NO_ERROR_MSGS = 64;

        private const int CFGFLAG_PROCESS = 1;

        private const int CFGFLAG_METADATA = 2;

        private IntPtr hConnMgr;

        private TrapWindow connMgrWindow;

        private bool _waiting;

        private bool _connected;

        /// <summary>
        /// Timeout for synchronous connection attempts
        /// </summary>
        public int Timeout = 5000;

        /// <summary>
        /// Set to true when connection has been completed
        /// </summary>
        public bool Connected
        {
            get
            {
                return this._connected;
            }
        }

        /// <summary>
        /// Handle to the current connection. Read Only.
        /// </summary>
        public IntPtr ConnMgrHandle
        {
            get
            {
                return this.hConnMgr;
            }
        }

        /// Set to true when connection is in progress
        public bool Waiting
        {
            get
            {
                return this._waiting;
            }
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public ConnMgr()
        {
            this.hConnMgr = IntPtr.Zero;
            this.connMgrWindow = new TrapWindow();
            ConnMgr connMgr = this;
            this.connMgrWindow.AddHandler(51917, new WM_Delegate(connMgr.OnStatusChanged));
        }

        /// <summary>
        /// Attempts to establish a connection using the GUID to an existing connectoid
        /// </summary>
        /// <param name="destGuid">GUID of existing connectoid</param>
        /// <param name="exclusive">Exclusive access of connectoid (boolean)</param>
        /// <param name="mode">ConnectionMode is either Synchronous or Asynchronous</param>
        public void Connect(Guid destGuid, bool exclusive, ConnMgr.ConnectionMode mode)
        {
            ConnMgr.ConnectionInfo connectionInfo = new ConnMgr.ConnectionInfo();
            connectionInfo.dwParams = 1;
            connectionInfo.dwPriority = 8192;
            connectionInfo.dwFlags = 65;
            connectionInfo.bExclusive = exclusive;
            connectionInfo.bDisabled = false;
            connectionInfo.guidDestNet = destGuid;
            connectionInfo.hWnd = this.connMgrWindow.Hwnd;
            connectionInfo.uMsg = 51917;
            connectionInfo.lParam = 0;
            connectionInfo.MarshalToUnManaged();
            int num = 0;
            if (mode != ConnMgr.ConnectionMode.Synchronous)
            {
                ConnMgr.sysConnMgrEstablishConnection(connectionInfo.structPtr, out this.hConnMgr);
            }
            else
            {
                int num1 = ConnMgr.sysConnMgrEstablishConnectionSync(connectionInfo.structPtr, out this.hConnMgr, this.Timeout, out num);
                if (num1 != 0)
                {
                    throw new ExternalException("ConnMgrEstablishConnectionSync failed", Marshal.GetExceptionForHR(num1));
                }
            }
        }

        /// <summary>
        /// Attempts to create and establish a connection to a new GPRS connectoid using the specified ISP parameters
        /// </summary>
        /// <param name="EntryName">Name to be given to the new GPRS connectoid</param>
        /// <param name="mode">ConnectionMode is either Synchronous or Asynchronous</param>
        /// <param name="Username">User name provided by local ISP</param>
        /// <param name="Password">Password provided by local ISP</param>
        /// <param name="APN">Access Point Name provided by local ISP</param>
        public void Connect(string EntryName, ConnMgr.ConnectionMode mode, string Username, string Password, string APN)
        {
            if (EntryName == null || EntryName == "")
            {
                throw new ArgumentException("EntryName is invalid");
            }
            if (Username == null)
            {
                throw new ArgumentException("Username is invalid");
            }
            if (Password == null)
            {
                throw new ArgumentException("Password is invalid");
            }
            if (APN == null)
            {
                throw new ArgumentException("APN is invalid");
            }
            int num = 0;
            Guid guid = new Guid("ADB0B001-10B5-3F39-27C6-9742E785FCD4");
            IntPtr zero = IntPtr.Zero;
            object[] entryName = new object[] { "<wap-provisioningdoc><characteristic type=\"CM_GPRSEntries\"><characteristic type=\"", EntryName, "\"><parm name=\"DestId\" value=\"{", guid, "}\"/><parm name=\"Phone\" value=\"~GPRS!", APN, "\"/><parm name=\"UserName\" value=\"", Username, "\"/><parm name=\"Password\" value=\"", Password, "\"/><parm name=\"DeviceType\" value=\"modem\"/><parm name=\"DeviceName\" value=\"Cellular Line\"/><parm name=\"Enabled\" value=\"1\"/><parm name=\"RequirePw\" value=\"1\"/><characteristic type=\"DevSpecificCellular\"><parm name=\"GPRSInfoAccessPointName\" value=\"", APN, "\"/></characteristic></characteristic></characteristic></wap-provisioningdoc>" };
            string str = string.Concat(entryName);
            num = ConnMgr.sysDMProcessConfigXML(str, 1, out zero);
            if (num != 0)
            {
                ConnMgr.sysOperator_Delete(zero);
                throw new ExternalException("DMProcessConfigXML failed", Marshal.GetExceptionForHR(num));
            }
            if (zero == IntPtr.Zero)
            {
                throw new Exception("xmlOut did not get set");
            }
            string stringUni = Marshal.PtrToStringUni(zero);
            ConnMgr.sysOperator_Delete(zero);
            if (stringUni.IndexOf("parm-error") > -1)
            {
                string[] strArrays = new string[] { "Can't set username and password for ", EntryName, " [", num.ToString(), "]" };
                throw new Exception(string.Concat(strArrays));
            }
            num = ConnMgr.sysConnMgrMapConRef(0, EntryName, out guid);
            if (num != 0)
            {
                string[] entryName1 = new string[] { "Can't map connection reference for ", EntryName, " [", num.ToString(), "]" };
                throw new ExternalException(string.Concat(entryName1), Marshal.GetExceptionForHR(num));
            }
            this.Connect(guid, false, mode);
        }

        /// <summary>
        /// Attempts to create and establish a connection to a new GPRS connectoid using the specified XML string
        /// </summary>
        /// <param name="EntryName">Name to be given to the new GPRS connectoid</param>
        /// <param name="mode">ConnectionMode is either Synchronous or Asynchronous</param>
        /// <param name="xmlIn">Complete XML string used to create new connectoid (refer to Connection Manager)</param>
        public void Connect(string EntryName, ConnMgr.ConnectionMode mode, string xmlIn)
        {
            Guid guid;
            if (xmlIn == null || xmlIn == "")
            {
                throw new ArgumentException("xmlIn is invalid");
            }
            IntPtr zero = IntPtr.Zero;
            int num = ConnMgr.sysDMProcessConfigXML(xmlIn, 1, out zero);
            if (num != 0)
            {
                ConnMgr.sysOperator_Delete(zero);
                throw new ExternalException("DMProcessConfigXML failed", Marshal.GetExceptionForHR(num));
            }
            if (zero == IntPtr.Zero)
            {
                throw new Exception("xmlOut did not get set");
            }
            string stringUni = Marshal.PtrToStringUni(zero);
            ConnMgr.sysOperator_Delete(zero);
            if (stringUni.IndexOf("parm-error") > -1)
            {
                string[] entryName = new string[] { "Can't set username and password for ", EntryName, " [", num.ToString(), "]" };
                throw new Exception(string.Concat(entryName));
            }
            num = ConnMgr.sysConnMgrMapConRef(0, EntryName, out guid);
            if (num != 0)
            {
                string[] strArrays = new string[] { "Can't map connection reference for ", EntryName, " [", num.ToString(), "]" };
                throw new ExternalException(string.Concat(strArrays), Marshal.GetExceptionForHR(num));
            }
            this.Connect(guid, false, mode);
        }

        /// <summary>
        /// Delete the connection request. Will most likely cause to drop physical connection.
        /// </summary>
        public void Disconnect()
        {
            if (this.hConnMgr == IntPtr.Zero)
            {
                return;
            }
            if (ConnMgr.sysConnMgrReleaseConnection(this.hConnMgr, 0) == 0)
            {
                Message status = new Message();
                status.WParam = (IntPtr)((long)this.GetStatus());
                this.hConnMgr = IntPtr.Zero;
                this.OnStatusChanged(ref status);
            }
        }

        /// <summary>
        /// Verifies if the given CM Entry exists
        /// </summary>
        /// <param name="EntryName">Name of the GPRS connectoid to be checked</param>
        public static bool EntryExists(string EntryName)
        {
            IntPtr zero = IntPtr.Zero;
            string str = string.Concat("<wap-provisioningdoc><characteristic type=\"CM_GPRSEntries\"><characteristic type=\"", EntryName, "\"><parm-query name=\"DestId\" /></characteristic></characteristic></wap-provisioningdoc>");
            int num = ConnMgr.sysDMProcessConfigXML(str, 1, out zero);
            if (num != 0)
            {
                ConnMgr.sysOperator_Delete(zero);
                throw new ExternalException("DMProcessConfigXML failed", Marshal.GetExceptionForHR(num));
            }
            if (zero == IntPtr.Zero)
            {
                throw new Exception("xmlOut did not get set");
            }
            string stringUni = Marshal.PtrToStringUni(zero);
            ConnMgr.sysOperator_Delete(zero);
            if (stringUni.IndexOf("nocharacteristic") > -1)
            {
                string[] entryName = new string[] { "Can't set username and password for ", EntryName, " [", num.ToString(), "]" };
                throw new Exception(string.Concat(entryName));
            }
            return true;
        }

        
        /// <summary>
        /// Class Destructor
        /// </summary>
        public void Dispose()// Finalize()
        {
            try
            {
                if (this.hConnMgr != IntPtr.Zero)
                {
                    this.Disconnect();
                }
                this.connMgrWindow.AddHandler(51917, null);
            }
            finally
            {
//                this.Finalize();
            }
        }

        /// <summary>
        /// Returns the Status for the current connection
        /// </summary>
        public ConnMgr.ConnectionStatus GetStatus()
        {
            ConnMgr.ConnectionStatus connectionStatu = ConnMgr.ConnectionStatus.Unknown;
            if (this.hConnMgr != IntPtr.Zero)
            {
                int num = 0;
                if (ConnMgr.sysConnMgrConnectionStatus(this.hConnMgr, out num) == 0)
                {
                    connectionStatu = (ConnMgr.ConnectionStatus)num;
                }
            }
            return connectionStatu;
        }

        /// <summary>
        /// Returns the Status Description for the current GPRS connection
        /// </summary>
        public string GetStatusDesc(ConnMgr.ConnectionStatus connstatus)
        {
            ConnMgr.ConnectionStatus connectionStatu = connstatus;
            if (connectionStatu > ConnMgr.ConnectionStatus.Suspended)
            {
                switch (connectionStatu)
                {
                    case ConnMgr.ConnectionStatus.Disconnected:
                        {
                            return "Disconnected";
                        }
                    case ConnMgr.ConnectionStatus.ConnectionFailed:
                        {
                            return "Connection failed";
                        }
                    case ConnMgr.ConnectionStatus.ConnectionCanceled:
                        {
                            return "User cancelled";
                        }
                    case ConnMgr.ConnectionStatus.ConnectionDisabled:
                        {
                            return "The connection can be made, but the connection itself is disabled";
                        }
                    case ConnMgr.ConnectionStatus.NoPathToDestination:
                        {
                            return "No path to the destination could be found";
                        }
                    case ConnMgr.ConnectionStatus.WaitingForPath:
                        {
                            return "A path to the destination exists but is not presently available";
                        }
                    case ConnMgr.ConnectionStatus.WaitingForPhone:
                        {
                            return "A voice call is in progress and is using resources that this connection requires";
                        }
                    case ConnMgr.ConnectionStatus.PhoneOff:
                        {
                            return "The phone has been turned off";
                        }
                    case ConnMgr.ConnectionStatus.ExclusiveConflict:
                        {
                            return "The connection could not be established because it would multi-home an exclusive connection";
                        }
                    case ConnMgr.ConnectionStatus.NoResources:
                        {
                            return "The Connection Manager failed to allocate resources to make the connection";
                        }
                    case ConnMgr.ConnectionStatus.ConnectionLinkedFailed:
                        {
                            return "The connection link was prematurely disconnected";
                        }
                    case ConnMgr.ConnectionStatus.AuthenticationFailed:
                        {
                            return "The user could not be authenticated";
                        }
                    default:
                        {
                            switch (connectionStatu)
                            {
                                case ConnMgr.ConnectionStatus.WaitingConnection:
                                    {
                                        return "The device is attempting to connect";
                                    }
                                case ConnMgr.ConnectionStatus.WaitingForResource:
                                    {
                                        return "Another client is using resources that this connection requires";
                                    }
                                case ConnMgr.ConnectionStatus.WaitingForNetwork:
                                    {
                                        return "The device is waiting for a task with a higher priority to connect to the network before connecting to the same network. This status value is returned only to clients that specify a priority of CONNMGR_PRIORITY_LOWBKGND when requesting a connection";
                                    }
                                default:
                                    {
                                        switch (connectionStatu)
                                        {
                                            case ConnMgr.ConnectionStatus.WaitingDisconnection:
                                                {
                                                    return "The connection is being brought down";
                                                }
                                            case ConnMgr.ConnectionStatus.WaitingConnectionAbort:
                                                {
                                                    return "The device is aborting the connection attempt";
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            else
            {
                if (connectionStatu == ConnMgr.ConnectionStatus.Unknown)
                {
                    return "Unknown status";
                }
                switch (connectionStatu)
                {
                    case ConnMgr.ConnectionStatus.Connected:
                        {
                            return "Connected";
                        }
                    case ConnMgr.ConnectionStatus.Suspended:
                        {
                            return "The connection has been established, but has been suspended";
                        }
                }
            }
            return "Unknown status";
        }

        /// <summary>
        /// Raises the StatusChanged event. Triggered when a ConnMgr notification has been received 
        /// by the underlying MessageWindow. 
        /// </summary>
        /// <param name="m">a Message that contains the notification details</param>	
        protected virtual void OnStatusChanged(ref Message m)
        {
            if (this.StatusChanged != null)
            {
                ConnMgr.ConnectionStatus num = (ConnMgr.ConnectionStatus)m.WParam.ToInt32();
                this._connected = false;
                this._waiting = false;
                if (num == ConnMgr.ConnectionStatus.Connected)
                {
                    this._connected = true;
                }
                else if (num == ConnMgr.ConnectionStatus.WaitingConnection || num == ConnMgr.ConnectionStatus.WaitingConnectionAbort || num == ConnMgr.ConnectionStatus.WaitingForNetwork || num == ConnMgr.ConnectionStatus.WaitingForPath || num == ConnMgr.ConnectionStatus.WaitingForPhone || num == ConnMgr.ConnectionStatus.WaitingForResource)
                {
                    this._waiting = true;
                }
                string statusDesc = this.GetStatusDesc(num);
                this.StatusChanged(this, new ConnMgr.StatusChangedEventArgs(num, statusDesc));
            }
        }

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrConnectionStatus", SetLastError = true)]
        internal static extern int sysConnMgrConnectionStatus(IntPtr hConnection, out int pdwStatus);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrEnumDestinations", SetLastError = true)]
        internal static extern int sysConnMgrEnumDestinations(int nIndex, IntPtr pDestinationInfo);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrEstablishConnection", SetLastError = true)]
        internal static extern int sysConnMgrEstablishConnection(IntPtr pConnInfo, out IntPtr phConnection);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrEstablishConnectionSync", SetLastError = true)]
        internal static extern int sysConnMgrEstablishConnectionSync(IntPtr pConnInfo, out IntPtr phConnection, int dwTimeout, out int dwStatus);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrMapConRef", SetLastError = true)]
        internal static extern int sysConnMgrMapConRef(int type, string pwszUrl, out Guid pguid);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrMapURL", SetLastError = true)]
        internal static extern int sysConnMgrMapURL(string pwszUrl, ref Guid pguid, ref int pdwIndex);

        [DllImport("cellcore.dll", EntryPoint = "ConnMgrReleaseConnection", SetLastError = true)]
        internal static extern int sysConnMgrReleaseConnection(IntPtr hConnection, int bCache);

        [DllImport("aygshell.dll", EntryPoint = "DMProcessConfigXML", SetLastError = true)]
        internal static extern int sysDMProcessConfigXML(string pszWXMLin, int dwFlags, out IntPtr pszWXMLOut);

        [DllImport("coredll.dll", EntryPoint = "#1457", SetLastError = true)]
        internal static extern int sysOperator_Delete(IntPtr p);

        /// <summary>
        /// Occurs when the connection status has changed		
        /// </summary>
        public event ConnMgr.StatusChangedEventHandler StatusChanged;

        private class ConnectionInfo
        {
            private int cbSize;

            public int dwParams;

            public int dwFlags;

            public int dwPriority;

            public bool bExclusive;

            public bool bDisabled;

            public Guid guidDestNet;

            public IntPtr hWnd;

            public int uMsg;

            public int lParam;

            private int ulMaxCost;

            private int ulMinRcvBw;

            private int ulMaxConnLatency;

            public IntPtr structPtr;

            public ConnectionInfo()
            {
                this.cbSize = this.CalcStructSize();
                this.structPtr = Memory.AllocHLocal(this.cbSize);
                if (this.structPtr == IntPtr.Zero)
                {
                    throw new OutOfMemoryException(string.Concat("Can't create ", this.ToString()));
                }
                this.ulMaxCost = 0;
                this.ulMinRcvBw = 0;
                this.ulMaxConnLatency = 0;
            }

            private int CalcStructSize()
            {
                int num = 0;
                Memory.AddAlignInt(ref num, 6);
                Memory.AddAlignByte(ref num, 16);
                Memory.AddAlignInt(ref num, 6);
                Memory.AlignStructSize(ref num);
                return num;
            }

            public void Dispose()
            {
                try
                {
                    Memory.FreeHLocal(ref this.structPtr);
                }
                finally
                {
                    //this.Finalize();
                }
            }

            public void MarshalFromUnManaged()
            {
                IntPtr intPtr = this.structPtr;
                Memory.PumpFromBuffer(ref intPtr, ref this.cbSize);
                Memory.PumpFromBuffer(ref intPtr, ref this.dwParams);
                Memory.PumpFromBuffer(ref intPtr, ref this.dwFlags);
                Memory.PumpFromBuffer(ref intPtr, ref this.dwPriority);
                Memory.PumpFromBuffer(ref intPtr, ref this.bExclusive);
                Memory.PumpFromBuffer(ref intPtr, ref this.bDisabled);
                Memory.PumpFromBuffer(ref intPtr, ref this.guidDestNet);
                Memory.PumpFromBuffer(ref intPtr, ref this.hWnd);
                Memory.PumpFromBuffer(ref intPtr, ref this.uMsg);
                Memory.PumpFromBuffer(ref intPtr, ref this.lParam);
                Memory.PumpFromBuffer(ref intPtr, ref this.ulMaxCost);
                Memory.PumpFromBuffer(ref intPtr, ref this.ulMinRcvBw);
                Memory.PumpFromBuffer(ref intPtr, ref this.ulMaxConnLatency);
            }

            public void MarshalToUnManaged()
            {
                IntPtr intPtr = this.structPtr;
                Memory.PumpToBuffer(ref intPtr, this.cbSize);
                Memory.PumpToBuffer(ref intPtr, this.dwParams);
                Memory.PumpToBuffer(ref intPtr, this.dwFlags);
                Memory.PumpToBuffer(ref intPtr, this.dwPriority);
                Memory.PumpToBuffer(ref intPtr, this.bExclusive);
                Memory.PumpToBuffer(ref intPtr, this.bDisabled);
                Memory.PumpToBuffer(ref intPtr, this.guidDestNet);
                Memory.PumpToBuffer(ref intPtr, this.hWnd);
                Memory.PumpToBuffer(ref intPtr, this.uMsg);
                Memory.PumpToBuffer(ref intPtr, this.lParam);
                Memory.PumpToBuffer(ref intPtr, this.ulMaxCost);
                Memory.PumpToBuffer(ref intPtr, this.ulMinRcvBw);
                Memory.PumpToBuffer(ref intPtr, this.ulMaxConnLatency);
            }
        }

        public enum ConnectionMode
        {
            Synchronous,
            Asynchronous
        }

        /// <summary>
        /// Priority of the connection requested
        /// </summary>    
        public enum ConnectionPriority
        {
            Cached = 2,
            LowBackground = 8,
            ExternalInteractive = 32,
            IdleBackground = 128,
            HighPriorityBackground = 512,
            UserIdle = 2048,
            UserBackground = 8192,
            UserInteractive = 32768,
            Voice = 131072
        }

        /// <summary>
        /// Describes the current status of the connection
        /// </summary>
        public enum ConnectionStatus
        {
            Unknown = 0,
            Connected = 16,
            Suspended = 17,
            Disconnected = 32,
            ConnectionFailed = 33,
            ConnectionCanceled = 34,
            ConnectionDisabled = 35,
            NoPathToDestination = 36,
            WaitingForPath = 37,
            WaitingForPhone = 38,
            PhoneOff = 39,
            ExclusiveConflict = 40,
            NoResources = 41,
            ConnectionLinkedFailed = 42,
            AuthenticationFailed = 43,
            WaitingConnection = 64,
            WaitingForResource = 65,
            WaitingForNetwork = 66,
            WaitingDisconnection = 128,
            WaitingConnectionAbort = 129
        }

        public enum ConnMgrConRefTypeEnum
        {
            ConRefType_NAP,
            ConRefType_PROXY
        }

        /// <summary>
        /// Provides data for the StatusChanged event of the class		
        /// </summary>
        public class StatusChangedEventArgs : EventArgs
        {
            public ConnMgr.ConnectionStatus connstatus;

            public string desc;

            public StatusChangedEventArgs(ConnMgr.ConnectionStatus connstatus, string desc)
            {
                this.connstatus = connstatus;
                this.desc = desc;
            }
        }

        /// <summary>
        /// Represents the method that will handle the StatusChanged event of the class   		
        /// </summary>
        public delegate void StatusChangedEventHandler(object sender, ConnMgr.StatusChangedEventArgs e);
    }


    /// <summary>
    ///  Delegate class use by Trapwindow to be called when a registered msg is received
    /// </summary>
    public delegate void WM_Delegate(ref Message m);

    /// <summary>
    /// Custom class to receive Window's Messages, and trigger associated Delegates.
    /// </summary>
    internal class TrapWindow : MessageWindow
    {
        private ArrayList msgTrapList = new ArrayList();

        public TrapWindow()
        {
        }

        /// <summary>
        /// Registers a new Message to the trapped and its associated handler (delegate)
        /// </summary>
        /// <param name="msg">Windows message number to trap</param>
        /// <param name="WM_Handler">Handler to invoke. Null=Unregister</param>
        public bool AddHandler(int msg, WM_Delegate WM_Handler)
        {
            MsgTrap msgTrap = new MsgTrap(msg, WM_Handler);
            if (this.msgTrapList.Contains(msgTrap))
            {
                return false;
            }
            if (WM_Handler != null)
            {
                this.msgTrapList.Add(msgTrap);
            }
            else
            {
                this.msgTrapList.Remove(msgTrap);
            }
            return true;
        }

        /// <summary>
        /// Window Procedure: Processes all Window messages looking for a registered 
        /// message and calls the associated msg handler (delegate).
        /// </summary>
        /// <param name="m"></param>		
        protected override void WndProc(ref Message m)
        {
            MsgTrap msgTrap = new MsgTrap(m.Msg, null);
            int num = this.msgTrapList.BinarySearch(0, this.msgTrapList.Count, msgTrap, MsgTrap.sortMsg());
            if (num < 0)
            {
                base.WndProc(ref m);
                return;
            }
            msgTrap = (MsgTrap)this.msgTrapList[num];
            msgTrap.InvokeHandler(ref m);
        }
    }

    /// <summary>
    /// An internal struct to store information about a Windows Message to be trapped
    /// </summary>
    internal struct MsgTrap : IComparable
    {
        private int msgNum;

        private WM_Delegate WM_Handler;

        /// <summary>
        /// Creates and Initializes a new MsgHandler structure
        /// </summary>
        /// <param name="m_MsgNum">Msg # to trap</param>
        /// <param name="m_WM_Handler">User-defined Handler for the message</param>
        public MsgTrap(int m_MsgNum, WM_Delegate m_WM_Handler)
        {
            this.msgNum = m_MsgNum;
            this.WM_Handler = m_WM_Handler;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is MsgTrap))
            {
                throw new ArgumentException("object is not a MsgTrap");
            }
            return this.msgNum.CompareTo(((MsgTrap)obj).msgNum);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MsgTrap))
            {
                return false;
            }
            return this == (MsgTrap)obj;
        }

        public override int GetHashCode()
        {
            return this.msgNum.GetHashCode();
        }

        /// <summary>
        /// Invokes the associated message Handler
        /// </summary>
        /// <param name="m"></param>
        public void InvokeHandler(ref Message m)
        {
            this.WM_Handler(ref m);
        }

        public static bool operator ==(MsgTrap x, MsgTrap y)
        {
            return x.msgNum == y.msgNum;
        }

        public static bool operator !=(MsgTrap x, MsgTrap y)
        {
            return x.msgNum != y.msgNum;
        }

        /// <summary>
        /// Method to return IComparer Interface to sort by Msg#
        /// </summary>
        /// <returns></returns>
        public static IComparer sortMsg()
        {
            return new MsgTrap.sortMsgHelper();
        }

        /// <summary>
        /// Internal class to implement IComparer interface sorting by Msg# for the MsgTrap type
        /// </summary>
        private class sortMsgHelper : IComparer
        {
            public sortMsgHelper()
            {
            }

            public int Compare(object x, object y)
            {
                if (!(x is MsgTrap) || !(y is MsgTrap))
                {
                    throw new ArgumentException("object is not a MsgTrap");
                }
                int num = ((MsgTrap)x).msgNum;
                return num.CompareTo(((MsgTrap)y).msgNum);
            }
        }
    }

    /// <summary>
    /// Provides simple memory allocation services and string-to-memory copying
    /// </summary>
    internal class Memory
    {
        private static int LMEM_FIXED;

        private static int LMEM_MOVEABLE;

        private static int LMEM_ZEROINIT;

        private static int LPTR;

        static Memory()
        {
            Memory.LMEM_FIXED = 0;
            Memory.LMEM_MOVEABLE = 2;
            Memory.LMEM_ZEROINIT = 64;
            Memory.LPTR = Memory.LMEM_FIXED | Memory.LMEM_ZEROINIT;
        }

        public Memory()
        {
        }

        /// <summary>
        /// Adds a byte count to the current size, considering memory alignment
        /// </summary>		
        public static void AddAlignByte(ref int currSize, int nelem)
        {
            currSize = currSize + nelem;
        }

        /// <summary>
        /// Adds an integer count to a current size, considering memory alignment
        /// </summary>		
        public static void AddAlignInt(ref int currSize, int nelem)
        {
            currSize = currSize + currSize % 4;
            currSize = currSize + 4 * nelem;
        }

        /// <summary>
        /// Adds a string length to a current size, considering memory alignment
        /// </summary>		
        public static void AddAlignString(ref int currSize, int nelem)
        {
            currSize = currSize + currSize % 2;
            int num = nelem * Marshal.SystemDefaultCharSize;
            currSize = currSize + num;
        }

        /// <summary>
        /// Corrects the struct size considering memory alignment
        /// </summary>
        public static void AlignStructSize(ref int currSize)
        {
            currSize = currSize + currSize % 4;
        }

        /// <summary>
        /// Allocates a block of memory using LocalAlloc
        /// </summary>		
        public static IntPtr AllocHLocal(int cb)
        {
            return Memory.sysLocalAlloc(Memory.LPTR, cb);
        }

        /// <summary>
        /// Frees memory allocated by AllocHLocal
        /// </summary>
        public static void FreeHLocal(ref IntPtr hlocal)
        {
            if (hlocal != IntPtr.Zero)
            {
                if (Memory.sysLocalFree(hlocal) != IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                hlocal = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Pushes the string out from Unmanaged buffer, considering memory alignment
        /// </summary>
        public static void PumpFromBuffer(ref IntPtr p, ref string s, int fixedlen)
        {
            if (p == IntPtr.Zero || fixedlen == 0)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 2);
            char[] chrArray = new char[fixedlen];
            Marshal.Copy(p, chrArray, 0, fixedlen);
            s = new string(chrArray);
            s = s.TrimEnd(new char[1]);
            int systemDefaultCharSize = Marshal.SystemDefaultCharSize * fixedlen;
            p = new IntPtr(p.ToInt32() + systemDefaultCharSize);
        }

        public static void PumpFromBuffer(ref IntPtr p, ref int num)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            num = Marshal.ReadInt32(p);
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpFromBuffer(ref IntPtr p, ref IntPtr ptr)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            ptr = new IntPtr(Marshal.ReadInt32(p));
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpFromBuffer(ref IntPtr p, ref bool val)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            val = Marshal.ReadInt32(p) == 1;
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpFromBuffer(ref IntPtr p, ref byte num)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            num = Marshal.ReadByte(p);
            p = new IntPtr(p.ToInt32() + 1);
        }

        /// <summary>
        /// Copies from a unmanaged-memory buffer to a managed byte array. 
        /// </summary>
        /// <param name="p">memory buffer</param>
        /// <param name="bytes">The managed array, which MUST have been initialized with the proper length</param>
        public static void PumpFromBuffer(ref IntPtr p, ref byte[] bytes)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            int length = (int)bytes.Length;
            Marshal.Copy(p, bytes, 0, length);
            p = new IntPtr(p.ToInt32() + length);
        }

        public static void PumpFromBuffer(ref IntPtr p, ref Guid guid)
        {
            byte[] numArray = new byte[16];
            Memory.PumpFromBuffer(ref p, ref numArray);
            guid = new Guid(numArray);
        }

        /// <summary>
        /// Pushes the managed string into the unmanaged buffer, considering memory alignment
        /// </summary>
        public static void PumpToBuffer(ref IntPtr p, string s, int fixedlen)
        {
            if (s == null || p == IntPtr.Zero || fixedlen == 0)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 2);
            s = string.Concat(s, "\0");
            Marshal.Copy(s.ToCharArray(), 0, p, s.Length);
            int systemDefaultCharSize = Marshal.SystemDefaultCharSize * fixedlen;
            p = new IntPtr(p.ToInt32() + systemDefaultCharSize);
        }

        public static void PumpToBuffer(ref IntPtr p, int num)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            Marshal.WriteInt32(p, num);
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpToBuffer(ref IntPtr p, IntPtr ptr)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            Marshal.WriteInt32(p, ptr.ToInt32());
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpToBuffer(ref IntPtr p, bool val)
        {
            int num;
            if (p == IntPtr.Zero)
            {
                return;
            }
            p = new IntPtr(p.ToInt32() + p.ToInt32() % 4);
            IntPtr intPtr = p;
            num = (val ? 1 : 0);
            Marshal.WriteInt32(intPtr, num);
            p = new IntPtr(p.ToInt32() + 4);
        }

        public static void PumpToBuffer(ref IntPtr p, byte num)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            Marshal.WriteByte(p, num);
            p = new IntPtr(p.ToInt32() + 1);
        }

        public static void PumpToBuffer(ref IntPtr p, byte[] bytes)
        {
            if (p == IntPtr.Zero)
            {
                return;
            }
            Marshal.Copy(bytes, 0, p, (int)bytes.Length);
            p = new IntPtr(p.ToInt32() + (int)bytes.Length);
        }

        public static void PumpToBuffer(ref IntPtr p, Guid guid)
        {
            Memory.PumpToBuffer(ref p, guid.ToByteArray());
        }

        /// <summary>
        /// Resizes a block of memory previously allocated with AllocHLocal
        /// </summary>
        public static IntPtr ReAllocHLocal(IntPtr pv, int cb)
        {
            IntPtr intPtr = Memory.sysLocalReAlloc(pv, cb, Memory.LMEM_MOVEABLE);
            if (intPtr == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }
            return intPtr;
        }

        /// <summary>
        /// Copies the contents of a managed string to a new buffer in unmanaged memory
        /// </summary>
        public static IntPtr StringToHLocalUni(string s)
        {
            if (s == null)
            {
                return IntPtr.Zero;
            }
            int length = s.Length;
            IntPtr intPtr = Memory.AllocHLocal(2 * (1 + length));
            if (intPtr == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }
            Marshal.Copy(s.ToCharArray(), 0, intPtr, s.Length);
            return intPtr;
        }

        [DllImport("coredll.dll", EntryPoint="LocalAlloc", SetLastError=true)]
        private static extern IntPtr sysLocalAlloc(int uFlags, int uBytes);

        [DllImport("coredll.dll", EntryPoint="LocalFree", SetLastError=true)]
        private static extern IntPtr sysLocalFree(IntPtr hMem);

        [DllImport("coredll.dll", EntryPoint="LocalReAlloc", SetLastError=true)]
        private static extern IntPtr sysLocalReAlloc(IntPtr hMem, int uBytes, int fuFlags);
    }
}
