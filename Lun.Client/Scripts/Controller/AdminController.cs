using Godot;
using Lun.Scripts.Models.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Controller
{
	internal class AdminController : Node
	{	
		public override void _Ready()
		{
			GetNode("../MapEditor").Connect("button_up", this, nameof(MapEditor_Release));
		}

		void MapEditor_Release()
		{
			GameplayScene.HideWindow("Admin");
		}

	}
}
