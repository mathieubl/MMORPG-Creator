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
    public partial class frmselect : Form
    {

        public frmselect()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            config.selectobj.Visible = true;
            config.selectevent.Visible = false;
            config.TypeScreen = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            config.selectobj.Visible = false;
            config.selectevent.Visible = false;
            config.TypeScreen = 2;
        }
    }
}
