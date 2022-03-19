using Godot;
using LiteNetLib.Utils;
using Lun.Scripts.Models.Player;
using Lun.Scripts.Services;
using Lun.Shared.Models;
using Lun.Shared.Models.Player;
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
				case PacketServer.Alert      : Alert(buffer); break;
				case PacketServer.Logged     : Logged(buffer); break;
				case PacketServer.ClassUpdate: ClassUpdate(buffer); break;
			}
		}

		static void ClassUpdate(NetDataReader buffer)
		{
			var classCount = buffer.GetInt();
			ClassService.Classes = new ClassModel[classCount];

			if (classCount > 0)
			{
				for(int i = 0; i < classCount; i++)
				{
					var classObj = new ClassModel();
					classObj.Name         = buffer.GetString();
					classObj.MaleSprite   = buffer.GetIntArray();
					classObj.FemaleSprite = buffer.GetIntArray();

					ClassService.Classes[i] = classObj;
				}
			}
		}

		static void Logged(NetDataReader buffer)
		{
			for(int i = 0; i < Constants.MAX_CHARACTERS; i++)
			{
				var name = buffer.GetString();
				if (name.Length > 0)
				{
					PlayerService.characterSelect[i] = new CharacterSelectModel {
						Name = name,
						SpriteID = buffer.GetInt()
					};
				}
				else
					PlayerService.characterSelect[i] = null;
			}

			GetTree.ChangeScene("res://Views/Scenes/Logged.tscn");			
		}

		static void Alert(NetDataReader buffer)
		{
			var text = buffer.GetString();
			Lun.Scripts.Alert.Show(text);
		}
	}
}
