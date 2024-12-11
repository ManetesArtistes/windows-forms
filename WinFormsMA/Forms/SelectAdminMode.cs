using WinFormsMA.Forms;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        private List<Center> centers;
        private JsonManager jsonManager;

        /// <summary>
        /// This method starts the form and download the json from ftp and
        /// put the centers from the json in the centers list
        /// 
        /// </summary>
        /// <param name="jsonManager"></param>
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

        /// <summary>
        /// This method ensures that the centers list is not null
        /// 
        /// /// </summary>
        /// <param name="centers"></param>
        public SelectAdminMode(List<Center> centers)
        {
            InitializeComponent();
            this.centers = centers ?? new List<Center>(); // Assegurem que no sigui nul
        }

        /// <summary>
        /// This method open the Logs form
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogs_Click(object sender, EventArgs e)
        {
            this.Hide();
            var logsForm = new Logs(centers);
            logsForm.Show();
        }

        /// <summary>
        /// This method open the Json forms
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.Hide();
            var jsonForm = new JsonManagement(centers);
            jsonForm.Show();
        }

        /// <summary>
        /// This method returns you to the form before
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new Login();
            loginForm.Show();
        }
    }
}