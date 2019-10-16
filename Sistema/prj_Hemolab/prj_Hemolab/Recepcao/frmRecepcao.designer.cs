namespace prj_Hemolab
{
    partial class frmRecepcao
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
            this.btnDoador = new System.Windows.Forms.Button();
            this.btnNovaDoacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDoador
            // 
            this.btnDoador.BackgroundImage = global::prj_Hemolab.Properties.Resources.doador1;
            this.btnDoador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoador.FlatAppearance.BorderSize = 0;
            this.btnDoador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoador.Location = new System.Drawing.Point(443, 12);
            this.btnDoador.Name = "btnDoador";
            this.btnDoador.Size = new System.Drawing.Size(200, 200);
            this.btnDoador.TabIndex = 2;
            this.btnDoador.UseVisualStyleBackColor = true;
            this.btnDoador.Click += new System.EventHandler(this.btnDoador_Click);
            // 
            // btnNovaDoacao
            // 
            this.btnNovaDoacao.BackgroundImage = global::prj_Hemolab.Properties.Resources.novadoacao3;
            this.btnNovaDoacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNovaDoacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovaDoacao.FlatAppearance.BorderSize = 0;
            this.btnNovaDoacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaDoacao.Location = new System.Drawing.Point(12, 12);
            this.btnNovaDoacao.Name = "btnNovaDoacao";
            this.btnNovaDoacao.Size = new System.Drawing.Size(200, 200);
            this.btnNovaDoacao.TabIndex = 0;
            this.btnNovaDoacao.UseVisualStyleBackColor = true;
            this.btnNovaDoacao.Click += new System.EventHandler(this.btnNovaDoacao_Click);
            // 
            // frmRecepcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 306);
            this.Controls.Add(this.btnDoador);
            this.Controls.Add(this.btnNovaDoacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRecepcao";
            this.Text = "frmRecepcao";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNovaDoacao;
        private System.Windows.Forms.Button btnDoador;


    }
}