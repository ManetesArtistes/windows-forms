using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class Login : BaseForm
    {
        private Ftp ftpClient;
        private JsonManager jsonManager;

        public Login()
        {
            InitializeComponent();
            Utils.LoadEnvFile();
            InitializeFtpClient();

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

                jsonManager = new JsonManager("path/to/local/json", ftpClient); // Proporciona el camí correcte
                jsonManager.LoadFromJson(); // Carrega els centres abans d'obrir el formulari

                Stats statsForm = new Stats(jsonManager); // Passa `JsonManager` com a argument
                statsForm.Show();
            }
            else if (username == user2 && password == pass2)
            {
                this.Hide();

                jsonManager = new JsonManager("path/to/local/json", ftpClient); // Proporciona el camí correcte
                jsonManager.LoadFromJson(); // Carrega els centres abans d'obrir el formulari

                SelectAdminMode selectForm = new SelectAdminMode(jsonManager.Centers); // Passa la llista de centres
                selectForm.Show();
            }
            else
            {
                Utils.ShowDialogError();
            }
        }

        private void InitializeFtpClient()
        {
            try
            {
                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();

                ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);
                if (!ftpClient.TestConnection())
                {
                    MessageBox.Show("No es pot establir la connexió amb el servidor FTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicialitzant el client FTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}