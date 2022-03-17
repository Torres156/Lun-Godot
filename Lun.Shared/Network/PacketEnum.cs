using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Shared.Network
{
    public enum PacketClient
    {
        Register,
        Login,
    }

    public enum PacketServer
    {
        Alert,
        Logged,
    }
}
