using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Shared.Models.Player
{
    public abstract class CharacterModel
    {
        public string  Name     { get; set; } = "";
        public int     ClassId  { get; set; }
        public int     SpriteId { get; set; }
        public int     MapId    { get; set; }
        public Vector2 Position { get; set; }
    }
}
