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
    public partial class frmtexture : Form
    {
        public frmtexture(string texture)
        {
            InitializeComponent();
             pictexture.LoadAsync(texture);
        }

        private void frmtexture_Load(object sender, EventArgs e)
        {
           
        }

        private void noclick(object sender, DragEventArgs e)
        {
            
        }
    }
}
