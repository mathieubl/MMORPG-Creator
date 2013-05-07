using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Xml.XPath;
namespace MmorpgEngine
{
    public partial class frmlogin : Form
    {
        delegate void CloseCallback();
        public frmlogin()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            socket.SendLogin(txtname.Text, txtpass.Text);
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            this.Text = GlobalDataGame.GameName;
            
            //Lecture xml de la liste des serveurs
            XPathDocument doc = new XPathDocument(GlobalDataGame.ProjectPath + "/configuration/server.xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("serverlist/server");
            while (iter.MoveNext())
            {
                cmbserver.Items.Add(iter.Current.SelectSingleNode("name").Value);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if (socket.Connect == true)
            {
                lblserver.Text = "Connecté";
                BtnConnect.Enabled = true;


                if (socket.logged == true)
                    Close();
            }
            else
            {
                lblserver.Text = "Non connecté";
                BtnConnect.Enabled = false;
            }   
        }

        private void cmbserver_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblserver.Text = "Non connecté";
            BtnConnect.Enabled = false;
                 int i = 0;
            //Lecture xml de la liste des serveurs
                 XPathDocument doc = new XPathDocument(GlobalDataGame.ProjectPath + "/configuration/server.xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iter = nav.Select("serverlist/server");

            while (iter.MoveNext())
            {
                if (i == cmbserver.SelectedIndex)
                {
                    socket.Init(iter.Current.SelectSingleNode("ip").Value, System.Convert.ToInt32(iter.Current.SelectSingleNode("port").Value));
                }
                i++;
            }
        }



    }
}
