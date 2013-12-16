using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ITC.Embedded.WirelessAssembly
{
    class WirelessManager
    {
        static bool m_wwan_state = false;
        static bool m_wlan_state = false;

        public static void GetWLANState(ref bool state)
        {
            state = m_wlan_state;
        }
        public static void GetWWANState(ref bool state)
        {
            state = m_wwan_state;
        }

        public static void SetWLANState(bool state)
        {
            m_wlan_state = state;
        }
        public static void SetWWANState(bool state)
        {
            m_wwan_state = state;
        }


        public WirelessManager()
        {
        }

    }
}
