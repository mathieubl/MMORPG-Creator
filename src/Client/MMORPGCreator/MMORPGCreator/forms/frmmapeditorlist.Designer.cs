namespace MmorpgEngine
{
    partial class frmmapeditorlist
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
            this.ctrlEditList.Location = new System.Drawing.Point(8, 4);
            this.ctrlEditList.Name = "ctrlEditList";
            this.ctrlEditList.Size = new System.Drawing.Size(267, 209);
            this.ctrlEditList.TabIndex = 6;
            this.ctrlEditList.Load += new System.EventHandler(this.ctrlEditList_Load);
            // 
            // frmmapeditorlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 203);
            this.Controls.Add(this.ctrlEditList);
            this.Name = "frmmapeditorlist";
            this.Text = "Listes des cartes";
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlEditList ctrlEditList;
    }
}