using System;
using System.Collections.Generic;
using System.Collections;
using Bindings;

namespace BomberBros
{
    class ClientHandleData
    {
        public PacketBuffer buffer = new PacketBuffer();

        delegate void Packet_(byte[] data);

        static Dictionary<int, Packet_> packets;

        public void InitializeMessages()
        {
            packets = new Dictionary<int, Packet_>();
            packets.Add((int)ServerPackets.SLogin, HandleLogin);
            packets.Add((int)ServerPackets.SReceiveMessage, HandleMessages);
            packets.Add((int)ServerPackets.SFullServer, HandleServerFull);
        }

        public void HandleNetworkMessages(byte[] data)
        {
            int packetNum;
            PacketBuffer _buffer;
            _buffer = new PacketBuffer();

            _buffer.AddBytes(data);
            packetNum = _buffer.GetInteger();
            _buffer.Dispose();

            if (packets.TryGetValue(packetNum, out Packet_ packet))
            {
                packet.Invoke(data);
            }
        }

        void HandleLogin(byte[] data)
        {
            int longueur;
            PacketBuffer _buffer = new PacketBuffer();
            _buffer.AddBytes(data);
            longueur = _buffer.GetInteger();
            longueur = BitConverter.GetBytes(longueur).Length;
            string login = _buffer.GetString(data.Length - longueur);
            Console.WriteLine("1st Option : " + login);
        }

        void HandleMessages(byte[] data)
        {
            int longueur;
            PacketBuffer _buffer = new PacketBuffer();
            _buffer.AddBytes(data);
            longueur = _buffer.GetInteger();
            longueur = BitConverter.GetBytes(longueur).Length;
            string login = _buffer.GetString(data.Length - longueur);
            Console.WriteLine("2nd Option : " + login);
        }

        void HandleServerFull(byte[] data)
        {
            int longueur;
            PacketBuffer _buffer = new PacketBuffer();
            _buffer.AddBytes(data);
            longueur = _buffer.GetInteger();
            longueur = BitConverter.GetBytes(longueur).Length;
            string login = _buffer.GetString(data.Length - longueur);
            Console.WriteLine(login);
        }
    }
}
