using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgEngine
{
    public class GlobalClass
    {
        public const int CLIENT = 0;
        public const int SERVER = 1;
        private static int _Program;
        public static Int32 screenY;
        public static Int32 screenX;
        private static String _AppPath;

        public static int Program
        {
            get
            {
                return _Program;
            }

            set
            {
                _Program = value;
            }
        }

        public static String AppPath
        {
            get
            {
                return _AppPath;
            }

            set
            {
                _AppPath = value;
            }
        }

    }
}
