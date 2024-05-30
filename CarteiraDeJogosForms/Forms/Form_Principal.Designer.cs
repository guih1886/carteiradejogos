namespace CarteiraDeJogosForms.Forms
{
    partial class Form_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Principal));
            Mnu_Menu = new MenuStrip();
            primeiroToolStripMenuItem = new ToolStripMenuItem();
            meusJogosToolStripMenuItem = new ToolStripMenuItem();
            todosOsJogosToolStripMenuItem = new ToolStripMenuItem();
            jogosFavoritosToolStripMenuItem = new ToolStripMenuItem();
            cadastrarJogoToolStripMenuItem = new ToolStripMenuItem();
            editarJogoToolStripMenuItem = new ToolStripMenuItem();
            inativarJogoToolStripMenuItem = new ToolStripMenuItem();
            deletarJogoToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            alterarDadosToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            Mnu_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Mnu_Menu
            // 
            resources.ApplyResources(Mnu_Menu, "Mnu_Menu");
            Mnu_Menu.BackColor = SystemColors.GradientActiveCaption;
            Mnu_Menu.Items.AddRange(new ToolStripItem[] { primeiroToolStripMenuItem, perfilToolStripMenuItem, sairToolStripMenuItem });
            Mnu_Menu.Name = "Mnu_Menu";
            // 
            // primeiroToolStripMenuItem
            // 
            resources.ApplyResources(primeiroToolStripMenuItem, "primeiroToolStripMenuItem");
            primeiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { meusJogosToolStripMenuItem, cadastrarJogoToolStripMenuItem, editarJogoToolStripMenuItem, inativarJogoToolStripMenuItem, deletarJogoToolStripMenuItem });
            primeiroToolStripMenuItem.Name = "primeiroToolStripMenuItem";
            // 
            // meusJogosToolStripMenuItem
            // 
            resources.ApplyResources(meusJogosToolStripMenuItem, "meusJogosToolStripMenuItem");
            meusJogosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { todosOsJogosToolStripMenuItem, jogosFavoritosToolStripMenuItem });
            meusJogosToolStripMenuItem.Name = "meusJogosToolStripMenuItem";
            // 
            // todosOsJogosToolStripMenuItem
            // 
            resources.ApplyResources(todosOsJogosToolStripMenuItem, "todosOsJogosToolStripMenuItem");
            todosOsJogosToolStripMenuItem.Name = "todosOsJogosToolStripMenuItem";
            todosOsJogosToolStripMenuItem.Click += todosOsJogosToolStripMenuItem_Click;
            // 
            // jogosFavoritosToolStripMenuItem
            // 
            resources.ApplyResources(jogosFavoritosToolStripMenuItem, "jogosFavoritosToolStripMenuItem");
            jogosFavoritosToolStripMenuItem.Name = "jogosFavoritosToolStripMenuItem";
            jogosFavoritosToolStripMenuItem.Click += jogosFavoritosToolStripMenuItem_Click;
            // 
            // cadastrarJogoToolStripMenuItem
            // 
            resources.ApplyResources(cadastrarJogoToolStripMenuItem, "cadastrarJogoToolStripMenuItem");
            cadastrarJogoToolStripMenuItem.Name = "cadastrarJogoToolStripMenuItem";
            // 
            // editarJogoToolStripMenuItem
            // 
            resources.ApplyResources(editarJogoToolStripMenuItem, "editarJogoToolStripMenuItem");
            editarJogoToolStripMenuItem.Name = "editarJogoToolStripMenuItem";
            // 
            // inativarJogoToolStripMenuItem
            // 
            resources.ApplyResources(inativarJogoToolStripMenuItem, "inativarJogoToolStripMenuItem");
            inativarJogoToolStripMenuItem.Name = "inativarJogoToolStripMenuItem";
            // 
            // deletarJogoToolStripMenuItem
            // 
            resources.ApplyResources(deletarJogoToolStripMenuItem, "deletarJogoToolStripMenuItem");
            deletarJogoToolStripMenuItem.Name = "deletarJogoToolStripMenuItem";
            // 
            // perfilToolStripMenuItem
            // 
            resources.ApplyResources(perfilToolStripMenuItem, "perfilToolStripMenuItem");
            perfilToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { alterarDadosToolStripMenuItem });
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            // 
            // alterarDadosToolStripMenuItem
            // 
            resources.ApplyResources(alterarDadosToolStripMenuItem, "alterarDadosToolStripMenuItem");
            alterarDadosToolStripMenuItem.Name = "alterarDadosToolStripMenuItem";
            // 
            // sairToolStripMenuItem
            // 
            resources.ApplyResources(sairToolStripMenuItem, "sairToolStripMenuItem");
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // Form_Principal
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Mnu_Menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = Mnu_Menu;
            Name = "Form_Principal";
            WindowState = FormWindowState.Maximized;
            Mnu_Menu.ResumeLayout(false);
            Mnu_Menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Mnu_Menu;
        private ToolStripMenuItem primeiroToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem meusJogosToolStripMenuItem;
        private ToolStripMenuItem todosOsJogosToolStripMenuItem;
        private ToolStripMenuItem jogosFavoritosToolStripMenuItem;
        private ToolStripMenuItem cadastrarJogoToolStripMenuItem;
        private ToolStripMenuItem editarJogoToolStripMenuItem;
        private ToolStripMenuItem inativarJogoToolStripMenuItem;
        private ToolStripMenuItem deletarJogoToolStripMenuItem;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private ToolStripMenuItem alterarDadosToolStripMenuItem;
    }
}