using Godot;
using Lun.Scripts.Services;
using System;

namespace Lun.Scripts.Models.Scenes
{		
	public class MenuScene : Control
	{
		Panel Login, Register;
		Label Status;

		long timerReconnect;

		public override void _Ready()
		{
			GetNode<Label>("Footer/Text").Text = $"{Settings.WindowTitle} - Version {LunVersion}";
			Status = GetNode<Label>("Status");
						
			Login = GetNode<Panel>("Login");
			Login.GetNode("Exit").Connect("button_up", this, nameof(Login_Exit));
			Login.GetNode("Register").Connect("button_up", this, nameof(Login_Register));
			Login.GetNode("Enter").Connect("button_up", this, nameof(Login_SignIn));

			Register = GetNode<Panel>("Register");
			Register.GetNode("Exit").Connect("button_up", this, nameof(Register_Exit));
			Register.GetNode("Create").Connect("button_up", this, nameof(Register_Create));
		}

		public override void _Process(float delta)
		{
			if (!Network.Socket.IsConnected && TickCount > timerReconnect)
			{
				Network.Socket.Connect();
				timerReconnect = TickCount + 1000;
			}

			var text = "Offline";
			var color = new Color("#fb6969");
			if (Network.Socket.IsConnected)	 			
				(text, color) = ("Online", new Color("#58F063"));
						
			if (Status.Text != text)
			{
				Status.Text = text;
				Status.AddColorOverride("font_color", color);
			}
		}

		void Register_Create()
		{
			var user = Register.GetNode<LineEdit> ("Username").Text.Trim();
			var pwd = Register.GetNode<LineEdit> ("Password").Text.Trim();
			var pwd2 = Register.GetNode<LineEdit> ("Password2").Text.Trim();

			if (user.Length < 3)
			{
				Alert.Show("Mínimo 3 caracteres para nome de usuário.");
				return;
			}

			if (pwd.Length < 3)
			{
				Alert.Show("Mínimo 3 caracteres para senha.");
				return;
			}

			if (pwd != pwd2)
			{
				Alert.Show("As senhas não se conferem.");
				return;
			}

			Network.Sender.Register(user, pwd);
		}

		void Register_Exit()
		{
			Register.Hide();
			Login.Show();
		}

		void Login_SignIn()
		{
			var user = Login.GetNode<LineEdit> ("Username").Text.Trim();
			var pwd = Login.GetNode<LineEdit> ("Password").Text.Trim();

			if (user.Length < 3 || pwd.Length < 3)
			{
				Alert.Show("Nome de usuário ou senha inválida!");
				return;
			}

			Network.Sender.Login(user, pwd);
		}

		void Login_Register()
		{
			Login.Hide();
			Register.Show();
		}

		void Login_Exit()
		{
			GetTree().Quit();
		}

	}
}
