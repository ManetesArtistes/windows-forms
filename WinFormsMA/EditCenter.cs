using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class EditCenter : Form
    {
        private List<Center> centers;
        private Center centerToEdit;

        public EditCenter(List<Center> centers, Center centerToEdit)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.centers = centers;
            this.centerToEdit = centerToEdit;
            textBoxEditCenter.Text = centerToEdit.Name;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string newCenterName = textBoxEditCenter.Text.Trim();

            if (string.IsNullOrEmpty(newCenterName))
            {
                MessageBox.Show("El nom del centre no pot estar buit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (centers.Any(c => c != centerToEdit && c.Name.Equals(newCenterName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    centerToEdit.Name = newCenterName;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}