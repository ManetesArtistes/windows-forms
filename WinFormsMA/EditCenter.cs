using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class EditCenter : Form
    {
        private List<Center> centers;
        private Center centerToEdit;
        private JsonManager jsonManager;

        public EditCenter(JsonManager jsonManager, List<Center> centers, Center centerToEdit)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.centers = centers;
            this.centerToEdit = centerToEdit;
            this.jsonManager = jsonManager;

            // Inicialitza el TextBox amb el nom actual del centre
            textBoxEditCenter.Text = centerToEdit.Name;
            this.AcceptButton = buttonAccept; // Permet acceptar amb "Enter"
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                // Obté el nou nom del centre des del TextBox
                string newCenterName = textBoxEditCenter.Text.Trim();

                // Valida que no estigui buit
                if (string.IsNullOrEmpty(newCenterName))
                {
                    MessageBox.Show("El nom del centre no pot estar buit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Valida que no existeixi un altre centre amb el mateix nom
                if (centers.Any(c => c != centerToEdit && c.Name.Equals(newCenterName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualitza el nom del centre
                centerToEdit.Name = newCenterName;

                // Desa el JSON actualitzat localment i al servidor FTP
                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                this.Close(); // Tanca el formulari
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editant el centre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}