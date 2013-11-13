using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Intermec.DataCollection;

namespace DecodeAssemblyITC
{
    /// <summary>
    /// class to mimic honeywell barcode reading DecodeAssembly
    /// </summary>
    class DecodeAssembly:IBarcodeAssembly,IDisposable
    {
        /// <summary>
        /// event will be fired for scanned barcode or timeout
        /// </summary>
        public event DecodeEventHandler DecodeEvent;

        #region fields
        int m_iTimeout = 1000;
        public int ScanTimeout
        {
            get { return m_iTimeout; }
            set { m_iTimeout = value; }
        }
        static BarcodeReader bcr;
        Timer timer1;
        #endregion

        public DecodeAssembly()
        {
            addLog("DecodeAssembly()...");
            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(timerCallback);
            timer1 = new Timer(timerDelegate, null, System.Threading.Timeout.Infinite, m_iTimeout);
            addLog("DecodeAssembly() done");
        }
        ~DecodeAssembly()
        {
            addLog("deInit DecodeAssembly...");
            if (timer1 != null)
                timer1.Dispose();
            if (bcr != null)
            {
                Disconnect();
                bcr = null;
            }
            addLog("deInit DecodeAssembly end");
        }
        public void Dispose()
        {
            addLog("Dispose()...");
            if (timer1 != null)
                timer1.Dispose();
            if (bcr != null)
            {
                Disconnect();
                bcr = null;
            }
            addLog("Dispose() end");
        }

        /// <summary>
        /// timer callback
        /// </summary>
        /// <param name="stateInfo"></param>
        void timerCallback(Object stateInfo)
        {
            addLog("timerCallback ...");
            timer1.Change(Timeout.Infinite, m_iTimeout);
            bcr.CancelRead(true);   //cancel pending reads
            bcr.ScannerOn = false;  //shutdown scanner light
            //we have to fire the event also for no barcode read
            DecodeEventArgs dea = new DecodeEventArgs("no data scan");
            doDecode(dea);
            addLog("timerCallback end");
        }

        /// <summary>
        /// enables event handler for barcode read
        /// </summary>
        public void Connect()
        {
            addLog("Connect()...");
            try
            {
                if (bcr == null)
                {
                    addLog("create new barcoderader");
                    bcr = new BarcodeReader();
                }
                else
                    addLog("using existing barcodereader");
            }
            catch (BarcodeReaderException ex)
            {
                addLog("BarcodeReaderException in Connect(): "+ex.Message);
            }
            catch (Exception ex)
            {
                addLog("Exception in Connect(): " + ex.Message);
            }
            if (bcr != null)
            {
                addLog("attach barcode read event");
                bcr.BarcodeRead += new BarcodeReadEventHandler(bcr_BarcodeRead);
            }
            else
                addLog("no BarcodeReader!");
            addLog("Connect() end");
        }
        /// <summary>
        /// stop timer, disconnect barcode event handler
        /// and cancel pending barcode reads
        /// </summary>
        public void Disconnect()
        {
            addLog("Disconnect...");
            if (timer1 != null)
            {
                try
                {
                    addLog("disable timer1");
                    timer1.Change(Timeout.Infinite, m_iTimeout);
                }
                catch (Exception) { }
            }
            else
                addLog("no timer1");
            try
            {
                if (bcr != null)
                {
                    addLog("removing event handler");
                    bcr.BarcodeRead -= bcr_BarcodeRead;
                    addLog("cancel pending read");
                    bcr.CancelRead(true);
                    addLog("Disposing barcodereader");
                    bcr.Dispose();
                    addLog("set barcodereader=null");
                    bcr = null;
                }
                else
                {
                    addLog("no barcodereader!");
                }
            }
            catch (Exception ex) {
                addLog("Exception in Disconnect(): " + ex.Message);
            }
        }
        /// <summary>
        /// function to be called to start a barcode read
        /// scanner will be lit and timer started
        /// </summary>
        public void ScanBarcode()
        {
            addLog("ScanBarcode...");
            if (bcr == null)
                return;
            bcr.ThreadedRead(false); //only request one scan
            bcr.ScannerEnable = true;
            bcr.ScannerOn = true;
            timer1.Change(m_iTimeout, 0);   //issue one timeout
            //Thread thReadThread = new Thread(new ThreadStart(readThread));
            //thReadThread.Start();
            addLog("ScanBarcode end");
        }

        /// <summary>
        /// called by barcode reader object on successful barcode read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bre"></param>
        void bcr_BarcodeRead(object sender, BarcodeReadEventArgs bre)
        {
            addLog("bcr_BarcodeRead...\r\nchange timer to off");
            //stop timer
            timer1.Change(Timeout.Infinite, m_iTimeout);
            //prepare data
            DecodeEventArgs dea = new DecodeEventArgs(bre.strDataBuffer);
            //fire event handler
            doDecode(dea);
            addLog("bcr_BarcodeRead end");
        }

        /// <summary>
        /// delegate for decode event handler
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        public delegate void DecodeEventHandler(object s, DecodeEventArgs args);
        /// <summary>
        /// fire the event handler if there is any subscriber
        /// </summary>
        /// <param name="args"></param>
        void doDecode(DecodeEventArgs args)
        {
            if (DecodeEvent != null)
            {
                addLog("doDecode: calling event subscriber");
                DecodeEvent(this, args);
            }
            else
                addLog("doDecode: No event subscriber");
        }

        void addLog(string s)
        {
            System.Diagnostics.Debug.WriteLine("BarcodeAssembly: " + s);
        }
    }

}
