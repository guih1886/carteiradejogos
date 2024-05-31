﻿namespace CarteiraDeJogosForms.Forms.Jogos
{
    partial class Form_JogosFavoritos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_JogosFavoritos));
            Dgv_JogosFavoritos = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enderecoImagemDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            anoLancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            plataformaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ativoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            readJogosDtoBindingSource = new BindingSource(components);
            Lbl_Total = new Label();
            ((System.ComponentModel.ISupportInitialize)Dgv_JogosFavoritos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // Dgv_JogosFavoritos
            // 
            Dgv_JogosFavoritos.AllowUserToAddRows = false;
            Dgv_JogosFavoritos.AllowUserToDeleteRows = false;
            Dgv_JogosFavoritos.AutoGenerateColumns = false;
            Dgv_JogosFavoritos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_JogosFavoritos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, enderecoImagemDataGridViewTextBoxColumn, anoLancamentoDataGridViewTextBoxColumn, plataformaDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, ativoDataGridViewTextBoxColumn });
            Dgv_JogosFavoritos.DataSource = readJogosDtoBindingSource;
            Dgv_JogosFavoritos.Location = new Point(0, 0);
            Dgv_JogosFavoritos.Name = "Dgv_JogosFavoritos";
            Dgv_JogosFavoritos.ReadOnly = true;
            Dgv_JogosFavoritos.Size = new Size(1108, 535);
            Dgv_JogosFavoritos.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.Frozen = true;
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
            // readJogosDtoBindingSource
            // 
            readJogosDtoBindingSource.DataSource = typeof(CarteiraDeJogos.Data.Dto.Jogos.ReadJogosDto);
            // 
            // Lbl_Total
            // 
            Lbl_Total.Location = new Point(0, 538);
            Lbl_Total.Name = "Lbl_Total";
            Lbl_Total.Size = new Size(366, 23);
            Lbl_Total.TabIndex = 2;
            // 
            // Form_JogosFavoritos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 559);
            Controls.Add(Lbl_Total);
            Controls.Add(Dgv_JogosFavoritos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_JogosFavoritos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Meus Jogos Favoritos";
            ((System.ComponentModel.ISupportInitialize)Dgv_JogosFavoritos).EndInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_JogosFavoritos;
        private BindingSource readJogosDtoBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enderecoImagemDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn anoLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn plataformaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
        private Label Lbl_Total;
    }
}