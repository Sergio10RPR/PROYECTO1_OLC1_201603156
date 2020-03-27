namespace PROYECTO1_OLC1
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
            this.txaEntrada = new System.Windows.Forms.TextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txaSalida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txaExpresiones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpresionReg = new System.Windows.Forms.TextBox();
            this.btnAFN = new System.Windows.Forms.Button();
            this.btnAFD = new System.Windows.Forms.Button();
            this.btnTransiciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txaEntrada
            // 
            this.txaEntrada.Location = new System.Drawing.Point(13, 35);
            this.txaEntrada.Multiline = true;
            this.txaEntrada.Name = "txaEntrada";
            this.txaEntrada.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txaEntrada.Size = new System.Drawing.Size(591, 527);
            this.txaEntrada.TabIndex = 0;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(13, 569);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(103, 34);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "ANALIZAR";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "ANALIZAR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txaSalida
            // 
            this.txaSalida.Location = new System.Drawing.Point(624, 35);
            this.txaSalida.Multiline = true;
            this.txaSalida.Name = "txaSalida";
            this.txaSalida.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txaSalida.Size = new System.Drawing.Size(417, 241);
            this.txaSalida.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ENTRADA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(621, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SALIDA:";
            // 
            // txaExpresiones
            // 
            this.txaExpresiones.Location = new System.Drawing.Point(624, 314);
            this.txaExpresiones.Multiline = true;
            this.txaExpresiones.Name = "txaExpresiones";
            this.txaExpresiones.Size = new System.Drawing.Size(417, 121);
            this.txaExpresiones.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "EXPRESIONES REGULARES";
            // 
            // txtExpresionReg
            // 
            this.txtExpresionReg.Location = new System.Drawing.Point(624, 463);
            this.txtExpresionReg.Name = "txtExpresionReg";
            this.txtExpresionReg.Size = new System.Drawing.Size(417, 20);
            this.txtExpresionReg.TabIndex = 8;
            // 
            // btnAFN
            // 
            this.btnAFN.Location = new System.Drawing.Point(649, 507);
            this.btnAFN.Name = "btnAFN";
            this.btnAFN.Size = new System.Drawing.Size(103, 34);
            this.btnAFN.TabIndex = 9;
            this.btnAFN.Text = "AFN";
            this.btnAFN.UseVisualStyleBackColor = true;
            this.btnAFN.Click += new System.EventHandler(this.btnAFN_Click);
            // 
            // btnAFD
            // 
            this.btnAFD.Location = new System.Drawing.Point(784, 507);
            this.btnAFD.Name = "btnAFD";
            this.btnAFD.Size = new System.Drawing.Size(103, 34);
            this.btnAFD.TabIndex = 10;
            this.btnAFD.Text = "AFD";
            this.btnAFD.UseVisualStyleBackColor = true;
            this.btnAFD.Click += new System.EventHandler(this.btnAFD_Click);
            // 
            // btnTransiciones
            // 
            this.btnTransiciones.Location = new System.Drawing.Point(916, 507);
            this.btnTransiciones.Name = "btnTransiciones";
            this.btnTransiciones.Size = new System.Drawing.Size(103, 34);
            this.btnTransiciones.TabIndex = 11;
            this.btnTransiciones.Text = "TRANSICIONES";
            this.btnTransiciones.UseVisualStyleBackColor = true;
            this.btnTransiciones.Click += new System.EventHandler(this.btnTransiciones_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 654);
            this.Controls.Add(this.btnTransiciones);
            this.Controls.Add(this.btnAFD);
            this.Controls.Add(this.btnAFN);
            this.Controls.Add(this.txtExpresionReg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txaExpresiones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txaSalida);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.txaEntrada);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txaEntrada;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txaSalida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txaExpresiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpresionReg;
        private System.Windows.Forms.Button btnAFN;
        private System.Windows.Forms.Button btnAFD;
        private System.Windows.Forms.Button btnTransiciones;
    }
}

