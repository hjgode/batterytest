using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Trans_o_flex_Battery_Test
{


    /**
    $GPGGA,hhmmss.ss,llll.ll,a,yyyyy.yy,a,x,xx,x.x,x.x,M,x.x,M,x.x,xxxx*hh
    $GPGGA,123519,4807.038,N,01131.324,E,1,08,0.9,545.4,M,46.9,M,,*42

    GGA  = Global Positioning System Fix Data

    1    = UTC of Position
    2    = Latitude
    3    = N or S
    4    = Longitude
    5    = E or W
    6    = GPS quality indicator (0=invalid; 1=GPS fix; 2=Diff. GPS fix)
    7    = Number of satellites in use [not those in view]
    8    = Horizontal dilution of position
    9    = Antenna altitude above/below mean sea level (geoid)
    10   = Meters  (Antenna height unit)
    11   = Geoidal separation (Diff. between WGS-84 earth ellipsoid and
           mean sea level.  -=geoid is below WGS-84 ellipsoid)
    12   = Meters  (Units of geoidal separation)
    13   = Age in seconds since last update from diff. reference station
    14   = Diff. reference station ID#
    15   = Checksum
    **/

    class GPSData : System.EventArgs
    {
        public string[] gpsdata = new string[23];
        public bool DataReceived;

        public GPSData()
        {
            DataReceived = false;

            for (int u = 0 ; u < gpsdata.Length ; u++)
                gpsdata[u] = "";
        }

        public bool GotPosition
        {
            get
            {
                return DataReceived && this.NumberOfSatellites > 0;
            }
        }

        public bool AddGPSString(string GPSString)
        {
            // this.doLog(GPSString);
            return (this.AddGGA(GPSString) || this.AddRMC(GPSString)); // V1.3.0
        }

        //GGA
        private bool AddGGA(string GPSString)
        {
            if (GPSString.Substring(0, 7) != "$GPGGA,")
                return false;

            DataReceived = true;

            //Number of , (max 23 ,)
            int x = 1;

            //GGA Datas
            gpsdata[0] = "$GPGGA,";

            gpsdata[1] = "";

            for (int i = 7 ; i < GPSString.Length ; i++)
            {
                if (x >= gpsdata.Length)
                {
                }
                else if (GPSString[i] == ',')
                {
                    x++;
                    gpsdata[x] = "";
                }
                else
                {
                    gpsdata[x] += GPSString[i];
                }

            }

            return true;

        }

        public void doLog(string logstring)
        {
            try
            {
                using (TextWriter tw = File.AppendText(@"\My Documents\gpslog.txt"))
                {
                    tw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " [" + logstring + "]");
                }
            }
            catch
            {
            }
        }

        //RMC Recommended minimum sentence C
        private bool AddRMC(string GPSString)
        {
            if (GPSString.Substring(0, 7) != "$GPRMC,")
                return false;

            DataReceived = true;

            string[] RMCData = new string[13];

            for (int u = 0 ; u < RMCData.Length ; u++)
                RMCData[u] = "";

            //Number of , (max 13 ,)
            int x = 1;

            //GGA Datas
            gpsdata[0] = "$GPRMC,";

            for (int i = 7 ; i < GPSString.Length ; i++)
            {
                if (x >= RMCData.Length)
                {
                }
                else if (GPSString[i] == ',')
                    x++;
                else
                {
                    RMCData[x] += GPSString[i];
                }
            }

            gpsdata[1] = RMCData[1];
            gpsdata[16] = RMCData[2];    //NavigatorReceiverWarning
            gpsdata[2] = RMCData[3];
            gpsdata[3] = RMCData[4];
            gpsdata[4] = RMCData[5];
            gpsdata[5] = RMCData[6];
            gpsdata[17] = RMCData[7];    //Speed (Knots)
            gpsdata[18] = RMCData[8];    //Course Made Good, true
            gpsdata[19] = RMCData[9];    //Date
            gpsdata[20] = RMCData[10];    //Magnetic variation
            gpsdata[21] = RMCData[11];    //Magnetic variation D
            gpsdata[22] = RMCData[12];    //Modus (A = Autonom; D = Differentiell; E = geschätzt (Estimated); N = ungültig (Not valid); S = Simulator) or Checksum (old std)

            return true;

        }


        public double MagneticVariation    //MagneticVariation
        {
            get
            {
                if (!DataReceived || gpsdata[20] == "")
                    return 0;

                return double.Parse(gpsdata[20].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public string MagneticVariationD    //MagneticVariation D
        {
            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[21];
            }
        }

        public string Mode    //Mode
        {
            get
            {
                if (!DataReceived | (gpsdata[22] != "A" && gpsdata[22] != "D" && gpsdata[22] != "E" && gpsdata[22] != "N" && gpsdata[22] != "S"))
                    return "";

                return gpsdata[22];
            }
        }

        public string NavigatorReceiverWarning    //NavigatorReceiverWarning
        {
            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[16];
            }
        }

        public double CourseMadeGood    //Course Made Good, true
        {
            get
            {
                if (!DataReceived || gpsdata[18] == "")
                    return 0;

                return double.Parse(gpsdata[18].Replace(".", ","), System.Globalization.NumberStyles.Currency);
                ;
            }
        }

        public double Speed    //Speed over ground (Knots)
        {
            get
            {
                if (!DataReceived || gpsdata[17] == "")
                    return 0;

                return double.Parse(gpsdata[17].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        //Date
        public string Date    //Date
        {
            get
            {
                if (!DataReceived)
                    return "";

                if (gpsdata[19] != "")
                    return gpsdata[19][0].ToString() + gpsdata[19][1] + "." + gpsdata[19][2] + gpsdata[19][3] + " 20" + gpsdata[19][4] + gpsdata[19][5];
                return "";
            }
        }

        //Time
        public string Time
        {
            get
            {
                if (!DataReceived || gpsdata[1] == "")
                    return "";

                if (gpsdata[1] != "")
                    return gpsdata[1][0].ToString() + gpsdata[1][1] + ":" + gpsdata[1][2] + gpsdata[1][3] + ":" + gpsdata[1][4] + gpsdata[1][5] + " UTC";
                return "";
            }
        }

        public string LastDataset    //LastDataset
        {
            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[0];
            }
        }

        public double Latitude    //Latitude, Breitengrad
        {
            set
            {
                DataReceived = true;
                gpsdata[2] = value.ToString();
            }

            get
            {
                if (!DataReceived || gpsdata[2] == "")
                    return 0;

                return double.Parse(gpsdata[2].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public string LatitudeD    //Latitude D
        {
            set
            {
                DataReceived = true;
                gpsdata[3] = value;
            }

            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[3];
            }
        }

        public double Longitude    //Longitude
        {
            set
            {
                DataReceived = true;
                gpsdata[4] = value.ToString();
            }

            get
            {
                if (!DataReceived || gpsdata[4] == "")
                    return 0;

                return double.Parse(gpsdata[4].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public string LongitudeD    //Longitude D
        {
            set
            {
                DataReceived = true;
                gpsdata[5] = value;
            }

            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[5];
            }
        }

        public int GPSType    //0 invalid; 1 GPS fix; 2 diff GPS fix
        {
            get
            {
                if (!DataReceived)
                    return 0;

                if (gpsdata[6] != "")// V1.4 fixed [1] into [6]
                    return Convert.ToInt32(gpsdata[6]);
                return 0;
            }
        }

        public int NumberOfSatellites    //Number of Satellites
        {
            get
            {
                if (!DataReceived)
                    return 0;

                if (gpsdata[7] != "") // V1.4 fixed [1] into [7]
                    return Convert.ToInt32(gpsdata[7]);
                return 0;
            }
        }

        public double HorizontalDilution    //The Horizontal Dilution
        {
            get
            {
                if (!DataReceived || gpsdata[8] == "")
                    return 0;

                return double.Parse(gpsdata[8].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public double GeoID    //The GeoID (See-Higth)
        {
            get
            {
                if (!DataReceived || gpsdata[9] == "")
                    return 0;

                return double.Parse(gpsdata[9].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public string AntennaHigthUnit    //Antenna height unit
        {
            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[10];
            }
        }

        public double GeoidalSeparation    //(Diff. between WGS-84 earth ellipsoid and    mean sea level)
        {
            get
            {
                if (!DataReceived || gpsdata[11] == "")
                    return 0;

                return double.Parse(gpsdata[11].Replace(".", ","), System.Globalization.NumberStyles.Currency);
            }
        }

        public string GeoidSepUnit    //Units of geoidal separation
        {
            get
            {
                if (!DataReceived)
                    return "";

                return gpsdata[12];
            }
        }

        public int LastDiffRefUpdate    //The Last Difference Reference Update
        {
            get
            {
                if (!DataReceived)
                    return 0;

                if (gpsdata[13] != "")// V1.4 fixed [1] into [13]
                    return Convert.ToInt32(gpsdata[13]);
                return 0;
            }
        }

    };

    class GPS
    {
        public static System.IO.Ports.SerialPort Port;
        public GPSData Data;

        public delegate void GPSDateEventHandler(object sender, GPSData e);
        public event GPSDateEventHandler OnGPSDateEventHandler;

        protected void OnNewData(GPSData e)
        {
            if (OnGPSDateEventHandler != null)
                OnGPSDateEventHandler(this, e);
        }

        public GPS(string strPortName, int baudRate)
        {
            Data = new GPSData();
            Port = new System.IO.Ports.SerialPort(strPortName, baudRate);

            Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SerialDataReceived);
        }

        public void SerialDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string line = Port.ReadLine();
                if (line != null)
                {
                    if (Data.AddGPSString(line))
                    {
                        OnNewData(Data);
                    }
                }
                else
                {
                    Data.doLog("(null)");
                }
            }
            catch
            {
            }
        }

        public void CloseComPort()
        {
            try
            {
                if (Port.IsOpen)
                    Port.Close();
            }
            catch
            {
            }
        }

        public int OpenComPort()
        {

            if (Port.IsOpen)
                return 0;

            try
            {
                Port.Open();
            }
            catch (Exception ee)
            {
                //ee = ee;
                System.Diagnostics.Debug.WriteLine("Excption in OpenComPort(): " + ee.Message);
                return 1;
            }

            return 0;
        }

        public GPSData Datas
        {
            get
            {
                return Data;
            }
        }
    };
}
