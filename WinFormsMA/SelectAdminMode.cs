using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        private List<Center> centers;
        private JsonManager jsonManager;

        public SelectAdminMode(JsonManager jsonManager)
        {
            InitializeComponent();
            this.jsonManager = jsonManager;

            try
            {
                centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");

                if (centers == null || centers.Count == 0) // Comprova si s'han carregat centres abans de continuar
                {
                    MessageBox.Show("No s'han trobat centres al fitxer JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SelectAdminMode(List<Center> centers)
        {
            InitializeComponent();
            this.centers = centers ?? new List<Center>(); // Assegurem que no sigui nul
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            this.Hide();
            var logsForm = new Logs(centers);
            logsForm.Show();
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.Hide();
            var jsonForm = new JsonManagement(centers);
            jsonForm.Show();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.Show();
        }
    }
}