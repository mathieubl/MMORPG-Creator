using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using MmorpgCreatorMain;
using MmorpgEngine.Engines;
namespace MmorpgEngine
{
    public class socket
    {
        public static NetworkStream NS;//Flux
        public static StreamReader SR;//Flux de lecture sur le réseau
        public static StreamWriter SW;//Flux d'écriture sur le réseau
        public static Thread thrReceive = new Thread(new ThreadStart(HandleData));//Thread d'écoute
        public static Thread thrConnect = new Thread(new ThreadStart(InitConnect));//Thread d'écoute

        private static string IP = "192.168.101.153";
        private static int Port = 5000;

        #region Variables de packets
         public static char sep_char = (char)255;
        #endregion

        public static int Nombre_Tentatives = 3;//Nombre de tentatives maximum de connexion
        public static int Compteur_Tentatives = 0;//Compteur du nombre de tentative
        public static int Delai_Tentatives = 3;//Délai entre chaque tentative
        public static bool Connect = false;
        public static bool logged = false;
        public static bool badlogged = false;
        public static Boolean SendingMap = false;
        public static TcpClient TCP_Client;

        public static Boolean IsWaitMap = false;

        [MTAThread]
        public static void Init(string ip, int port)
        {
            
            if (TCP_Client != null)
            {
                Connect = false;
                thrReceive.Abort();
                thrConnect.Abort();
                thrReceive = new Thread(new ThreadStart(HandleData));//Thread d'écoute
                thrConnect = new Thread(new ThreadStart(InitConnect));//Thread d'écoute

                TCP_Client.Close();
            }
          
            IP = ip;
            Port = port;

            thrConnect.Start();// On lance le thread de connection
        }


        public static void InitConnect()
        {
            while (Connect == false)
            {
                try
                {
                    //Connexion établie, on ouvre donc le thread d'écoute
                    //et on lance la méthode d'envoi de message

                    TCP_Client = new TcpClient(IP, Port);//Lancement de la connexion

                    NS = TCP_Client.GetStream();//On récupère le flux

                    thrReceive.Start();
    
                    Connect = true;

                }
                catch (Exception e)
                {

                }
            }
        }

