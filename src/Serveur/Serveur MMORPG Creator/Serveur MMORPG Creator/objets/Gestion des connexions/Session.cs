#region Protocoles
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Text;
using MmorpgCreatorMain;
#endregion

namespace MmorpgEngine
{
    public class Session
    {
        public NetworkStream NS;
        public StreamReader SR;
        public StreamWriter SW;
        private Account _PlayerData = new Account();
        Boolean ingame = false;
        private Thread ClientThread;
        public int Index;
        public bool Connected;


        public const char sep_char = (char)255;
        public TcpClient NetSystem;


        public Session(int New_Numero, NetworkStream New_NS)
        {
            Index = New_Numero;
            Connected = true;
            NS = New_NS;

            SR = new StreamReader(NS);
            SW = new StreamWriter(NS);
        }

        public void Receivedatabase()
        {
            while (Connected)
            {
                try
                {
                    String[] parse = (SR.ReadLine()).Split(sep_char);

                    //Connexion
                    if (ingame == false)
                    {
                        switch ((EnumServerPacket)Enum.Parse(typeof(EnumServerPacket), parse[0]))
                        {
                            case EnumServerPacket.Login:
                                if (File.Exists("database/accounts/" + parse[1] + ".xml"))
                                {
                                    PlayerData.Character = new Player(parse[1]);
                                    if (PlayerData.Character.PasswordVerification(parse[2]) == true)
                                    {
                                        ingame = true;
                                        ((IPlayerServer)PlayerData.Character).LoadPlayer();
                                        GlobalEngine.AddMsg("Tentative de connexion réeussie", "000", TexteStyle.STYLE_REGULAR);
                                        Send(EnumClientPacket.Logged, PlayerData.Character.ID.ToString());
                                    
                                    }
                                    else
                                    {
                                        GlobalEngine.AddMsg("Tentative de connexion échouée - Mauvais mots de passe", "000", TexteStyle.STYLE_BOLD);
                                        Send_AlertMsg("Mauvais mots de passe", 1);
                                    }
                                }
                                else
                                {
                                    GlobalEngine.AddMsg("Tentative de connexion échouée - Compte inexistant", "000", TexteStyle.STYLE_BOLD);
                                    Send_AlertMsg("Compte inexistant", 1);
                                }

                                break;
                        }
                    }
                    else
                    {
                        //En jeu, peut envoyer et recevoir les packets désiré.
                        switch ((EnumServerPacket)Enum.Parse(typeof(EnumServerPacket), parse[0]))
                        {
                            case EnumServerPacket.JoinGame: Process_JoinGame();               
                                break;
                            case EnumServerPacket.RequestWarp: Process_RequestWarp(Int32.Parse(parse[1]));
                                break;
                            case EnumServerPacket.Msg: Process_Msg(parse[1]);
                                break;
                            case EnumServerPacket.MovePlayer: Process_MovePlayer(System.Convert.ToByte(parse[1]), System.Convert.ToInt32(parse[2]), System.Convert.ToInt32(parse[3]));
                                break;
                            case EnumServerPacket.RequestNpcEditorList: Process_RequestNpcEditorList();
                                break;
                            case EnumServerPacket.RequestMapEditorList: Process_RequestMapEditorList();
                                break;
                            case EnumServerPacket.RequestSendMap: Process_RequestSendMap();
                                break;
                            case EnumServerPacket.SendSendMap:
                                Byte[] Data = Convert.FromBase64String(parse[1]);
                                MemoryStream Stream = new MemoryStream();
                                Stream.Write(Data,0, Data.Length);
                                Stream.Position = 0;
                                Map curMap = new Map(PlayerData.Character.Map);
                                curMap.DeserializeMap(Stream);
                                GlobalEngine.Maps[PlayerData.Character.Map] = curMap;
                                GlobalEngine.SaveMap(PlayerData.Character.Map);
                                break;
                            default:
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    EndSession();
                }
            }
        }

        public void EndSession()
        {
            Connected = false;
            if (ingame == true)
            Send_LeaveMap();
            //Fermeture des Threads
            SR.Close();
            SW.Close();
            NS.Close();
            ClientThread.Abort();
            //Supression de la session
            GlobalEngine.Socket.DisconnectPlayer(Index);
        }
        private void Process_JoinGame()
        {
            Send_WarpPlayer(PlayerData.Character.Map, 10, 10);
            Send_BaseData();
            Send_Msg(GlobalEngine.motd);
        }

        private void Process_RequestWarp(Int32 mapID)
        {
            Send_LeaveMap();
            PlayerData.Character.Map = mapID;
            Send_WarpPlayer(PlayerData.Character.Map, 10, 10);
        }

        private void Process_Msg(String Msg)
        {
            Send_Msg(PlayerData.Character.Name + " a écrit: " + Msg);
          //  GlobalData.maps[data.Map].spawn_npc(1, 10, 10);
        }
        public void Send_AlertMsg(string msg, byte command)
        {
            Send(EnumClientPacket.AlertMsg, msg + sep_char + command);
        }
        public void Send_BaseData()
        {
            Send(EnumClientPacket.PlayerBaseData, PlayerData.Character.ID.ToString() + sep_char + PlayerData.Character.Name + sep_char + PlayerData.Character.Sprite.ToString());
        }

        public void Send_Msg(string msg)
        {
            GlobalEngine.Socket.SendDataToMap(PlayerData.Character.Map, EnumClientPacket.Msg, msg);
        }

        public void Send_GlobalMsg(string msg)
        {
            GlobalEngine.Socket.SendDataToAll(EnumClientPacket.Msg, msg);

        }
        public void Process_MovePlayer(byte dir, int x, int y)
        {
            PlayerData.Character.Location.X = x;
            PlayerData.Character.Location.Y = y;
            PlayerData.Character.Direction = dir;
            GlobalEngine.Socket.SendDataToMap(PlayerData.Character.Map, EnumClientPacket.PlayerMove, PlayerData.Character.ID.ToString() + sep_char + PlayerData.Character.Direction.ToString() + sep_char + PlayerData.Character.Location.X.ToString() + sep_char + PlayerData.Character.Location.Y.ToString());
        }

        public void Send_WarpPlayer(int map, int x, int y)
        {
            Map Maps = (Map)GlobalEngine.Maps[map];
            //Changement de coordonnées
            PlayerData.Character.Map = map;
            PlayerData.Character.Location.X = x;
            PlayerData.Character.Location.Y = y;

            //Envoi à tous: les coordonnée du joueurs
            GlobalEngine.Socket.SendDataToMap(map, EnumClientPacket.PlayerJoinMap,
            PlayerData.Character.ID.ToString() + sep_char +
             PlayerData.Character.Name + sep_char +
            PlayerData.Character.Direction.ToString() + sep_char +
            x.ToString() + sep_char +
            y.ToString() + sep_char +
            PlayerData.Character.Sprite.ToString()
            );

            //Ordonne l'actualisation de la map
            Send(EnumClientPacket.RefreshMap, map.ToString() + sep_char + Maps.Revision);

            Session[] Session = GlobalEngine.Socket.GetPlayersByMap(PlayerData.Character.Map);

            //Charge les joueurs de la map
            foreach (Session Cli in Session)
            {
                Send(EnumClientPacket.PlayerJoinMap,
                   Cli.PlayerData.Character.ID.ToString() + sep_char +
                    Cli.PlayerData.Character.Name + sep_char +
                   Cli.PlayerData.Character.Direction.ToString() + sep_char +
                   Cli.PlayerData.Character.Location.X.ToString() + sep_char +
                   Cli.PlayerData.Character.Location.Y.ToString() + sep_char +
                   Cli.PlayerData.Character.Sprite.ToString()
                   );
            }

           foreach (Npc Npc in Maps.Npc_actif)
            {
                Send(EnumClientPacket.NpcJoinMap,
               Npc.ID.ToString() + sep_char +
                Npc.Name + sep_char +
               Npc.Direction.ToString() + sep_char +
               Npc.Location.X.ToString() + sep_char +
               Npc.Location.Y.ToString() + sep_char +
               Npc.Sprite.ToString()
               );
            }
            
        }

        public void Send_NpcJoinMap(int num)
        {
            Map Maps = (Map)GlobalEngine.Maps[PlayerData.Character.Map];
               Npc Npc = (Npc)Maps.Npc_actif[num];

               Send(EnumClientPacket.NpcJoinMap,
               Npc.ID.ToString() + sep_char +
                Npc.Name + sep_char +
               Npc.Direction.ToString() + sep_char +
               Npc.Location.X.ToString() + sep_char +
               Npc.Location.Y.ToString() + sep_char +
               Npc.Sprite.ToString()
               );
        }
      

        public void Send_LeaveMap()
        {
            GlobalEngine.Socket.SendDataToMap(PlayerData.Character.Map, EnumClientPacket.PlayerLeaveMap, PlayerData.Character.ID.ToString());
        }

        public void Process_RequestNpcEditorList()
        {
            string packet;
            packet = GlobalEngine.Maps.Count.ToString();

            foreach (Npc curNpc in GlobalEngine.Npcs)
                packet += sep_char + curNpc.Name;

            Send(EnumClientPacket.NpcEditorList, packet);
        }

        public void Process_RequestMapEditorList()
        {
            string packet;
            packet = GlobalEngine.Maps.Count.ToString();

            foreach (Map curMap in GlobalEngine.Maps)
                packet += sep_char + curMap.Name;

            Send(EnumClientPacket.MapEditorList, packet);
        }

        public void Send_ConditionName_All()
        {

        }

        public void Send(EnumClientPacket idpacket, String packet)
        {
            if (Connected)
            {
                SW.WriteLine(idpacket.ToString() + sep_char + packet);
                SW.Flush();
            }
        }

        public void Process_RequestSendMap()
        {
            Map MapTemp = (Map)GlobalEngine.Maps[PlayerData.Character.Map];

            MemoryStream packet = (MemoryStream)MapTemp.SerializeMapMemory();
 
            StreamReader sr = new StreamReader(packet);

            String map = Convert.ToBase64String(packet.GetBuffer());

            Send(EnumClientPacket.MapSendMap, map);
        }



    #region Propriétés
        public Account PlayerData
        {
            get
            {
                return _PlayerData;
            }

            set
            {
                _PlayerData = value;
            }
        }

    #endregion
        
    }
}
