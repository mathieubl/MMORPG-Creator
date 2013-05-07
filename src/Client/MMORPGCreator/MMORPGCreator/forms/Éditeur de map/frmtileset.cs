using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MmorpgEngine
{
    public partial class frmtileset : Form
    {
        Bitmap img;
        string _CurrentTilesetPath;
        private int _locationx = 0;
        private int _locationy = 0;
        private int _sizex;
        private int _sizey;


        private Boolean selectionmode = false;

        System.Drawing.Graphics g;
        System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.White, 2F);
        System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Black,1);
        public frmtileset()
        {
            InitializeComponent();
          
        }

        private void frmtileset_Load(object sender, EventArgs e)
        {
      
            tilescroll.Maximum = GlobalDataGame.maptileset.Count - 1;
            _CurrentTilesetPath = GlobalDataGame.ProjectPath + "/graphics/tileset/0.png";

            img = new Bitmap(_CurrentTilesetPath);
            pictilset.Image = img;
            g = pictilset.CreateGraphics();
        }




        private void mouse_up(object sender, MouseEventArgs e)
        {
            sizex = ((e.Location.X / 32) * 32 - locationx) + 32;
            sizey = ((e.Location.Y / 32) * 32 - locationy) + 32;
            selectionmode = false;


            GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizex_Value = sizex;
            GlobalDataEditor.EngineEditorWinform.SelectObject.updownsizey_Value = sizey;

            g.Clear(Color.FromArgb(255, 247, 247, 247));
            g.DrawImage(img, 0, 0);

            g.DrawRectangle(pen2, new Rectangle(locationx + 1, locationy + 1, sizex - 3, sizey - 3));
            g.DrawRectangle(pen2, new Rectangle(locationx - 2, locationy - 2, sizex + 3, sizey + 3));

            g.DrawRectangle(pen1, new Rectangle(locationx, locationy, sizex, sizey));

        
        }

        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                selectionmode = true;
                this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
              
            }
        }

        private void key_up(object sender, KeyEventArgs e)
        {
            selectionmode = false;
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void tilescroll_Scroll(object sender, ScrollEventArgs e)
        {
            _CurrentTilesetPath = GlobalDataGame.ProjectPath + "graphics/tileset/" + tilescroll.Value + ".png";
            this.Text = "TileSet: " + tilescroll.Value;

            img = new Bitmap(_CurrentTilesetPath);
            pictilset.Image = img;
            g = pictilset.CreateGraphics();
            GlobalDataEditor.EngineEditorParameter.SelectedTilesetID = (byte)tilescroll.Value;


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

        private void pictilset_Click(object sender, EventArgs e)
        {

        }

        private void pictilset_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectionmode == false)
            {
                selectionmode = true;
                locationx = (e.Location.X / 32) * 32;
                locationy = (e.Location.Y / 32) * 32;

            }
            else
            {
                selectionmode = false;
            }

            this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;


        }

   







    }
}
