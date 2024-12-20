using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;

namespace WinFormsMA
{
    public partial class EditClass : Form
    {
        private List<Center> centers;
        private Group selectedGroup;
        private Center selectedCenter;
        private JsonManager jsonManager;

        /// <summary>
        /// This method starts the form
        /// 
        /// </summary>
        /// <param name="jsonManager"></param>
        /// <param name="centers"></param>
        /// <param name="groupToEdit"></param>
        /// <param name="selectedCenter"></param>
        public EditClass(JsonManager jsonManager, List<Center> centers, Group groupToEdit, Center selectedCenter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.jsonManager = jsonManager;
            this.centers = centers;
            this.selectedGroup = groupToEdit;
            this.selectedCenter = selectedCenter;

            InitializeGroupData();
            this.AcceptButton = buttonSave; // Permet acceptar amb "Enter"
        }

        /// <summary>
        /// This method initializes the data of the students in the class by putting
        /// each student in their correponding textBox and the class name in theirs
        /// 
        /// </summary>
        private void InitializeGroupData()
        {
            // Inicialitza el TextBox amb el nom de la classe seleccionada
            textBoxEditClass.Text = selectedGroup.Name;

            // Assigna els noms dels estudiants als TextBoxes
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

        /// <summary>
        /// This method saves the changes made in the class taking into
        /// account that there are not 2 classes with the same name witthin the
        /// same center
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida que el nou nom de la classe no estigui duplicat
                if (selectedCenter.Groups.Any(g => g != selectedGroup && g.Name.Equals(textBoxEditClass.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualitza el nom de la classe
                selectedGroup.Name = textBoxEditClass.Text.Trim();

                // Actualitza la llista d'estudiants
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
                                Id = i,
                                Stats = new Stats
                                {
                                    Score = [0],
                                    Draws = new List<Draw>() // Inicialitza amb una llista buida de Draw
                                }
                            });
                        }
                    }
                    else
                    {
                        if (i < selectedGroup.Students.Count && selectedGroup.Students[i] != null)
                        {
                            selectedGroup.Students[i] = null;
                        }
                        updatedStudents.Add(new Student
                        {
                            Id = i,
                            Name = null,
                            Stats = new Stats
                            {
                                Score = [0],
                                Draws = new List<Draw>()
                            }
                        });
                    }
                }

                // Assigna la nova llista d'estudiants al grup
                selectedGroup.Students = updatedStudents;

                // Desa els canvis al JSON local i al servidor FTP
                jsonManager.SaveToJson();
                jsonManager.UploadJsonToFtp("json/manetes_artistes.json");

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error desant els canvis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error durant l'edici� de la classe.");
            }
        }

        /// <summary>
        /// This method returns you to the form before without save the changes
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            var selectProfessorForm = new SelectProfessor(jsonManager);
            selectProfessorForm.Show();
        }
    }
}