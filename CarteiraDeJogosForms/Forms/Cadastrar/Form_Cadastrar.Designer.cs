namespace CarteiraDeJogosForms.Forms.Cadastrar
{
    partial class Form_Cadastrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Cadastrar));
            Pic_Cadastro = new PictureBox();
            Lbl_Email = new Label();
            Txt_Email = new TextBox();
            Txt_Senha = new TextBox();
            Lbl_Senha = new Label();
            Lbl_ConfirmaSenha = new Label();
            Txt_ConfirmaSenha = new TextBox();
            Btn_Cadastrar = new Button();
            Lbl_Erro = new Label();
            Btn_Voltar = new Button();
            Lbl_Titulo = new Label();
            Txt_Nome = new TextBox();
            Lbl_Nome = new Label();
            ((System.ComponentModel.ISupportInitialize)Pic_Cadastro).BeginInit();
            SuspendLayout();
            // 
            // Pic_Cadastro
            // 
            Pic_Cadastro.Image = Properties.Resources.cadastro;
            Pic_Cadastro.Location = new Point(11, 34);
            Pic_Cadastro.Name = "Pic_Cadastro";
            Pic_Cadastro.Size = new Size(282, 71);
            Pic_Cadastro.SizeMode = PictureBoxSizeMode.Zoom;
            Pic_Cadastro.TabIndex = 3;
            Pic_Cadastro.TabStop = false;
            // 
            // Lbl_Email
            // 
            Lbl_Email.AutoSize = true;
            Lbl_Email.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Email.Location = new Point(12, 156);
            Lbl_Email.Name = "Lbl_Email";
            Lbl_Email.Size = new Size(56, 19);
            Lbl_Email.TabIndex = 0;
            Lbl_Email.Text = "E-mail";
            // 
            // Txt_Email
            // 
            Txt_Email.Location = new Point(12, 178);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.PlaceholderText = "Insira seu e-mail";
            Txt_Email.Size = new Size(281, 23);
            Txt_Email.TabIndex = 2;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(11, 226);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.PlaceholderText = "Insira sua senha";
            Txt_Senha.Size = new Size(281, 23);
            Txt_Senha.TabIndex = 3;
            // 
            // Lbl_Senha
            // 
            Lbl_Senha.AutoSize = true;
            Lbl_Senha.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Senha.Location = new Point(12, 204);
            Lbl_Senha.Name = "Lbl_Senha";
            Lbl_Senha.Size = new Size(58, 19);
            Lbl_Senha.TabIndex = 0;
            Lbl_Senha.Text = "Senha";
            // 
            // Lbl_ConfirmaSenha
            // 
            Lbl_ConfirmaSenha.AutoSize = true;
            Lbl_ConfirmaSenha.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_ConfirmaSenha.Location = new Point(12, 252);
            Lbl_ConfirmaSenha.Name = "Lbl_ConfirmaSenha";
            Lbl_ConfirmaSenha.Size = new Size(183, 19);
            Lbl_ConfirmaSenha.TabIndex = 0;
            Lbl_ConfirmaSenha.Text = "Confirmação da Senha";
            // 
            // Txt_ConfirmaSenha
            // 
            Txt_ConfirmaSenha.Location = new Point(11, 274);
            Txt_ConfirmaSenha.Name = "Txt_ConfirmaSenha";
            Txt_ConfirmaSenha.PasswordChar = '*';
            Txt_ConfirmaSenha.PlaceholderText = "Insira a confirmação de senha";
            Txt_ConfirmaSenha.Size = new Size(281, 23);
            Txt_ConfirmaSenha.TabIndex = 4;
            // 
            // Btn_Cadastrar
            // 
            Btn_Cadastrar.Location = new Point(64, 304);
            Btn_Cadastrar.Name = "Btn_Cadastrar";
            Btn_Cadastrar.Size = new Size(183, 23);
            Btn_Cadastrar.TabIndex = 5;
            Btn_Cadastrar.Text = "Cadastrar";
            Btn_Cadastrar.UseVisualStyleBackColor = true;
            Btn_Cadastrar.Click += Btn_Cadastrar_Click;
            // 
            // Lbl_Erro
            // 
            Lbl_Erro.ForeColor = Color.Red;
            Lbl_Erro.Location = new Point(12, 328);
            Lbl_Erro.Name = "Lbl_Erro";
            Lbl_Erro.Size = new Size(281, 23);
            Lbl_Erro.TabIndex = 5;
            Lbl_Erro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Btn_Voltar
            // 
            Btn_Voltar.Location = new Point(193, 361);
            Btn_Voltar.Name = "Btn_Voltar";
            Btn_Voltar.Size = new Size(100, 23);
            Btn_Voltar.TabIndex = 6;
            Btn_Voltar.Text = "Voltar";
            Btn_Voltar.UseVisualStyleBackColor = true;
            Btn_Voltar.Click += Btn_Voltar_Click;
            // 
            // Lbl_Titulo
            // 
            Lbl_Titulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Titulo.Location = new Point(11, 1);
            Lbl_Titulo.Name = "Lbl_Titulo";
            Lbl_Titulo.Size = new Size(282, 30);
            Lbl_Titulo.TabIndex = 7;
            Lbl_Titulo.Text = "Carteira de Jogos - Sign Up";
            Lbl_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(12, 130);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.PlaceholderText = "Insira seu nome";
            Txt_Nome.Size = new Size(281, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Nome.Location = new Point(12, 108);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(54, 19);
            Lbl_Nome.TabIndex = 8;
            Lbl_Nome.Text = "Nome";
            // 
            // Form_Cadastrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(305, 394);
            Controls.Add(Txt_Nome);
            Controls.Add(Lbl_Nome);
            Controls.Add(Lbl_Titulo);
            Controls.Add(Btn_Voltar);
            Controls.Add(Lbl_Erro);
            Controls.Add(Btn_Cadastrar);
            Controls.Add(Txt_ConfirmaSenha);
            Controls.Add(Lbl_ConfirmaSenha);
            Controls.Add(Lbl_Senha);
            Controls.Add(Txt_Senha);
            Controls.Add(Txt_Email);
            Controls.Add(Lbl_Email);
            Controls.Add(Pic_Cadastro);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Cadastrar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CJ - Cadastro";
            ((System.ComponentModel.ISupportInitialize)Pic_Cadastro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Pic_Cadastro;
        private Label Lbl_Email;
        private TextBox Txt_Email;
        private TextBox Txt_Senha;
        private Label Lbl_Senha;
        private Label Lbl_ConfirmaSenha;
        private TextBox Txt_ConfirmaSenha;
        private Button Btn_Cadastrar;
        private Label Lbl_Erro;
        private Button Btn_Voltar;
        private Label Lbl_Titulo;
        private TextBox Txt_Nome;
        private Label Lbl_Nome;
    }
}