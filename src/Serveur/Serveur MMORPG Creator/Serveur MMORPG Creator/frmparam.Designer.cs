namespace MmorpgEngine
{
    partial class frmparam
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmotd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numport = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnannul = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.btnapp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmotd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Général";
            // 
            // txtmotd
            // 
            this.txtmotd.Location = new System.Drawing.Point(11, 53);
            this.txtmotd.Multiline = true;
            this.txtmotd.Name = "txtmotd";
            this.txtmotd.Size = new System.Drawing.Size(432, 38);
            this.txtmotd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mots de bienvenue:";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(81, 14);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(362, 20);
            this.txtname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom du jeu: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numport);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Réseau:";
            // 
            // numport
            // 
            this.numport.Location = new System.Drawing.Point(41, 33);
            this.numport.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numport.Name = "numport";
            this.numport.Size = new System.Drawing.Size(50, 20);
            this.numport.TabIndex = 4;
            this.numport.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port:";
            // 
            // btnannul
            // 
            this.btnannul.Location = new System.Drawing.Point(379, 181);
            this.btnannul.Name = "btnannul";
            this.btnannul.Size = new System.Drawing.Size(73, 22);
            this.btnannul.TabIndex = 2;
            this.btnannul.Text = "Annuler";
            this.btnannul.UseVisualStyleBackColor = true;
            this.btnannul.Click += new System.EventHandler(this.btnannul_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(300, 181);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(73, 22);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnapp
            // 
            this.btnapp.Location = new System.Drawing.Point(221, 181);
            this.btnapp.Name = "btnapp";
            this.btnapp.Size = new System.Drawing.Size(73, 22);
            this.btnapp.TabIndex = 4;
            this.btnapp.Text = "Appliquer";
            this.btnapp.UseVisualStyleBackColor = true;
            this.btnapp.Click += new System.EventHandler(this.btnapp_Click);
            // 
            // frmparam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 209);
            this.ControlBox = false;
            this.Controls.Add(this.btnapp);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnannul);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmparam";
            this.Text = "Paramètres du serveur";
            this.Load += new System.EventHandler(this.frmparam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmotd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnannul;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnapp;
    }
}