using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Scripts.Network
{
	internal class Socket
	{
		static EventBasedNetListener listener;

		public static NetManager Device { get; private set; }

		static bool Debug_Closing = false;

		public static void Initialize()
		{
			listener = new EventBasedNetListener();

			Device = new NetManager(listener);
			Device.IPv6Enabled = IPv6Mode.Disabled;
			Device.Start();

			listener.NetworkReceiveEvent += Listener_NetworkReceiveEvent;
		}

		private static void Listener_NetworkReceiveEvent(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
		{
			Receive.Handle(reader);
		}

		public static void Connect()
		{				
			if (Debug_Closing)
				return;

			Device.Connect("localhost", Constants.PORT, "");
		}

		public static void Poll()
			=> Device.PollEvents();

		public static void Close()
		{
			if (IsConnected)
			{
				Device.FirstPeer.Disconnect();
				Debug_Closing = true;
			}
		}

		public static bool IsConnected
			=> Device != null && Device.FirstPeer != null && Device.FirstPeer.ConnectionState == ConnectionState.Connected;
	}
}
