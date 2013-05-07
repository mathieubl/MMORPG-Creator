namespace MmorpgEngine
{
    partial class frmprojects
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupcreate = new System.Windows.Forms.GroupBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btncreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnfilepatch = new System.Windows.Forms.Button();
            this.texturl = new System.Windows.Forms.TextBox();
            this.textname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauProjetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerProjetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horsLigneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enLigneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmorpgCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.àProposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupcreate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupcreate
            // 
            this.groupcreate.Controls.Add(this.btncancel);
            this.groupcreate.Controls.Add(this.btncreate);
            this.groupcreate.Controls.Add(this.label2);
            this.groupcreate.Controls.Add(this.btnfilepatch);
            this.groupcreate.Controls.Add(this.texturl);
            this.groupcreate.Controls.Add(this.textname);
            this.groupcreate.Controls.Add(this.label1);
            this.groupcreate.Location = new System.Drawing.Point(12, 27);
            this.groupcreate.Name = "groupcreate";
            this.groupcreate.Size = new System.Drawing.Size(357, 203);
            this.groupcreate.TabIndex = 13;
            this.groupcreate.TabStop = false;
            this.groupcreate.Text = "Création d\'un projet";
            this.groupcreate.Visible = false;
            // 
            // btncancel
            // 
            this.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancel.Location = new System.Drawing.Point(6, 112);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(78, 25);
            this.btncancel.TabIndex = 20;
            this.btncancel.Text = "Annuler";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click_1);
            // 
            // btncreate
            // 
            this.btncreate.Location = new System.Drawing.Point(254, 112);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(78, 25);
            this.btncreate.TabIndex = 19;
            this.btncreate.Text = "Créer";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Chemin:";
            // 
            // btnfilepatch
            // 
            this.btnfilepatch.Location = new System.Drawing.Point(262, 78);
            this.btnfilepatch.Name = "btnfilepatch";
            this.btnfilepatch.Size = new System.Drawing.Size(70, 28);
            this.btnfilepatch.TabIndex = 17;
            this.btnfilepatch.Text = "Parcourir...";
            this.btnfilepatch.UseVisualStyleBackColor = true;
            this.btnfilepatch.Click += new System.EventHandler(this.btnfilepatch_Click_1);
            // 
            // texturl
            // 
            this.texturl.Location = new System.Drawing.Point(11, 81);
            this.texturl.Name = "texturl";
            this.texturl.Size = new System.Drawing.Size(245, 20);
            this.texturl.TabIndex = 16;
            this.texturl.TextChanged += new System.EventHandler(this.texturl_TextChanged);
            // 
            // textname
            // 
            this.textname.Location = new System.Drawing.Point(10, 38);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(322, 20);
            this.textname.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nom du projet:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.mmorpgCreatorToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauProjetToolStripMenuItem1,
            this.chargerProjetToolStripMenuItem1,
            this.toolStripSeparator2,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouveauProjetToolStripMenuItem1
            // 
            this.nouveauProjetToolStripMenuItem1.Name = "nouveauProjetToolStripMenuItem1";
            this.nouveauProjetToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.nouveauProjetToolStripMenuItem1.Text = "Nouveau projet";
            this.nouveauProjetToolStripMenuItem1.Click += new System.EventHandler(this.nouveauProjetToolStripMenuItem1_Click);
            // 
            // chargerProjetToolStripMenuItem1
            // 
            this.chargerProjetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horsLigneToolStripMenuItem,
            this.enLigneToolStripMenuItem});
            this.chargerProjetToolStripMenuItem1.Name = "chargerProjetToolStripMenuItem1";
            this.chargerProjetToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.chargerProjetToolStripMenuItem1.Text = "Charger projet";
            // 
            // horsLigneToolStripMenuItem
            // 
            this.horsLigneToolStripMenuItem.Name = "horsLigneToolStripMenuItem";
            this.horsLigneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.horsLigneToolStripMenuItem.Text = "Hors ligne";
            this.horsLigneToolStripMenuItem.Click += new System.EventHandler(this.horsLigneToolStripMenuItem_Click);
            // 
            // enLigneToolStripMenuItem
            // 
            this.enLigneToolStripMenuItem.Name = "enLigneToolStripMenuItem";
            this.enLigneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.enLigneToolStripMenuItem.Text = "En ligne";
            this.enLigneToolStripMenuItem.Click += new System.EventHandler(this.enLigneToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // mmorpgCreatorToolStripMenuItem
            // 
            this.mmorpgCreatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramètresToolStripMenuItem});
            this.mmorpgCreatorToolStripMenuItem.Name = "mmorpgCreatorToolStripMenuItem";
            this.mmorpgCreatorToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.mmorpgCreatorToolStripMenuItem.Text = "Mmorpg Creator";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Enabled = false;
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            this.paramètresToolStripMenuItem.Click += new System.EventHandler(this.paramètresToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.toolStripSeparator1,
            this.àProposToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Enabled = false;
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // àProposToolStripMenuItem1
            // 
            this.àProposToolStripMenuItem1.Name = "àProposToolStripMenuItem1";
            this.àProposToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.àProposToolStripMenuItem1.Text = "À propos";
            this.àProposToolStripMenuItem1.Click += new System.EventHandler(this.àProposToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 203);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accueil";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bienvenu sur la nouvelle démo de MmorpgCreator, \r\ncette démo vous permettera d\'ex" +
                "périmenter la puissance de \r\nl\'éditeur de carte!";
            // 
            // frmprojects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(374, 234);
            this.Controls.Add(this.groupcreate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmprojects";
            this.Text = "Mmorpg Creator";
            this.Load += new System.EventHandler(this.frmprojects_Load);
            this.groupcreate.ResumeLayout(false);
            this.groupcreate.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.GroupBox groupcreate;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnfilepatch;
        private System.Windows.Forms.TextBox texturl;
        private System.Windows.Forms.TextBox textname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauProjetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chargerProjetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horsLigneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enLigneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem àProposToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mmorpgCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;


    }
}