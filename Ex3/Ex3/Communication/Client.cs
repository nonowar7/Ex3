using Ex3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace Ex3.Communication
{
    public class Client
    {

        private TcpClient client;
        public Client()
        {
            client = new TcpClient();

        }

        public void connect(string ip, int port)
        {
            while(true)
            {
                try
                {
                    client.Connect(ip, port);
                    break;
                }
                catch { }
            }
        }

        public string getInfo(string kind)
        {
            string request = "get ";
            switch (kind)
            {
                case "longitude":
                    request += Consts.LONGIDUTE_XML;
                    break;
                case "latitude":
                    request += Consts.LATITUDE_XML;
                    break;
                case "rudder":
                    request += Consts.RUDDER_XML;
                    break;
                case "throttle":
                    request += Consts.THROTTLE_XML;
                    break;
                default:
                    return "";

            }

            request += Consts.NEW_LINE;
            string info = "";
            
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] buffer = asen.GetBytes(request);
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);

                byte[] readBytes = new byte[client.ReceiveBufferSize];
                int sizeRead = stream.Read(readBytes, 0, client.ReceiveBufferSize);
                if (sizeRead >0)
                {
                    info = System.Text.Encoding.UTF8.GetString(readBytes, 0, readBytes.Length);
                    string []splitInfo = info.Split('\'');
                    info = splitInfo[1];

                } else
                {
                    // print message?
                }

            }
            catch { }

            return info;

        }

    }
}