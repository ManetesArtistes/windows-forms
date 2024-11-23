using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

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
            if (string.IsNullOrWhiteSpace(textBoxNewClass.Text))
            {
                MessageBox.Show("Afegeix una classe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (selectedCenter.Groups.Any(g => g.Name.Equals(textBoxNewClass.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var newGroup = new Group
                    {
                        Name = textBoxNewClass.Text.Trim(),
                        Students = new List<Student>(new Student[16])
                    };

                    for (int i = 0; i < 16; i++)
                    {
                        var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                        if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            newGroup.Students[i] = new Student
                            {
                                Name = textBox.Text.Trim(),
                                Id = i
                            };
                        }
                    }

                    selectedCenter.Groups.Add(newGroup);
                    MessageBox.Show("Classe creada correctament");
                    this.Hide();

                    SelectProfessor statsForm = new SelectProfessor(new JsonManager(new Ftp("ftpUrl", "ftpUsername", "ftpPassword")));
                    statsForm.Show();
                }
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectProfessor statsForm = new SelectProfessor(new JsonManager(new Ftp("ftpUrl", "ftpUsername", "ftpPassword")));
            statsForm.Show();
        }
    }
}