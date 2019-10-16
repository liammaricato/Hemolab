namespace prj_Hemolab.Sala_de_Coleta
{
    partial class frmSalaDeColeta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSala = new System.Windows.Forms.Label();
            this.btnProsseguir = new System.Windows.Forms.Button();
            this.tblEspera = new System.Windows.Forms.DataGridView();
            this.btnCancelarDoacao = new System.Windows.Forms.Button();
            this.btnTrocaSala = new System.Windows.Forms.Button();
            this.pnlSaladeColeta = new System.Windows.Forms.Panel();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.tblColeta = new System.Windows.Forms.DataGridView();
            this.tmrColeta = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tblEspera)).BeginInit();
            this.pnlSaladeColeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblColeta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblSala.Location = new System.Drawing.Point(29, 24);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(173, 25);
            this.lblSala.TabIndex = 32;
            this.lblSala.Text = "Sala de Espera";
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
            this.btnProsseguir.TabIndex = 31;
            this.btnProsseguir.UseVisualStyleBackColor = true;
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
            // 
            // tblEspera
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEspera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tblEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblEspera.DefaultCellStyle = dataGridViewCellStyle2;
            this.tblEspera.Location = new System.Drawing.Point(34, 69);
            this.tblEspera.MultiSelect = false;
            this.tblEspera.Name = "tblEspera";
            this.tblEspera.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEspera.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tblEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEspera.Size = new System.Drawing.Size(557, 317);
            this.tblEspera.TabIndex = 30;
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
            this.btnCancelarDoacao.TabIndex = 33;
            this.btnCancelarDoacao.UseVisualStyleBackColor = true;
            this.btnCancelarDoacao.Click += new System.EventHandler(this.btnCancelarDoacao_Click);
            // 
            // btnTrocaSala
            // 
            this.btnTrocaSala.BackgroundImage = global::prj_Hemolab.Properties.Resources.bordaretangular;
            this.btnTrocaSala.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrocaSala.FlatAppearance.BorderSize = 0;
            this.btnTrocaSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrocaSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrocaSala.Location = new System.Drawing.Point(395, 18);
            this.btnTrocaSala.Name = "btnTrocaSala";
            this.btnTrocaSala.Size = new System.Drawing.Size(196, 38);
            this.btnTrocaSala.TabIndex = 34;
            this.btnTrocaSala.Text = "Ver Sala de Coleta";
            this.btnTrocaSala.UseVisualStyleBackColor = true;
            this.btnTrocaSala.Click += new System.EventHandler(this.btnTrocaSala_Click);
            // 
            // pnlSaladeColeta
            // 
            this.pnlSaladeColeta.Controls.Add(this.btnConcluir);
            this.pnlSaladeColeta.Controls.Add(this.tblColeta);
            this.pnlSaladeColeta.Location = new System.Drawing.Point(34, 69);
            this.pnlSaladeColeta.Name = "pnlSaladeColeta";
            this.pnlSaladeColeta.Size = new System.Drawing.Size(557, 376);
            this.pnlSaladeColeta.TabIndex = 35;
            this.pnlSaladeColeta.Visible = false;
            // 
            // btnConcluir
            // 
            this.btnConcluir.BackgroundImage = global::prj_Hemolab.Properties.Resources.concluir;
            this.btnConcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConcluir.FlatAppearance.BorderSize = 0;
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Location = new System.Drawing.Point(404, 333);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(153, 43);
            this.btnConcluir.TabIndex = 35;
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // tblColeta
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblColeta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tblColeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblColeta.DefaultCellStyle = dataGridViewCellStyle5;
            this.tblColeta.Location = new System.Drawing.Point(0, 0);
            this.tblColeta.MultiSelect = false;
            this.tblColeta.Name = "tblColeta";
            this.tblColeta.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblColeta.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.tblColeta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblColeta.Size = new System.Drawing.Size(557, 317);
            this.tblColeta.TabIndex = 34;
            // 
            // tmrColeta
            // 
            this.tmrColeta.Interval = 5000;
            this.tmrColeta.Tick += new System.EventHandler(this.tmrColeta_Tick);
            // 
            // frmSalaDeColeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 468);
            this.Controls.Add(this.pnlSaladeColeta);
            this.Controls.Add(this.btnTrocaSala);
            this.Controls.Add(this.btnCancelarDoacao);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.btnProsseguir);
            this.Controls.Add(this.tblEspera);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalaDeColeta";
            this.Text = "frmSalaDeColeta";
            this.Load += new System.EventHandler(this.frmSalaDeColeta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblEspera)).EndInit();
            this.pnlSaladeColeta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblColeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Button btnProsseguir;
        private System.Windows.Forms.DataGridView tblEspera;
        private System.Windows.Forms.Button btnCancelarDoacao;
        private System.Windows.Forms.Button btnTrocaSala;
        private System.Windows.Forms.Panel pnlSaladeColeta;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.DataGridView tblColeta;
        private System.Windows.Forms.Timer tmrColeta;

    }
}