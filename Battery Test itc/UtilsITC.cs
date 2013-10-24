﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace HSM.Embedded.Utility
{
    class SystemNotification
    {
        [DllImport("itc50.dll", SetLastError=true)]
        extern static int ITCPowerStatus(ref UInt32 lpdwLineStatus, ref UInt32 lpdwBatteryStatus, ref UInt32 lpdwBackupStatus, ref UInt32 puFuelGauge);

        public static int GetBatteryLife()
        {
            UInt32 uPercent = 255;
            UInt32 uLineStat=0, uBattStat=0, uBackupStat=0;
            try
            {
                int hRes = ITCPowerStatus(ref uLineStat, ref uBattStat, ref uBackupStat, ref uPercent);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in GetBatteryLife: " + e.Message);
            }
            //System.Diagnostics.Debug.WriteLine("ITCPowerStatus: hRes="+hRes.ToString()+", GetLastError()=" + Marshal.GetLastWin32Error().ToString());
            return (int)uPercent;
        }
    }
}
