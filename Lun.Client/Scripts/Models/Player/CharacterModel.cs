using Lun.Shared.Enums;
using Lun.Shared.Models;
using Lun.Shared.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Player
{
	internal class CharacterModel : ICharacterModel
	{
		public string Name           { get; set; }
		public int ClassId           { get; set; }
		public int SpriteId          { get; set; }
		public int MapId             { get; set; }
		public Vector2 Position      { get; set; }
		public Directions Direction { get; set; }
	}
}
