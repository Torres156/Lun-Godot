using Godot;
using Lun.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Player
{
	internal class Character  : Node2D
	{
		public Directions Direction;
		public Sprite Sprite;
		public Camera2D Camera;

		public long timerMovingFrame =0;

		AnimationPlayer animation;

		public override void _Ready()
		{
			Sprite = GetNode<Sprite>("Sprite");
			animation = Sprite.GetNode<AnimationPlayer>("Animation");
			Camera = Sprite.GetNode<Camera2D>("Camera");
		}

		public override void _Process(float delta)
		{
			var action = "normal";
			var direction = "up";

			switch (Direction)
			{
				case Directions.Up   : direction = "up"; break;
				case Directions.Down : direction = "down"; break;
				case Directions.Left : direction = "left"; break;
				case Directions.Right: direction = "right"; break;
			}

			if (timerMovingFrame > 0)
			{					
				if (TickCount >= timerMovingFrame)
					timerMovingFrame = 0;
				else
					action = "move";
			}

			animation.Play(action + "_" + direction);
		}
	}
}
