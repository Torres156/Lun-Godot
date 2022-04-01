using Godot;
using Lun.Scripts.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Scenes
{
	internal class GameplayScene : Node
	{
		static GameplayScene Instance;

		public override void _Ready()
		{
			Instance = this;
		}

		public static void ShowWindow(string name)
		{
			var fullName = "./UI/WindowManager/" + name;
			if (!Instance.HasNode(fullName))
				return;

			var window = Instance.GetNode<WindowComponent>(fullName);
			window.Show();
		}

		public static void HideWindow(string name)
		{
			var fullName = "./UI/WindowManager/" + name;
			if (!Instance.HasNode(fullName))
				return;

			var window = Instance.GetNode<WindowComponent>(fullName);
			window.Hide();
		}

		public static void ToggleWindow(string name)
		{
			var fullName = "./UI/WindowManager/" + name;
			if (!Instance.HasNode(fullName))
				return;

			var window = Instance.GetNode<WindowComponent>(fullName);
			if (window.Visible)
				window.Hide();
			else
				window.Show();
		}
	}
}
