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
    public partial class frmconditioneditor : Form
    {
        private List<condition> _condition;

    //   delegate void load_conditionsCallback(ArrayList lsbox);


        public frmconditioneditor()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }


        private void RefreshComboBox()
        {


        }


        private void LoadCondition()
        {
            if (GlobalDataGame.online == true)
            {

            }
            else
            {

            }

        }

        private void txtColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtColor.BackColor = colorDialog.Color;
                txtColor.Text = colorDialog.Color.ToString();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



    }
}
