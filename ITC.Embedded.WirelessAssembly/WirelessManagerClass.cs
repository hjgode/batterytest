using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.WindowsMobile.Status;

namespace ITC.Embedded.WirelessAssembly
{
    public class WirelessManager : IWirelessManager, IDisposable
    {
        static bool m_wwan_state = false;
        static bool m_wlan_state = false;
        static NetworkITC itcNetwork = new NetworkITC();
        public WirelessManager()
        {
        }
        public void Dispose()
        {
            itcNetwork.Dispose();
        }

        public static void GetWLANState(ref bool state)
        {
            bool bIsOn = false;
            if (itcNetwork.IsWifiInstalled())
                if (itcNetwork.IsWiFiOn())
                    bIsOn = true;
            m_wlan_state = bIsOn;
            state = m_wlan_state;
        }

        public static void GetWWANState(ref bool state)
        {
            //return (this.GetSSAPIValue(this.XmlGetPhonePowerFormat, "phone on") == "1");
            if (SystemState.PhoneRadioPresent)
            {
                if (SystemState.PhoneRadioOff)
                    m_wwan_state = false;
                else
                    m_wwan_state = true;
            }
            else
                m_wwan_state = false;
            state = m_wwan_state;
        }

        public static int SetWLANState(bool state)
        {
            m_wlan_state = state;
            if (state)
                itcNetwork.TurnOnWiFi();
            else
                itcNetwork.TurnOffWiFi();
            return 0;
        }

        public static int SetWWANState(bool state)
        {
            if (state)
                itcNetwork.TurnOffPhone();
            else
                itcNetwork.TurnOnPhone();

            return 0;
        }
    }
}