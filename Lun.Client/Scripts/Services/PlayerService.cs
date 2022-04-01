using Lun.Scripts.Models.Player;
using Lun.Shared.Enums;
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
		public static Character My;

		public static void RequestMove(Directions direction)
		{
			var speed = 150/100f;
			speed = speed.Round();

			if (CanMove(direction, speed))
			{
				My.timerMovingFrame = TickCount + 150;
				My.Direction = direction;

				var pos = My.Position;
				switch (direction)
				{
					case Directions.Up:
						pos.y -= speed;
						break;
					case Directions.Down:
						pos.y += speed;
						break;
					case Directions.Left:
						pos.x -= speed;
						break;
					case Directions.Right:
						pos.x += speed;
						break;
				}

				My.Position = pos;
			}
		}

		static bool CanMove(Directions direction, float speed)
		{
			var pos = My.Position;

			switch (direction)
			{
				case Directions.Up:
					pos.y -= (speed + 8);
					break;
				case Directions.Down:
					pos.y += (speed + 8);
					break;
				case Directions.Left:
					pos.x -= (speed + 8);
					break;
				case Directions.Right:
					pos.x += (speed + 8);
					break;
			}

			if (pos.x < 8)
			{
				return false;
			}

			if (pos.y < 8)
			{
				return false;
			}

			return true;
		}

	}
}
