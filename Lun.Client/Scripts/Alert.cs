using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts
{
	internal class Alert : Node
	{
		long timer;

		public override void _Input(InputEvent @event)
		{
			if (@event is InputEventMouseButton eventMouse && !eventMouse.IsPressed())
				QueueFree();

			base._Input(@event);
		}

		public override void _Process(float delta)
		{
			if (TickCount > timer)
				QueueFree();

			base._Process(delta);
		}

		public static void Show(string text)
		{
			var instance = ResourceLoader.Load<PackedScene>("res://Views/Alert.tscn").Instance() as Alert;
			instance.GetNode<Label>("Text").Text = text;
			instance.timer = TickCount + 4000;

			CurrentScene.AddChild(instance);
		}
	}
}
