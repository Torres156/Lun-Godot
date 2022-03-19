using LiteNetLib;
using Lun.Server.Network.Interfaces;
using Lun.Shared.Models.Player;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Models.Player
{
    internal class Character : CharacterModel, INetPeer
    {
        [JsonIgnore]
        public NetPeer peer { get; set; }
    }
}
