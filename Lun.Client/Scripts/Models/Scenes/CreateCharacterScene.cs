using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Scenes
{
	internal class CreateCharacterScene : Control
	{
		OptionButton Classes;
		CheckBox Male, Female;

		public override void _Ready()
		{
			Classes = GetNode<OptionButton>("Panel/Classe");

			Classes.AddItem("Guerreiro");
			Classes.AddItem("Mago");
			Classes.Select(0);

			Male = GetNode<CheckBox>("Panel/Male");
			Male.Connect("button_up", this, nameof(Sex_Release), new Godot.Collections.Array(false));

			Female = GetNode<CheckBox>("Panel/Female");
			Female.Connect("button_up", this, nameof(Sex_Release), new Godot.Collections.Array(true));
		}

		void Sex_Release(bool female)
		{
			if (!female)
			{
				Male.Pressed = true;
				Female.Pressed = false;
			}
			else
			{
				Male.Pressed = false;
				Female.Pressed = true;
			}
		}
	}
}
