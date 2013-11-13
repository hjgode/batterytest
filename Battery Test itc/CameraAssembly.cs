using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Threading;

using Intermec.Multimedia;

using System.Windows.Forms;

namespace CameraAssembly
{
    class CameraAssembly:Control,ICameraAssembly,IDisposable
    {
        static Intermec.Multimedia.Camera cam;
        Camera.Resolution currentRes;
        System.Threading.Timer timer1;
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
            timer1 = new System.Threading.Timer(timerDelegate, null, System.Threading.Timeout.Infinite, m_iTimeout);
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
        
        Boolean startCAM()
        {
            addLog("startCAM()");
            try
            {
                if (cam == null)
                {
                    addLog("creat new cam");
                    Camera.ImageResolutionType viewFinderResolution = Camera.ImageResolutionType.Medium;
                    cam = new Camera(m_pb, viewFinderResolution);
                    if (cam.Features.Torch.Available)
                    {
                        cam.Features.Torch.PresetValue = Camera.Feature.TorchFeature.TorchPresets.Off;
                    }
                    if (cam.Features.Flash.Available)
                    {
                        cam.Features.Flash.CurrentValue = cam.Features.Flash.MaxValue;
                    }
                }
                else
                {
                    addLog("using existing cam");
                }
                return true;
            }
            catch(CameraException ex){
                addLog("CameraException: " + ex.Message);
            }
            catch(Exception ex){
                addLog("Exception: " + ex.Message);
            }
            return false;
        }
        
        void stopCAM()
        {
            addLog("StopCAM()");
            if (cam != null)
            {
                addLog("stopCAM(): cam is not null");
                StopPreview();
                //cam.Streaming = false;
                //cam.PictureBoxUpdate = Camera.PictureBoxUpdateType.None;
            }
            try
            {
                //we have to set the event, otherwise the main app will never stop!
                CameraEventArgs cea = new CameraEventArgs(CameraTaskCodes.ImageCaptureComplete);
                addLog("stopCAM(): fire event CaptureComplete");
                doHandleEvent(cea);
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                addLog("stopCAM(): Exception for doHandleEvent(): " + ex.Message);
            }
            addLog("StopCAM(): DeInit cam");

            //cam MUST be disposed to have barcoding work!
            if(cam!=null)
                camDispose(cam);// cam.Dispose();    //control invoke????
            if (cam != null)
            {
                addLog("stopCAM(): setting cam = null");
                cam = null;
            }
            addLog("StopCAM() done");
        }
        delegate void setImageCallback(PictureBox pb, System.Drawing.Bitmap bmp);
        public void setImage(PictureBox pb, System.Drawing.Bitmap bmp)
        {
            if (this.InvokeRequired)
            {
                setImageCallback d = new setImageCallback(setImage);
                this.Invoke(d, new object[] { pb, bmp });
            }
            else
            {
                pb.Image = bmp;
            }
        }
        delegate void camDisposeCallback(Intermec.Multimedia.Camera obj);
        public void camDispose(Intermec.Multimedia.Camera obj)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                camDisposeCallback d = new camDisposeCallback(camDispose);
                this.Invoke(d, new object[] { obj });
            }
            else
            {
                obj.Dispose();
            }
        }
        public void Connect(ref System.Windows.Forms.PictureBox pb, int iTimeout, object o2)
        {
            m_iTimeout = iTimeout;
            this.Connect(ref pb, null, null);
        }

        public void Connect(ref System.Windows.Forms.PictureBox pb, object o1, object o2)
        {
            addLog("Connect...");
            try
            {
                m_pb = pb; // Added so that m_pb is not null when startCAM() instantiates the camera
                startCAM();
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
                startCAM();
                addLog("StartPreview: new cam");
            }
            addLog("StartPreview: start streaming");
            cam.PictureBoxUpdate = Camera.PictureBoxUpdateType.Center;
            cam.Streaming = true;
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
            if (cam.Features.Torch.Available)
                cam.Features.Torch.CurrentValue = cam.Features.Torch.MinValue;
            timer1.Change(Timeout.Infinite, m_iTimeout);

            if (m_pb != null)
                setImage(m_pb, null);    //control invoke????

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
