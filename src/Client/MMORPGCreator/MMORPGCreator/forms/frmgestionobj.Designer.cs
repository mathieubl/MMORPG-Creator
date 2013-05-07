namespace amdaro
{
    partial class frmgestionobj
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
            this.lstobjet = new System.Windows.Forms.ListBox();
            this.addobjet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btntexture = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbtexture = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstobjet);
            this.groupBox1.Controls.Add(this.addobjet);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste d\'objets";
            // 
            // lstobjet
            // 
            this.lstobjet.FormattingEnabled = true;
            this.lstobjet.Location = new System.Drawing.Point(12, 19);
            this.lstobjet.Name = "lstobjet";
            this.lstobjet.Size = new System.Drawing.Size(187, 95);
            this.lstobjet.TabIndex = 1;
            // 
            // addobjet
            // 
            this.addobjet.Location = new System.Drawing.Point(6, 119);
            this.addobjet.Name = "addobjet";
            this.addobjet.Size = new System.Drawing.Size(193, 24);
            this.addobjet.TabIndex = 2;
            this.addobjet.Text = "Ajouter un objet";
            this.addobjet.UseVisualStyleBackColor = true;
            this.addobjet.Click += new System.EventHandler(this.addobjet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btntexture);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbtexture);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(217, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 119);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option de la sélection";
            // 
            // btntexture
            // 
            this.btntexture.Location = new System.Drawing.Point(186, 81);
            this.btntexture.Name = "btntexture";
            this.btntexture.Size = new System.Drawing.Size(91, 20);
            this.btntexture.TabIndex = 5;
            this.btntexture.Text = "Voir la texture";
            this.btntexture.UseVisualStyleBackColor = true;
            this.btntexture.Click += new System.EventHandler(this.btntexture_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom de l\'objet: ";
            // 
            // cmbtexture
            // 
            this.cmbtexture.FormattingEnabled = true;
            this.cmbtexture.Location = new System.Drawing.Point(8, 80);
            this.cmbtexture.Name = "cmbtexture";
            this.cmbtexture.Size = new System.Drawing.Size(172, 21);
            this.cmbtexture.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texture: ";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(217, 128);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(129, 24);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Ok";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(374, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Appliquer";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmgestionobj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 156);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmgestionobj";
            this.ShowIcon = false;
            this.Text = "Éditeur d\'objets de carte";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstobjet;
        private System.Windows.Forms.Button addobjet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbtexture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btntexture;
        private System.Windows.Forms.Button button1;
    }
}