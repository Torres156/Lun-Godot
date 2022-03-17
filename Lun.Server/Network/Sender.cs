using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Server.Models.Player;
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
        public static void Logged(Account account)
        {
            SendTo(account, Create(PacketServer.Logged));
        }

        public static void Alert(INetPeer peer, string text)
            => Alert(peer.peer, text);

        public static void Alert(NetPeer peer, string text)
        {
            var buffer = Create(PacketServer.Alert);
            buffer.Put(text);
            SendTo(peer, buffer);
        }

        static void SendTo(INetPeer peer, NetDataWriter buffer, DeliveryMethod delivery = DeliveryMethod.ReliableOrdered)
            => SendTo(peer.peer, buffer, delivery);

        static void SendTo(NetPeer peer, NetDataWriter buffer, DeliveryMethod delivery = DeliveryMethod.ReliableOrdered)
            => peer.Send(buffer, delivery);

        static NetDataWriter Create(PacketServer packet)
        {
            var buffer = new NetDataWriter();
            buffer.Put((short)packet);
            return buffer;
        }
    }
}
