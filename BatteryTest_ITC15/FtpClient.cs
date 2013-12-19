using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace HSM.Samples.Ftp
{
	/// <summary>
	/// This class can be used for FTP operations
	/// </summary>
	public class FtpClient 
	{
		private const int BUFFER_SIZE = 512;

		private const int FTP_PORT = 21;
		private readonly string FTP_HOST = "";
		private Socket ftpSocket;
		private readonly byte[] FTP_BUFFER = new byte[BUFFER_SIZE];

        public static bool LoggingEnabled = false;
        public static bool ActiveTransfer = false;

		/// <summary>
		/// Creates an FtpClient object and connect it with host
		/// </summary>
		/// <param name="remoteHost">Hostname that will be connected to.  The port will default to 21.</param>
		public FtpClient(string remoteHost, string username, string password)
		{
			FTP_HOST = remoteHost;
			IPEndPoint endpoint;
			ftpSocket = new Socket(AddressFamily.InterNetwork,
			  SocketType.Stream,
			  ProtocolType.Tcp);

			try
			{
				IPAddress address = IPAddress.Parse(FTP_HOST);
				endpoint = new IPEndPoint(address, FTP_PORT);
			}
			catch (System.FormatException)
			{
				try
				{
					IPAddress address = Dns.GetHostEntry(FTP_HOST).AddressList[0];
					endpoint = new IPEndPoint(address, FTP_PORT);
				}
				catch (SocketException ee)
				{
                    this.doLog(" ==1 [" + ee.Message + "]");
                    throw new Exception(ee.Message);
                    //return;
				}

			}
			// make the connection
			try
			{
                this.doLog(" FTP " + endpoint.Address.ToString() + ":" + endpoint.Port.ToString());
				ftpSocket.Connect(endpoint);
			}
			catch (Exception ee)
			{
                this.doLog(" ==2 [" + ee.Message + "]");
                throw new Exception(ee.Message);
                //return;
			}
			// check the result
			FtpResponse response = ReadResponse();

			if (response.Id != 220)
			{
				ftpSocket.Close();
				ftpSocket = null;
                this.doLog(" ==3 bad response (not 220)");
                throw new Exception("bad response (not 220)");
                //return;
			}

			// set the user id
			response = SendCommand("USER " + username);
			// check the response
			if (!((response.Id == 331) || (response.Id == 230)))
			{
                response = SendCommand("USER anonymous");
                if (!((response.Id == 331) || (response.Id == 230)))
                {
                    ftpSocket.Close();
                    ftpSocket = null;
                    this.doLog(" ==4 bad username (not 331, 230)");
                    throw new Exception("bad username (not 331, 230)");
                    //return;
                }
			}

			// if a PWD is required, send it
			if (response.Id == 331)
			{
				response = SendCommand("PASS " + password);
				if (!((response.Id == 202) || (response.Id == 230)))
				{
					ftpSocket.Close();
					ftpSocket = null;
                    this.doLog(" ==5 bad password (not 202, 230)");
                    throw new Exception("bad password (not 202, 230)");
                    //return;
				}
			}

			// get the server type
			response = SendCommand("SYST");
			
		}


		/// <summary>
		/// Die öffentliche Dispose Methode für die Implementierung des Dispose
		/// Patterns
		/// </summary>
		public void Dispose()
		{
            if (ftpSocket != null)
            {
                try // V1.1.0 add try/catch 
                {
                    FtpResponse response = SendCommand("QUIT");
                }
                catch (Exception ee)
                {
                    this.doLog(" ### [" + ee.Message + "]");
                }
                ftpSocket.Close();
                ftpSocket = null;
            }

			GC.SuppressFinalize(this);

		}

		/// <summary>
		/// Sendet Byte-Array per FTP an Drucker
		/// </summary>
		/// <param name="printData">Byte-Array zu drucken</param>
		/// <returns>Anzahl von gedrückten Bytes oder -1 bei Miserfolg</returns>
		public int SendBytes(int numbytes)
		{
            int sended = -1;

            if (ftpSocket != null)
            {
                try
                {
                    byte[] bulkData = new byte[1024];
                    for (int i = 0 ; i < 1024 ; i++)
                    {
                        bulkData[i] = (byte)'A';
                    }


                    sended = 0;
                    if (FtpClient.ActiveTransfer)
                    {
                        Socket socket;
                      //  if ((socket = OpenListenSocket()) != null)
                      //  {
                      //  }
                    }
                    else
                    {
                        Socket socket;
                        if ((socket = OpenDataSocket()) != null)
                        {
                            // send the STOR command
                            var response = SendCommand("STOR " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt"); // V1.3.0 new DT format
                            try
                            {
                                if (response.Id == 125 || response.Id == 150)
                                {
                                    this.doLog(" ==> sending " + numbytes.ToString() + " bytes data ...");

                                    int sum = 0;
                                    while (sum + 1024 <= numbytes)
                                    {
                                        socket.Send(bulkData);
                                        sum += 1024;
                                        sended = sum;
                                    }
                                    if (sum < numbytes)
                                    {
                                        int restant = numbytes - sum; // V1.2.0 new[] was using numbytes-sum, loop was using 1024, now using variable
                                        bulkData = new byte[restant];
                                        for (int i = 0 ; i < restant ; i++)
                                        {
                                            bulkData[i] = (byte)'B';
                                        }
                                        socket.Send(bulkData);
                                        sum += restant;
                                        sended = sum;
                                    }
                                }
                            }
                            catch (Exception ee)
                            {
                                this.doLog(" ### [" + ee.Message + "]");
                            }
                            if (socket.Connected)
                            {
                                socket.Close();
                            }
                        }
                        this.doLog(" ### " + sended.ToString() + " bytes sent");
                        if (sended > 0)
                        {
                            var response = ReadResponse();
                            if (!(response.Id == 226 || response.Id == 250))
                            {
                                this.doLog(" ### bad response (not 226, 250)");
                                sended = -1;
                            }
                        }
                    }

                }
                catch (Exception ee)
                {
                    this.doLog(" ### [" + ee.Message + "]");
                }
            }
            else
            {
                this.doLog(" ### socket is null");
            }
            this.doLog(" ### reply " + sended.ToString() + " bytes sent");
            return sended;
		}

		private FtpResponse SendCommand(string command)
		{
            this.doLog(" --> [" + command + "]");

            if (ftpSocket != null)
            {
                // encode the command
                byte[] bytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());

                // send it
                ftpSocket.Send(bytes, bytes.Length, 0);
            }
			return ReadResponse();
		}

		private FtpResponse ReadResponse()
		{
			lock (ftpSocket)
			{

				var response = new FtpResponse();
				string responsetext = "";

				// make sure any command sent has enough time to respond
                int maxwaittimes = 50; // V1.3.0 change from 10 to 50
                while (ftpSocket.Available == 0 && maxwaittimes-- > 0)
                {
                    Thread.Sleep(100);
                }

                this.doLog(" <== " + ftpSocket.Available.ToString() + " bytes available @ " + (50-maxwaittimes).ToString() + " ticks");
                bool hascrlf = false;
                for ( ; ftpSocket.Available > 0 || (!hascrlf && maxwaittimes-- > 0) ; )
                {
                    int bytesrecvd = ftpSocket.Receive(FTP_BUFFER, FTP_BUFFER.Length, 0);
                    if (bytesrecvd > 0)
                    {
                        responsetext += Encoding.ASCII.GetString(FTP_BUFFER, 0, bytesrecvd);
                    }
                    hascrlf = responsetext.EndsWith("\n");
                    if (!hascrlf)
                    {
                        Thread.Sleep(100);
                    }
                }
                
				if (responsetext.Length == 0)
				{
					response.Id = 0;
					response.Text = "";
                    this.doLog(" <-- []");

					return response;
				}

                this.doLog(" <-- [" + responsetext.Replace("\r\n","<cr><lf>") + "]");

                string[] message = responsetext.Replace("\r", "").Split('\n');

				// we may have multiple responses, 
				// particularly if retriving small amounts of data like directory listings
				// such as the command sent and transfer complete together
				// a response may also have multiple lines
				for (int m = 0; m < message.Length; m++)
				{
					try
					{
						// is the first line a response?  If so, the first 3 characters
						// are the response ID number
						FtpResponse resp = new FtpResponse();
						if (message[m].Length > 0)
						{
							try
							{
								resp.Id = int.Parse(message[m].Substring(0, 3));
							}
							catch (Exception)
							{
								resp.Id = 0;
							}

							resp.Text = message[m].Substring(4);

							if (m == 0)
							{
								response = resp;
							}
						}
					}
					catch (Exception)
					{
						continue;
					}

					return response;
				}

				// return the first response received
				return response;
			}
		}

		private Socket OpenDataSocket()
		{
			FtpResponse response;
			int port;
			string ipAddress;

			response = SendCommand("PASV");

			if (response.Id != 227)
			{
                this.doLog(" ==> Passive failed (not 227)");
                return null;
			}

			// get the remote server's IP address
			int start = response.Text.IndexOf('(');
			int end = response.Text.IndexOf(')');

			string ipstring = response.Text.Substring(start + 1, end - start - 1);
			int[] parts = new int[6];

			int part = 0;
			string buffer = string.Empty;

			for (int i = 0; (i < ipstring.Length) && (part <= 6); i++)
			{
				char ch = ipstring[i];
				if (char.IsDigit(ch))
				{
					buffer += ch;
				}

				else if (ch != ',')
				{
                    this.doLog("==> IP Parse failed (not a comma)");
                    return null;
				}

				if ((ch == ',') || (i + 1 == ipstring.Length))
				{

					try
					{
						parts[part++] = int.Parse(buffer);
						buffer = "";
					}
					catch (Exception)
					{
                        this.doLog("==> IP Parse failed (not an int)");
						return null;
					}
				}
			} // for (int i = 0 ;(i < ipstring.Length) && (part <= 6); i++)

			ipAddress = parts[0] + "." + parts[1] + "." +
							parts[2] + "." + parts[3];

			port = (parts[4] << 8) + parts[5];

			Socket socket = new Socket(AddressFamily.InterNetwork,
			  SocketType.Stream,
			  ProtocolType.Tcp);


			try
			{
				IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                this.doLog(" SOC " + endpoint.Address.ToString() + ":" + endpoint.Port.ToString());
                socket.Connect(endpoint);
			}
			catch (Exception ee)
			{
                this.doLog(" --> [" + ee.Message + "]");
                return null;
			}

			System.Threading.Thread.Sleep(1000);

			return socket;
		}

        private void doLog(string message)
        {
            if (FtpClient.LoggingEnabled)
            {
                try
                {
                    using (TextWriter tw = File.AppendText(@"\My Documents\ftplog.txt"))
                    {
                        tw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + message);
                    }
                }
                catch
                {
                }
            }
        }
	}


    /// <summary>
    /// Detected FTP Server type
    /// </summary>
    public enum FtpServerType
    {
        /// <summary>
        /// Unix-compliant server
        /// </summary>
        Unix = 0,

        /// <summary>
        /// Windows/IIS-compliant server
        /// </summary>
        Windows = 1,

        /// <summary>
        /// Unknown server type
        /// </summary>
        Unknown = 2
    }

    /// <summary>
    /// Information returned in a response from an FTP command
    /// <seealso cref="FTP.ReadResponse()"/>
    /// </summary>
    public struct FtpResponse
    {
        /// <summary>
        /// Response ID value
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Response text
        /// </summary>
        public string Text
        {
            get;
            set;
        }
    }

}
