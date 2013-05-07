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
    public partial class frmselectground : Form
    {
        Bitmap img;
        string tileset;

        private int _locationx = 0;
        private int _locationy = 0;
        private int _sizex;
        private int _sizey;




        System.Drawing.Graphics g;
        System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.White, 2F);
        System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Black, 1);
        private Boolean selectionmode = false;


        public frmselectground()
        {
            InitializeComponent();
        }



        private void tilescroll_Scroll(object sender, ScrollEventArgs e)
        {
            tileset = GlobalDataGame.ProjectPath + "graphics/tiles/" + tilescroll.Value + ".png";
            this.Text = "AutoTile: " + tilescroll.Value;
            img = new Bitmap(tileset);
            pictilset.Image = img;
            GlobalDataEditor.EngineEditorParameter.SelectedTilesetID = (byte)(tilescroll.Value);

        }

        private void frmselectground_Load(object sender, EventArgs e)
        {
            tilescroll.Maximum = GlobalDataGame.maptile.Count - 1;
            GlobalDataEditor.EngineEditorParameter.SelectedTilesetID = 1;
            tileset = GlobalDataGame.ProjectPath + "/graphics/tiles/1.png";
            img = new Bitmap(tileset);
            pictilset.Image = img;

            g = pictilset.CreateGraphics();
        }






        private void mouse_up(object sender, MouseEventArgs e)
        {

        }








        #region Get/Set
        public int sizex
        {
            get
            {
                return _sizex;
            }

            set
            {
                _sizex = value;
            }
        }
        public int sizey
        {
            get
            {
                return _sizey;
            }

            set
            {
                _sizey = value;
            }
        }
        public int locationx
        {
            get
            {
                return _locationx;
            }

            set
            {
                _locationx = value;
            }
        }
        public int locationy
        {
            get
            {
                return _locationy;
            }

            set
            {
                _locationy = value;
            }
        }
        #endregion

        private void frmselectground_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectionmode == false)
            {
                selectionmode = true;
                locationx = (e.Location.X / 16) * 16;
                locationy = (e.Location.Y / 16) * 16;

            }
            else
            {
                selectionmode = false;
            }
              
                this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;

                sizex = ((e.Location.X / 16) * 16 - locationx) + 16;
                sizey = ((e.Location.Y / 16) * 16 - locationy) + 16;

                g.Clear(Color.FromArgb(255, 247, 247, 247));
                g.DrawImage(img, 0, 0);

                g.DrawRectangle(pen2, new Rectangle(locationx + 1, locationy + 1, sizex - 3, sizey - 3));
                g.DrawRectangle(pen2, new Rectangle(locationx - 2, locationy - 2, sizex + 3, sizey + 3));

                g.DrawRectangle(pen1, new Rectangle(locationx, locationy, sizex, sizey));
        }

        private void frmselectground_MouseUp(object sender, MouseEventArgs e)
        {
            sizex = ((e.Location.X / 16) * 16 - locationx) + 16;
            sizey = ((e.Location.Y / 16) * 16 - locationy) + 16;
                selectionmode = false;
            
            
            GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value = sizex;
            GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value = sizey;

            g.Clear(Color.FromArgb(255, 247, 247, 247));
            g.DrawImage(img, 0, 0);

            g.DrawRectangle(pen2, new Rectangle(locationx + 1, locationy + 1, sizex - 3, sizey - 3));
            g.DrawRectangle(pen2, new Rectangle(locationx - 2, locationy - 2, sizex + 3, sizey + 3));

            g.DrawRectangle(pen1, new Rectangle(locationx, locationy, sizex, sizey));
   
            
        }

        private void pictilset_Click(object sender, EventArgs e)
        {
  
        }
    }
}
