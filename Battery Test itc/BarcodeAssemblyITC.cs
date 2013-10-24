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
            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(timerCallback);
            timer1 = new Timer(timerDelegate, null, System.Threading.Timeout.Infinite, m_iTimeout);

        }
        ~DecodeAssembly()
        {
            if (timer1 != null)
                timer1.Dispose();
            if (bcr != null)
            {
                Disconnect();
                bcr = null;
            }
        }
        public void Dispose()
        {
            if (timer1 != null)
                timer1.Dispose();
            if (bcr != null)
            {
                Disconnect();
                bcr = null;
            }
        }

        /// <summary>
        /// timer callback
        /// </summary>
        /// <param name="stateInfo"></param>
        void timerCallback(Object stateInfo)
        {
            timer1.Change(Timeout.Infinite, m_iTimeout);
            bcr.CancelRead(true);   //cancel pending reads
            bcr.ScannerOn = false;  //shutdown scanner light
            //we have to fire the event also for no barcode read
            DecodeEventArgs dea = new DecodeEventArgs("no data scan");
            doDecode(dea);
        }

        /// <summary>
        /// enables event handler for barcode read
        /// </summary>
        public void Connect()
        {
            try
            {
                if (bcr == null)
                    bcr = new BarcodeReader();

            }
            catch (BarcodeReaderException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (bcr != null)
                bcr.BarcodeRead += new BarcodeReadEventHandler(bcr_BarcodeRead);
        }
        /// <summary>
        /// stop timer, disconnect barcode event handler
        /// and cancel pending barcode reads
        /// </summary>
        public void Disconnect()
        {
            if (timer1 != null)
            {
                try
                {
                    timer1.Change(Timeout.Infinite, m_iTimeout);
                }
                catch (Exception) { }
            }
            try
            {
                if (bcr != null)
                {
                    bcr.BarcodeRead -= bcr_BarcodeRead;
                    bcr.CancelRead(true);
                }
                bcr.Dispose();
                bcr = null;
            }
            catch (Exception) { }
        }
        /// <summary>
        /// function to be called to start a barcode read
        /// scanner will be lit and timer started
        /// </summary>
        public void ScanBarcode()
        {
            if (bcr == null)
                return;
            bcr.ThreadedRead(false); //only request one scan
            bcr.ScannerEnable = true;
            bcr.ScannerOn = true;
            timer1.Change(m_iTimeout, m_iTimeout);
            //Thread thReadThread = new Thread(new ThreadStart(readThread));
            //thReadThread.Start();
        }

        /// <summary>
        /// called by barcode reader object on successful barcode read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bre"></param>
        void bcr_BarcodeRead(object sender, BarcodeReadEventArgs bre)
        {
            //stop timer
            timer1.Change(Timeout.Infinite, m_iTimeout);
            //prepare data
            DecodeEventArgs dea = new DecodeEventArgs(bre.strDataBuffer);
            //fire event handler
            doDecode(dea);
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
                DecodeEvent(this, args);
        }

    }

}
