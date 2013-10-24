using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CameraAssembly
{
    public delegate void CameraEventHandler(object sender, CameraEventArgs e);
    interface ICameraAssembly
    {
        void Disconnect();
        void Connect(IntPtr handle, object o1, object o2);
        void GetResolutionCount(out long lCount);
        void SetResolution(uint uIndex);
        void SetProperty(CameraProperty prop, int val, PropertyMode flags);
        void StartPreview();
        void StopPreview();
        //void CameraEvent();
    }

    public enum CameraProperty
    {
        /// <summary>
        /// </summary>
        Brightness = 0,
        /// <summary>
        /// </summary>
        Contrast = 1,
        /// <summary>
        /// </summary>
        Saturation = 3,
        /// <summary>
        /// </summary>
        Sharpness = 4,
        /// <summary>
        /// </summary>
        Gamma = 5,
        /// <summary>
        /// </summary>
        ColorEnable = 6,
        /// <summary>
        /// </summary>
        WhiteBalance = 7,
        /// <summary>
        /// </summary>
        Zoom = 12,
        /// <summary>
        /// </summary>
        FocusMode = 15,
        /// <summary>
        /// </summary>
        Illumination = 16,
        /// <summary>
        /// </summary>
        FocusStep = 59,
        /// <summary>
        /// </summary>
        FocusMax = 60,
        /// <summary>
        /// </summary>
        FocusMin = 61,
        /// <summary>
        /// </summary>
        FocusFixed = 62,
        /// <summary>
        /// </summary>
        FocusPoint = 63,
        /// <summary>
        /// </summary>
        FocusWindow = 64,
        /// <summary>
        /// </summary>
        Aimer = 80
    }

    public enum PropertyMode
    {
        /// <summary>
        /// Property automatically controlled at the camera driver level
        /// </summary>
        Auto = 1,
        /// <summary>
        /// Property can be manually contolled
        /// </summary>
        Manual = 2
    }
}
