namespace CarteiraDeJogosForms.Forms.Jogos
{
    partial class Form_BuscarJogo
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BuscarJogo));
            Dgv_Jogos = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            plataformaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ativoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            readJogosDtoBindingSource = new BindingSource(components);
            Pnl_Grid = new Panel();
            Gpb_Busca = new GroupBox();
            Ckb_Favoritos = new CheckBox();
            Txt_Plataforma = new TextBox();
            Lbl_Plataforma = new Label();
            Cmb_Genero = new ComboBox();
            Lbl_Genero = new Label();
            Gpb_Ativo = new GroupBox();
            Cmb_Ativo = new ComboBox();
            Txt_Nome = new TextBox();
            Lbl_Nome = new Label();
            Txt_Id = new TextBox();
            Lbl_Id = new Label();
            Btn_Cancelar = new Button();
            Btn_Selecionar = new Button();
            Btn_Buscar = new Button();
            Btn_Limpar = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).BeginInit();
            Pnl_Grid.SuspendLayout();
            Gpb_Busca.SuspendLayout();
            Gpb_Ativo.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv_Jogos
            // 
            Dgv_Jogos.AllowUserToAddRows = false;
            Dgv_Jogos.AllowUserToDeleteRows = false;
            Dgv_Jogos.AllowUserToOrderColumns = true;
            Dgv_Jogos.AllowUserToResizeColumns = false;
            Dgv_Jogos.AllowUserToResizeRows = false;
            Dgv_Jogos.AutoGenerateColumns = false;
            Dgv_Jogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Jogos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, plataformaDataGridViewTextBoxColumn, ativoDataGridViewTextBoxColumn });
            Dgv_Jogos.DataSource = readJogosDtoBindingSource;
            Dgv_Jogos.Location = new Point(0, 0);
            Dgv_Jogos.MultiSelect = false;
            Dgv_Jogos.Name = "Dgv_Jogos";
            Dgv_Jogos.ReadOnly = true;
            Dgv_Jogos.ScrollBars = ScrollBars.Vertical;
            Dgv_Jogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Jogos.Size = new Size(810, 290);
            Dgv_Jogos.TabIndex = 1;
            Dgv_Jogos.TabStop = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            nomeDataGridViewTextBoxColumn.Width = 400;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            generoDataGridViewTextBoxColumn.HeaderText = "Genero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            generoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plataformaDataGridViewTextBoxColumn
            // 
            plataformaDataGridViewTextBoxColumn.DataPropertyName = "Plataforma";
            plataformaDataGridViewTextBoxColumn.HeaderText = "Plataforma";
            plataformaDataGridViewTextBoxColumn.Name = "plataformaDataGridViewTextBoxColumn";
            plataformaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ativoDataGridViewTextBoxColumn
            // 
            ativoDataGridViewTextBoxColumn.DataPropertyName = "Ativo";
            ativoDataGridViewTextBoxColumn.HeaderText = "Ativo";
            ativoDataGridViewTextBoxColumn.Name = "ativoDataGridViewTextBoxColumn";
            ativoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // readJogosDtoBindingSource
            // 
            readJogosDtoBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Dto.Jogos.ReadJogosDto);
            // 
            // Pnl_Grid
            // 
            Pnl_Grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Pnl_Grid.Controls.Add(Dgv_Jogos);
            Pnl_Grid.Location = new Point(1, 1);
            Pnl_Grid.Name = "Pnl_Grid";
            Pnl_Grid.Size = new Size(810, 290);
            Pnl_Grid.TabIndex = 2;
            // 
            // Gpb_Busca
            // 
            Gpb_Busca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_Busca.Controls.Add(Ckb_Favoritos);
            Gpb_Busca.Controls.Add(Txt_Plataforma);
            Gpb_Busca.Controls.Add(Lbl_Plataforma);
            Gpb_Busca.Controls.Add(Cmb_Genero);
            Gpb_Busca.Controls.Add(Lbl_Genero);
            Gpb_Busca.Controls.Add(Gpb_Ativo);
            Gpb_Busca.Controls.Add(Txt_Nome);
            Gpb_Busca.Controls.Add(Lbl_Nome);
            Gpb_Busca.Controls.Add(Txt_Id);
            Gpb_Busca.Controls.Add(Lbl_Id);
            Gpb_Busca.Location = new Point(1, 297);
            Gpb_Busca.Name = "Gpb_Busca";
            Gpb_Busca.Size = new Size(809, 166);
            Gpb_Busca.TabIndex = 3;
            Gpb_Busca.TabStop = false;
            // 
            // Ckb_Favoritos
            // 
            Ckb_Favoritos.AutoSize = true;
            Ckb_Favoritos.Location = new Point(195, 31);
            Ckb_Favoritos.Name = "Ckb_Favoritos";
            Ckb_Favoritos.Size = new Size(74, 19);
            Ckb_Favoritos.TabIndex = 0;
            Ckb_Favoritos.TabStop = false;
            Ckb_Favoritos.Text = "Favoritos";
            Ckb_Favoritos.UseVisualStyleBackColor = true;
            Ckb_Favoritos.CheckedChanged += Ckb_Favoritos_CheckedChanged;
            // 
            // Txt_Plataforma
            // 
            Txt_Plataforma.Location = new Point(227, 137);
            Txt_Plataforma.Name = "Txt_Plataforma";
            Txt_Plataforma.Size = new Size(561, 23);
            Txt_Plataforma.TabIndex = 4;
            // 
            // Lbl_Plataforma
            // 
            Lbl_Plataforma.AutoSize = true;
            Lbl_Plataforma.Location = new Point(227, 119);
            Lbl_Plataforma.Name = "Lbl_Plataforma";
            Lbl_Plataforma.Size = new Size(65, 15);
            Lbl_Plataforma.TabIndex = 7;
            Lbl_Plataforma.Text = "Plataforma";
            // 
            // Cmb_Genero
            // 
            Cmb_Genero.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Genero.FormattingEnabled = true;
            Cmb_Genero.Location = new Point(6, 137);
            Cmb_Genero.Name = "Cmb_Genero";
            Cmb_Genero.Size = new Size(215, 23);
            Cmb_Genero.TabIndex = 3;
            // 
            // Lbl_Genero
            // 
            Lbl_Genero.AutoSize = true;
            Lbl_Genero.Location = new Point(6, 119);
            Lbl_Genero.Name = "Lbl_Genero";
            Lbl_Genero.Size = new Size(45, 15);
            Lbl_Genero.TabIndex = 5;
            Lbl_Genero.Text = "Genero";
            // 
            // Gpb_Ativo
            // 
            Gpb_Ativo.Controls.Add(Cmb_Ativo);
            Gpb_Ativo.Location = new Point(2, 10);
            Gpb_Ativo.Name = "Gpb_Ativo";
            Gpb_Ativo.Size = new Size(187, 56);
            Gpb_Ativo.TabIndex = 0;
            Gpb_Ativo.TabStop = false;
            Gpb_Ativo.Text = "Status";
            // 
            // Cmb_Ativo
            // 
            Cmb_Ativo.Dock = DockStyle.Top;
            Cmb_Ativo.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_Ativo.FormattingEnabled = true;
            Cmb_Ativo.Items.AddRange(new object[] { "Ativo", "Inativo" });
            Cmb_Ativo.Location = new Point(3, 19);
            Cmb_Ativo.Name = "Cmb_Ativo";
            Cmb_Ativo.Size = new Size(181, 23);
            Cmb_Ativo.TabIndex = 9;
            Cmb_Ativo.TabStop = false;
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(119, 90);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(669, 23);
            Txt_Nome.TabIndex = 2;
            // 
            // Lbl_Nome
            // 
            Lbl_Nome.AutoSize = true;
            Lbl_Nome.Location = new Point(119, 72);
            Lbl_Nome.Name = "Lbl_Nome";
            Lbl_Nome.Size = new Size(40, 15);
            Lbl_Nome.TabIndex = 2;
            Lbl_Nome.Text = "Nome";
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(6, 90);
            Txt_Id.Name = "Txt_Id";
            Txt_Id.Size = new Size(107, 23);
            Txt_Id.TabIndex = 1;
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.Location = new Point(6, 72);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(17, 15);
            Lbl_Id.TabIndex = 0;
            Lbl_Id.Text = "Id";
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Cancelar.Location = new Point(724, 469);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(75, 23);
            Btn_Cancelar.TabIndex = 7;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Selecionar
            // 
            Btn_Selecionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Selecionar.Location = new Point(643, 469);
            Btn_Selecionar.Name = "Btn_Selecionar";
            Btn_Selecionar.Size = new Size(75, 23);
            Btn_Selecionar.TabIndex = 6;
            Btn_Selecionar.Text = "Selecionar";
            Btn_Selecionar.UseVisualStyleBackColor = true;
            Btn_Selecionar.Click += Btn_Selecionar_Click;
            // 
            // Btn_Buscar
            // 
            Btn_Buscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Buscar.Location = new Point(562, 469);
            Btn_Buscar.Name = "Btn_Buscar";
            Btn_Buscar.Size = new Size(75, 23);
            Btn_Buscar.TabIndex = 5;
            Btn_Buscar.Text = "Buscar";
            Btn_Buscar.UseVisualStyleBackColor = true;
            Btn_Buscar.Click += Btn_Buscar_Click;
            // 
            // Btn_Limpar
            // 
            Btn_Limpar.Location = new Point(12, 469);
            Btn_Limpar.Name = "Btn_Limpar";
            Btn_Limpar.Size = new Size(75, 23);
            Btn_Limpar.TabIndex = 8;
            Btn_Limpar.Text = "Limpar";
            Btn_Limpar.UseVisualStyleBackColor = true;
            Btn_Limpar.Click += Btn_Limpar_Click;
            // 
            // Form_BuscarJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 499);
            Controls.Add(Btn_Limpar);
            Controls.Add(Btn_Buscar);
            Controls.Add(Btn_Selecionar);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Gpb_Busca);
            Controls.Add(Pnl_Grid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(827, 538);
            MinimumSize = new Size(827, 538);
            Name = "Form_BuscarJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Jogo";
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).EndInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).EndInit();
            Pnl_Grid.ResumeLayout(false);
            Gpb_Busca.ResumeLayout(false);
            Gpb_Busca.PerformLayout();
            Gpb_Ativo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_Jogos;
        private BindingSource readJogosDtoBindingSource;
        private Panel Pnl_Grid;
        private GroupBox Gpb_Busca;
        private Button Btn_Cancelar;
        private Button Btn_Selecionar;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn plataformaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
        private Button Btn_Buscar;
        private GroupBox Gpb_Ativo;
        private TextBox Txt_Nome;
        private Label Lbl_Nome;
        private TextBox Txt_Id;
        private Label Lbl_Id;
        private TextBox Txt_Plataforma;
        private Label Lbl_Plataforma;
        private ComboBox Cmb_Genero;
        private Label Lbl_Genero;
        private ComboBox Cmb_Ativo;
        private Button Btn_Limpar;
        private CheckBox Ckb_Favoritos;
    }
}