
namespace Sistema_Facturacion_Restaurantes.Forms
{
    partial class FrmOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxFormaPago = new System.Windows.Forms.GroupBox();
            this.rbtnCredito = new System.Windows.Forms.RadioButton();
            this.rbtnContado = new System.Windows.Forms.RadioButton();
            this.cmbMesas = new System.Windows.Forms.ComboBox();
            this.cmbMeseros = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbxFormaPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxFormaPago
            // 
            this.gbxFormaPago.Controls.Add(this.rbtnCredito);
            this.gbxFormaPago.Controls.Add(this.rbtnContado);
            this.gbxFormaPago.Location = new System.Drawing.Point(111, 125);
            this.gbxFormaPago.Name = "gbxFormaPago";
            this.gbxFormaPago.Size = new System.Drawing.Size(200, 83);
            this.gbxFormaPago.TabIndex = 51;
            this.gbxFormaPago.TabStop = false;
            this.gbxFormaPago.Text = "Forma de pago";
            // 
            // rbtnCredito
            // 
            this.rbtnCredito.AutoSize = true;
            this.rbtnCredito.Location = new System.Drawing.Point(6, 49);
            this.rbtnCredito.Name = "rbtnCredito";
            this.rbtnCredito.Size = new System.Drawing.Size(128, 21);
            this.rbtnCredito.TabIndex = 1;
            this.rbtnCredito.Text = "Credito (tarjeta)";
            this.rbtnCredito.UseVisualStyleBackColor = true;
            this.rbtnCredito.CheckedChanged += new System.EventHandler(this.rbtnCredito_CheckedChanged);
            // 
            // rbtnContado
            // 
            this.rbtnContado.AutoSize = true;
            this.rbtnContado.Checked = true;
            this.rbtnContado.Location = new System.Drawing.Point(7, 22);
            this.rbtnContado.Name = "rbtnContado";
            this.rbtnContado.Size = new System.Drawing.Size(82, 21);
            this.rbtnContado.TabIndex = 0;
            this.rbtnContado.TabStop = true;
            this.rbtnContado.Text = "Contado";
            this.rbtnContado.UseVisualStyleBackColor = true;
            this.rbtnContado.CheckedChanged += new System.EventHandler(this.rbtnContado_CheckedChanged);
            // 
            // cmbMesas
            // 
            this.cmbMesas.FormattingEnabled = true;
            this.cmbMesas.Location = new System.Drawing.Point(111, 83);
            this.cmbMesas.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMesas.Name = "cmbMesas";
            this.cmbMesas.Size = new System.Drawing.Size(265, 24);
            this.cmbMesas.TabIndex = 50;
            // 
            // cmbMeseros
            // 
            this.cmbMeseros.FormattingEnabled = true;
            this.cmbMeseros.Location = new System.Drawing.Point(111, 31);
            this.cmbMeseros.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMeseros.Name = "cmbMeseros";
            this.cmbMeseros.Size = new System.Drawing.Size(265, 24);
            this.cmbMeseros.TabIndex = 47;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "\"yyyy-MM-dd hh:mm:ss.fff\"";
            this.dtpFecha.Location = new System.Drawing.Point(111, 240);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(265, 22);
            this.dtpFecha.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 45;
            this.label6.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "Mesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Mesero:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(111, 288);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(76, 39);
            this.btnGuardar.TabIndex = 52;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(301, 288);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 39);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 355);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbxFormaPago);
            this.Controls.Add(this.cmbMesas);
            this.Controls.Add(this.cmbMeseros);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden";
            this.gbxFormaPago.ResumeLayout(false);
            this.gbxFormaPago.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFormaPago;
        private System.Windows.Forms.RadioButton rbtnCredito;
        private System.Windows.Forms.RadioButton rbtnContado;
        private System.Windows.Forms.ComboBox cmbMesas;
        private System.Windows.Forms.ComboBox cmbMeseros;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}