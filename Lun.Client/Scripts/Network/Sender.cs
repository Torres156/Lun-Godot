using LiteNetLib;
using LiteNetLib.Utils;
using Lun.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Network
{
	internal static class Sender
	{
		public static void Login(string user, string password)
		{
			var buffer = Create(PacketClient.Login);
			buffer.Put(user);
			buffer.Put(password);
			SendTo(buffer);
		}

		public static void Register(string user, string password)
		{
			var buffer = Create(PacketClient.Register);
			buffer.Put(user);
			buffer.Put(password);
			SendTo(buffer);
		}

		static void SendTo(NetDataWriter buffer, DeliveryMethod delivery = DeliveryMethod.ReliableOrdered)
		{
			if (!Socket.IsConnected)
				return;

			Socket.Device.FirstPeer.Send(buffer, delivery);
		}

		static NetDataWriter Create(PacketClient packet)
		{
			var buffer = new NetDataWriter();
			buffer.Put((short)packet);
			return buffer;
		}
	}
}
