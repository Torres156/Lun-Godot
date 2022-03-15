global using static Lun.Scripts.Services.GlobalService;

using Godot;

namespace Lun.Scripts
{
    public class Startup : Node
    {
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            InitializeSettings();               

            Network.Socket.Initialize();

            this.GetTree().Root.Connect("size_changed", this, nameof(Window_SizeChanged));
        }

        void Window_SizeChanged()
        {
            if (OS.WindowMaximized)
            {
                Settings.WindowMaximize = true;                 
            }
            else
            {
                Settings.WindowSize     = OS.WindowSize;
                Settings.WindowMaximize = false;
            }
            SaveSettings();
        }

        public override void _Process(float delta)
        {
            Network.Socket.Poll();
            base._Process(delta);
        }

        public override void _Notification(int what)
        {
            if (what == NotificationWmQuitRequest)
            {
                Network.Socket.Close();
            }
        }

    }
}