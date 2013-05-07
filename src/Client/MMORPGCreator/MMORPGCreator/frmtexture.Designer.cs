namespace amdaro
{
    partial class frmtexture
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
            this.pictexture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictexture)).BeginInit();
            this.SuspendLayout();
            // 
            // pictexture
            // 
            this.pictexture.Location = new System.Drawing.Point(2, 1);
            this.pictexture.Name = "pictexture";
            this.pictexture.Size = new System.Drawing.Size(267, 249);
            this.pictexture.TabIndex = 0;
            this.pictexture.TabStop = false;
            // 
            // frmtexture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 251);
            this.Controls.Add(this.pictexture);
            this.Name = "frmtexture";
            this.Text = "Texture";
            this.Load += new System.EventHandler(this.frmtexture_Load);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.noclick);
            ((System.ComponentModel.ISupportInitialize)(this.pictexture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictexture;
    }
}