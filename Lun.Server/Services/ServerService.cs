using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lun.Server.Services
{
    internal class ServerService
    {
        public static void Core()
        {
            int   timerCurrent = TickCount;
            int   timerOld     = 0 ;
            float delta        = 0f;
            float accumulative = 0f;

            const float ratePhysic = 1 / 60f;


            while(Program.Running)
            {
                timerOld     = timerCurrent;
                timerCurrent = TickCount;
                delta        = (timerCurrent - timerOld) / 1000f;

                Network.Socket.Poll();

                accumulative += delta;
                while(accumulative >= ratePhysic)
                {
                    accumulative -= ratePhysic;
                }
            }
        }
    }
}
