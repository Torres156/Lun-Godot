using Lun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Shared.Models.Player
{
    public interface ICharacterModel
    {
         string     Name       { get; set; }
         int        ClassId    { get; set; }
         int        SpriteId   { get; set; }
         int        MapId      { get; set; }
         Vector2    Position   { get; set; }
         Directions Direction { get; set; }
    }
}
