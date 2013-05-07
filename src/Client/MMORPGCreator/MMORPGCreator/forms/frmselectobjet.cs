using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace amdaro
{
    public partial class frmselectobjet : Form
    {
        public frmselectobjet()
        {
            InitializeComponent();
        }

        private void editor_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < config.tile.Count; i++)
            {
                mapobj tile_temp = (mapobj)config.tile[i];
                CmbListObj.Items.Add(tile_temp.get_name());
            }
        }

        

        private void process1_Exited(object sender, EventArgs e)
        {

        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (chklayer.Checked)
            {
                config.editorniv = true;
            }
            else
            {
                config.editorniv = false;
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void CmbListObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.editorIdObj = CmbListObj.SelectedIndex;
        }

        private void over_actif(object sender, EventArgs e)
        {
            config.iseditoractif = true;
        }

        private void over_deactif(object sender, EventArgs e)
        {
            config.iseditoractif = false;
        }

        private void over_deactif(object sender, MouseEventArgs e)
        {
            config.iseditoractif = false;
        }

       



    }
}
