using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class NewClass : Form
    {
        private List<Center> centers;
        private JsonManager jsonManager;
        private Center selectedCenter;

        public NewClass(JsonManager jsonManager, List<Center> centers, Center selectedCenter)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.jsonManager = jsonManager;
            this.centers = centers;
            this.selectedCenter = selectedCenter;
            this.AcceptButton = buttonCreate;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string className = textBoxNewClass.Text.Trim();

                if (string.IsNullOrEmpty(className))
                {
                    MessageBox.Show("Afegeix un nom per a la classe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (selectedCenter.Groups.Any(g => g.Name.Equals(className, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Genera un nou ID per al grup
                int newGroupId = selectedCenter.Groups.Any() ? selectedCenter.Groups.Max(g => g.Id) + 1 : 0;

                // Crea el nou grup
                var newGroup = new Group
                {
                    Id = newGroupId,
                    Name = className,
                    Students = new List<Student>() // Inicialitza amb una llista buida
                };

                // Afegeix els estudiants introduïts als TextBoxs
                for (int i = 0; i < 16; i++)
                {
                    var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                    if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        newGroup.Students.Add(new Student
                        {
                            Id = i,
                            Name = textBox.Text.Trim(),
                            Stats = new Stats
                            {
                                Score = 0,
                                Draws = new List<Draw>() // Inicialitza amb una llista buida de Draw
                            }
                        });
                    }
                }

                // Afegeix el grup al centre seleccionat
                selectedCenter.Groups.Add(newGroup);

                // Desa el JSON i el puja al servidor FTP
                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creant la classe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error durant la creació de la classe.");
            }
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}