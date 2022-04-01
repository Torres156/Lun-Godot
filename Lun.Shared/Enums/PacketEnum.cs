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
        CharacterCreate,
        CharacterUse,
        RequestGameplayData,
    }

    public enum PacketServer
    {
        Alert,
        Logged,
        ClassUpdate,  
        GameplayStart,
        CharacterMainData,
    }
}
