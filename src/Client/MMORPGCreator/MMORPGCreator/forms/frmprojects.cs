using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Configuration;
using MmorpgEngine.Engines;
namespace MmorpgEngine
{
    [Serializable]
    public partial class frmprojects : Form
    {
        Stream stream;
        public ArrayList projets = new ArrayList();
        public Thread dialogThr;
        frmapropos winapropos = new frmapropos();
        public frmprojects()
        {
            InitializeComponent();
        }



        private void save_projets()
        {
            stream = new FileStream("projets.conf", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, projets);
            stream.Close();
        }

        private void create_projet()
        {

        }



        private void btnnew_Click_2(object sender, EventArgs e)
        {

            groupcreate.Visible = true;
        }

        private void btncreate_Click(object sender, EventArgs e)
        {

            string targetPath = texturl.Text + "/" + textname.Text;
            Stream patch;

            System.IO.Directory.CreateDirectory(targetPath + "/" + textname.Text);
            //Enregistrer le patch
            projets.Add(targetPath);

            //Création du fichier de configuration
            patch = new FileStream(targetPath + "/projet.conf", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(patch, textname.Text);
            patch.Close();


            groupcreate.Visible = false;


        }

        private void btnfilepatch_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                this.texturl.Text = folderBrowser.SelectedPath;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            groupcreate.Visible = false;
        }

        private void btnopen_Click(object sender, EventArgs e)
        {


        }

        private void frmprojects_Load(object sender, EventArgs e)
        {

         
            //projetToolStripMenuItem.Text = ConfigurationManager.AppSettings["LastProjectName"];
        //   mcConfig.
        }




        private void btncreate_Click_1(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(texturl.Text + "/" + textname.Text))
            {
                System.Windows.Forms.MessageBox.Show("Un dossier au nom du projet existe déjà à ce chemin.");
            }
            else
            {
                System.IO.Directory.CreateDirectory(texturl.Text + "/" + textname.Text);
                GlobalDataEditor.NewProject(texturl.Text + "/" + textname.Text, textname.Text);
                System.Windows.Forms.MessageBox.Show("Le projet a été créer au nom de: " + textname.Text);
            }


 
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            groupcreate.Visible = true;
        }

        private void btncancel_Click_1(object sender, EventArgs e)
        {
            groupcreate.Visible = false;
        }

        private void nouveauProjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupcreate.Visible = true;
        }

        private void modeEnLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void modeHorsLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void horsLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.online = false;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(folderBrowser.SelectedPath + "/projet.conf"))
                {
                    GlobalDataEditor.LoadGameProject(folderBrowser.SelectedPath);

                    Close();
                }
                else
                {
                    //mcConfig
                    System.Windows.Forms.MessageBox.Show("Le dossier ne contient pas de projet Mmorpg Creator.");
                }
            }
              winapropos.Visible = false;

              
            
        }

        private void enLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.online = true;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(folderBrowser.SelectedPath + "/projet.conf"))
                {
                    GlobalDataEditor.LoadGameProject(folderBrowser.SelectedPath);
                    Close();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Le dossier ne contient pas de projet Mmorpg Creator.");
                }
            }
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.AlertStatus = true;
            Application.Exit();
        }

        private void àProposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            winapropos.Visible = true;
        }

        private void nouveauProjetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            groupcreate.Visible = true;
        }

        private void btnfilepatch_Click_1(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                  texturl.Text = folderBrowser.SelectedPath;
        }

        private void texturl_TextChanged(object sender, EventArgs e)
        {

        }

        private void enLigneToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


    }
}
