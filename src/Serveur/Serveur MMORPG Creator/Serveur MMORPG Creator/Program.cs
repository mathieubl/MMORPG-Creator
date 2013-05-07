#region Protocoles
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
#endregion

namespace MmorpgEngine
{
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            GlobalEngine.Socket.thrsocketloop.Start();
            GameLogic.AiStart();
            Application.EnableVisualStyles();
            Application.Run(GlobalEngine.frmmain);

        }

    }

}