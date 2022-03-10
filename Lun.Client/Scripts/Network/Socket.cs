using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Client.Scripts.Network
{
    internal class Socket
    {
        static EventBasedNetListener listener;

        public static NetManager Device { get; private set; }

        public static void Initialize()
        {
            listener = new EventBasedNetListener();

            Device = new NetManager(listener);
            Device.IPv6Enabled = IPv6Mode.Disabled;
            Device.Start();
        }

        public static void Connect()
        {
            Device.Connect("localhost", 4000, "");
        }

        public static void Poll()
            => Device.PollEvents();

        public static void Close()
            => Device.Stop();
    }
}
