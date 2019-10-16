namespace prj_Hemolab
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pcbUsuario = new System.Windows.Forms.PictureBox();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.pcbCabecalho = new System.Windows.Forms.PictureBox();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnTrocarUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrPainelUsuario = new System.Windows.Forms.Timer(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCabecalho)).BeginInit();
            this.pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(662, 69);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(518, 24);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Bem vindo, ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pcbUsuario
            // 
            this.pcbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbUsuario.BackgroundImage = global::prj_Hemolab.Properties.Resources.Usuario2;
            this.pcbUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbUsuario.Location = new System.Drawing.Point(1182, 33);
            this.pcbUsuario.Name = "pcbUsuario";
            this.pcbUsuario.Size = new System.Drawing.Size(60, 60);
            this.pcbUsuario.TabIndex = 5;
            this.pcbUsuario.TabStop = false;
            this.pcbUsuario.Click += new System.EventHandler(this.pcbUsuario_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.BackgroundImage = global::prj_Hemolab.Properties.Resources.logoteste;
            this.pcbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbLogo.Location = new System.Drawing.Point(17, 17);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(324, 93);
            this.pcbLogo.TabIndex = 4;
            this.pcbLogo.TabStop = false;
            // 
            // pcbCabecalho
            // 
            this.pcbCabecalho.BackColor = System.Drawing.Color.White;
            this.pcbCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcbCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pcbCabecalho.Name = "pcbCabecalho";
            this.pcbCabecalho.Size = new System.Drawing.Size(1280, 130);
            this.pcbCabecalho.TabIndex = 3;
            this.pcbCabecalho.TabStop = false;
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUsuario.BackColor = System.Drawing.Color.LightGray;
            this.pnlUsuario.Controls.Add(this.btnSair);
            this.pnlUsuario.Controls.Add(this.btnTrocarUsuario);
            this.pnlUsuario.Location = new System.Drawing.Point(1112, 11);
            this.pnlUsuario.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(130, 80);
            this.pnlUsuario.TabIndex = 9;
            // 
            // btnSair
            // 
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(0, 40);
            this.btnSair.Margin = new System.Windows.Forms.Padding(0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(130, 40);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnTrocarUsuario
            // 
            this.btnTrocarUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrocarUsuario.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTrocarUsuario.FlatAppearance.BorderSize = 0;
            this.btnTrocarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnTrocarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.btnTrocarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrocarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrocarUsuario.Location = new System.Drawing.Point(0, 0);
            this.btnTrocarUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrocarUsuario.Name = "btnTrocarUsuario";
            this.btnTrocarUsuario.Size = new System.Drawing.Size(130, 40);
            this.btnTrocarUsuario.TabIndex = 8;
            this.btnTrocarUsuario.Text = "Trocar Usuário";
            this.btnTrocarUsuario.UseVisualStyleBackColor = false;
            this.btnTrocarUsuario.Click += new System.EventHandler(this.btnTrocarUsuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(1112, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 93);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // tmrPainelUsuario
            // 
            this.tmrPainelUsuario.Interval = 1;
            this.tmrPainelUsuario.Tick += new System.EventHandler(this.tmrPainelUsuario_Tick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.Control;
            this.btnVoltar.BackgroundImage = global::prj_Hemolab.Properties.Resources.voltar;
            this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Location = new System.Drawing.Point(18, 147);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(50, 50);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseEnter += new System.EventHandler(this.btnVoltar_MouseEnter);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pcbUsuario);
            this.Controls.Add(this.pcbLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.pcbCabecalho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCabecalho)).EndInit();
            this.pnlUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbCabecalho;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.PictureBox pcbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnTrocarUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrPainelUsuario;
        private System.Windows.Forms.Button btnVoltar;
    }
}

