global using static Lun.Server.Services.GlobalService;
global using Lun.Server.Services;
global using Lun.Shared;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lun.Server
{
    internal class Program
    {
        public static bool Running = false;


        [STAThread]
        public static void Main()
        {
            Console.Title = "Lun Server";

            WriteLine("Initialize server!");
            WriteLine("");

            WriteLine(":: Database ::");
            ClassService.Initialize();

            WriteLine("");
            WriteLine("Initialize connection!");
            Network.Socket.Initialize();
            WriteLine("");

            Running = true;
            var threadConsole = new Thread(ConsoleService.Core);
            threadConsole.Priority = ThreadPriority.Lowest;
            threadConsole.Start();

            ServerService.Core();

            Network.Socket.Close();
        }
    }
}
