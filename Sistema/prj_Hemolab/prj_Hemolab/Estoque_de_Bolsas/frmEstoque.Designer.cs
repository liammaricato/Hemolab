namespace prj_Hemolab.Estoque_de_Bolsas
{
    partial class frmEstoque
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tblEstoque = new System.Windows.Forms.DataGridView();
            this.tmrSelect = new System.Windows.Forms.Timer(this.components);
            this.btnVer = new System.Windows.Forms.Button();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.rdbLiberada = new System.Windows.Forms.RadioButton();
            this.rdbReprovada = new System.Windows.Forms.RadioButton();
            this.rdbValidade = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tblEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 30;
            this.label1.Text = "Estoque de Bolsas";
            // 
            // tblEstoque
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.tblEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblEstoque.DefaultCellStyle = dataGridViewCellStyle11;
            this.tblEstoque.Location = new System.Drawing.Point(34, 109);
            this.tblEstoque.MultiSelect = false;
            this.tblEstoque.Name = "tblEstoque";
            this.tblEstoque.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEstoque.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.tblEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEstoque.Size = new System.Drawing.Size(647, 310);
            this.tblEstoque.TabIndex = 28;
            this.tblEstoque.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblEstoque_CellDoubleClick);
            // 
            // tmrSelect
            // 
            this.tmrSelect.Enabled = true;
            this.tmrSelect.Interval = 5000;
            this.tmrSelect.Tick += new System.EventHandler(this.tmrSelect_Tick);
            // 
            // btnVer
            // 
            this.btnVer.BackgroundImage = global::prj_Hemolab.Properties.Resources.prosseguir;
            this.btnVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Location = new System.Drawing.Point(530, 428);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(151, 44);
            this.btnVer.TabIndex = 36;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Checked = true;
            this.rdbTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTodos.Location = new System.Drawing.Point(43, 76);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(71, 24);
            this.rdbTodos.TabIndex = 37;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbLiberada
            // 
            this.rdbLiberada.AutoSize = true;
            this.rdbLiberada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLiberada.Location = new System.Drawing.Point(158, 76);
            this.rdbLiberada.Name = "rdbLiberada";
            this.rdbLiberada.Size = new System.Drawing.Size(89, 24);
            this.rdbLiberada.TabIndex = 38;
            this.rdbLiberada.Text = "Liberada";
            this.rdbLiberada.UseVisualStyleBackColor = true;
            this.rdbLiberada.CheckedChanged += new System.EventHandler(this.rdbLiberada_CheckedChanged);
            // 
            // rdbReprovada
            // 
            this.rdbReprovada.AutoSize = true;
            this.rdbReprovada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbReprovada.Location = new System.Drawing.Point(278, 76);
            this.rdbReprovada.Name = "rdbReprovada";
            this.rdbReprovada.Size = new System.Drawing.Size(105, 24);
            this.rdbReprovada.TabIndex = 39;
            this.rdbReprovada.Text = "Reprovada";
            this.rdbReprovada.UseVisualStyleBackColor = true;
            this.rdbReprovada.CheckedChanged += new System.EventHandler(this.rdbReprovada_CheckedChanged);
            // 
            // rdbValidade
            // 
            this.rdbValidade.AutoSize = true;
            this.rdbValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbValidade.Location = new System.Drawing.Point(415, 76);
            this.rdbValidade.Name = "rdbValidade";
            this.rdbValidade.Size = new System.Drawing.Size(148, 24);
            this.rdbValidade.TabIndex = 40;
            this.rdbValidade.Text = "Fora da Validade";
            this.rdbValidade.UseVisualStyleBackColor = true;
            this.rdbValidade.CheckedChanged += new System.EventHandler(this.rdbValidade_CheckedChanged);
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 489);
            this.Controls.Add(this.rdbValidade);
            this.Controls.Add(this.rdbReprovada);
            this.Controls.Add(this.rdbLiberada);
            this.Controls.Add(this.rdbTodos);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblEstoque);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEstoque";
            this.Text = "frmEstoque";
            this.Load += new System.EventHandler(this.frmEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblEstoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblEstoque;
        private System.Windows.Forms.Timer tmrSelect;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdbLiberada;
        private System.Windows.Forms.RadioButton rdbReprovada;
        private System.Windows.Forms.RadioButton rdbValidade;

    }
}