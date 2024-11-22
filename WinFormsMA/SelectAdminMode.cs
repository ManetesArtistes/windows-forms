using WinFormsMA.Logic.Entities;

namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        private List<Center> centers;

        public SelectAdminMode()
        {
            InitializeComponent();
            this.centers = new List<Center>(); // Inicialització de la llista de centres
        }

        public SelectAdminMode(List<Center> centers)
        {
            InitializeComponent();
            this.centers = centers ?? new List<Center>(); // Assegurem que no sigui nul
        }

        private void buttonLogs_Click(object sender, EventArgs e)
        {
            this.Hide();
            var logsForm = new Logs();
            logsForm.Show();
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.Hide();
            var jsonForm = new JsonManagement(centers); // Passa la llista de centres al formulari de gestió JSON
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