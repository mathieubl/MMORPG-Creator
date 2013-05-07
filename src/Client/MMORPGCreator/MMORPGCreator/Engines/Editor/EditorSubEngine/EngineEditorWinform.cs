using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgEngine.Engines
{
    public class EngineEditorWinform
    {
        //FORMULAIRES
        private frmselectobjet _SelectObject = new frmselectobjet();
        private frmselectground _SelectGround = new frmselectground();
        private frmtileset _SelectTileset = new frmtileset();
        private frmnavigator _Navigator = new frmnavigator();
        private frmselectnpc _NpcEditorList = new frmselectnpc();
        private frmmapeditorlist _MapEditorList = new frmmapeditorlist();

        private frmconditioneditor _ConditionEditor = new frmconditioneditor();

        private frmprojects _Projects;
        private frmlogin _Login;

        #region load

        public void LoadMapEditorList()
        {
            if (_MapEditorList.Visible == false)
            {
                _MapEditorList.Visible = true;
            }

            if (GlobalDataGame.online == true)
            {
                socket.SendRequestMapEditorList();
            }
            else
            {
                Dictionary<Int32, String> listmaps = new Dictionary<Int32, String>();
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(GlobalDataGame.ProjectPath + "../Server/database/maps");

                foreach (System.IO.FileInfo fi in di.GetFiles())
                {
                    listmaps.Add(Convert.ToInt32(fi.Name), fi.Name);
                }
                _MapEditorList.load_maps(listmaps);
            }
        }

    #endregion

        #region get/set
        public frmselectobjet SelectObject
        {
            get
            {
                return _SelectObject;
            }

            set
            {
                _SelectObject = value;
            }
        }

        public frmselectground SelectGround
        {
            get
            {
                return _SelectGround;
            }

            set
            {
                _SelectGround = value;
            }
        }

        public frmtileset SelectTileset
        {
            get
            {
                return _SelectTileset;
            }

            set
            {
                _SelectTileset = value;
            }
        }

        public frmnavigator Navigator
        {
            get
            {
                return _Navigator;
            }

            set
            {
                _Navigator = value;
            }
        }

        public frmselectnpc NpcEditorList
        {
            get
            {
                return _NpcEditorList;
            }

            set
            {
                _NpcEditorList = value;
            }
        }

        public frmmapeditorlist MapEditorList
        {
            get
            {
                return _MapEditorList;
            }

            set
            {
                _MapEditorList = value;
            }
        }

        public frmconditioneditor ConditionEditor
        {
            get
            {
                return _ConditionEditor;
            }

            set
            {
                _ConditionEditor = value;
            }
        }

        public frmprojects Projects
        {
            get
            {
                return _Projects;
            }

            set
            {
                _Projects = value;
            }
        }

        public frmlogin Login
        {
            get
            {
                return _Login;
            }

            set
            {
                _Login = value;
            }
        }
        #endregion


    }
}
