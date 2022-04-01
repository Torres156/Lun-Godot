using Godot;
using Lun.Scripts.Models.Scenes;
using Lun.Scripts.Services;
using Lun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Controller
{
	internal class ActionController	 : Node
	{
		public override void _PhysicsProcess(float delta)
		{		 			
			if (Input.IsKeyPressed((int)KeyList.W) || Input.IsKeyPressed((int)KeyList.Up))
				PlayerService.RequestMove(Directions.Up);

			if (Input.IsKeyPressed((int)KeyList.S) || Input.IsKeyPressed((int)KeyList.Down))
				PlayerService.RequestMove(Directions.Down);

			if (Input.IsKeyPressed((int)KeyList.A) || Input.IsKeyPressed((int)KeyList.Left))
				PlayerService.RequestMove(Directions.Left);

			if (Input.IsKeyPressed((int)KeyList.D) || Input.IsKeyPressed((int)KeyList.Right))
				PlayerService.RequestMove(Directions.Right);

		}

		public override void _Input(InputEvent @event)
		{
			if (@event is InputEventKey eventKey)
			{
				if (!eventKey.IsPressed())
				{
					switch((KeyList)eventKey.Scancode)
					{
						case KeyList.Insert:
							GameplayScene.ToggleWindow("Admin");
							break;
					}
				}
			}
		}
	}
}
