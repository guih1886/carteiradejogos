﻿namespace CarteiraDeJogosForms.Forms.Jogos
{
    partial class Form_CadastrarJogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CadastrarJogo));
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
            toolStripReset = new ToolStripButton();
            Gpb_DadosJogos.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Gpb_DadosJogos
            // 
            Gpb_DadosJogos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            Gpb_DadosJogos.Location = new Point(12, 28);
            Gpb_DadosJogos.Name = "Gpb_DadosJogos";
            Gpb_DadosJogos.Size = new Size(620, 337);
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripNovo, toolStripSeparator1, toolStripSalvar, toolStripSeparator2, toolStripReset });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(644, 25);
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
            // Form_CadastrarJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 377);
            Controls.Add(toolStrip1);
            Controls.Add(Gpb_DadosJogos);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(660, 416);
            MinimumSize = new Size(660, 416);
            Name = "Form_CadastrarJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastrar Jogo";
            Gpb_DadosJogos.ResumeLayout(false);
            Gpb_DadosJogos.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
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
    }
}