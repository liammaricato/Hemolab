namespace prj_Hemolab.Triagem
{
    partial class frmTriagem
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
            this.tblTriagem = new System.Windows.Forms.DataGridView();
            this.btnProsseguir = new System.Windows.Forms.Button();
            this.btnCancelarDoacao = new System.Windows.Forms.Button();
            this.tmrTriagem = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblTriagem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Triagem";
            // 
            // tblTriagem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblTriagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblTriagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblTriagem.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblTriagem.Location = new System.Drawing.Point(34, 69);
            this.tblTriagem.MultiSelect = false;
            this.tblTriagem.Name = "tblTriagem";
            this.tblTriagem.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblTriagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblTriagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTriagem.Size = new System.Drawing.Size(557, 317);
            this.tblTriagem.TabIndex = 27;
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
            this.btnProsseguir.TabIndex = 28;
            this.btnProsseguir.UseVisualStyleBackColor = true;
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
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
            this.btnCancelarDoacao.TabIndex = 30;
            this.btnCancelarDoacao.UseVisualStyleBackColor = true;
            this.btnCancelarDoacao.Click += new System.EventHandler(this.btnCancelarDoacao_Click);
            // 
            // tmrTriagem
            // 
            this.tmrTriagem.Interval = 10000;
            this.tmrTriagem.Tick += new System.EventHandler(this.tmrTriagem_Tick);
            // 
            // frmTriagem
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
            this.Controls.Add(this.tblTriagem);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTriagem";
            this.Text = "Triagem";
            this.Load += new System.EventHandler(this.frmTriagem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblTriagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProsseguir;
        private System.Windows.Forms.DataGridView tblTriagem;
        private System.Windows.Forms.Button btnCancelarDoacao;
        private System.Windows.Forms.Timer tmrTriagem;


    }
}