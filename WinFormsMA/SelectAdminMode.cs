namespace WinFormsMA
{
    public partial class SelectAdminMode : BaseForm
    {
        private List<JsonBase.Center> centers;

        public SelectAdminMode()
        {
            InitializeComponent();
            this.centers = centers ?? new List<JsonBase.Center>(); // Assegurem que no sigui nul
        }

        public SelectAdminMode(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers ?? new List<JsonBase.Center>(); // Assegurem que no sigui nul
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