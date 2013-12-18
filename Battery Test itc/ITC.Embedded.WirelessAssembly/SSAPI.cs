using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Intermec.DeviceManagement.SmartSystem;

namespace ITC.Embedded.WirelessAssembly
{
    class SSAPI : IDisposable
    {
        static Intermec.DeviceManagement.SmartSystem.ITCSSApi mySSAPI = new ITCSSApi();
        const uint E_SS_SUCCESS = 0x00000000;

        public SSAPI()
        {
        }
        public void Dispose()
        {
        }
        public static uint DoAction(string sXML, string sMethod, out string sResponse)
        {
            int max_len = 1024;
            StringBuilder sb = new StringBuilder(max_len);
            string sRet = "";
            uint uRes = 99;
            try
            {
                Intermec.DeviceManagement.SmartSystem.ITCSSApi ssAPI = mySSAPI;
                uRes = ssAPI.Get(sXML, sb, ref max_len, 2);
                if (uRes == E_SS_SUCCESS)
                {
                    sRet = sb.ToString();
                }
            }
            catch (Exception)
            {
            }
            sResponse = sRet;
            return uRes;
        }
    }

}
