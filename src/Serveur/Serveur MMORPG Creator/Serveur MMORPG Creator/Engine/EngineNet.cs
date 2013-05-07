using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using MmorpgCreatorMain;
namespace MmorpgEngine
{
    public class EngineNet: IDisposable
    {
        private List<Session> _Sessions = new List<Session>();
        public Thread thrsocketloop;
        List<TcpClient> TCP_Client = new List<TcpClient>();

        Int32 Index = 0;

        public EngineNet()
        {
            thrsocketloop = new Thread(new ThreadStart(ServerLoop));
            thrsocketloop.Name = "MCServer_ListenTCP";
        }

        private void ServerLoop()
        {
            TcpListener TCP_Serveur;
            
            try
            {
                while (GlobalEngine.IsLoaded == false)
                {

                }

                GlobalEngine.LoadDatabase();

                GlobalEngine.ServeOpen = true;
                TCP_Serveur = new TcpListener(5000);
                TCP_Serveur.Start();

                GlobalEngine.AddMsg("Serveur Ouvert", "000", TexteStyle.STYLE_BOLD);

                GlobalEngine.AddMsg("Port: " + 5000 + "\n******************************", "000", TexteStyle.STYLE_ITALIC);

                while (GlobalEngine.ServeOpen == true)
                {
                  
                    TCP_Client.Add(TCP_Serveur.AcceptTcpClient());

                    Session receive = new Session(Index, TCP_Client[TCP_Client.Count - 1].GetStream());
                    _Sessions.Add(receive);

                    Thread ClientThread = new Thread(new ThreadStart(receive.Receivedatabase));
                    ClientThread.Start();

                    GlobalEngine.AddMsg("Connexion de l'ip " + TCP_Client[TCP_Client.Count - 1].Client.RemoteEndPoint, "000", TexteStyle.STYLE_UNDERLINE);
                       
                    Index++;
                }
            }
            catch (Exception e)
            {
                GlobalEngine.AddMsg(e.Message);
            }
        }

        public void Packet_AddMapNpc(int idMap, int idnpc)
        {
            foreach (Session Cli in Sessions)
            {
                if (Cli.PlayerData.Character.Map == idMap)
                {
                    Cli.Send_NpcJoinMap(idnpc);
                }
            }
        }

        public void SendDataToAll(EnumClientPacket idpacket, string Packet)
        {
            foreach (Session Cli in _Sessions)
            {
                Cli.Send(idpacket, Packet);
            }
        }

        public void SendDataToMap(Int32 map, EnumClientPacket idpacket, String Packet)
        {
            foreach (Session Cli in _Sessions)
            {
                if (Cli.Connected == true && Cli.PlayerData != null)
                {
                    if (Cli.PlayerData.Character.Map == map)
                    {
                        Cli.Send(idpacket, Packet);
                    }
                }
            }
        }

        public void SendDataToPlayer(Int32 id, EnumClientPacket idpacket, String Packet)
        {
            foreach (Session Cli in _Sessions)
            {
                if (Cli.PlayerData.Character.ID == id)
                {
                    Cli.Send(idpacket, Packet);
                }
            }
        }

        public int FindPlayerByIndex(Int32 Index)
        {
            int val = new int();
            for (Int32 i = 0; i < Sessions.Count; i++)
            {
                if (Sessions[i].Index == Index)
                {
                    val = i;
                    break;
                }
            }
            return val;
        }

        public void DisconnectPlayer(Int32 index)
        {
            Sessions.RemoveAt(FindPlayerByIndex(index));
        }

        public List<Session> Sessions
        {
            get
            {
                return _Sessions;
            }

            set
            {
                _Sessions = value;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Session[] GetPlayersByMap(Int32 map)
        {
            List<Session> curSessionArray = new List<Session>();

            foreach (Session curSession in Sessions)
            {
                if (curSession.PlayerData != null)
                    if (curSession.PlayerData.Character.Map == map)
                        curSessionArray.Add(curSession);
            }

            return curSessionArray.ToArray();
        }
    }



}
