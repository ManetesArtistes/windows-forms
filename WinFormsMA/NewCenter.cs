using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class NewCenter : Form
    {
        private List<Center> centers;
        private JsonManager jsonManager;

        public NewCenter(JsonManager jsonManager, List<Center> centers)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.jsonManager = jsonManager;
            this.centers = centers;
            this.AcceptButton = buttonAccept;
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
            else if (centers.Any(c => c.Name.Equals(centerName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int centerId = centers.Any() ? centers.Max(c => c.Id) + 1 : 1;

                // Crea el nou objecte Center
                var center = new Center
                {
                    Id = centerId,
                    Name = centerName,
                    Groups = new List<Group>() // Inicialitza una llista buida
                };

                jsonManager.AddCenter(center); // Utilitza JsonManager per afegir el centre i desar els canvis

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}