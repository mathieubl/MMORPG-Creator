using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MmorpgEngine
{
    public partial class frmparam : Form
    {
        public frmparam()
        {
            InitializeComponent();
        }

        private void btnannul_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Visible = false;
        }

        private void SaveData()
        {
            GlobalEngine.name = txtname.Text;
            GlobalEngine.motd = txtmotd.Text;

            GlobalEngine.port = (Int32)numport.Value;
            GlobalEngine.SaveConfig();

        }

        private void btnapp_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void frmparam_Load(object sender, EventArgs e)
        {
            txtname.Text = GlobalEngine.name;
            txtmotd.Text = GlobalEngine.motd;
            numport.Value = GlobalEngine.port;
        }



    }
}
