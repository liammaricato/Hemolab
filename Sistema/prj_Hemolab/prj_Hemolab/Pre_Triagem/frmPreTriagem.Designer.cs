namespace prj_Hemolab.Pre_Triagem
{
    partial class frmPreTriagem
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tblPreTriagem = new System.Windows.Forms.DataGridView();
            this.btnCancelarDoacao = new System.Windows.Forms.Button();
            this.btnProsseguir = new System.Windows.Forms.Button();
            this.tmrPreTriagem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblPreTriagem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Pré-Triagem";
            // 
            // tblPreTriagem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblPreTriagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblPreTriagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblPreTriagem.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblPreTriagem.Location = new System.Drawing.Point(34, 69);
            this.tblPreTriagem.MultiSelect = false;
            this.tblPreTriagem.Name = "tblPreTriagem";
            this.tblPreTriagem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblPreTriagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblPreTriagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblPreTriagem.Size = new System.Drawing.Size(557, 317);
            this.tblPreTriagem.TabIndex = 24;
            // 
            // btnCancelarDoacao
            // 
            this.btnCancelarDoacao.BackgroundImage = global::prj_Hemolab.Properties.Resources.cancelardoacao;
            this.btnCancelarDoacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarDoacao.FlatAppearance.BorderSize = 0;
            this.btnCancelarDoacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarDoacao.Location = new System.Drawing.Point(34, 402);
            this.btnCancelarDoacao.Name = "btnCancelarDoacao";
            this.btnCancelarDoacao.Size = new System.Drawing.Size(223, 43);
            this.btnCancelarDoacao.TabIndex = 27;
            this.btnCancelarDoacao.UseVisualStyleBackColor = true;
            this.btnCancelarDoacao.Click += new System.EventHandler(this.btnCancelarDoacao_Click);
            // 
            // btnProsseguir
            // 
            this.btnProsseguir.BackgroundImage = global::prj_Hemolab.Properties.Resources.prosseguir;
            this.btnProsseguir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProsseguir.FlatAppearance.BorderSize = 0;
            this.btnProsseguir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProsseguir.Location = new System.Drawing.Point(438, 402);
            this.btnProsseguir.Name = "btnProsseguir";
            this.btnProsseguir.Size = new System.Drawing.Size(153, 43);
            this.btnProsseguir.TabIndex = 25;
            this.btnProsseguir.UseVisualStyleBackColor = true;
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
            // 
            // tmrPreTriagem
            // 
            this.tmrPreTriagem.Interval = 10000;
            this.tmrPreTriagem.Tick += new System.EventHandler(this.tmrPreTriagem_Tick);
            // 
            // frmPreTriagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 468);
            this.Controls.Add(this.btnCancelarDoacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProsseguir);
            this.Controls.Add(this.tblPreTriagem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreTriagem";
            this.Text = "frmPreTriagem";
            this.Load += new System.EventHandler(this.frmPreTriagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblPreTriagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProsseguir;
        private System.Windows.Forms.DataGridView tblPreTriagem;
        private System.Windows.Forms.Button btnCancelarDoacao;
        private System.Windows.Forms.Timer tmrPreTriagem;

    }
}