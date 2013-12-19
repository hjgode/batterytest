using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using System.Xml;

namespace ITC.Embedded.WirelessAssembly
{
    public class NetworkITC:IDisposable
    {
        public NetworkITC()
        {
            
        }
        public void Dispose()
        {
            //mySSAPI=null;//.Dispose(); //throws uninit not found
        }

        public bool IsWifiInstalled()
        {
            return (this.GetSSAPIValue(xmlGetWifiInstalledFormat, "WifiInstalled") == "True");
        }

        public bool IsWiFiOn()
        {
            string sSAPIValue = this.GetSSAPIValue(xmlGetWifiPowerFormat, "WiFi Enable");
            return ("1" == sSAPIValue);
        }

        private bool IsPhoneOn()
        {
            return (this.GetSSAPIValue(xmlGetPhonePowerFormat, "phone on") == "1");
        }

        public void TurnOffPhone()
        {
            string xmlSet = string.Format(xmlSetPhonePowerFormat, "0");
            this.SetSSAPIValue(xmlSet, "Turn off phone");
        }

        public void TurnOffWiFi()
        {
            string xmlSet = string.Format(xmlSetWifiPowerFormat, "0");
            this.SetSSAPIValue(xmlSet, "Turn off WiFi");
        }
        public void TurnOnPhone()
        {
            string xmlSet = string.Format(xmlSetPhonePowerFormat, "1");
            this.SetSSAPIValue(xmlSet, "Turn on phone");
        }

        public void TurnOnWiFi()
        {
            string xmlSet = string.Format(xmlSetWifiPowerFormat, "1");
            this.SetSSAPIValue(xmlSet, "Turn on WiFi");
        }

        private string GetSSAPIValue(string xmlGet, string errorText)
        {
            string response = "";
            try
            {
                uint num = SSAPI.DoAction(xmlGet, "Get", out response);
                if (num == 0)
                {
                    return this.ExtractField(response, errorText);
                }
                Log(string.Format("Failed to get {0}", errorText), "Error");
                string message = string.Format("Failed to get {0}, status={1:X}", errorText, num);
                Log(message);
            }
            catch
            {
                string text = string.Format("Attempting to get {0} caused exception", errorText);
                Log(text, "Error");
                Log(text);
            }
            return "";
        }
        private void SetSSAPIValue(string xmlSet, string errorText)
        {
            string str;
            uint num = SSAPI.DoAction(xmlSet, "Set", out str);
            if (num != 0)
            {
                Log(string.Format("{0} failed", errorText), "Error");
                string message = string.Format("{0} failed, status={1:X}", errorText, num);
                Log(message);
            }
        }
        void Log(string s)
        {
            System.Diagnostics.Debug.WriteLine(s);
        }
        void Log(string s, string t)
        {
            System.Diagnostics.Debug.WriteLine(t + ": " + s);
        }
        private string ExtractField(string response, string errorText)
        {
            XmlDocument document = new XmlDocument();
            string innerText = "";
            try
            {
                document.LoadXml(response.ToString());
                innerText = document.InnerText;
            }
            catch
            {
                Log(string.Format("Attempting to parse getting {0} caused exception", errorText), "Error");
            }
            return innerText;
        }

        private const string xmlGetPhonePowerFormat = "<Subsystem Name=\"WWAN Radio\"><Group Name=\"Manage Radio State\"><Field Name=\"Radio Power State\"></Field></Group></Subsystem>";
        private const string xmlSetPhonePowerFormat = "<Subsystem Name=\"WWAN Radio\"><Group Name=\"Manage Radio State\"><Field Name=\"Radio Power State\">{0}</Field></Group></Subsystem>";

        private static string xmlGetWifiInstalledFormat = "<Subsystem Name=\"Communications\"><Group Name=\"802.11 Radio\"><Field Name=\"WifiInstalled\"></Field></Group></Subsystem>";
        private const string xmlGetWifiPowerFormat = "<Subsystem Name=\"Communications\"><Group Name=\"802.11 Radio\"><Field Name=\"Radio Enabled\"></Field></Group></Subsystem>";
        private const string xmlSetWifiPowerFormat = "<Subsystem Name=\"Communications\"><Group Name=\"802.11 Radio\"><Field Name=\"Radio Enabled\">{0}</Field></Group></Subsystem>";
    }
}
