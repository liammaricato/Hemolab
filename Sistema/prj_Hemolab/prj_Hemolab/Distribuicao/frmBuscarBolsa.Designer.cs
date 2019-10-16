namespace prj_Hemolab.Distribuicao
{
    partial class frmBuscarBolsa
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbABO = new System.Windows.Forms.ComboBox();
            this.cmbRh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tblBuscarBolsa = new System.Windows.Forms.DataGridView();
            this.cmbFracionamento = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProsseguir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblBuscarBolsa)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tipo Sanguíneo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Buscar Bolsa";
            // 
            // cmbABO
            // 
            this.cmbABO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbABO.FormattingEnabled = true;
            this.cmbABO.Items.AddRange(new object[] {
            "(nenhum) ",
            " A",
            " B",
            " AB",
            " O"});
            this.cmbABO.Location = new System.Drawing.Point(182, 64);
            this.cmbABO.Name = "cmbABO";
            this.cmbABO.Size = new System.Drawing.Size(122, 32);
            this.cmbABO.TabIndex = 32;
            // 
            // cmbRh
            // 
            this.cmbRh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRh.FormattingEnabled = true;
            this.cmbRh.Items.AddRange(new object[] {
            "(nenhum) ",
            " +",
            "  -"});
            this.cmbRh.Location = new System.Drawing.Point(373, 64);
            this.cmbRh.Name = "cmbRh";
            this.cmbRh.Size = new System.Drawing.Size(122, 32);
            this.cmbRh.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(328, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 24);
            this.label3.TabIndex = 33;
            this.label3.Text = "Rh:";
            // 
            // tblBuscarBolsa
            // 
            this.tblBuscarBolsa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblBuscarBolsa.Location = new System.Drawing.Point(30, 154);
            this.tblBuscarBolsa.Name = "tblBuscarBolsa";
            this.tblBuscarBolsa.ReadOnly = true;
            this.tblBuscarBolsa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblBuscarBolsa.Size = new System.Drawing.Size(547, 220);
            this.tblBuscarBolsa.TabIndex = 36;
            // 
            // cmbFracionamento
            // 
            this.cmbFracionamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFracionamento.FormattingEnabled = true;
            this.cmbFracionamento.Items.AddRange(new object[] {
            "(nenhum)",
            "Hemácias",
            "Plasma",
            "Plaquetas"});
            this.cmbFracionamento.Location = new System.Drawing.Point(174, 110);
            this.cmbFracionamento.Name = "cmbFracionamento";
            this.cmbFracionamento.Size = new System.Drawing.Size(151, 32);
            this.cmbFracionamento.TabIndex = 38;
            this.cmbFracionamento.SelectedIndexChanged += new System.EventHandler(this.cmbFracionamento_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 24);
            this.label4.TabIndex = 37;
            this.label4.Text = "Fracionamento:";
            // 
            // btnProsseguir
            // 
            this.btnProsseguir.BackgroundImage = global::prj_Hemolab.Properties.Resources.prosseguir;
            this.btnProsseguir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProsseguir.FlatAppearance.BorderSize = 0;
            this.btnProsseguir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProsseguir.Location = new System.Drawing.Point(434, 383);
            this.btnProsseguir.Name = "btnProsseguir";
            this.btnProsseguir.Size = new System.Drawing.Size(143, 43);
            this.btnProsseguir.TabIndex = 39;
            this.btnProsseguir.UseVisualStyleBackColor = true;
            this.btnProsseguir.Click += new System.EventHandler(this.btnProsseguir_Click);
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
            this.btnFechar.Location = new System.Drawing.Point(569, 12);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 25);
            this.btnFechar.TabIndex = 41;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.MouseEnter += new System.EventHandler(this.btnFechar_MouseEnter);
            this.btnFechar.MouseLeave += new System.EventHandler(this.btnFechar_MouseLeave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscar.FlatAppearance.BorderSize = 3;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(373, 107);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 37);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmBuscarBolsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(606, 441);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnProsseguir);
            this.Controls.Add(this.cmbFracionamento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tblBuscarBolsa);
            this.Controls.Add(this.cmbRh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbABO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBuscarBolsa";
            this.Text = "frmRequisitarBolsa";
            this.Load += new System.EventHandler(this.frmBuscarBolsa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblBuscarBolsa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbABO;
        private System.Windows.Forms.ComboBox cmbRh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tblBuscarBolsa;
        private System.Windows.Forms.ComboBox cmbFracionamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProsseguir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnBuscar;
    }
}