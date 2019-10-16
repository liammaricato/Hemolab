namespace prj_Hemolab.Distribuicao
{
    partial class frmRegistrarSaida
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
            this.label1 = new System.Windows.Forms.Label();
            this.tblAdicionar = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCdBolsa = new System.Windows.Forms.TextBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblAdicionar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Registrar Saída para Transfusão";
            // 
            // tblAdicionar
            // 
            this.tblAdicionar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAdicionar.Location = new System.Drawing.Point(28, 111);
            this.tblAdicionar.Name = "tblAdicionar";
            this.tblAdicionar.ReadOnly = true;
            this.tblAdicionar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblAdicionar.Size = new System.Drawing.Size(461, 262);
            this.tblAdicionar.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "Código:";
            // 
            // txtCdBolsa
            // 
            this.txtCdBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCdBolsa.Location = new System.Drawing.Point(116, 72);
            this.txtCdBolsa.Name = "txtCdBolsa";
            this.txtCdBolsa.Size = new System.Drawing.Size(208, 29);
            this.txtCdBolsa.TabIndex = 30;
            this.txtCdBolsa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCdBolsa_KeyDown);
            this.txtCdBolsa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCdBolsa_KeyPress);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAdicionar.FlatAppearance.BorderSize = 3;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.Location = new System.Drawing.Point(342, 69);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(104, 36);
            this.btnAdicionar.TabIndex = 31;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImage = global::prj_Hemolab.Properties.Resources.confirmar2;
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Location = new System.Drawing.Point(506, 298);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 75);
            this.btnConfirmar.TabIndex = 34;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackgroundImage = global::prj_Hemolab.Properties.Resources.remover;
            this.btnRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemover.FlatAppearance.BorderSize = 0;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Location = new System.Drawing.Point(506, 204);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 75);
            this.btnRemover.TabIndex = 33;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::prj_Hemolab.Properties.Resources.buscar1;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(506, 111);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 75);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmRegistrarSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(607, 401);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtCdBolsa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tblAdicionar);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistrarSaida";
            this.Text = "frmRegistrarReserva";
            this.Load += new System.EventHandler(this.frmRegistrarSaida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblAdicionar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblAdicionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCdBolsa;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnConfirmar;
    }
}