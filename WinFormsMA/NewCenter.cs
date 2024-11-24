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
            try
            {
                string centerName = textBoxNewCenter.Text.Trim();

                if (string.IsNullOrEmpty(centerName))
                {
                    MessageBox.Show("Afegeix el nom d'un centre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (centers.Any(c => c.Name.Equals(centerName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix un centre amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int centerId = centers.Any() ? centers.Max(c => c.Id) + 1 : 1;

                // Crea el nou objecte Center
                var center = new Center
                {
                    Id = centerId,
                    Name = centerName,
                    Groups = new List<Group>() // Inicialitza una llista buida
                };

                centers.Add(center);

                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creant el centre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}