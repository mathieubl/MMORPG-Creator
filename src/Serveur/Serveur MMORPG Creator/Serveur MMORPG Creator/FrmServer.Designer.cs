namespace MmorpgEngine
{
    partial class FrmServer
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
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCommandCall = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.boxall = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.boxchat = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.boxadmin = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.boxplayer = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 22);
            this.button3.TabIndex = 22;
            this.button3.Text = "Paramètres";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 52);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status du serveur";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "En maintenance";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 198);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actions global";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(52, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "Faire l\'action";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(129, 147);
            this.listBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 46;
            this.button1.Text = "Commandes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtCommandCall
            // 
            this.txtCommandCall.Location = new System.Drawing.Point(229, 277);
            this.txtCommandCall.Name = "txtCommandCall";
            this.txtCommandCall.Size = new System.Drawing.Size(301, 20);
            this.txtCommandCall.TabIndex = 45;
            this.txtCommandCall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommandCall_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Commande:";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Controls.Add(this.tabPage4);
            this.tab.HotTrack = true;
            this.tab.Location = new System.Drawing.Point(159, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(452, 256);
            this.tab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tab.TabIndex = 43;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.boxall);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 230);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tous";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // boxall
            // 
            this.boxall.BackColor = System.Drawing.Color.White;
            this.boxall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxall.Location = new System.Drawing.Point(3, 0);
            this.boxall.Name = "boxall";
            this.boxall.ReadOnly = true;
            this.boxall.Size = new System.Drawing.Size(436, 224);
            this.boxall.TabIndex = 1;
            this.boxall.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(444, 240);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.boxchat);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 230);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // boxchat
            // 
            this.boxchat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxchat.Location = new System.Drawing.Point(4, 3);
            this.boxchat.Name = "boxchat";
            this.boxchat.Size = new System.Drawing.Size(436, 234);
            this.boxchat.TabIndex = 2;
            this.boxchat.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.boxadmin);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(444, 230);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Administration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // boxadmin
            // 
            this.boxadmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxadmin.Location = new System.Drawing.Point(4, 3);
            this.boxadmin.Name = "boxadmin";
            this.boxadmin.Size = new System.Drawing.Size(436, 234);
            this.boxadmin.TabIndex = 2;
            this.boxadmin.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.boxplayer);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(444, 230);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Joueurs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // boxplayer
            // 
            this.boxplayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxplayer.Location = new System.Drawing.Point(4, 3);
            this.boxplayer.Name = "boxplayer";
            this.boxplayer.Size = new System.Drawing.Size(436, 234);
            this.boxplayer.TabIndex = 3;
            this.boxplayer.Text = "";
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(617, 301);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCommandCall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmServer";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FrmServer_Load);
            this.Leave += new System.EventHandler(this.FrmServer_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCommandCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox boxchat;
        private System.Windows.Forms.RichTextBox boxadmin;
        private System.Windows.Forms.RichTextBox boxplayer;
        public System.Windows.Forms.RichTextBox boxall;


    }
}