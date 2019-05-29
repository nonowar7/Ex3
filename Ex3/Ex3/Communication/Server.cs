using Ex3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;

namespace Ex3.Communication
{
    public class Server
    {

        private TcpListener listener;
        private Thread listenThread;
        private TcpClient clientSocket;

        public Server(string ip, int port)
        {
            listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void listen()
        {
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            listenThread = new Thread(new ParameterizedThreadStart(readDataFromSimulator));
            listenThread.Start(client);
        }

        public void readDataFromSimulator(object client)
        {
            clientSocket = (TcpClient)client;
            NetworkStream stream = clientSocket.GetStream();
            int numBytes = 0;
            byte[] buffer = new byte[Consts.BUFFER_SIZE];
            byte[] str = new byte[Consts.BUFFER_SIZE];

            string data = "";

            try
            {
                    numBytes = stream.Read(buffer, 0, buffer.Length);
            }
            catch
            {
                    return;
            }

            data = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                string[] filtered = data.Split('\n');
                foreach (string s in filtered)
                {
                    if (String.IsNullOrEmpty(s) || s[0] == '\0' || s.Length == 0 || s == null)
                    {
                        continue;
                    }
                }
            }


        public void closeStream()
        {
            this.clientSocket.GetStream().Dispose();
            this.clientSocket.Close();
        }


    }
}