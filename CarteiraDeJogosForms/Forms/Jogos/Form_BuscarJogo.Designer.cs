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
            Btn_Cancelar = new Button();
            Btn_Selecionar = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).BeginInit();
            Pnl_Grid.SuspendLayout();
            SuspendLayout();
            // 
            // Dgv_Jogos
            // 
            Dgv_Jogos.AllowUserToAddRows = false;
            Dgv_Jogos.AllowUserToDeleteRows = false;
            Dgv_Jogos.AutoGenerateColumns = false;
            Dgv_Jogos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Jogos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, plataformaDataGridViewTextBoxColumn, ativoDataGridViewTextBoxColumn });
            Dgv_Jogos.DataSource = readJogosDtoBindingSource;
            Dgv_Jogos.Location = new Point(0, 0);
            Dgv_Jogos.Name = "Dgv_Jogos";
            Dgv_Jogos.ReadOnly = true;
            Dgv_Jogos.ScrollBars = ScrollBars.Vertical;
            Dgv_Jogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Dgv_Jogos.Size = new Size(794, 290);
            Dgv_Jogos.TabIndex = 1;
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
            Pnl_Grid.Size = new Size(795, 290);
            Pnl_Grid.TabIndex = 2;
            // 
            // Gpb_Busca
            // 
            Gpb_Busca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Gpb_Busca.Location = new Point(1, 297);
            Gpb_Busca.Name = "Gpb_Busca";
            Gpb_Busca.Size = new Size(795, 166);
            Gpb_Busca.TabIndex = 3;
            Gpb_Busca.TabStop = false;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Cancelar.Location = new Point(709, 469);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(75, 23);
            Btn_Cancelar.TabIndex = 4;
            Btn_Cancelar.Text = "Cancelar";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Selecionar
            // 
            Btn_Selecionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_Selecionar.Location = new Point(628, 469);
            Btn_Selecionar.Name = "Btn_Selecionar";
            Btn_Selecionar.Size = new Size(75, 23);
            Btn_Selecionar.TabIndex = 5;
            Btn_Selecionar.Text = "Selecionar";
            Btn_Selecionar.UseVisualStyleBackColor = true;
            Btn_Selecionar.Click += Btn_Selecionar_Click;
            // 
            // Form_BuscarJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 499);
            Controls.Add(Btn_Selecionar);
            Controls.Add(Btn_Cancelar);
            Controls.Add(Gpb_Busca);
            Controls.Add(Pnl_Grid);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_BuscarJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Jogo";
            ((System.ComponentModel.ISupportInitialize)Dgv_Jogos).EndInit();
            ((System.ComponentModel.ISupportInitialize)readJogosDtoBindingSource).EndInit();
            Pnl_Grid.ResumeLayout(false);
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
    }
}