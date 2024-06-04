namespace CarteiraDeJogosForms.Forms.Jogos
{
    partial class Form_CadastroDeJogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadastroDeJogos));
            Gpb_DadosJogos = new GroupBox();
            Lbl_Erro = new Label();
            Mtb_Nota = new MaskedTextBox();
            Lbl_Nota = new Label();
            Mtb_AnoLancamento = new MaskedTextBox();
            Txt_Plataforma = new TextBox();
            Lbl_Plataforma = new Label();
            Lbl_AnoLancamento = new Label();
            Txt_UsuarioId = new TextBox();
            Lbl_UsuarioId = new Label();
            Cmb_Genero = new ComboBox();
            Lbl_Genero = new Label();
            Txt_Imagem = new TextBox();
            Lbl_Imagem = new Label();
            Txt_Descricao = new TextBox();
            Lbl_Descricao = new Label();
            Txt_Nome = new TextBox();
            Lbl_Nome = new Label();
            toolStrip1 = new ToolStrip();
            toolStripNovo = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSalvar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripBuscar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripReset = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripFavoritos = new ToolStripButton();
            Gpb_Flags = new GroupBox();
            Ckb_Favorito = new CheckBox();
            Ckb_Ativo = new CheckBox();
            Pic_Jogo = new PictureBox();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripDeletar = new ToolStripButton();
            Gpb_DadosJogos.SuspendLayout();
            toolStrip1.SuspendLayout();
            Gpb_Flags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Jogo).BeginInit();
            SuspendLayout();
            // 
            // Gpb_DadosJogos
            // 
            Gpb_DadosJogos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_DadosJogos.Controls.Add(Lbl_Erro);
            Gpb_DadosJogos.Controls.Add(Mtb_Nota);
            Gpb_DadosJogos.Controls.Add(Lbl_Nota);
            Gpb_DadosJogos.Controls.Add(Mtb_AnoLancamento);
            Gpb_DadosJogos.Controls.Add(Txt_Plataforma);
            Gpb_DadosJogos.Controls.Add(Lbl_Plataforma);
            Gpb_DadosJogos.Controls.Add(Lbl_AnoLancamento);
            Gpb_DadosJogos.Controls.Add(Txt_UsuarioId);
            Gpb_DadosJogos.Controls.Add(Lbl_UsuarioId);
            Gpb_DadosJogos.Controls.Add(Cmb_Genero);
            Gpb_DadosJogos.Controls.Add(Lbl_Genero);
            Gpb_DadosJogos.Controls.Add(Txt_Imagem);
            Gpb_DadosJogos.Controls.Add(Lbl_Imagem);
            Gpb_DadosJogos.Controls.Add(Txt_Descricao);
            Gpb_DadosJogos.Controls.Add(Lbl_Descricao);
            Gpb_DadosJogos.Controls.Add(Txt_Nome);
            Gpb_DadosJogos.Controls.Add(Lbl_Nome);
            Gpb_DadosJogos.Location = new Point(12, 264);
            Gpb_DadosJogos.MinimumSize = new Size(620, 352);
            Gpb_DadosJogos.Name = "Gpb_DadosJogos";
            Gpb_DadosJogos.Size = new Size(620, 352);
            Gpb_DadosJogos.TabIndex = 1;
            Gpb_DadosJogos.TabStop = false;
            // 
            // Lbl_Erro
            // 
            Lbl_Erro.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Erro.ForeColor = Color.Red;
            Lbl_Erro.Location = new Point(293, 271);
            Lbl_Erro.Name = "Lbl_Erro";
            Lbl_Erro.Size = new Size(321, 63);
            Lbl_Erro.TabIndex = 16;
            Lbl_Erro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Mtb_Nota
            // 
            Mtb_Nota.Location = new Point(9, 294);
            Mtb_Nota.Mask = "00";
            Mtb_Nota.Name = "Mtb_Nota";
            Mtb_Nota.ReadOnly = true;
            Mtb_Nota.Size = new Size(278, 23);
            Mtb_Nota.TabIndex = 15;
            Mtb_Nota.ValidatingType = typeof(int);
            // 
            // Lbl_Nota
            // 
            Lbl_Nota.AutoSize = true;
            Lbl_Nota.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Nota.Location = new Point(6, 271);
            Lbl_Nota.Name = "Lbl_Nota";
            Lbl_Nota.Size = new Size(36, 20);
            Lbl_Nota.TabIndex = 15;
            Lbl_Nota.Text = "Nota";
            // 
            // Mtb_AnoLancamento
            // 
            Mtb_AnoLancamento.Location = new Point(9, 242);
            Mtb_AnoLancamento.Mask = "0000";
            Mtb_AnoLancamento.Name = "Mtb_AnoLancamento";
            Mtb_AnoLancamento.ReadOnly = true;
            Mtb_AnoLancamento.Size = new Size(275, 23);
            Mtb_AnoLancamento.TabIndex = 13;
            Mtb_AnoLancamento.ValidatingType = typeof(int);
            // 
            // Txt_Plataforma
            // 
            Txt_Plataforma.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Plataforma.Location = new Point(290, 242);
            Txt_Plataforma.Name = "Txt_Plataforma";
            Txt_Plataforma.ReadOnly = true;
            Txt_Plataforma.Size = new Size(324, 23);
            Txt_Plataforma.TabIndex = 14;
            // 
            // Lbl_Plataforma
            // 
            Lbl_Plataforma.AutoSize = true;
            Lbl_Plataforma.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Plataforma.Location = new Point(287, 219);
            Lbl_Plataforma.Name = "Lbl_Plataforma";
            Lbl_Plataforma.Size = new Size(71, 20);
            Lbl_Plataforma.TabIndex = 12;
            Lbl_Plataforma.Text = "Plataforma";
            // 
            // Lbl_AnoLancamento
            // 
            Lbl_AnoLancamento.AutoSize = true;
            Lbl_AnoLancamento.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_AnoLancamento.Location = new Point(6, 219);
            Lbl_AnoLancamento.Name = "Lbl_AnoLancamento";
            Lbl_AnoLancamento.Size = new Size(125, 20);
            Lbl_AnoLancamento.TabIndex = 10;
            Lbl_AnoLancamento.Text = "Ano de lançamento";
            // 
            // Txt_UsuarioId
            // 
            Txt_UsuarioId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_UsuarioId.Cursor = Cursors.No;
            Txt_UsuarioId.Location = new Point(290, 190);
            Txt_UsuarioId.Name = "Txt_UsuarioId";
            Txt_UsuarioId.ReadOnly = true;
            Txt_UsuarioId.Size = new Size(324, 23);
            Txt_UsuarioId.TabIndex = 9;
            // 
            // Lbl_UsuarioId
            // 
            Lbl_UsuarioId.AutoSize = true;
            Lbl_UsuarioId.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_UsuarioId.Location = new Point(287, 167);
            Lbl_UsuarioId.Name = "Lbl_UsuarioId";
            Lbl_UsuarioId.Size = new Size(87, 20);
            Lbl_UsuarioId.TabIndex = 8;
            Lbl_UsuarioId.Text = "Id do usuário";
            // 
            // Cmb_Genero
            // 
            Cmb_Genero.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Genero.Enabled = false;
            Cmb_Genero.FormattingEnabled = true;
            Cmb_Genero.Location = new Point(9, 190);
            Cmb_Genero.Name = "Cmb_Genero";
            Cmb_Genero.Size = new Size(275, 23);
            Cmb_Genero.TabIndex = 7;
            // 
            // Lbl_Genero
            // 
            Lbl_Genero.AutoSize = true;
            Lbl_Genero.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Genero.Location = new Point(6, 167);
            Lbl_Genero.Name = "Lbl_Genero";
            Lbl_Genero.Size = new Size(54, 20);
            Lbl_Genero.TabIndex = 6;
            Lbl_Genero.Text = "Genero";
            // 
            // Txt_Imagem
            // 
            Txt_Imagem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Imagem.Location = new Point(9, 141);
            Txt_Imagem.Name = "Txt_Imagem";
            Txt_Imagem.ReadOnly = true;
            Txt_Imagem.Size = new Size(605, 23);
            Txt_Imagem.TabIndex = 5;
            Txt_Imagem.Leave += Txt_Imagem_Leave;
            // 
            // Lbl_Imagem
            // 
            Lbl_Imagem.AutoSize = true;
            Lbl_Imagem.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Imagem.Location = new Point(6, 118);
            Lbl_Imagem.Name = "Lbl_Imagem";
            Lbl_Imagem.Size = new Size(96, 20);
            Lbl_Imagem.TabIndex = 4;
            Lbl_Imagem.Text = "Url da Imagem";
            // 
            // Txt_Descricao
            // 
            Txt_Descricao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Descricao.Location = new Point(9, 92);
            Txt_Descricao.Name = "Txt_Descricao";
            Txt_Descricao.ReadOnly = true;
            Txt_Descricao.Size = new Size(605, 23);
            Txt_Descricao.TabIndex = 3;
            // 
            // Lbl_Descricao
            // 
            Lbl_Descricao.AutoSize = true;
            Lbl_Descricao.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Descricao.Location = new Point(6, 69);
            Lbl_Descricao.Name = "Lbl_Descricao";
            Lbl_Descricao.Size = new Size(69, 20);
            Lbl_Descricao.TabIndex = 2;
            Lbl_Descricao.Text = "Descrição";
            // 
            // Txt_Nome
            // 
            Txt_Nome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Txt_Nome.Location = new Point(9, 41);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.ReadOnly = true;
            Txt_Nome.Size = new Size(605, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Nome.Location = new Point(6, 18);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(45, 20);
            Lbl_Nome.TabIndex = 0;
            Lbl_Nome.Text = "Nome";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripNovo, toolStripSeparator1, toolStripSalvar, toolStripSeparator2, toolStripBuscar, toolStripSeparator4, toolStripFavoritos, toolStripSeparator3, toolStripReset, toolStripSeparator5, toolStripDeletar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(641, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNovo
            // 
            toolStripNovo.Image = Properties.Resources.novo;
            toolStripNovo.ImageTransparentColor = Color.Magenta;
            toolStripNovo.Name = "toolStripNovo";
            toolStripNovo.Size = new Size(56, 22);
            toolStripNovo.Text = "Novo";
            toolStripNovo.ToolTipText = "Novo";
            toolStripNovo.Click += toolStripNovo_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripSalvar
            // 
            toolStripSalvar.Image = Properties.Resources.salvar;
            toolStripSalvar.ImageTransparentColor = Color.Magenta;
            toolStripSalvar.Name = "toolStripSalvar";
            toolStripSalvar.Size = new Size(58, 22);
            toolStripSalvar.Text = "Salvar";
            toolStripSalvar.Click += toolStripSalvar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripBuscar
            // 
            toolStripBuscar.Image = Properties.Resources.buscar;
            toolStripBuscar.ImageTransparentColor = Color.Magenta;
            toolStripBuscar.Name = "toolStripBuscar";
            toolStripBuscar.Size = new Size(62, 22);
            toolStripBuscar.Text = "Buscar";
            toolStripBuscar.ToolTipText = "Abre a tela de busca de jogos";
            toolStripBuscar.Click += toolStripBuscar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripReset
            // 
            toolStripReset.Image = Properties.Resources.cancelar;
            toolStripReset.ImageTransparentColor = Color.Magenta;
            toolStripReset.Name = "toolStripReset";
            toolStripReset.Size = new Size(64, 22);
            toolStripReset.Text = "Limpar";
            toolStripReset.ToolTipText = "Limpar";
            toolStripReset.Click += toolStripReset_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripFavoritos
            // 
            toolStripFavoritos.Image = Properties.Resources.favorito;
            toolStripFavoritos.ImageTransparentColor = Color.Magenta;
            toolStripFavoritos.Name = "toolStripFavoritos";
            toolStripFavoritos.Size = new Size(75, 22);
            toolStripFavoritos.Text = "Favoritos";
            toolStripFavoritos.Click += toolStripFavoritos_Click;
            // 
            // Gpb_Flags
            // 
            Gpb_Flags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_Flags.Controls.Add(Ckb_Favorito);
            Gpb_Flags.Controls.Add(Ckb_Ativo);
            Gpb_Flags.Location = new Point(305, 207);
            Gpb_Flags.Name = "Gpb_Flags";
            Gpb_Flags.Size = new Size(324, 51);
            Gpb_Flags.TabIndex = 3;
            Gpb_Flags.TabStop = false;
            // 
            // Ckb_Favorito
            // 
            Ckb_Favorito.AutoSize = true;
            Ckb_Favorito.Enabled = false;
            Ckb_Favorito.Location = new Point(69, 20);
            Ckb_Favorito.Name = "Ckb_Favorito";
            Ckb_Favorito.Size = new Size(69, 19);
            Ckb_Favorito.TabIndex = 1;
            Ckb_Favorito.Text = "Favorito";
            Ckb_Favorito.UseVisualStyleBackColor = true;
            // 
            // Ckb_Ativo
            // 
            Ckb_Ativo.AutoSize = true;
            Ckb_Ativo.Enabled = false;
            Ckb_Ativo.Location = new Point(9, 20);
            Ckb_Ativo.Name = "Ckb_Ativo";
            Ckb_Ativo.Size = new Size(54, 19);
            Ckb_Ativo.TabIndex = 0;
            Ckb_Ativo.Text = "Ativo";
            Ckb_Ativo.UseVisualStyleBackColor = true;
            // 
            // Pic_Jogo
            // 
            Pic_Jogo.BorderStyle = BorderStyle.Fixed3D;
            Pic_Jogo.ErrorImage = null;
            Pic_Jogo.ImageLocation = "";
            Pic_Jogo.InitialImage = null;
            Pic_Jogo.Location = new Point(12, 28);
            Pic_Jogo.Name = "Pic_Jogo";
            Pic_Jogo.Size = new Size(287, 230);
            Pic_Jogo.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic_Jogo.TabIndex = 4;
            Pic_Jogo.TabStop = false;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // toolStripDeletar
            // 
            toolStripDeletar.Image = Properties.Resources.excluir;
            toolStripDeletar.ImageTransparentColor = Color.Magenta;
            toolStripDeletar.Name = "toolStripDeletar";
            toolStripDeletar.Size = new Size(62, 22);
            toolStripDeletar.Text = "Excluir";
            toolStripDeletar.Click += toolStripDeletar_Click;
            // 
            // Form_CadastroDeJogos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 628);
            Controls.Add(Pic_Jogo);
            Controls.Add(Gpb_Flags);
            Controls.Add(toolStrip1);
            Controls.Add(Gpb_DadosJogos);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(657, 667);
            MinimumSize = new Size(657, 667);
            Name = "Form_CadastroDeJogos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de jogos";
            Gpb_DadosJogos.ResumeLayout(false);
            Gpb_DadosJogos.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            Gpb_Flags.ResumeLayout(false);
            Gpb_Flags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Jogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox Gpb_DadosJogos;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripNovo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripSalvar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripReset;
        private TextBox Txt_Imagem;
        private Label Lbl_Imagem;
        private TextBox Txt_Descricao;
        private Label Lbl_Descricao;
        private TextBox Txt_Nome;
        private Label Lbl_Nome;
        private ComboBox Cmb_Genero;
        private Label Lbl_Genero;
        private TextBox Txt_Plataforma;
        private Label Lbl_Plataforma;
        private Label Lbl_AnoLancamento;
        private TextBox Txt_UsuarioId;
        private Label Lbl_UsuarioId;
        private MaskedTextBox Mtb_AnoLancamento;
        private MaskedTextBox Mtb_Nota;
        private Label Lbl_Nota;
        private Label Lbl_Erro;
        private ToolStripButton toolStripBuscar;
        private GroupBox Gpb_Flags;
        private CheckBox Ckb_Ativo;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripFavoritos;
        private CheckBox Ckb_Favorito;
        private PictureBox Pic_Jogo;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripDeletar;
    }
}