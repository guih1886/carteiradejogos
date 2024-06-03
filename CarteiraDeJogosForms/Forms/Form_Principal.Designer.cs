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
            deletarJogoToolStripMenuItem = new ToolStripMenuItem();
            perfilToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            Mnu_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Mnu_Menu
            // 
            Mnu_Menu.BackColor = SystemColors.GradientActiveCaption;
            Mnu_Menu.Items.AddRange(new ToolStripItem[] { primeiroToolStripMenuItem, perfilToolStripMenuItem, sairToolStripMenuItem });
            resources.ApplyResources(Mnu_Menu, "Mnu_Menu");
            Mnu_Menu.Name = "Mnu_Menu";
            // 
            // primeiroToolStripMenuItem
            // 
            primeiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { meusJogosToolStripMenuItem, cadastrarJogoToolStripMenuItem, deletarJogoToolStripMenuItem });
            primeiroToolStripMenuItem.Name = "primeiroToolStripMenuItem";
            resources.ApplyResources(primeiroToolStripMenuItem, "primeiroToolStripMenuItem");
            // 
            // meusJogosToolStripMenuItem
            // 
            meusJogosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { todosOsJogosToolStripMenuItem, jogosFavoritosToolStripMenuItem });
            meusJogosToolStripMenuItem.Name = "meusJogosToolStripMenuItem";
            resources.ApplyResources(meusJogosToolStripMenuItem, "meusJogosToolStripMenuItem");
            // 
            // todosOsJogosToolStripMenuItem
            // 
            todosOsJogosToolStripMenuItem.Name = "todosOsJogosToolStripMenuItem";
            resources.ApplyResources(todosOsJogosToolStripMenuItem, "todosOsJogosToolStripMenuItem");
            todosOsJogosToolStripMenuItem.Click += todosOsJogosToolStripMenuItem_Click;
            // 
            // jogosFavoritosToolStripMenuItem
            // 
            jogosFavoritosToolStripMenuItem.Name = "jogosFavoritosToolStripMenuItem";
            resources.ApplyResources(jogosFavoritosToolStripMenuItem, "jogosFavoritosToolStripMenuItem");
            jogosFavoritosToolStripMenuItem.Click += jogosFavoritosToolStripMenuItem_Click;
            // 
            // cadastrarJogoToolStripMenuItem
            // 
            cadastrarJogoToolStripMenuItem.Name = "cadastrarJogoToolStripMenuItem";
            resources.ApplyResources(cadastrarJogoToolStripMenuItem, "cadastrarJogoToolStripMenuItem");
            cadastrarJogoToolStripMenuItem.Click += cadastrarJogoToolStripMenuItem_Click;
            // 
            // deletarJogoToolStripMenuItem
            // 
            deletarJogoToolStripMenuItem.Name = "deletarJogoToolStripMenuItem";
            resources.ApplyResources(deletarJogoToolStripMenuItem, "deletarJogoToolStripMenuItem");
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            resources.ApplyResources(perfilToolStripMenuItem, "perfilToolStripMenuItem");
            perfilToolStripMenuItem.Click += perfilToolStripMenuItem_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(sairToolStripMenuItem, "sairToolStripMenuItem");
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
        private ToolStripMenuItem deletarJogoToolStripMenuItem;
        private ToolStripMenuItem perfilToolStripMenuItem;
    }
}