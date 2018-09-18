using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using Bindings;

namespace BomberBros
{
    class ClientTCP
    {
        public TcpClient PlayerSocket;
        private static NetworkStream myStream;

        ClientHandleData chd;

        byte[] asyncBuff;

        bool connecting;
        bool connected;

        public void ConnectToServer()
        {
            if (PlayerSocket != null)
            {
                if (PlayerSocket.Connected || connected)
                {
                    PlayerSocket.Close();
                    PlayerSocket = null;
                }
            }
            PlayerSocket = new TcpClient();
            chd = new ClientHandleData();
            PlayerSocket.ReceiveBufferSize = 4096;
            PlayerSocket.SendBufferSize = 4096;
            PlayerSocket.NoDelay = false;
            Array.Resize(ref asyncBuff, 8192);
            PlayerSocket.BeginConnect("127.0.0.1", 100, new AsyncCallback(ConnectCallBack), null);
            connecting = true;
        }

        private void ConnectCallBack(IAsyncResult ar)
        {

            PlayerSocket.EndConnect(ar);
            if (PlayerSocket.Connected == false)
            {
                connecting = false;
                connected = false;
                return;
            }
            else
            {
                PlayerSocket.NoDelay = true;
                myStream = PlayerSocket.GetStream();
                myStream.BeginRead(asyncBuff, 0, 8192, OnReceive, null);
                connecting = false;
                connected = true;
            }

        }

        private void OnReceive(IAsyncResult ar)
        {
            int byteAmt = myStream.EndRead(ar);
            byte[] myBytes = null;
            Array.Resize(ref myBytes, byteAmt);
            Buffer.BlockCopy(asyncBuff, 0, myBytes, 0, byteAmt);
            if (byteAmt == 0)
            {
                //DestroyUranus
                return;
            }

            //Handle Network Packets
            chd.HandleNetworkMessages(myBytes);
            myStream.BeginRead(asyncBuff, 0, 8912, OnReceive, null);
        }

        public  void SendData(byte[] data)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.AddBytes(data);
            myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
            buffer.Dispose();
        }

        public void SendLogin()
        {
            PacketBuffer _buffer = new PacketBuffer();
            _buffer.AddInteger((int)ClientPackets.CLogin);
            _buffer.AddString("Nahil");
            _buffer.AddString("231456");
            
            SendData(_buffer.ToArray());
            _buffer.Dispose();
        }
    }
}
