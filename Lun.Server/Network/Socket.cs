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
            listener.NetworkReceiveEvent += Listener_NetworkReceiveEvent;
            listener.ConnectionRequestEvent += Listener_ConnectionRequestEvent;
        }

        private static void Listener_ConnectionRequestEvent(ConnectionRequest request)
        {
            if (Device.ConnectedPeersCount < Constants.MAX_PLAYERS)
                request.Accept();
            else
                request.Reject();
        }

        private static void Listener_NetworkReceiveEvent(NetPeer peer, NetPacketReader reader, DeliveryMethod deliveryMethod)
        {
            Receive.Handle(peer, reader);
        }

        private static void Listener_PeerDisconnectedEvent(NetPeer peer, DisconnectInfo disconnectInfo)
        {
            var findAccount = PlayerService.FindAccount(peer);
            if (findAccount != null)
            {
                PlayerService.SaveAccount(findAccount);
                PlayerService.Accounts.Remove(findAccount);
            }
            
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
