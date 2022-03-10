using Godot;
using System;

namespace Lun.Scripts
{
    public class Startup : Node
    {
        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            OS.SetWindowTitle("Lun-Godot Engine");

            Network.Socket.Initialize();
        }

        public override void _Process(float delta)
        {
            Network.Socket.Poll();
            base._Process(delta);
        }
    }
}