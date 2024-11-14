using WinFormsMA.Logic;
using Newtonsoft.Json;

namespace WinFormsMA
{
    public partial class Login : BaseForm
    {
        private List<JsonBase.Center> centers;
        public Login()
        {
            InitializeComponent();
            Utils.LoadEnvFile();
            this.AcceptButton = buttonLogIn;
            centers = new List<JsonBase.Center>();
            LoadCenters();
            testFTP();
        }

        private void LoadCenters()
        {
            string ftpUrl = Utils.GetEnvVariable("FTP_URL");
            string ftpUsername = Utils.GetEnvVariable("FTP_USERNAME");
            string ftpPassword = Utils.GetEnvVariable("FTP_PASSWORD");
            string localFilePath = Path.Combine(Path.GetTempPath(), "jsonExemple.json");

            Ftp ftpConnection = new Ftp(ftpUrl, ftpUsername, ftpPassword);

            ftpConnection.DownloadFile("jsonbase/jsonExemple.json", localFilePath);

            string jsonContent = File.ReadAllText(localFilePath);

            JsonBase.Root root = JsonConvert.DeserializeObject<JsonBase.Root>(jsonContent);

            if (root != null)
            {
                centers = root.Centers;
            }
            else
            {
                MessageBox.Show("No s'ha pogut carregar el fitxer JSON o està buit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                Stats statsForm = new Stats(centers);
                statsForm.Show();
            }
            else if (username == user2 && password == pass2)
            {
                this.Hide();

                SelectAdminMode SelectForm = new SelectAdminMode(centers);
                SelectForm.Show();
            }
            else
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

            // Comprovar la connexió FTP
            if (ftpClient.TestConnection())
            {
                Console.WriteLine("Connexió FTP correcta!");
            }
            else
            {
                Console.WriteLine("No s'ha pogut establir la connexió FTP.");
            }
        }
    }
}