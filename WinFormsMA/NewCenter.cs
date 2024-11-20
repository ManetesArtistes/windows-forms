using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class NewCenter : Form
    {
        private List<JsonBase.Center> centers;
        private Ftp ftp;

        public NewCenter(Ftp ftp, List<JsonBase.Center> centers)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.ftp = ftp;
            this.centers = centers;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string centerName = textBoxNewCenter.Text.Trim();

            if (string.IsNullOrEmpty(centerName))
            {
                MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (centers.Any(c => c.CenterName.Equals(centerName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int centerId = centers.Any() ? centers.Max(c => c.CenterId) + 1 : 1;

                JsonBase.Center center = new JsonBase.Center
                {
                    CenterId = centerId,
                    CenterName = centerName,
                    Groups = null
                };

                ftp.AddCenter(center); // Utilitza el mètode centralitzat
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}