using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using MmorpgEngine.Engines;
namespace MmorpgEngine
{
    public class GlobalDataEditor
    {
        private static EngineEditorParameter _EngineEditorParameter = new EngineEditorParameter();
        private static EngineEditorWinform _EngineEditorWinform = new EngineEditorWinform();

        #region get/set
        public static EngineEditorParameter EngineEditorParameter
        {
            get
            {
                return _EngineEditorParameter;
            }

            set
            {
                _EngineEditorParameter = value;
            }
        }
        public static EngineEditorWinform EngineEditorWinform
        {
            get
            {
                return _EngineEditorWinform;
            }

            set
            {
                _EngineEditorWinform = value;
            }
        }
        #endregion







        //Editor
        public static Int32 EditGround_Sheet = 1;
        public static Int32 EditGround_Selectx = 1;
        public static Int32 EditGround_Selecty = 1;
        public static Int32 EditGround_Sizex = 4;
        public static Int32 EditGround_Sizey = 4;

        public static void LoadGameProject(string filename)
        {
            Stream stream;
            GlobalDataGame.ProjectPath = filename + "/Client/";

            stream = new FileStream(filename + "/projet.conf", FileMode.OpenOrCreate);
            BinaryFormatter bFormatter = new BinaryFormatter();

            GlobalDataGame.GameName = (string)bFormatter.Deserialize(stream);

            stream.Close();
        }

        public static void NewProject(string chemin, string name)
        {
            MmorpgEngine.Utils.FileManager_CopyDir("base/Client", chemin);
            MmorpgEngine.Utils.FileManager_CopyDir("base/Server", chemin);
            MmorpgEngine.Utils.FileManager_CopyDir("base/Publish", chemin);

            Stream stream;
            stream = new FileStream(chemin + "/projet.conf", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            GlobalDataGame.GameName = name;
            formatter.Serialize(stream, GlobalDataGame.GameName);
            stream.Close();
        }

    }
}
