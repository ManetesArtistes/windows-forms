using WinFormsMA.Forms;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class Login : BaseForm
    {
        private Ftp ftpClient;
        private JsonManager jsonManager;

        public Login()
        {
            InitializeComponent();
            //Utils.LoadEnvFile();
            InitializeFtpClient();

            this.AcceptButton = buttonLogIn;
        }

        /// <summary>
        /// This method chechs that the username and password written
        /// are correct and depending on the user it takes you to one form or another
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUser.Text;
            string password = textBoxPassword.Text;

            //string user1 = Utils.GetEnvVariable("WF_USER1");
            //string pass1 = Utils.GetEnvVariable("WF_PASSWORD1");
            //string user2 = Utils.GetEnvVariable("WF_USER2");
            //string pass2 = Utils.GetEnvVariable("WF_PASSWORD2");
            var (user1, pass1, user2, pass2) = Utils.GetEnvVariable();

            //if (!Utils.EnvLoaded)
            //{
            //    MessageBox.Show("No s'ha carregat el fitxer .env. Login incorrecte.");
            //    return;
            //}

            if (username == user1 && password == pass1)
            {
                this.Hide();

                jsonManager = new JsonManager(ftpClient);
                jsonManager.LoadFromJson(); // Carrega els centres abans d'obrir el formulari

                SelectProfessor statsForm = new SelectProfessor(jsonManager);
                statsForm.Show();
            }
            else if (username == user2 && password == pass2)
            {
                this.Hide();

                jsonManager = new JsonManager(ftpClient);
                jsonManager.LoadFromJson(); // Carrega els centres abans d'obrir el formulari

                SelectAdminMode selectForm = new SelectAdminMode(jsonManager);
                selectForm.Show();
            }
            else
            {
                Utils.ShowDialogError();
            }
        }

        /// <summary>
        /// This method tries to establish a connection with the ftp server
        /// 
        /// </summary>
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