using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Services
{
    internal class ConsoleService
    {
        public static void Core()
        {
            string cmd = "";

            while(Program.Running && (cmd = Console.ReadLine()) != "exit")
            {

            }
        }
    }
}
