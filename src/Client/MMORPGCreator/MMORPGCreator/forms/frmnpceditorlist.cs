using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace MmorpgEngine
{
    delegate void load_itemsCallback(Dictionary<Int32, String> lsbox);

    public partial class frmselectnpc : Form
    {
        public frmselectnpc()
        {
            InitializeComponent();
        }

        public void Load_Npcs(Dictionary<Int32, String> lsbox)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.ctrlEditList.InvokeRequired)
            {
                load_itemsCallback d = new load_itemsCallback(Load_Npcs);
                this.Invoke(d, new object[] { lsbox });
            }
            else
            {
                ctrlEditList.LoadItems(lsbox);
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
          
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (GlobalDataGame.online == true)
            {

            }
            else
            {

            }
        }

        private void ctrlEditList_Load(object sender, EventArgs e)
        {

        }


    }
}
