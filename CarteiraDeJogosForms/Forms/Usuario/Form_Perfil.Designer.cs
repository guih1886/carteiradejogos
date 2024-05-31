namespace CarteiraDeJogosForms.Forms.Usuario
{
    partial class Form_Perfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Perfil));
            toolStrip1 = new ToolStrip();
            toolStripEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSalvar = new ToolStripButton();
            Pic_Usuario = new PictureBox();
            Txt_Id = new TextBox();
            Txt_Nome = new TextBox();
            Txt_Jogos = new TextBox();
            Txt_JogosFavoritos = new TextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Usuario).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripEditar, toolStripSeparator1, toolStripSalvar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(465, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripEditar
            // 
            toolStripEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripEditar.Image = Properties.Resources.editar;
            toolStripEditar.ImageTransparentColor = Color.Magenta;
            toolStripEditar.Name = "toolStripEditar";
            toolStripEditar.Size = new Size(23, 22);
            toolStripEditar.Text = "Editar";
            toolStripEditar.Click += toolStripEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripSalvar
            // 
            toolStripSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSalvar.Image = Properties.Resources.salvar;
            toolStripSalvar.ImageTransparentColor = Color.Magenta;
            toolStripSalvar.Name = "toolStripSalvar";
            toolStripSalvar.Size = new Size(23, 22);
            toolStripSalvar.Text = "Salvar";
            toolStripSalvar.TextDirection = ToolStripTextDirection.Horizontal;
            toolStripSalvar.Click += toolStripSalvar_Click;
            // 
            // Pic_Usuario
            // 
            Pic_Usuario.Image = Properties.Resources.login;
            Pic_Usuario.Location = new Point(57, 28);
            Pic_Usuario.Name = "Pic_Usuario";
            Pic_Usuario.Size = new Size(348, 348);
            Pic_Usuario.SizeMode = PictureBoxSizeMode.AutoSize;
            Pic_Usuario.TabIndex = 1;
            Pic_Usuario.TabStop = false;
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(12, 400);
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(441, 23);
            Txt_Id.TabIndex = 2;
            Txt_Id.TabStop = false;
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(12, 429);
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.ReadOnly = true;
            Txt_Nome.Size = new Size(441, 23);
            Txt_Nome.TabIndex = 3;
            Txt_Nome.TabStop = false;
            // 
            // Txt_Jogos
            // 
            Txt_Jogos.Location = new Point(12, 458);
            Txt_Jogos.MaximumSize = new Size(441, 70);
            Txt_Jogos.Multiline = true;
            Txt_Jogos.Name = "Txt_Jogos";
            Txt_Jogos.ReadOnly = true;
            Txt_Jogos.Size = new Size(441, 23);
            Txt_Jogos.TabIndex = 4;
            Txt_Jogos.TabStop = false;
            // 
            // Txt_JogosFavoritos
            // 
            Txt_JogosFavoritos.Location = new Point(12, 487);
            Txt_JogosFavoritos.MaximumSize = new Size(441, 70);
            Txt_JogosFavoritos.Multiline = true;
            Txt_JogosFavoritos.Name = "Txt_JogosFavoritos";
            Txt_JogosFavoritos.ReadOnly = true;
            Txt_JogosFavoritos.Size = new Size(441, 23);
            Txt_JogosFavoritos.TabIndex = 5;
            Txt_JogosFavoritos.TabStop = false;
            // 
            // Form_Perfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(465, 621);
            Controls.Add(Txt_JogosFavoritos);
            Controls.Add(Txt_Jogos);
            Controls.Add(Txt_Nome);
            Controls.Add(Txt_Id);
            Controls.Add(Pic_Usuario);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(481, 660);
            MinimizeBox = false;
            MinimumSize = new Size(481, 660);
            Name = "Form_Perfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Perfil";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Pic_Usuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripSalvar;
        private PictureBox Pic_Usuario;
        private TextBox Txt_Id;
        private TextBox Txt_Nome;
        private TextBox Txt_Jogos;
        private TextBox Txt_JogosFavoritos;
    }
}