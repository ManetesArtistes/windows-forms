namespace WinFormsMA
{
    using DotNetEnv;
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Env.Load();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;

            string user1 = Utils.GetEnvVariable("USER1");
            string pass1 = Utils.GetEnvVariable("PASSWORD1");
            string user2 = Utils.GetEnvVariable("USER2");
            string pass2 = Utils.GetEnvVariable("PASSWORD2");

            MessageBox.Show(user1, pass1);

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
