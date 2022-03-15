using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Network
{
    internal static class Receive
    {
        public static void Handle(NetPeer peer, NetDataReader buffer)
        {
            var packet = (PacketClient)buffer.GetInt();
        }
    }
}
