namespace WinFormsMA
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Utils.LoadEnvFile();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;

            string user1 = Utils.GetEnvVariable("WF_USER1");
            string pass1 = Utils.GetEnvVariable("WF_PASSWORD1");
            string user2 = Utils.GetEnvVariable("WF_USER2");
            string pass2 = Utils.GetEnvVariable("WF_PASSWORD2");

            if (!Utils.EnvLoaded)
            {
                MessageBox.Show("No s'ha carregat el fitxer .env. Login incorrecte.");
                return;
            }

            if ((username == user1 && password == pass1) || (username == user2 && password == pass2))
            {
                MessageBox.Show("Correcte");
            } else
            {
                MessageBox.Show("Incorrecte");
            }
        }
    }
}