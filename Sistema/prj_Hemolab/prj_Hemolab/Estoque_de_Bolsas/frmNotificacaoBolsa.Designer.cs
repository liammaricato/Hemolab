namespace prj_Hemolab.Estoque_de_Bolsas
{
    partial class frmNotificacaoBolsa
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
            this.lblOcorrencia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCdBolsa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTipoFracionamento = new System.Windows.Forms.Label();
            this.btnFeito = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOcorrencia
            // 
            this.lblOcorrencia.BackColor = System.Drawing.Color.PaleGreen;
            this.lblOcorrencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcorrencia.Location = new System.Drawing.Point(12, 9);
            this.lblOcorrencia.Name = "lblOcorrencia";
            this.lblOcorrencia.Size = new System.Drawing.Size(504, 79);
            this.lblOcorrencia.TabIndex = 0;
            this.lblOcorrencia.Text = "Bolsa liberada: A bolsa de sangue passou nos exames, coloque-a na respectiva gela" +
                "deira de sangue liberado.";
            this.lblOcorrencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "Código da bolsa:";
            // 
            // lblCdBolsa
            // 
            this.lblCdBolsa.AutoSize = true;
            this.lblCdBolsa.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCdBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCdBolsa.Location = new System.Drawing.Point(177, 102);
            this.lblCdBolsa.Name = "lblCdBolsa";
            this.lblCdBolsa.Size = new System.Drawing.Size(120, 24);
            this.lblCdBolsa.TabIndex = 32;
            this.lblCdBolsa.Text = "37651603311";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tipo de Fracionamento:";
            // 
            // lblTipoFracionamento
            // 
            this.lblTipoFracionamento.AutoSize = true;
            this.lblTipoFracionamento.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTipoFracionamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoFracionamento.Location = new System.Drawing.Point(237, 136);
            this.lblTipoFracionamento.Name = "lblTipoFracionamento";
            this.lblTipoFracionamento.Size = new System.Drawing.Size(235, 24);
            this.lblTipoFracionamento.TabIndex = 34;
            this.lblTipoFracionamento.Text = "Concentrado de Hemácias";
            // 
            // btnFeito
            // 
            this.btnFeito.BackgroundImage = global::prj_Hemolab.Properties.Resources.feito2;
            this.btnFeito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFeito.FlatAppearance.BorderSize = 0;
            this.btnFeito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeito.Location = new System.Drawing.Point(291, 183);
            this.btnFeito.Name = "btnFeito";
            this.btnFeito.Size = new System.Drawing.Size(129, 48);
            this.btnFeito.TabIndex = 35;
            this.btnFeito.UseVisualStyleBackColor = true;
            this.btnFeito.Click += new System.EventHandler(this.btnFeito_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::prj_Hemolab.Properties.Resources.cancelar2;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(104, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 48);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmNotificacaoBolsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 253);
            this.Controls.Add(this.btnFeito);
            this.Controls.Add(this.lblTipoFracionamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCdBolsa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblOcorrencia);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificacaoBolsa";
            this.Text = "frmEncaminharBolsa";
            this.Load += new System.EventHandler(this.frmNotificacaoBolsa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOcorrencia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCdBolsa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTipoFracionamento;
        private System.Windows.Forms.Button btnFeito;

    }
}