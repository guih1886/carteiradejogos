namespace CarteiraDeJogosForms.Forms
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            Btn_Entrar = new Button();
            Btn_Sair = new Button();
            Lbl_Erro = new Label();
            Pic_Login = new PictureBox();
            Txt_Email = new TextBox();
            Txt_Senha = new TextBox();
            Lbl_Titulo = new Label();
            Btn_Cadastrar = new Button();
            Lbl_Email = new Label();
            Lbl_Senha = new Label();
            ((System.ComponentModel.ISupportInitialize)Pic_Login).BeginInit();
            SuspendLayout();
            // 
            // Btn_Entrar
            // 
            Btn_Entrar.Location = new Point(11, 309);
            Btn_Entrar.Name = "Btn_Entrar";
            Btn_Entrar.Size = new Size(99, 23);
            Btn_Entrar.TabIndex = 3;
            Btn_Entrar.Text = "Entrar";
            Btn_Entrar.UseVisualStyleBackColor = true;
            Btn_Entrar.Click += Btn_Entrar_Click;
            // 
            // Btn_Sair
            // 
            Btn_Sair.Location = new Point(193, 361);
            Btn_Sair.Name = "Btn_Sair";
            Btn_Sair.Size = new Size(100, 23);
            Btn_Sair.TabIndex = 5;
            Btn_Sair.Text = "Sair";
            Btn_Sair.UseVisualStyleBackColor = true;
            Btn_Sair.Click += Btn_Sair_Click;
            // 
            // Lbl_Erro
            // 
            Lbl_Erro.ForeColor = Color.Red;
            Lbl_Erro.Location = new Point(11, 335);
            Lbl_Erro.Name = "Lbl_Erro";
            Lbl_Erro.Size = new Size(282, 23);
            Lbl_Erro.TabIndex = 0;
            Lbl_Erro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Pic_Login
            // 
            Pic_Login.Image = Properties.Resources.login;
            Pic_Login.Location = new Point(11, 34);
            Pic_Login.Name = "Pic_Login";
            Pic_Login.Size = new Size(282, 172);
            Pic_Login.SizeMode = PictureBoxSizeMode.Zoom;
            Pic_Login.TabIndex = 3;
            Pic_Login.TabStop = false;
            // 
            // Txt_Email
            // 
            Txt_Email.Location = new Point(11, 231);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.PlaceholderText = "E-mail";
            Txt_Email.Size = new Size(282, 23);
            Txt_Email.TabIndex = 1;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(11, 280);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.PlaceholderText = "Senha";
            Txt_Senha.Size = new Size(282, 23);
            Txt_Senha.TabIndex = 2;
            // 
            // Lbl_Titulo
            // 
            Lbl_Titulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Titulo.Location = new Point(11, 1);
            Lbl_Titulo.Name = "Lbl_Titulo";
            Lbl_Titulo.Size = new Size(282, 30);
            Lbl_Titulo.TabIndex = 5;
            Lbl_Titulo.Text = "Carteira de Jogos - Login";
            Lbl_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Btn_Cadastrar
            // 
            Btn_Cadastrar.Location = new Point(193, 309);
            Btn_Cadastrar.Name = "Btn_Cadastrar";
            Btn_Cadastrar.Size = new Size(99, 23);
            Btn_Cadastrar.TabIndex = 4;
            Btn_Cadastrar.Text = "Cadastrar";
            Btn_Cadastrar.UseVisualStyleBackColor = true;
            Btn_Cadastrar.Click += Btn_Cadastrar_Click;
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Email.Location = new Point(12, 209);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(56, 19);
            Lbl_Email.TabIndex = 0;
            Lbl_Email.Text = "E-mail";
            // 
            // Lbl_Senha
            // 
            Lbl_Senha.AutoSize = true;
            Lbl_Senha.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Senha.Location = new Point(12, 257);
            Lbl_Senha.Name = "Lbl_Senha";
            Lbl_Senha.Size = new Size(58, 19);
            Lbl_Senha.TabIndex = 0;
            Lbl_Senha.Text = "Senha";
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(305, 394);
            Controls.Add(Lbl_Senha);
            Controls.Add(Lbl_Email);
            Controls.Add(Btn_Cadastrar);
            Controls.Add(Lbl_Titulo);
            Controls.Add(Txt_Senha);
            Controls.Add(Txt_Email);
            Controls.Add(Pic_Login);
            Controls.Add(Lbl_Erro);
            Controls.Add(Btn_Sair);
            Controls.Add(Btn_Entrar);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CJ - Login";
            ((System.ComponentModel.ISupportInitialize)Pic_Login).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Entrar;
        private Button Btn_Sair;
        private Label Lbl_Erro;
        private PictureBox Pic_Login;
        private TextBox Txt_Email;
        private TextBox Txt_Senha;
        private Label Lbl_Titulo;
        private Button Btn_Cadastrar;
        private Label Lbl_Email;
        private Label Lbl_Senha;
    }
}