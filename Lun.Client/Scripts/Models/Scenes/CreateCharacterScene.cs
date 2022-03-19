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

			GetNode("Panel/Create").Connect("button_up", this, nameof(Create_Release));
			GetNode("Panel/Back").Connect("button_up", this, nameof(Back_Release));
		}

		void Back_Release()
		{
			GetTree().ChangeScene("res://Views/Scenes/Logged.tscn");
		}

		void Create_Release()
		{
			var name = GetNode<LineEdit>("Panel/Name").Text.Trim();
			var male = Male.Pressed;

			if (name.Length < 3)
			{
				Alert.Show("Mínimo 3 caracteres para o nome do personagem!");
				return;
			}

			Network.Sender.CharacterCreate(UseCharacterSlot, name, Classes.Selected, 1);
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
