namespace prj_Hemolab.Triagem
{
    partial class frmTriagemDoador
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRG = new System.Windows.Forms.Label();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnReprovar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "RG:";
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
            this.btnFechar.Location = new System.Drawing.Point(480, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 25);
            this.btnFechar.TabIndex = 40;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.MouseEnter += new System.EventHandler(this.btnFechar_MouseEnter);
            this.btnFechar.MouseLeave += new System.EventHandler(this.btnFechar_MouseLeave);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(123, 65);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(182, 25);
            this.lblNome.TabIndex = 24;
            this.lblNome.Text = "João Figueiredo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome:";
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRG.Location = new System.Drawing.Point(96, 27);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(151, 25);
            this.lblRG.TabIndex = 22;
            this.lblRG.Text = "12.345.678-9";
            // 
            // btnAprovar
            // 
            this.btnAprovar.BackgroundImage = global::prj_Hemolab.Properties.Resources.aprovar1;
            this.btnAprovar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAprovar.FlatAppearance.BorderSize = 0;
            this.btnAprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprovar.Location = new System.Drawing.Point(103, 120);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(138, 40);
            this.btnAprovar.TabIndex = 19;
            this.btnAprovar.UseVisualStyleBackColor = true;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // btnReprovar
            // 
            this.btnReprovar.BackgroundImage = global::prj_Hemolab.Properties.Resources.reprovar1;
            this.btnReprovar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReprovar.FlatAppearance.BorderSize = 0;
            this.btnReprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprovar.Location = new System.Drawing.Point(286, 120);
            this.btnReprovar.Name = "btnReprovar";
            this.btnReprovar.Size = new System.Drawing.Size(138, 40);
            this.btnReprovar.TabIndex = 18;
            this.btnReprovar.UseVisualStyleBackColor = true;
            this.btnReprovar.Click += new System.EventHandler(this.btnReprovar_Click);
            // 
            // frmTriagemDoador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(517, 191);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReprovar);
            this.Controls.Add(this.lblRG);
            this.Controls.Add(this.btnAprovar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTriagemDoador";
            this.Text = "frmTriagemDoador";
            this.Load += new System.EventHandler(this.frmTriagemDoador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReprovar;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.Button btnFechar;
    }
}