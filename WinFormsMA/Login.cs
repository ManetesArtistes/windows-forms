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

            testFTP();
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

                SelectAdminMode SelectForm = new SelectAdminMode();
                SelectForm.Show();
            } else
            {
                Utils.ShowDialogError();
            }
        }

        private void testFTP()
        {
            string ftpUrl = Utils.GetEnvVariable("FTP_URL");
            string ftpUsername = Utils.GetEnvVariable("FTP_USERNAME");
            string ftpPassword = Utils.GetEnvVariable("FTP_PASSWORD");

            if (string.IsNullOrEmpty(ftpUrl) || string.IsNullOrEmpty(ftpUsername) || string.IsNullOrEmpty(ftpPassword))
            {
                MessageBox.Show("Les variables d'entorn per FTP no estan carregades correctament.");
                return;
            }

            Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

            // Comprovar la connexi� FTP
            if (ftpClient.TestConnection())
            {
                Console.WriteLine("Connexi� FTP correcta!");
            }
            else
            {
                Console.WriteLine("No s'ha pogut establir la connexi� FTP.");
            }
        }
    }
}