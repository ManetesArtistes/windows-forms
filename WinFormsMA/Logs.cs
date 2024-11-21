using WinFormsMA.Logic.Entities;

namespace WinFormsMA
{
    public partial class Logs : BaseForm
    {
        private List<Center> centers;

        public Logs(List<Center> centers)
        {
            InitializeComponent();
            this.centers = centers ?? new List<Center>(); // Assegura que la llista no sigui nul·la
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Passa la llista de centres correctament al formulari `SelectAdminMode`
            SelectAdminMode selectForm = new SelectAdminMode(centers);
            selectForm.Show();
        }
    }
}