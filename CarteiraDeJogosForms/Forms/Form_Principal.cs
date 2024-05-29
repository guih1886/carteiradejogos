namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Principal : Form
    {
        private Form loginForm;
        public Form_Principal(Form login)
        {
            InitializeComponent();
            loginForm = login;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Windows\\Temp\\jwt.txt"))
            {
                File.Delete("C:\\Windows\\Temp\\jwt.txt");
            }
            loginForm.Show();
            this.Close();
        }
    }
}
