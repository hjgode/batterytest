using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MS.Embedded.Utility
{
    class UtilMethods
    {
        [DllImport("coredll.dll", EntryPoint = "GwesPowerOffSystem", SetLastError = true)]
        private static extern void sysGwesPowerOffSystem();

        [DllImport("coredll.dll", EntryPoint = "SetCleanRebootFlag", SetLastError = true)]
        private static extern void sysSetCleanRebootFlag();

        public static void SuspendDevice()
        {
            try
            {
                UtilMethods.sysGwesPowerOffSystem();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
