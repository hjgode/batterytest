using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Threading;

using Intermec.Multimedia;

namespace CameraAssembly
{
    class CameraAssembly:ICameraAssembly,IDisposable
    {
        static Intermec.Multimedia.Camera cam;
        Camera.Resolution currentRes;
        Timer timer1;
        int m_iTimeout = 3000;
        System.Windows.Forms.PictureBox m_pb = null;

        ///// <summary>
        ///// provider for event subscription
        ///// </summary>
        public event CameraEventHandler CameraEvent;

        public CameraAssembly()
        {
            addLog("CameraAssembly started");
            TimerCallback timerDelegate = new TimerCallback(timerCallback);
            //init the timer but do not start it
            timer1 = new Timer(timerDelegate, null, System.Threading.Timeout.Infinite, m_iTimeout);
        }

        public void Dispose()
        {
            addLog("Dispose...");
            if (cam == null)
            {
                addLog("Dispose: no cam!");
                return;
            }
            cam.Streaming = false;
            cam.Dispose();
            cam = null;
            addLog("Dispose done.");
        }

        /// <summary>
        /// timer callback
        /// </summary>
        /// <param name="stateInfo"></param>
        void timerCallback(Object stateInfo)
        {
            addLog("timerCallback...");
            timer1.Change(Timeout.Infinite, m_iTimeout);
            Disconnect();
            //we have to fire the event also for no barcode read
            CameraEventArgs cea = new CameraEventArgs(CameraTaskCodes.ImageCaptureComplete);
            doHandleEvent(cea);
            addLog("timeCallback: event signaled");
        }
        
        //we cannt use this for intermec camera init with picturebox
        public void Connect(IntPtr handle, object o1, object o2){
            addLog("Connect with handle UNSUPPORTED");
            cam = new Camera(Intermec.Multimedia.Camera.ImageResolutionType.Medium);
        }
        
        void startCAM()
        {
            addLog("startCAM()");
            if (cam == null)
            {
                addLog("creat new cam");
                cam = new Camera(m_pb, Camera.ImageResolutionType.Medium);
            }
            else
            {
                addLog("using existing cam");
            }
        }
        
        void stopCAM()
        {
            addLog("StopCAM()");
            if (cam == null)
            {
                addLog("StopCAM(): no cam");
                startCAM();
                //return;
            }
            
            if(true)
            {
                cam.Streaming = false;
                cam.PictureBoxUpdate = Camera.PictureBoxUpdateType.None;
                if (cam.Features.Torch.Available)
                    cam.Features.Torch.CurrentValue = cam.Features.Torch.MinValue;
            }
            try
            {
                //we have to set the event, otherwise the main app will never stop!
                CameraEventArgs cea = new CameraEventArgs(CameraTaskCodes.ImageCaptureComplete);
                doHandleEvent(cea);
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                addLog("stopCAM(): Exception for doHandleEvent(): " + ex.Message);
            }
            //addLog("StopCAM(): DeInit cam");            
            //cam.Dispose();
            //cam = null;

            addLog("StopCAM() done");
        }

        public void Connect(System.Windows.Forms.PictureBox pb, object o1, object o2)
        {
            addLog("Connect...");
            try
            {
                startCAM();
                //if (cam == null)
                //{
                //    m_pb = pb;
                //    cam = new Camera(pb, Camera.ImageResolutionType.Lowest);
                //    addLog("Connect: created new cam");
                //}
                //else
                //{
                //    addLog("Connect: using existing cam...");
                //}
            }
            catch (Exception) {
                //we have to set the event, otherwise the main app will never stop!
                CameraEventArgs cea = new CameraEventArgs(CameraTaskCodes.ImageCaptureComplete);
                doHandleEvent(cea);
            }
        }

        public void Disconnect()
        {
            //just shut of streaming or dispose the camera????
            addLog("Disconnect...");
            stopCAM();
            addLog("Disconnect done.");
        }
        
        public void GetResolutionCount(out long resCount)
        {
            addLog("GetResolutionCount...");
            if (cam == null)
            {
                resCount = 0;
                return;
            }
            Camera.Resolution[] resList = cam.AvailableImageResolutions;
            resCount = resList.Length;
            addLog("GetResolutionCount done.");
        }
        public void SetResolution(uint uRes){
            addLog("SetResolution...");
            if (cam == null)
            {
                addLog("SetResolution no cam!");
                return;
            }
            Camera.Resolution[] resList = cam.AvailableImageResolutions;
            if (uRes < resList.Length)
                currentRes = resList[uRes];
            addLog("SetResolution done");
        }
        public void SetProperty(CameraProperty prop, int val, PropertyMode flags){
            addLog("SetProperty...");
            if (cam == null)
            {
                addLog("SetProperty no cam!");
                return;
            }
            switch (prop){
                case CameraProperty.Illumination:
                    if (cam.Features.Torch.Available)
                        cam.Features.Torch.CurrentValue = cam.Features.Torch.MaxValue;
                    break;
                case CameraProperty.ColorEnable:
                    break;
            }
            addLog("SetProperty done");
        }
        
        public void StartPreview(){
            addLog("StartPreview...");
            if (cam == null)
            {
                addLog("StartPreview: no cam");
                return;
            }
            addLog("StartPreview: start streaming");
            cam.Streaming = true;
            cam.PictureBoxUpdate = Camera.PictureBoxUpdateType.AdjustToFrameSize;
            addLog("StartPreview activate timer");
            timer1.Change(m_iTimeout, m_iTimeout);
            addLog("StartPreview done.");
        }

        public void StopPreview(){
            addLog("StopPreview...");
            if (cam == null)
            {
                addLog("StopPreview no cam!.");
                return;
            }
            cam.Streaming = false;
            timer1.Change(Timeout.Infinite, m_iTimeout);
            addLog("StopPreview done.");
        }

        public delegate void CameraEventHandler(object s, CameraEventArgs args);
        void doHandleEvent(CameraEventArgs args)
        {
            addLog("doHandleEvent...");
            CameraEventArgs localEA = args;
            if (CameraEvent != null)
            {
                addLog("doHandleEvent: fire event");
                if (cam != null)
                    try
                    {
                        CameraEvent(this, localEA);
                    }
                    catch (Exception ex)
                    {
                        addLog("Exception in CameraEvent: " + ex.Message);
                    }
                else
                    addLog("dHandleEvent() cam is null");
            }
            addLog("doHandleEvent done.");
        }
        void addLog(string s)
        {
            System.Diagnostics.Debug.WriteLine("CameraAssembly: "+s);
        }
    }
}
