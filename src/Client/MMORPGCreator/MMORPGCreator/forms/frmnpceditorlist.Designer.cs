namespace MmorpgEngine
{
    partial class frmselectnpc
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
            this.ctrlEditList = new MmorpgEngine.CtrlEditList();
            this.SuspendLayout();
            // 
            // ctrlEditList
            // 
            this.ctrlEditList.Location = new System.Drawing.Point(6, 2);
            this.ctrlEditList.Name = "ctrlEditList";
            this.ctrlEditList.Size = new System.Drawing.Size(227, 197);
            this.ctrlEditList.TabIndex = 0;
            this.ctrlEditList.Load += new System.EventHandler(this.ctrlEditList_Load);
            // 
            // frmselectnpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 197);
            this.Controls.Add(this.ctrlEditList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmselectnpc";
            this.Text = "Éditeur de pnj\'s";
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlEditList ctrlEditList;


    }
}