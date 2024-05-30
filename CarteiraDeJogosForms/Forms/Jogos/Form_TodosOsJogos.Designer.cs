namespace CarteiraDeJogosForms.Forms.Jogos
{
    partial class Form_TodosOsJogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TodosOsJogos));
            jogosContextBindingSource = new BindingSource(components);
            jogosControllerBindingSource = new BindingSource(components);
            jogosRepositoryBindingSource1 = new BindingSource(components);
            jogosRepositoryBindingSource = new BindingSource(components);
            readUsuariosDtoBindingSource = new BindingSource(components);
            readJogosDtoBindingSource = new BindingSource(components);
            Dgv_Jogos = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enderecoImagemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            anoLancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            plataformaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ativoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)jogosContextBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogosControllerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogosRepositoryBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogosRepositoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readUsuariosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).BeginInit();
            SuspendLayout();
            // 
            // jogosContextBindingSource
            // 
            jogosContextBindingSource.DataSource = typeof(CarteiraDeJogos.Data.JogosContext);
            // 
            // jogosControllerBindingSource
            // 
            jogosControllerBindingSource.DataSource = typeof(CarteiraDeJogos.Controllers.JogosController);
            // 
            // jogosRepositoryBindingSource1
            // 
            jogosRepositoryBindingSource1.DataSource = typeof(CarteiraDeJogos.Data.Repository.JogosRepository);
            // 
            // jogosRepositoryBindingSource
            // 
            jogosRepositoryBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Repository.JogosRepository);
            // 
            // readUsuariosDtoBindingSource
            // 
            readUsuariosDtoBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Dto.Usuarios.ReadUsuariosDto);
            // 
            // readJogosDtoBindingSource
            // 
            readJogosDtoBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Dto.Jogos.ReadJogosDto);
            // 
            // Dgv_Jogos
            // 
            Dgv_Jogos.AllowUserToAddRows = false;
            Dgv_Jogos.AllowUserToDeleteRows = false;
            Dgv_Jogos.AutoGenerateColumns = false;
            Dgv_Jogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Jogos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, enderecoImagemDataGridViewTextBoxColumn, anoLancamentoDataGridViewTextBoxColumn, plataformaDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, ativoDataGridViewTextBoxColumn });
            Dgv_Jogos.DataSource = readJogosDtoBindingSource;
            Dgv_Jogos.Dock = DockStyle.Fill;
            Dgv_Jogos.Location = new Point(0, 0);
            Dgv_Jogos.Name = "Dgv_Jogos";
            Dgv_Jogos.ReadOnly = true;
            Dgv_Jogos.Size = new Size(1108, 559);
            Dgv_Jogos.TabIndex = 0;
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
            nomeDataGridViewTextBoxColumn.Width = 200;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            descricaoDataGridViewTextBoxColumn.Width = 250;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            generoDataGridViewTextBoxColumn.HeaderText = "Genero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            generoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enderecoImagemDataGridViewTextBoxColumn
            // 
            enderecoImagemDataGridViewTextBoxColumn.DataPropertyName = "EnderecoImagem";
            enderecoImagemDataGridViewTextBoxColumn.HeaderText = "Imagem";
            enderecoImagemDataGridViewTextBoxColumn.Name = "enderecoImagemDataGridViewTextBoxColumn";
            enderecoImagemDataGridViewTextBoxColumn.ReadOnly = true;
            enderecoImagemDataGridViewTextBoxColumn.Width = 150;
            // 
            // anoLancamentoDataGridViewTextBoxColumn
            // 
            anoLancamentoDataGridViewTextBoxColumn.DataPropertyName = "AnoLancamento";
            anoLancamentoDataGridViewTextBoxColumn.HeaderText = "Lançamento";
            anoLancamentoDataGridViewTextBoxColumn.Name = "anoLancamentoDataGridViewTextBoxColumn";
            anoLancamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plataformaDataGridViewTextBoxColumn
            // 
            plataformaDataGridViewTextBoxColumn.DataPropertyName = "Plataforma";
            plataformaDataGridViewTextBoxColumn.HeaderText = "Plataforma";
            plataformaDataGridViewTextBoxColumn.Name = "plataformaDataGridViewTextBoxColumn";
            plataformaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notaDataGridViewTextBoxColumn
            // 
            notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            notaDataGridViewTextBoxColumn.ReadOnly = true;
            notaDataGridViewTextBoxColumn.Width = 50;
            // 
            // ativoDataGridViewTextBoxColumn
            // 
            ativoDataGridViewTextBoxColumn.DataPropertyName = "Ativo";
            ativoDataGridViewTextBoxColumn.HeaderText = "Ativo";
            ativoDataGridViewTextBoxColumn.Name = "ativoDataGridViewTextBoxColumn";
            ativoDataGridViewTextBoxColumn.ReadOnly = true;
            ativoDataGridViewTextBoxColumn.Width = 50;
            // 
            // Form_TodosOsJogos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 559);
            Controls.Add(Dgv_Jogos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_TodosOsJogos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meus Jogos";
            ((System.ComponentModel.ISupportInitialize)jogosContextBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogosControllerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogosRepositoryBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogosRepositoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)readUsuariosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource jogosContextBindingSource;
        private BindingSource jogosControllerBindingSource;
        private BindingSource jogosRepositoryBindingSource1;
        private BindingSource jogosRepositoryBindingSource;
        private BindingSource readUsuariosDtoBindingSource;
        private BindingSource readJogosDtoBindingSource;
        private DataGridView Dgv_Jogos;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enderecoImagemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn anoLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn plataformaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
    }
}