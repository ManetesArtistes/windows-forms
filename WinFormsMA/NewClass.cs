using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class NewClass : BaseForm
    {
        private List<Center> centers;
        private Center selectedCenter;

        public NewClass(List<Center> centers, Center selectedCenter)
        {
            InitializeComponent();
            this.centers = centers;
            this.selectedCenter = selectedCenter;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxNewClass.Text))
                {
                    MessageBox.Show("Afegeix un nom per a la classe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newClassName = textBoxNewClass.Text.Trim();

                if (selectedCenter.Groups.Any(g => g.Name.Equals(newClassName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newGroup = new Group
                {
                    Name = newClassName,
                    Students = new List<Student>() // Inicialitza amb una llista buida
                };

                for (int i = 0; i < 16; i++)
                {
                    var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                    if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        newGroup.Students.Add(new Student
                        {
                            Name = textBox.Text.Trim(),
                            Id = i
                        });
                    }
                }

                selectedCenter.Groups.Add(newGroup);

                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();

                var jsonManager = new JsonManager(new Ftp(ftpUrl, ftpUsername, ftpPassword));
                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                MessageBox.Show("Classe creada correctament.");
                this.DialogResult = DialogResult.OK;
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
            this.Hide();

            SelectProfessor statsForm = new SelectProfessor(new JsonManager(new Ftp("", "", "")));
            statsForm.Show();
        }
    }
}