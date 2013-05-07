namespace MmorpgEngine
{
    partial class frmselectground
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
            this.tilescroll = new System.Windows.Forms.HScrollBar();
            this.pictilset = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictilset)).BeginInit();
            this.SuspendLayout();
            // 
            // tilescroll
            // 
            this.tilescroll.LargeChange = 1;
            this.tilescroll.Location = new System.Drawing.Point(1, 1);
            this.tilescroll.Maximum = 10;
            this.tilescroll.Name = "tilescroll";
            this.tilescroll.Size = new System.Drawing.Size(98, 23);
            this.tilescroll.TabIndex = 3;
            this.tilescroll.Value = 1;
            this.tilescroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tilescroll_Scroll);
            // 
            // pictilset
            // 
            this.pictilset.Location = new System.Drawing.Point(3, 27);
            this.pictilset.Name = "pictilset";
            this.pictilset.Size = new System.Drawing.Size(96, 128);
            this.pictilset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictilset.TabIndex = 2;
            this.pictilset.TabStop = false;
            this.pictilset.Click += new System.EventHandler(this.pictilset_Click);
            this.pictilset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmselectground_MouseDown);
            this.pictilset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmselectground_MouseUp);
            // 
            // frmselectground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 157);
            this.Controls.Add(this.tilescroll);
            this.Controls.Add(this.pictilset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmselectground";
            this.Text = "frmselectground";
            this.Load += new System.EventHandler(this.frmselectground_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictilset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictilset;
        public System.Windows.Forms.HScrollBar tilescroll;

    }
}