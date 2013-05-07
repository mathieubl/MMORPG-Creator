using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MmorpgCreatorMain;
using MmorpgEngine.Engines;

namespace MmorpgEngine
{
    public partial class frmnavigator : Form
    {
        public const Byte SCREEN_TYPE_NORMAL = 0;
        public const Byte SCREEN_TYPE_INEDITMAPOBJ = 1;
        public const Byte SCREEN_TYPE_INEDITCOLLISION = 2;
        public const Byte SCREEN_TYPE_INEDITEVENEMENTS = 3;
        public const Byte SCREEN_TYPE_INEDITGROUND = 4;

        frmapropos winapropos = new frmapropos();
        frmoption winoption = new frmoption();

        public frmnavigator()
        {
            InitializeComponent();

        }

        private void saToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void éditeursToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void éditeurDeSolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditGround;

            GlobalDataEditor.EngineEditorWinform.SelectGround.Visible = true;
            GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = false;
            GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = false;

            éditeurDobjetsToolStripMenuItem.Checked = false;
            éditeurDeCollisionToolStripMenuItem.Checked = false;
            éditeurDeSolToolStripMenuItem.Checked = true;
        }

        private void éditeurDobjetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditMapObj;

                GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = true;
                GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = true;
                GlobalDataEditor.EngineEditorWinform.SelectGround.Visible = false;

                éditeurDobjetsToolStripMenuItem.Checked = true;
                éditeurDeSolToolStripMenuItem.Checked = false;
                éditeurDeCollisionToolStripMenuItem.Checked = false;
        }

        private void éditeurDeCollisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataGame.TypeScreen = GlobalEnum.ScreenModeEnum.EditCollision;


            GlobalDataEditor.EngineEditorWinform.SelectObject.Visible = false;
            GlobalDataEditor.EngineEditorWinform.SelectTileset.Visible = false;
            GlobalDataEditor.EngineEditorWinform.SelectGround.Visible = false;

            éditeurDeSolToolStripMenuItem.Checked = false;
            éditeurDobjetsToolStripMenuItem.Checked = false;
            éditeurDeCollisionToolStripMenuItem.Checked = true;
        }

        private void ressourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmnavigator_Load(object sender, EventArgs e)
        {

        }


        private void àProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            winapropos.Visible = true;
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GlobalDataGame.online)
            {
                 ((IMapClient)GlobalDataGame.CurrentMap).SaveMap();
                 ((IMapClient)GlobalDataGame.CurrentMap).SaveMap(true);

                if (GlobalDataEditor.EngineEditorWinform.MapEditorList.Visible == true)
                {
                    GlobalDataEditor.EngineEditorWinform.LoadMapEditorList();
                }
            }
            else
            {
                 ((IMapClient)GlobalDataGame.CurrentMap).SaveMap();
                ((IMapClient)GlobalDataGame.CurrentMap).SaveMap(true);
                socket.SendMap();
            }

           
        }

        private void propriétésToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void éditeurDePnjsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monstresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataEditor.EngineEditorWinform.NpcEditorList.Visible = true;
            
            if (GlobalDataGame.online == true)
            {
                socket.SendRequestNpcEditorList();
            }
            else
            {
             
            }
            
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void lancerServeurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void naviguateurDeCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void naviguateursDeCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataEditor.EngineEditorWinform.LoadMapEditorList();

        }

        private void conditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataEditor.EngineEditorWinform.ConditionEditor.Visible = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            winoption.load_data();
            winoption.Visible = true;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void connexionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void propriétésDeLaCarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            winoption.load_data();
            winoption.Visible = true;
        }





 
    }
}
