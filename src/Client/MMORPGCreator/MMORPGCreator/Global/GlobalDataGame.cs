using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.XPath;

using System.IO;
using System.Windows.Forms;
using System.Threading;
using MmorpgCreatorMain;
using MmorpgEngine.Engines;
namespace MmorpgEngine
{
    [Serializable]
    public static class GlobalDataGame
    {
       public static Game GameScreen;

        #region paramètres du client
        //GENERAL
        public static string ProjectPath = "";
        public static string GameName = "";
        public static int Max_Session = 0;
        public static int Max_SessionConnected = 0;

        public static string website = "";

        public static int last_version = 1;

        //OPTION
        public static string lang;
        public static Boolean OpFog = true;
        public static Boolean OpShadow = true;
   

        #endregion

        //RESSOURCES PRINCIPAL
        private static ArrayList _mapobj = new ArrayList();
        private static List<Player> _character = new List<Player>();
        public static List<Npc> npc_actif = new List<Npc>();
        private static ArrayList _maptile = new ArrayList();
        private static ArrayList _maptileset = new ArrayList();
        private static Map _CurrentMap;

        public static GraphicsDeviceManager graphics;

        public static List<SkinWindow> UserInterfaceKit = new List<SkinWindow>();

        //TRANSITION
        public static Boolean transition = false;
        private static Byte transition_type;
        private static Timer transition_timer;

        //SOCKET
        public static Boolean connected = false;
        public static Boolean online = false;

        //JEU
        public static Int32 Index = 3;

        private static Int32 _max_line = 10;

        private static GlobalEnum.XNAScreensType _Screen = 0;
        private static chat _ChatChannel = new chat();
        public static Boolean ingame = false;
        public static Int32 MyId;

        public static Boolean NeedMap = false;
        public static Boolean NeedEffect = false;
        public static Int32 maplocation = 1;
        public static Boolean AlertStatus = false;
        public static String focused = "";
        public static Int32 MapRevision = 0;

        private static GlobalEnum.ScreenModeEnum _TypeScreen;

        public static void SaveNpc(Int32 i)
        {
            if (GlobalDataGame.online == true)
            {
                //SavePacket
            }
            else
            {
                //SaveLocal
            }

        }

        public static void MakeTransition(Byte type)
        {
            const Byte NORMAL_FADER = 0;

            transition_type = type;
            switch (type)
            {
                case NORMAL_FADER:
                    transition_timer = new Timer(1000, false);
                    break;
            }
        }


        public static void SaveGameData()
        {
            Stream stream;
            stream = new FileStream(GlobalDataGame.ProjectPath + "/projet.conf", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, GameName);
            stream.Close();
        }

        public static int FindPlayer(int id)
        {
            int val = new int();
            for (int i = 0; i < character.Count; i++)
            {
                Player character_temp = (Player)character[i];
                if (character_temp.ID == id)
                {
                    val = i;
                    break;
                }
            }
            return val;
        }


        public static Boolean PlayerExist(int id)
        {
            for (Int32 i = 0; i < character.Count; i++)
            {
                Player character_temp = (Player)character[i];
                if (character_temp.ID == id)
                {
                    return true;
                }
            }
            return false;
        }


        #region get/set

        public static Map CurrentMap
        {
            get
            {
                return _CurrentMap;
            }

            set
            {
                _CurrentMap = value;
            }
        }




        public static int max_line
        {
            get
            {
                return _max_line;
            }

            set
            {
                _max_line = value;
            }
        }

        public static chat ChatChannel
        {
            get
            {
                return _ChatChannel;
            }

            set
            {
                _ChatChannel = value;
            }
        }


        public static GlobalEnum.XNAScreensType screen
        {
            get
            {
                return _Screen;
            }

            set
            {
                _Screen = value;
            }
        }


        public static GlobalEnum.ScreenModeEnum TypeScreen
        {
            get
            {
                return _TypeScreen;
            }

            set
            {
                _TypeScreen = value;
            }
        }


        public static List<Player> character
        {
            get
            {
                return _character;
            }

            set
            {
                _character = value;
            }
        }


        public static ArrayList maptile
        {
            get
            {
                return _maptile;
            }

            set
            {
                _maptile = value;
            }
        }


        public static ArrayList maptileset
        {
            get
            {
                return _maptileset;
            }

            set
            {
                _maptileset = value;
            }
        }


        public static ArrayList mapobj
        {
            get
            {
                return _mapobj;
            }

            set
            {
                _mapobj = value;
            }
        }




        public static void load_tile(){


        }
        #endregion

   

    }
}
