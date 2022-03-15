using LiteNetLib.Utils;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Network
{
    internal static class Receive
    {
        public static void Handle(NetDataReader buffer)
        {
            var packet = (PacketServer)buffer.GetInt();
        }
    }
}
