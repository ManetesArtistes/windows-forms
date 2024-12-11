using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class EditCenter : Form
    {
        private List<Center> centers;
        private Center centerToEdit;
        private JsonManager jsonManager;

        /// <summary>
        /// This method starts the form with the name of the selected center
        /// in the textBox
        /// 
        /// </summary>
        /// <param name="jsonManager"></param>
        /// <param name="centers"></param>
        /// <param name="centerToEdit"></param>
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

        /// <summary>
        /// This method close the form without save the changes
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This button save the new center name taking into account 
        /// that there is a name in the textBox
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editant el centre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}