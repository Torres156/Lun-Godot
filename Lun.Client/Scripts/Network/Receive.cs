using Godot;
using LiteNetLib.Utils;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Network
{
    internal static class Receive
    {
        public static void Handle(NetDataReader buffer)
        {
            var packet = (PacketServer)buffer.GetShort();

			switch(packet)
			{
				case PacketServer.Alert: Alert(buffer); break;
				case PacketServer.Logged: Logged(buffer); break;
			}
        }

		static void Logged(NetDataReader buffer)
		{
			GetTree.ChangeScene("res://Views/Scenes/Logged.tscn");
			GD.Print("Logged");
		}

		static void Alert(NetDataReader buffer)
		{
			var text = buffer.GetString();
			Lun.Scripts.Alert.Show(text);
		}
    }
}
