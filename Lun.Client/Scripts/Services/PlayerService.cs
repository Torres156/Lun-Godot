using Lun.Scripts.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Services
{
	internal static class PlayerService
	{
		public static CharacterSelectModel[] characterSelect = new CharacterSelectModel[Constants.MAX_CHARACTERS];
	}
}
