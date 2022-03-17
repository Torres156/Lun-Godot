using LiteNetLib;
using Lun.Server.Network.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Models.Player
{
    internal class Account : INetPeer
    {   
        public string   Name          { get; set; } = "";
        public string   Password      { get; set; } = "";
        public string[] CharacterName { get; set; }


        [JsonIgnore]
        public NetPeer peer { get; set; }


        public Account()
        {
            CharacterName = new string[Constants.MAX_CHARACTERS];
            for (int i = 0; i < Constants.MAX_CHARACTERS; i++)
                CharacterName[i] = "";
        }
    }
}
