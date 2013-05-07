using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace MmorpgEngine
{
    public partial class frmselectobjet : Form
    {
      
        public frmselectobjet()
        {
            InitializeComponent();
        }

        private void editor_Load(object sender, EventArgs e)
        {
          /*  for (int i = 0; i < config.mapobj.Count; i++)
            {
                mapobj tile_temp = (mapobj)config.mapobj[i];
                CmbListObj.Items.Add(tile_temp.name);
            }*/
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (chklayer.Checked)
            {
               GlobalDataEditor.EngineEditorParameter.IsMagnetism = true;
            }
            else
            {
                GlobalDataEditor.EngineEditorParameter.IsMagnetism = false;
            }
        }



        private void CmbListObj_SelectedIndexChanged(object sender, EventArgs e)
        {


         /*   mapobj tile_temp = (mapobj)config.mapobj[2];
            updownsizex.Value = (decimal)tile_temp.sprite.Width;
            updownsizey.Value = (decimal)tile_temp.sprite.Height;
       
            updownalpha.Value = 255;*/

        }



        public Boolean chklayer_Checked
        {
            get
            {
                return chklayer.Checked;
            }

            set
            {
                chklayer.Checked = value;
            }
        }

        public Boolean chkcollision_Checked
        {
            get
            {
                return chkcollision.Checked;
            }

            set
            {
                chkcollision.Checked = value;
            }
        }

        public Boolean chkmagnetisme_Checked
        {
            get
            {
                return chkmagnetisme.Checked;
            }

            set
            {
                chkmagnetisme.Checked = value;
            }
        }

        public decimal updownsizex_Value
        {
            get
            {
                return updownsizex.Value;
            }

            set
            {
                updownsizex.Value = value;
            }
        }

        public decimal updownsizey_Value
        {
            get
            {
                return updownsizey.Value;
            }

            set
            {
                updownsizey.Value = value;
            }
        }

        public decimal updownalpha_Value
        {
            get
            {
                return updownalpha.Value;
            }

            set
            {
                updownalpha.Value = value;
            }
        }

        private void chkmagnetisme_CheckedChanged(object sender, EventArgs e)
        {
            if (chkmagnetisme.Checked == true)
            {
                GlobalDataEditor.EngineEditorParameter.IsMagnetism = true;
            }
            else
            {
                GlobalDataEditor.EngineEditorParameter.IsMagnetism = false;
            }
        }









    }
}
