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
            textBoxEditCenter.Text = centerToEdit.Name;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string newCenterName = textBoxEditCenter.Text.Trim();

                if (string.IsNullOrEmpty(newCenterName))
                {
                    MessageBox.Show("El nom del centre no pot estar buit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (centers.Any(c => c != centerToEdit && c.Name.Equals(newCenterName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                centerToEdit.Name = newCenterName;

                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editant el centre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}