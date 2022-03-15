using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Server.Network.Interfaces;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Network
{
    internal static class Sender
    {
        static void SendTo(INetPeer peer, NetDataWriter buffer, DeliveryMethod delivery = DeliveryMethod.ReliableOrdered)
            => SendTo(peer.peer, buffer, delivery);

        static void SendTo(NetPeer peer, NetDataWriter buffer, DeliveryMethod delivery = DeliveryMethod.ReliableOrdered)
            => peer.Send(buffer, delivery);

        static NetDataWriter Create(PacketServer packet)
        {
            var buffer = new NetDataWriter();
            buffer.Put((int)packet);
            return buffer;
        }
    }
}
