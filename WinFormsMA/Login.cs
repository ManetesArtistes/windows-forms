using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class Login : BaseForm
    {
        public Login()
        {
            InitializeComponent();
            Utils.LoadEnvFile();
            this.AcceptButton = buttonLogIn;
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

            if (username == user1 && password == pass1)
            {
                this.Hide();

                Stats statsForm = new Stats();
                statsForm.Show();
            }
            else if (username == user2 && password == pass2)
            {
                this.Hide();

                Logs logsForm = new Logs();
                logsForm.Show();
            } else
            {
                Utils.ShowDialogError();
            }
        }
    }
}