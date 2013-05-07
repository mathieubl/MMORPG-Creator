using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using MmorpgCreatorMain;
namespace MmorpgEngine
{
    public partial class frmmapeditorlist : Form
    {
        delegate void load_mapsCallback(Dictionary<Int32, String> lsbox);
        public frmmapeditorlist()
        {
            InitializeComponent();

        }



        public void load_maps(Dictionary<Int32, String> lsbox)
        {
          //  CtrlEditList
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ctrlEditList.InvokeRequired)
            {

                load_mapsCallback d = new load_mapsCallback(load_maps);
                this.Invoke(d, new object[] { lsbox });
            }
            else
            {
                this.ctrlEditList.LoadItems(lsbox);
                this.ctrlEditList.btnAdd.Click += btnadd_Click;
                this.ctrlEditList.btnEdit.Click += btnedit_Click;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (GlobalDataGame.online == true)
            {
                socket.SendRequestToWarp(Convert.ToInt32(ctrlEditList.listEdit.SelectedValue));
            }
            else
            {
                GlobalDataGame.TypeScreen = 0;
                GlobalDataGame.CurrentMap = new Map(Convert.ToInt32(ctrlEditList.listEdit.SelectedValue));
                ((IMapClient)GlobalDataGame.CurrentMap).LoadMap(true);
                GlobalDataGame.NeedEffect = true;
                GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditMapObj;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int i = 0 ;
            //Chargement des AutoTiles
            while (File.Exists(GlobalDataGame.ProjectPath + "../Server/database/maps/" + i + ".dat"))
            {
                i++;
            }

            GlobalDataGame.TypeScreen = 0;
            GlobalDataGame.CurrentMap = new Map(i);
            GlobalDataGame.CurrentMap.map_reset();
            GlobalDataGame.TypeScreen =  GlobalEnum.ScreenModeEnum.EditMapObj;
        }

        private void ctrlEditList_Load(object sender, EventArgs e)
        {

        }
    }
}
