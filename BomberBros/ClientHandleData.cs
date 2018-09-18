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

        Dictionary<int, Packet_> packets;

        public void InitializeMessages()
        {
            packets = new Dictionary<int, Packet_>();
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
    }
}
