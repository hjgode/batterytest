using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Battery_Test_itc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                Application.Run(new batteryTestfrm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}