        [MTAThread]
        public static void HandleData()
        {
            MemoryStream stream = new MemoryStream();
            SR = new StreamReader(NS);//Ouverture du flux de lecture
            string ReceivedData = "";
            
            Player character_temp;
            int n = 0;
            while (true)
            {
                try
                {
                    ReceivedData = SR.ReadLine();

                    List<String> parse = ReceivedData.Split(sep_char).ToList<String>();

                    switch ((EnumClientPacket)Enum.Parse(typeof(EnumClientPacket), parse[0]))
                    {
                        case EnumClientPacket.Msg:
                            GlobalDataGame.ChatChannel.newmsg(parse[1], Color.White);
                            break;
                        case EnumClientPacket.Logged:
                            GlobalDataGame.MyId = System.Convert.ToInt32(parse[1]);
                            logged = true;
                            GlobalDataGame.online = true;
                            GlobalDataGame.connected = true;
                            break;

                        case EnumClientPacket.RefreshMap:
                            GlobalDataGame.maplocation = System.Convert.ToInt32(parse[1]);
                            Player curPlayer = GlobalDataGame.character[GlobalDataGame.Index];
                            GlobalDataGame.character.Clear();
                            GlobalDataGame.character = new List<Player>();
                            GlobalDataGame.npc_actif.Clear();
                            GlobalDataGame.MapRevision = System.Convert.ToInt32(parse[2]);
                            GlobalDataGame.NeedMap = true;
                            break;

                        case EnumClientPacket.PlayerJoinMap:
                            Stream stream1;
                            stream1 = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/entities/" + parse[6] + ".png");
                            GlobalDataGame.character.Add(new Player(System.Convert.ToInt32(parse[1]), parse[2], System.Convert.ToInt32(parse[4]), System.Convert.ToInt32(parse[5]), Texture2D.FromStream(GlobalDataGame.graphics.GraphicsDevice, stream1)));
                            GlobalDataGame.Index = GlobalDataGame.FindPlayer(GlobalDataGame.MyId);
                            break;

                        case EnumClientPacket.PlayerLeaveMap:
                                GlobalDataGame.character.RemoveAt(GlobalDataGame.FindPlayer(System.Convert.ToInt32(parse[1])));
                            break;

                        case EnumClientPacket.PlayerBaseData:
                            Stream stream2;
                            character_temp = (Player)GlobalDataGame.character[GlobalDataGame.FindPlayer(System.Convert.ToInt32(parse[1]))];
                            character_temp.Name = parse[2];
                            stream2 = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/entities/" + parse[3] + ".png");
                            character_temp.Sprites = Texture2D.FromStream(GlobalDataGame.graphics.GraphicsDevice, stream2);
                            break;

                        case EnumClientPacket .PlayerMove:
                            character_temp = (Player)GlobalDataGame.character[GlobalDataGame.FindPlayer(System.Convert.ToInt32(parse[1]))];
                            character_temp.Direction = System.Convert.ToByte(parse[2]);
                            character_temp.NextLocation.X = System.Convert.ToInt32(parse[3]);
                            character_temp.NextLocation.Y = System.Convert.ToInt32(parse[4]);
                            break;

                        case EnumClientPacket.NpcJoinMap:
                            Boolean CanAdd = true;

                            foreach (Npc Npc in GlobalDataGame.npc_actif)
                            {
                                if (Npc.ID == System.Convert.ToInt32(parse[1]))
                                {
                                    CanAdd = false;
                                }
                            }

                            if (CanAdd == true)
                            {
                                Stream stream3;
                                stream3 = File.OpenRead(GlobalDataGame.ProjectPath + "/graphics/entities/" + parse[6] + ".png");
                                GlobalDataGame.npc_actif.Add(new Npc(System.Convert.ToInt32(parse[1]), parse[2], System.Convert.ToInt32(parse[4]), System.Convert.ToInt32(parse[5]), Texture2D.FromStream(GlobalDataGame.graphics.GraphicsDevice, stream3)));
                            }
                            break;

                        case EnumClientPacket.AlertMsg:
                            string msg = parse[1];
                            string command = parse[2];

                            if (command == "1")
                            {
                                MessageBox.Show(msg);
                                GlobalDataGame.AlertStatus = true;
                            }
                            break;

                        case EnumClientPacket.NpcEditorList:

                               Dictionary<Int32, String> npcNameLst = new Dictionary<Int32, String>();

                               List<Npc> npcs = new List<Npc>();

                               while (n <= System.Convert.ToInt32(parse[1]))
                               {
                                   npcNameLst.Add(n, (String)parse[n + 1]);
                                   n++;
                               }

                               GlobalDataEditor.EngineEditorWinform.NpcEditorList.Load_Npcs(npcNameLst);  
                            break;

                        case EnumClientPacket.MapEditorList:
                               n = 1;
                               Dictionary<Int32, String> mapNameLst = new Dictionary<Int32, String>();

                               List<Map> maps = new List<Map>();

                               while (n <= System.Convert.ToInt32(parse[1]))
                               {
                                   mapNameLst.Add(n, (String)parse[n + 1]);
                                   n++;
                               }

                               GlobalDataEditor.EngineEditorWinform.MapEditorList.load_maps(mapNameLst);  
                            break;
                        case EnumClientPacket.MapSendMap:
                            stream = new MemoryStream();
                            Byte[] Data = Convert.FromBase64String(parse[1]);
                            stream.Write(Data, 0, Data.Length);
                            stream.Position = 0;
                            GlobalDataGame.CurrentMap = new Map(GlobalDataGame.maplocation);
                            GlobalDataGame.CurrentMap.DeserializeMap(stream);
                            GlobalDataGame.NeedMap = false;
                            GlobalDataGame.NeedEffect = true;
                            GlobalDataGame.screen = GlobalEnum.XNAScreensType.Play;
                            IsWaitMap = false;
                        break;
                    }

                }
                catch (Exception e)
                {
                    GlobalDataGame.connected = false;
                }
            }


        }
        #region Send Packet
        public static void Send(EnumServerPacket idpacket, string Packet)
        {
            if (GlobalDataGame.online == true)
            {
                SW = new StreamWriter(NS);//Ouverture du flux d'écriture
                string Donnee_envoye = "\0";//Donnee a envoyé
                //Tant que le message n'est pas exit, on ne sort pas de la boucle
                Donnee_envoye = idpacket.ToString() + sep_char + Packet;

                SW.WriteLine(Donnee_envoye);//On transmet la donnee au serveur
                SW.Flush();//on vide le flux d'écriture, IMPORTANT
            }
        }

        #endregion
        public static void SendLogin(string name, string pass)
        {
            socket.Send(EnumServerPacket.Login, name + sep_char + pass);
        }

        public static void SendMove(byte dir, int x, int y)
        {
            socket.Send(EnumServerPacket.MovePlayer, dir.ToString() + sep_char + x.ToString() + sep_char + y.ToString());
        }

        public static void SendJoinGame()
        {
            socket.Send(EnumServerPacket.JoinGame, String.Empty);
        }

        public static void SendMsg(string msg)
        {
            socket.Send(EnumServerPacket.Msg, msg);
        }

        public static void SendRequestNpcEditorList()
        {
            socket.Send(EnumServerPacket.RequestNpcEditorList, String.Empty);
        }

        public static void SendRequestMapEditorList()
        {
            socket.Send(EnumServerPacket.RequestMapEditorList, String.Empty);
        }

        public static void SendRequestSendMap(Int32 mapNumber)
        {
            socket.Send(EnumServerPacket.RequestSendMap, mapNumber.ToString());
        }

        public static void SendRequestSendMap()
        {
            socket.Send(EnumServerPacket.RequestSendMap, String.Empty);
        }

        public static void SendRequestToWarp(Int32 mapNumber)
        {
            GlobalDataGame.screen = GlobalEnum.XNAScreensType.Loading;
            socket.Send(EnumServerPacket.RequestWarp, mapNumber.ToString());
        }

        public static void SendMap()
        {
            Map MapTemp = (Map)GlobalDataGame.CurrentMap;

            MemoryStream packet = (MemoryStream)MapTemp.SerializeMapMemory();
            packet.Position = 0;
            StreamReader sr = new StreamReader(packet);

            String map = Convert.ToBase64String(packet.GetBuffer());

            Send(EnumServerPacket.SendSendMap, map);
        }

    }

}
