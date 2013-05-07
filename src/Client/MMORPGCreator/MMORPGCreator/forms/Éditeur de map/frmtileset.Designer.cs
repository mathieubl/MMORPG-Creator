namespace MmorpgEngine
{
    partial class frmtileset
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
            this.pictilset = new System.Windows.Forms.PictureBox();
            this.tilescroll = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictilset)).BeginInit();
            this.SuspendLayout();
            // 
            // pictilset
            // 
            this.pictilset.Location = new System.Drawing.Point(2, 26);
            this.pictilset.Name = "pictilset";
            this.pictilset.Size = new System.Drawing.Size(277, 355);
            this.pictilset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictilset.TabIndex = 0;
            this.pictilset.TabStop = false;
            this.pictilset.Click += new System.EventHandler(this.pictilset_Click);
            this.pictilset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictilset_MouseDown);
            this.pictilset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouse_up);
            // 
            // tilescroll
            // 
            this.tilescroll.LargeChange = 1;
            this.tilescroll.Location = new System.Drawing.Point(0, 0);
            this.tilescroll.Maximum = 10;
            this.tilescroll.Name = "tilescroll";
            this.tilescroll.Size = new System.Drawing.Size(279, 23);
            this.tilescroll.TabIndex = 1;
            this.tilescroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tilescroll_Scroll);
            // 
            // frmtileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(282, 383);
            this.ControlBox = false;
            this.Controls.Add(this.tilescroll);
            this.Controls.Add(this.pictilset);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmtileset";
            this.Text = "Texture";
            this.Load += new System.EventHandler(this.frmtileset_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.key_up);
            ((System.ComponentModel.ISupportInitialize)(this.pictilset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictilset;
        private System.Windows.Forms.HScrollBar tilescroll;
    }
}