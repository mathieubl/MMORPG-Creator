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
    public partial class frmgestionobj : Form
    {
        public frmgestionobj()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void btntexture_Click(object sender, EventArgs e)
        {
            frmtexture showtexture = new frmtexture((string)lstobjet.SelectedItem);        
        }
    }
}
