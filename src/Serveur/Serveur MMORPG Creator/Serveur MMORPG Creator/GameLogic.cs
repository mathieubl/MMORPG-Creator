using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace MmorpgEngine
{
    class GameLogic
    {
        public static Thread thrAi;
        public static void AiStart()
        {
            thrAi = new Thread(new ThreadStart(AiLoop));
            thrAi.Name = "McServer_AI";
            thrAi.Start();
        }

        private static void AiLoop()
        {

        }
    }
}
