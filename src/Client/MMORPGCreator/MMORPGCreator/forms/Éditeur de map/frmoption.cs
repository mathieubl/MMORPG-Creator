using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MmorpgEngine
{
    public partial class frmoption : Form
    {
        public frmoption()
        {
            InitializeComponent();
        }

        private void frmoption_Load(object sender, EventArgs e)
        {



        }


        public void load_data()
        {
            string[] files;

            // pour avoir les noms des fichiers et sous-répertoires
            files = Directory.GetFiles(GlobalDataGame.ProjectPath + "/graphics/fogs/");

            int filecount = files.GetUpperBound(0) + 1;
            //FOIREUX
            cmbfogtexture.Items.Clear();
            for (int i = 0; i < filecount; i++)
            {
                cmbfogtexture.Items.Add(System.IO.Path.GetFileName(files[i]));
                if (GlobalDataGame.CurrentMap.FogTexture == (string)cmbfogtexture.Items[cmbfogtexture.Items.Count - 1])
                {
                    cmbfogtexture.SelectedItem = System.IO.Path.GetFileName(files[i]);
                    //data.cmbfogtexture.Items[cmbfogtexture.Items.Count]
                }
            }

            txtname.Text = GlobalDataGame.CurrentMap.Name;
            numsizex.Value = GlobalDataGame.CurrentMap.SizeX;
            numsizey.Value = GlobalDataGame.CurrentMap.SizeY;
            chkmeteo.Checked = GlobalDataGame.CurrentMap.Meteo;
            chktime.Checked = GlobalDataGame.CurrentMap.Time;

            chkfog.Checked = GlobalDataGame.CurrentMap.Fog;
            //À VOIR POUR LE TEXTURE
            chkfogmove.Checked = GlobalDataGame.CurrentMap.FogMove;
            numfogvitx.Value = GlobalDataGame.CurrentMap.FogSpeedX;
            numfogvity.Value = GlobalDataGame.CurrentMap.FogSpeedY;


            lblid.Text = GlobalDataGame.CurrentMap.ID.ToString();

            checkStatusOfChkFog();
            checkStatusOfchkFogMove();
        }

        private void save_data()
        {
            GlobalDataGame.CurrentMap.Name = txtname.Text;
            GlobalDataGame.CurrentMap.resize_map((int)numsizex.Value, (int)numsizey.Value);

            GlobalDataGame.CurrentMap.Meteo = chkmeteo.Checked;
            GlobalDataGame.CurrentMap.Time = chktime.Checked;

            GlobalDataGame.CurrentMap.Fog = chkfog.Checked;
            if (cmbfogtexture.SelectedIndex != -1)
            {
                GlobalDataGame.CurrentMap.FogTexture = (string)cmbfogtexture.Items[cmbfogtexture.SelectedIndex];
            }
            //À VOIR POUR LE TEXTURE
            GlobalDataGame.CurrentMap.FogMove = chkfogmove.Checked;
            GlobalDataGame.CurrentMap.FogSpeedX = (int)numfogvitx.Value;
            GlobalDataGame.CurrentMap.FogSpeedY = (int)numfogvity.Value;

            GlobalDataGame.NeedEffect = true;

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.save_data();
            this.Visible = false;
        }

        private void btnapp_Click(object sender, EventArgs e)
        {
            this.save_data();
        }

        private void chkfogmove_CheckedChanged(object sender, EventArgs e)
        {
            checkStatusOfchkFogMove();
        }


        private void checkStatusOfchkFogMove()
        {
            if (chkfogmove.Checked)
            {
                numfogvitx.Enabled = true;
                numfogvity.Enabled = true;
            }
            else
            {
                numfogvitx.Enabled = false;
                numfogvity.Enabled = false;
            }
        }


        private void chkfog_CheckedChanged(object sender, EventArgs e)
        {
            checkStatusOfChkFog();
        }


        private void checkStatusOfChkFog()
        {
            if (chkfog.Checked)
            {
                cmbfogtexture.Enabled = true;
                btnview.Enabled = true;
                chkfogmove.Enabled = true;
                numfogvitx.Enabled = true;
                numfogvity.Enabled = true;
            }
            else
            {
                cmbfogtexture.Enabled = false;
                btnview.Enabled = false;
                chkfogmove.Enabled = false;
                numfogvitx.Enabled = false;
                numfogvity.Enabled = false;
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {

        }

        private void cmbfogtexture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
