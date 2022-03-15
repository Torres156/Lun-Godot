using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Models.Components
{
	[Tool]
	internal class WindowComponent : Panel
	{
		[Export]
		public bool ButtonExit
		{
			get => _buttonExit;
			set
			{
				_buttonExit = value;
				GetNode<Button>("Header/Exit").Visible = value;
			}
		}
		bool _buttonExit = true;

		[Export]
		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				GetNode<Label>("Header/Title").Text = _title;
			}
		}
		string _title = "Title";

		[Export(PropertyHint.None)]
		public bool Drag
		{
			get => _drag;
			set
			{
				_drag = value;
			}
		}
		bool _drag = true;

		Panel header;

		Vector2 dragPosition;
		bool dragPress = false;

		public override string _GetConfigurationWarning()
		{
			if (this.GetParent() == null || !(this.GetParent() is WindowManager))
				return "Require a WindowManager owner!";
			return "";
		}

		public override void _Ready()
		{
			header = GetNode<Panel>("Header");
			header.Connect("gui_input", this, nameof(Header_Input));
			header.GetNode("Exit").Connect("button_down", this, nameof(ButtonExit_Pressed));

			this.Connect("gui_input", this, nameof(GuiInput));
		}

		void GuiInput(InputEvent e)
		{
			if (e is InputEventMouseButton input)
			{
				if (input.Pressed)
				{
					if (this.GetParent() != null && (this.GetParent() is WindowManager))
						this.GetParent<WindowManager>()?.SetWindowFocus(this);
				}
			}
		}

		void ButtonExit_Pressed()
		{
			this.Hide();
		}

		void Header_Input(InputEvent e)
		{
			if (!Drag)
				return;

			if (e is InputEventMouseButton input)
			{
				var mousepos = input.GlobalPosition;
				if (input.IsPressed())
				{
					if (this.GetParent() != null && (this.GetParent() is WindowManager))
						this.GetParent<WindowManager>()?.SetWindowFocus(this);

					if (input.ButtonIndex == (int)ButtonList.Left && !dragPress)
					{
						dragPress    = true;
						dragPosition = mousepos - this.RectGlobalPosition;
					}
				}
			}
			else if (e is InputEventMouseMotion mouse)
			{
				if (dragPress)
				{
					if (mouse.ButtonMask == (int)ButtonList.Left)
					{
						var                     mousepos = mouse.GlobalPosition;
						this.RectGlobalPosition          = mousepos - dragPosition;
					}
					else
					{
						dragPress = false;
					}
				}
			}

		}
	}
}
