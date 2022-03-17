using Godot;
using Lun.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Scenes
{
	internal class LoggedScene : Control
	{
		Button[] slots;

		public override void _Ready()
		{
			slots = new Button[Constants.MAX_CHARACTERS];
			for (int i = 0; i < Constants.MAX_CHARACTERS; i++)
			{
				slots[i] = GetNode<Button>($"Panel/Slot{i}");
				slots[i].Connect("button_up", this, nameof(Slot_Release), new Godot.Collections.Array(i));
			}

			GetNode<Button>("Panel/Back").Connect("button_up", this, nameof(Back_Release));
		}

		void Back_Release()
		{
			Network.Socket.Device.FirstPeer?.Disconnect();
			GetTree().ChangeScene("res://Views/Scenes/Menu.tscn");
		}

		void Slot_Release(int Index)
		{
			for(int i = 0;i < slots.Length;i++)
				if (i != Index)
					slots[i].Pressed = false;

			slots[Index].Pressed = true;
		}

		public override void _Process(float delta)
		{
			for (int i = 0; i < Constants.MAX_CHARACTERS; i++)
			{
				var sprite = slots[i].GetNode<Sprite>("Sprite");
				var name   = slots[i].GetNode<Label>("Name");

				if (PlayerService.characterSelect[i] == null)
				{	
					sprite.Visible = false;
					name.Visible   = false;
				 }
				else
				{
					sprite.Visible = true;
					name.Visible   = true;
				}
			}
		}
	}
}
