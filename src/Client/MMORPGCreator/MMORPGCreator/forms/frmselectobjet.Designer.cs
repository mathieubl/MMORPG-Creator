namespace amdaro
{
    partial class frmselectobjet
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
            this.CmbListObj = new System.Windows.Forms.ComboBox();
            this.chkcollision = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chklayer = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbListObj
            // 
            this.CmbListObj.FormattingEnabled = true;
            this.CmbListObj.Location = new System.Drawing.Point(5, 19);
            this.CmbListObj.Name = "CmbListObj";
            this.CmbListObj.Size = new System.Drawing.Size(216, 21);
            this.CmbListObj.TabIndex = 2;
            this.CmbListObj.SelectedIndexChanged += new System.EventHandler(this.CmbListObj_SelectedIndexChanged);
            // 
            // chkcollision
            // 
            this.chkcollision.AutoSize = true;
            this.chkcollision.Location = new System.Drawing.Point(8, 46);
            this.chkcollision.Name = "chkcollision";
            this.chkcollision.Size = new System.Drawing.Size(125, 17);
            this.chkcollision.TabIndex = 3;
            this.chkcollision.Text = "Collision automatique";
            this.chkcollision.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Objets :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chklayer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.domainUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(5, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 71);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apparance";
            // 
            // chklayer
            // 
            this.chklayer.AutoSize = true;
            this.chklayer.Location = new System.Drawing.Point(7, 19);
            this.chklayer.Name = "chklayer";
            this.chklayer.Size = new System.Drawing.Size(149, 17);
            this.chklayer.TabIndex = 9;
            this.chklayer.Text = "Au dessus du personnage";
            this.chklayer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transparence :";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(89, 42);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(53, 20);
            this.domainUpDown1.TabIndex = 7;
            // 
            // frmselectobjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(225, 145);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkcollision);
            this.Controls.Add(this.CmbListObj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmselectobjet";
            this.Text = "Sélection d\'objet de carte";
            this.Activated += new System.EventHandler(this.over_deactif);
            this.Load += new System.EventHandler(this.editor_Load);
            this.MouseLeave += new System.EventHandler(this.over_actif);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbListObj;
        private System.Windows.Forms.CheckBox chkcollision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chklayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;

    }
}