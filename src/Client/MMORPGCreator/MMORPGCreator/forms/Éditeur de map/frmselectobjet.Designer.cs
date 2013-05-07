namespace MmorpgEngine
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
            this.chkcollision = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updownalpha = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chklayer = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updownsizey = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.updownsizex = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkmagnetisme = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownalpha)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownsizey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownsizex)).BeginInit();
            this.SuspendLayout();
            // 
            // chkcollision
            // 
            this.chkcollision.AutoSize = true;
            this.chkcollision.Location = new System.Drawing.Point(143, 27);
            this.chkcollision.Name = "chkcollision";
            this.chkcollision.Size = new System.Drawing.Size(64, 17);
            this.chkcollision.TabIndex = 3;
            this.chkcollision.Text = "Collision";
            this.chkcollision.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updownalpha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apparance";
            // 
            // updownalpha
            // 
            this.updownalpha.Location = new System.Drawing.Point(92, 21);
            this.updownalpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.updownalpha.Name = "updownalpha";
            this.updownalpha.Size = new System.Drawing.Size(48, 20);
            this.updownalpha.TabIndex = 10;
            this.updownalpha.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transparence :";
            // 
            // chklayer
            // 
            this.chklayer.AutoSize = true;
            this.chklayer.Location = new System.Drawing.Point(5, 27);
            this.chklayer.Name = "chklayer";
            this.chklayer.Size = new System.Drawing.Size(61, 17);
            this.chklayer.TabIndex = 9;
            this.chklayer.Text = "Dessus";
            this.chklayer.UseVisualStyleBackColor = true;

            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updownsizey);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.updownsizex);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(2, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 44);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grandeur";
            // 
            // updownsizey
            // 
            this.updownsizey.Location = new System.Drawing.Point(159, 18);
            this.updownsizey.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.updownsizey.Name = "updownsizey";
            this.updownsizey.Size = new System.Drawing.Size(43, 20);
            this.updownsizey.TabIndex = 14;
            this.updownsizey.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Hauteur :";
            // 
            // updownsizex
            // 
            this.updownsizex.Location = new System.Drawing.Point(61, 18);
            this.updownsizex.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.updownsizex.Name = "updownsizex";
            this.updownsizex.Size = new System.Drawing.Size(43, 20);
            this.updownsizex.TabIndex = 12;
            this.updownsizex.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Largeur :";
            // 
            // chkmagnetisme
            // 
            this.chkmagnetisme.AutoSize = true;
            this.chkmagnetisme.Location = new System.Drawing.Point(5, 8);
            this.chkmagnetisme.Name = "chkmagnetisme";
            this.chkmagnetisme.Size = new System.Drawing.Size(83, 17);
            this.chkmagnetisme.TabIndex = 11;
            this.chkmagnetisme.Text = "Magnétisme";
            this.chkmagnetisme.UseVisualStyleBackColor = true;
            this.chkmagnetisme.CheckedChanged += new System.EventHandler(this.chkmagnetisme_CheckedChanged);
            // 
            // frmselectobjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(212, 166);
            this.ControlBox = false;
            this.Controls.Add(this.chkmagnetisme);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chklayer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkcollision);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmselectobjet";
            this.Text = "Propriétés de l\'objet";
            this.Load += new System.EventHandler(this.editor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownalpha)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownsizey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownsizex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkcollision;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown updownalpha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown updownsizey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown updownsizex;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chklayer;
        private System.Windows.Forms.CheckBox chkmagnetisme;

    }
}