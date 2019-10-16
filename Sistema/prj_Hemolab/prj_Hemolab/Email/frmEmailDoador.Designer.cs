namespace prj_Hemolab
{
    partial class frmEmailDoador
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tblEmail = new System.Windows.Forms.DataGridView();
            this.btnMandarTodos = new System.Windows.Forms.Button();
            this.btnRemoverTodos = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblEmail)).BeginInit();
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
            this.label1.TabIndex = 32;
            this.label1.Text = "E-mails Pendentes";
            // 
            // tblEmail
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEmail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.tblEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblEmail.DefaultCellStyle = dataGridViewCellStyle8;
            this.tblEmail.Location = new System.Drawing.Point(34, 69);
            this.tblEmail.MultiSelect = false;
            this.tblEmail.Name = "tblEmail";
            this.tblEmail.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblEmail.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.tblEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblEmail.Size = new System.Drawing.Size(677, 289);
            this.tblEmail.TabIndex = 31;
            this.tblEmail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblEmail_CellDoubleClick);
            // 
            // btnMandarTodos
            // 
            this.btnMandarTodos.BackgroundImage = global::prj_Hemolab.Properties.Resources.mandartodos;
            this.btnMandarTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMandarTodos.FlatAppearance.BorderSize = 0;
            this.btnMandarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMandarTodos.Location = new System.Drawing.Point(498, 370);
            this.btnMandarTodos.Name = "btnMandarTodos";
            this.btnMandarTodos.Size = new System.Drawing.Size(213, 43);
            this.btnMandarTodos.TabIndex = 33;
            this.btnMandarTodos.UseVisualStyleBackColor = true;
            this.btnMandarTodos.Click += new System.EventHandler(this.btnMandarTodos_Click);
            // 
            // btnRemoverTodos
            // 
            this.btnRemoverTodos.BackgroundImage = global::prj_Hemolab.Properties.Resources.removertodos;
            this.btnRemoverTodos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoverTodos.FlatAppearance.BorderSize = 0;
            this.btnRemoverTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverTodos.Location = new System.Drawing.Point(267, 370);
            this.btnRemoverTodos.Name = "btnRemoverTodos";
            this.btnRemoverTodos.Size = new System.Drawing.Size(213, 43);
            this.btnRemoverTodos.TabIndex = 34;
            this.btnRemoverTodos.UseVisualStyleBackColor = true;
            this.btnRemoverTodos.Click += new System.EventHandler(this.btnRemoverTodos_Click);
            // 
            // btnVer
            // 
            this.btnVer.BackgroundImage = global::prj_Hemolab.Properties.Resources.ver1;
            this.btnVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Location = new System.Drawing.Point(34, 370);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(91, 39);
            this.btnVer.TabIndex = 35;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // frmEmailDoador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = global::prj_Hemolab.Properties.Resources.borda2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(747, 435);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnRemoverTodos);
            this.Controls.Add(this.btnMandarTodos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblEmail);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmailDoador";
            this.Text = "frmEmailDoador";
            this.Load += new System.EventHandler(this.frmEmailDoador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblEmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tblEmail;
        private System.Windows.Forms.Button btnMandarTodos;
        private System.Windows.Forms.Button btnRemoverTodos;
        private System.Windows.Forms.Button btnVer;
    }
}