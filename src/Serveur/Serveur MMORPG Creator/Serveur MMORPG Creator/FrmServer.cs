using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace MmorpgEngine
{
    public partial class FrmServer : Form
    {


        delegate void SetTextCallback(string text, Color Couleur, FontStyle fontstyle);
        delegate void SetLineTextCallback(Int32 line, String text);
        public FrmServer()
        {
            InitializeComponent();
            GlobalEngine.IsLoaded = true;

        }

        private void FrmServer_Load(object sender, EventArgs e)
        {
            GlobalEngine.IsLoaded = true;

        }

        public void AddMsg(string texte, Color Couleur, FontStyle fontstyle)
        {
            SetText(texte, Couleur, fontstyle);
        }

        private void SetText(string text, Color Couleur, FontStyle fontstyle)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.boxall.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, Couleur, fontstyle });
            }
            else
            {
                Font fBold = new Font("Tahoma", 8, fontstyle);
                this.boxall.SelectionFont = fBold;

                this.boxall.SelectionColor = Couleur;
                this.boxall.SelectedText  = "\n" + text;
          
            }
        }

        private void SetLine(Int32 line, String text)
        {
            if (this.boxall.InvokeRequired)
            {
                SetLineTextCallback d = new SetLineTextCallback(SetLine);
                this.Invoke(d, new object[] { line, text });
            }
            else
            {
                this.boxall.Lines[line] = "text";
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalEngine.frmparam.Visible = true;
        }

        private void FrmServer_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtCommandCall_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                if (ValidCommand(txtCommandCall.Text) == true)
                    txtCommandCall.Text = String.Empty;
        }

        private Boolean ValidCommand(String text)
        {
            Boolean retIsValid = false;

            if (text == "/Who")
            {
                String textToSend = String.Empty;
                Int32 index = 0;
                foreach (Session curSession in GlobalEngine.Socket.Sessions)
                {

                    if (curSession.Connected == true)
                    {
                        index++;
                        if (index != 1)
                            textToSend += ",";

                        textToSend += curSession.PlayerData.Character.Name;
                    }
                        
                }

                SetText(index + " Joueur en ligne: " + textToSend, Color.Black, FontStyle.Regular);
                retIsValid = true;
            }
                return retIsValid;
        }


    }
}
