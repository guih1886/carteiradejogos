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
            Lbl_Total = new Label();
            readJogosDtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // Dgv_Jogos
            // 
            Dgv_Jogos.AllowUserToAddRows = false;
            Dgv_Jogos.AllowUserToDeleteRows = false;
            Dgv_Jogos.AllowUserToOrderColumns = true;
            Dgv_Jogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Jogos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, enderecoImagemDataGridViewTextBoxColumn, anoLancamentoDataGridViewTextBoxColumn, plataformaDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, ativoDataGridViewTextBoxColumn });
            Dgv_Jogos.Location = new Point(0, 0);
            Dgv_Jogos.MultiSelect = false;
            Dgv_Jogos.Name = "Dgv_Jogos";
            Dgv_Jogos.ReadOnly = true;
            Dgv_Jogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Jogos.Size = new Size(1093, 535);
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
            // Lbl_Total
            // 
            Lbl_Total.Location = new Point(0, 538);
            Lbl_Total.Name = "Lbl_Total";
            Lbl_Total.Size = new Size(366, 23);
            Lbl_Total.TabIndex = 1;
            // 
            // readJogosDtoBindingSource
            // 
            readJogosDtoBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Dto.Jogos.ReadJogosDto);
            // 
            // Form_TodosOsJogos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 559);
            Controls.Add(Lbl_Total);
            Controls.Add(Dgv_Jogos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(1111, 598);
            MinimumSize = new Size(1111, 598);
            Name = "Form_TodosOsJogos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meus Jogos";
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).EndInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView Dgv_Jogos;
        private Label Lbl_Total;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enderecoImagemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn anoLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn plataformaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
        private BindingSource readJogosDtoBindingSource;
    }
}