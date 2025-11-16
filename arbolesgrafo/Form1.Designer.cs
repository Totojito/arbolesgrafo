namespace arbolesgrafo
{
    partial class Form1
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
            this.btnMostrarArbol = new System.Windows.Forms.Button();
            this.txtArbolResultado = new System.Windows.Forms.TextBox();
            this.btnContar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMostrarArbol
            // 
            this.btnMostrarArbol.Location = new System.Drawing.Point(115, 63);
            this.btnMostrarArbol.Name = "btnMostrarArbol";
            this.btnMostrarArbol.Size = new System.Drawing.Size(75, 23);
            this.btnMostrarArbol.TabIndex = 0;
            this.btnMostrarArbol.Text = "Mostrar";
            this.btnMostrarArbol.UseVisualStyleBackColor = true;
            this.btnMostrarArbol.Click += new System.EventHandler(this.btnMostrarArbol_Click);
            // 
            // txtArbolResultado
            // 
            this.txtArbolResultado.Location = new System.Drawing.Point(196, 63);
            this.txtArbolResultado.Multiline = true;
            this.txtArbolResultado.Name = "txtArbolResultado";
            this.txtArbolResultado.Size = new System.Drawing.Size(100, 22);
            this.txtArbolResultado.TabIndex = 1;
            // 
            // btnContar
            // 
            this.btnContar.Location = new System.Drawing.Point(115, 106);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(75, 23);
            this.btnContar.TabIndex = 2;
            this.btnContar.Text = "Contar";
            this.btnContar.UseVisualStyleBackColor = true;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 487);
            this.Controls.Add(this.btnContar);
            this.Controls.Add(this.txtArbolResultado);
            this.Controls.Add(this.btnMostrarArbol);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarArbol;
        private System.Windows.Forms.TextBox txtArbolResultado;
        private System.Windows.Forms.Button btnContar;
    }
}

