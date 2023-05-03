namespace CapaPresentacion
{
    partial class frmPais
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lblCampo1
            // 
            this.lblCampo1.Size = new System.Drawing.Size(37, 16);
            this.lblCampo1.Text = "Pais:";
            // 
            // txtCampo1
            // 
            this.txtCampo1.MaxLength = 30;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(110, 36);
            this.lblTitulo.Text = "Paises";
            // 
            // frmPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1059, 589);
            this.Name = "frmPais";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
