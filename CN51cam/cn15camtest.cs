#define test2
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#if test1
using Intermec.Multimedia;
#elif test2
using CameraAssembly;
#endif
namespace CN51cam
{
    public partial class frmCamTest : Form
    {
#if test1
        Camera cam; //for test1 OK
#elif test2
        CameraAssembly.CameraAssembly ca;
#endif
        public frmCamTest()
        {
            InitializeComponent();
            testCam1();
            testCam2();
        }

        void testCam2(){
#if test2
            ca = new CameraAssembly.CameraAssembly();
            ca.Connect(ref this.pictureBox1, System.Threading.Timeout.Infinite, null);
            ca.StartPreview();
#endif
        }

        void testCam1() //works OK
        {
#if test1
            try
            {
                cam = new Camera(this.pictureBox1, Camera.ImageResolutionType.Medium);
                cam.PictureBoxUpdate = Camera.PictureBoxUpdateType.Center;
                cam.Streaming = true;
            }
            catch (Exception ex)
            {
                addLog("Exception in Init(): " + ex.Message);
            }
#endif
        }
        void addLog(string s)
        {
            System.Diagnostics.Debug.WriteLine("CameraAssembly: " + s);
        }

        private void frmCamTest_Closing(object sender, CancelEventArgs e)
        {
#if test1
            if (cam != null)
            {
                cam.Streaming = false;
                cam.Dispose();
                cam = null;
            }
#elif test2
            if(ca!=null){
                ca.Disconnect();
                ca.Dispose();
                ca=null;
            }
#endif
        }
    }
}