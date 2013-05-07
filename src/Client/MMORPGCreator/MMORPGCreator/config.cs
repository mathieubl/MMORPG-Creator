using System;
using System.Collections;

using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace MmorpgEngine
{

    public class config
    {
        //RESSOURCES PRINCIPAL
        private static ArrayList _mapobj = new ArrayList();
        private static ArrayList _character = new ArrayList();
        private static ArrayList _maptile = new ArrayList();
        private static ArrayList _maptileset = new ArrayList();
   
        //JEU
        private static int _screenX = 1024;
        private static int _screenY = 768;
        private static int _max_line = 5;

        private static Byte _Screen;
        private static chat _ChatChannel = new chat();
        
        //ÉDITION
        private static byte _editorIdObj = 1;
        private static Byte _TypeScreen;
        private static Boolean _editorniv = false;
        private static Boolean _iseditoractif = false;
        private static frmselectobjet _selectobj = new frmselectobjet();
        private static frmtileset _selecttileset;

        #region get/set
        public static frmtileset selecttileset
        {
            get
            {
                return _selecttileset;
            }

            set
            {
                _selecttileset = value;
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



        public static frmselectobjet selectobj
        {
            get
            {
                return _selectobj;
            }

            set
            {
                _selectobj = value;
            }
        }



        public static Byte screen
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


        public static Boolean iseditoractif
        {
            get
            {
                return _iseditoractif;
            }

            set
            {
                _iseditoractif = value;
            }
        }

        public static Byte TypeScreen
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


        public static ArrayList character
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


        public static int screenx
        {
            get
            {
                return _screenX;
            }

            set
            {
                _screenX = value;
            }

        }

        public static int screeny
        {
            get
            {
                return _screenY;
            }

            set
            {
                _screenY = value;
            }

        }

        public static byte editorIdObj
        {
            get
            {
                return _editorIdObj;
            }

            set
            {
                _editorIdObj = value;
            }
        }

        public static Boolean editorniv
        {
            get
            {
                return _editorniv;
            }

            set
            {
                _editorniv = value;
            }
        }


        public static void load_tile(){


        }
        #endregion



    }
}
