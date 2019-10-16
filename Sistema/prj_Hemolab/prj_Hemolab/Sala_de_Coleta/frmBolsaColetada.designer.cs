namespace prj_Hemolab.Sala_de_Coleta
{
    partial class frmBolsaColetada
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnConcluirCom = new System.Windows.Forms.Button();
            this.btnConcluirSem = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::prj_Hemolab.Properties.Resources.xfinalagoravai;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnFechar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Location = new System.Drawing.Point(532, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 25);
            this.btnFechar.TabIndex = 40;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.MouseEnter += new System.EventHandler(this.btnFechar_MouseEnter);
            this.btnFechar.MouseLeave += new System.EventHandler(this.btnFechar_MouseLeave);
            // 
            // btnConcluirCom
            // 
            this.btnConcluirCom.BackgroundImage = global::prj_Hemolab.Properties.Resources.concluircomsucesso;
            this.btnConcluirCom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConcluirCom.FlatAppearance.BorderSize = 0;
            this.btnConcluirCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluirCom.Location = new System.Drawing.Point(301, 134);
            this.btnConcluirCom.Name = "btnConcluirCom";
            this.btnConcluirCom.Size = new System.Drawing.Size(226, 45);
            this.btnConcluirCom.TabIndex = 27;
            this.btnConcluirCom.UseVisualStyleBackColor = true;
            this.btnConcluirCom.Click += new System.EventHandler(this.btnConcluirCom_Click);
            // 
            // btnConcluirSem
            // 
            this.btnConcluirSem.BackgroundImage = global::prj_Hemolab.Properties.Resources.concluirsemsucesso;
            this.btnConcluirSem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConcluirSem.FlatAppearance.BorderSize = 0;
            this.btnConcluirSem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluirSem.Location = new System.Drawing.Point(38, 134);
            this.btnConcluirSem.Name = "btnConcluirSem";
            this.btnConcluirSem.Size = new System.Drawing.Size(226, 45);
            this.btnConcluirSem.TabIndex = 26;
            this.btnConcluirSem.UseVisualStyleBackColor = true;
            this.btnConcluirSem.Click += new System.EventHandler(this.btnConcluirSem_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(124, 68);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(182, 25);
            this.lblNome.TabIndex = 24;
            this.lblNome.Text = "João Figueiredo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Nome:";
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRG.Location = new System.Drawing.Point(124, 29);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(155, 25);
            this.lblRG.TabIndex = 22;
            this.lblRG.Text = "12345678910";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(66, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "RG:";
            // 
            // frmBolsaColetada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(569, 220);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConcluirCom);
            this.Controls.Add(this.btnConcluirSem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblRG);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBolsaColetada";
            this.Text = "frmBolsaColetada";
            this.Load += new System.EventHandler(this.frmBolsaColetada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConcluirSem;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnConcluirCom;
        private System.Windows.Forms.Button btnFechar;
    }
}