using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ITC.Embedded.Camera
{
    public partial class CameraAssembly : Control, ICameraAssembly, IDisposable
    {
        public enum CameraTaskCodes
        {
            ImageCaptureComplete
        }

        /// <summary>
        /// The CameraEventArgs class defines the data being passed to the camera event.
        /// </summary>
        public class CameraEventArgs : EventArgs
        {
            private readonly CameraTaskCodes m_TaskCode;

            public CameraTaskCodes TaskCode
            {
                get
                {
                    return this.m_TaskCode;
                }
            }

            internal CameraEventArgs(CameraTaskCodes TaskCode)
            {
                this.m_TaskCode = TaskCode;
            }
        }
    }
}