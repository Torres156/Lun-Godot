using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Network
{
    internal static class Socket
    {
        static EventBasedNetListener listener;

        public static NetManager Device { get; private set; }

        public static void Initialize()
        {
            listener = new EventBasedNetListener();

            Device = new NetManager(listener);
            Device.Start(4000);

            listener.PeerConnectedEvent += Listener_PeerConnectedEvent;
            listener.PeerDisconnectedEvent += Listener_PeerDisconnectedEvent;
        }

        private static void Listener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            Console.WriteLine($"Connection entry <{peer.EndPoint.ToString()}> has been disconnected!");
        }

        private static void Listener_PeerConnectedEvent(NetPeer peer)
        {               
            Console.WriteLine($"New connection entry <{peer.EndPoint.ToString()}>!");
        }

        public static void Poll()
            => Device.PollEvents();

        public static void Close()
            => Device.Stop();
    }
}
