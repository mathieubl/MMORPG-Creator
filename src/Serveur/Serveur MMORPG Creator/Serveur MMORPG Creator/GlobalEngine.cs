#region Protocoles
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using System.Globalization;
using MmorpgCreatorMain;
using MmorpgEngine.Engine;
#endregion

namespace MmorpgEngine
{

    [Serializable]
    public  class GlobalEngine
    {
        
        //Paramètres
        public static string name = "MmorpgCreator" ;
        public static string motd = "Bienvenue sur MmorpgCreator";
        private static string _SecurityKey = "almlm";
        public static int port = 5000;

        //Engine
        public static EngineMap _MapEngine = new EngineMap();
        public static EngineNpc _NpcEngine = new EngineNpc();
        public static EngineItem _ItemEngine = new EngineItem();
        public static EngineCondition _ConditionEngine = new EngineCondition();
        public static EngineNet Socket = new EngineNet();
     
        //Limit


        //Forms
        public static FrmServer frmmain = new FrmServer();
        public static frmparam frmparam = new frmparam();

        //Variables
        public static bool _Isloaded = false;

        private static bool _ServeOpen = false;
        private static bool _NeedReset = false;


        
        public static void LoadDatabase()
        {
            GlobalEngine.AddMsg("Chargement de la base de donnée", "000000", TexteStyle.STYLE_BOLD);

            //Ordre importante
            LoadConfig();
            LoadNpcs();
            LoadMaps();
        }

        #region Gestion des fichiers de cartes


        public static void SaveMaps()
        {
            foreach (Map curMap in Maps)
                ((IMapServer)curMap).SaveMap();
        }

        public static void LoadMaps()
        {
            int i = 0;
            GlobalEngine.AddMsg("Chargement des cartes...", "000000", TexteStyle.STYLE_BOLD);

            //Chargement des cartes
            while (File.Exists("database/maps/" + i + ".dat"))
            {
                Map carte = new Map(i);
                 ((IMapServer)carte).LoadMap();
                //TODO
                // ((IMapClient)carte).respawn_npc();
                 Maps.Add(carte);
                i++;

                GlobalEngine.AddMsg(carte.Name, "008000", TexteStyle.STYLE_REGULAR);
            }

            GlobalEngine.AddMsg("Ok", "008000", TexteStyle.STYLE_REGULAR);
        }

        public static void SaveMap(int i)
        {
            ((IMapServer)Maps[i]).SaveMap();
        }
        #endregion
        #region Gestion des fichiers d'npcs
        public static void LoadNpcs()
        {
            int i = 1;
            GlobalEngine.AddMsg("Chargement des pnj's...", "000000", TexteStyle.STYLE_BOLD);
            //Chargement des cartes
            while (File.Exists("database/npcs/" + i + ".dat"))
            {
                try
                {
                    Npc Npc = new Npc(i);
                    ((INpcServer)Npc).LoadNpc();
                    Npcs.Add(Npc);
                    i++;
                }
                catch
                {
                    Npc Npc = new Npc(i);
                    Npcs.Add(Npc);

                    ((INpcServer)Npc).SaveNpc();    
                }
             
            }

            Npcs.Add(new Npc(1, "ds", 50, 50, "angel"));
            SaveNpcs();

            GlobalEngine.AddMsg("Ok", "008000", TexteStyle.STYLE_REGULAR);
        }

        public static void SaveNpc(Int32 id)
        {

            ((INpcServer)Npcs[id]).SaveNpc();
        }

        public static void SaveNpcs()
        {

            foreach (Npc curNpc in Npcs)
                 ((INpcServer)curNpc).SaveNpc();

        }

        #endregion
        #region Gestion des fichiers de configuration
        public static void SaveConfig()
        {

            Stream stream;
            stream = new FileStream("config.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
           
            IFormatter formatter = new BinaryFormatter();
        
            formatter.Serialize(stream, name);
            formatter.Serialize(stream, motd);
            formatter.Serialize(stream, port);
            formatter.Serialize(stream, Securitykey);

            stream.Close();
        }

        public static void LoadConfig()
        {

            GlobalEngine.AddMsg("Fichier de configuration...", "000000", TexteStyle.STYLE_ITALIC);

            Stream stream;
            stream = new FileStream("config.dat", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();

            name = (String)bFormatter.Deserialize(stream);
            motd = (String)bFormatter.Deserialize(stream);
            port = (Int32)bFormatter.Deserialize(stream);
            Securitykey = (String)bFormatter.Deserialize(stream);
            GlobalEngine.AddMsg("Ok", "008000", TexteStyle.STYLE_REGULAR);
            stream.Close();
          
          }
        #endregion
        #region entrée de messages

        public static void UpdateLine(Int32 line, String text)
        {
            
        }

        public static void AddMsg(string texte, string color, string style)
        {
            Color txtcolor = MmorpgEngine.Utils.ConvertColorToHexadecimal(color);
            FontStyle txtstyle = TexteStyle.StyleTexte(style);

            frmmain.AddMsg(texte, txtcolor, txtstyle);
        }

        public static void AddMsg(String texte)
        {
            Color txtcolor = MmorpgEngine.Utils.ConvertColorToHexadecimal("000");
            FontStyle txtstyle = TexteStyle.StyleTexte("normal");

            frmmain.AddMsg(texte, txtcolor, txtstyle);
        }
        #endregion
        #region Propriétés

        public static bool ServeOpen
        {
            get
            {
                return _ServeOpen;
            }

            set
            {
                _ServeOpen = value;
            }
        }

        public static bool NeedReset
        {
            get
            {
                return _NeedReset;
            }

            set
            {
                _NeedReset = value;
            }
        }

        public static string Securitykey
        {
            get
            {
                return _SecurityKey;
            }

            set
            {
                _SecurityKey = value;
            }
        }

        public static EngineMap MapEngine
        {
            get
            {
                return _MapEngine;
            }

            set
            {
                _MapEngine = value;
            }
        }

        public static List<Map> Maps
        {
            get
            {
                return _MapEngine.Maps;
            }

            set
            {
                _MapEngine.Maps = value;
            }
        }

        public static List<Npc> Npcs
        {
            get
            {
                return _NpcEngine.Npcs;
            }

            set
            {
                _NpcEngine.Npcs = value;
            }
        }

        public static EngineNpc NpcEngine
        {
            get
            {
                return _NpcEngine;
            }

            set
            {
                _NpcEngine = value;
            }
        }

        public static List<Item> Items
        {
            get
            {
                return _ItemEngine.Items;
            }

            set
            {
                _ItemEngine.Items = value;
            }
        }

        public static EngineItem ItemEngine
        {
            get
            {
                return _ItemEngine;
            }

            set
            {
                _ItemEngine = value;
            }
        }

        public static bool IsLoaded
        {
            get
            {
                return _Isloaded;
            }

            set
            {
                _Isloaded = value;
            }
        }
        #endregion
    }
}
