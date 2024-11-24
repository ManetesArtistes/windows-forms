using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class EditClass : BaseForm
    {
        private List<Center> centers;
        private Group selectedGroup;
        private Center selectedCenter;

        public EditClass(List<Center> centers, Group groupToEdit, Center selectedCenter)
        {
            InitializeComponent();
            this.centers = centers;
            this.selectedGroup = groupToEdit;
            this.selectedCenter = selectedCenter;

            InitializeGroupData();
        }

        private void InitializeGroupData()
        {
            textBoxEditClass.Text = selectedGroup.Name;

            for (int i = 0; i < 16; i++)
            {
                var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    if (i < selectedGroup.Students.Count && selectedGroup.Students[i] != null)
                    {
                        textBox.Text = selectedGroup.Students[i].Name;
                    }
                    else
                    {
                        textBox.Text = string.Empty;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCenter.Groups.Any(g => g != selectedGroup && g.Name.Equals(textBoxEditClass.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                selectedGroup.Name = textBoxEditClass.Text.Trim();

                var updatedStudents = new List<Student>();

                for (int i = 0; i < 16; ++i)
                {
                    var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                    if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        if (i < selectedGroup.Students.Count)
                        {
                            selectedGroup.Students[i].Name = textBox.Text.Trim();
                            updatedStudents.Add(selectedGroup.Students[i]);
                        }
                        else
                        {
                            updatedStudents.Add(new Student
                            {
                                Name = textBox.Text.Trim(),
                                Id = i
                            });
                        }
                    }
                }
                selectedGroup.Students = updatedStudents;

                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                var jsonManager = new JsonManager(new Ftp(ftpUrl, ftpUsername, ftpPassword));
                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                MessageBox.Show("Canvis fets correctament.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error desant els canvis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error durant l'edició de la classe.");
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