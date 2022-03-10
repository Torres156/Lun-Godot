using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Services
{
    internal static class GlobalService
    {
        public static int TickCount
            => Environment.TickCount < 0 ? Environment.TickCount & int.MaxValue : Environment.TickCount ;

        public static Action<string> WriteLine = Console.WriteLine;
    }
}
