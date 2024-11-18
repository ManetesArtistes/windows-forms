using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class EditClass : BaseForm
    {
        private List<JsonBase.Center> centers;
        private JsonBase.Group selectedGroup;
        public EditClass(List<JsonBase.Center> centers, JsonBase.Group groupToEdit)
        {
            InitializeComponent();
            this.centers = centers;
            this.selectedGroup = groupToEdit;

            InitializedGroupData();
        }

        private void InitializedGroupData()
        {
            textBoxEditClass.Text = selectedGroup.GroupName;

            for (int i = 0; i < 16; i++)
            {
                var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    if (i < selectedGroup.Students.Count && selectedGroup.Students[i] != null)
                    {
                        textBox.Text = selectedGroup.Students[i].StudentName;
                    }
                    else
                    {
                        textBox.Text = string.Empty;
                    }

                }
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Stats statsForm = new Stats(centers);
            statsForm.Show();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            selectedGroup.GroupName = textBoxEditClass.Text.Trim();

            var updateStudents = new List<JsonBase.Student>();

            for (int i = 0; i < 16; ++i)
            {
                var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                if(textBox != null)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        if (i < selectedGroup.Students.Count)
                        {
                            updateStudents.Add(null);
                        }
                    }
                   
                    else
                    {
                        if (i < selectedGroup.Students.Count)
                        {
                            var existingStudent = selectedGroup.Students[i];
                            existingStudent.StudentName = textBox.Text.Trim();
                            updateStudents.Add(existingStudent);
                        }
                        else
                        {
                            updateStudents.Add(new JsonBase.Student
                            {
                                StudentName = textBox.Text.Trim(),
                                StudentId = i
                            });
                        }
                    }
                }
            }
            selectedGroup.Students = updateStudents;
            MessageBox.Show("Cambis fet");
            this.Hide();

            Stats statsForm = new Stats(centers);
            statsForm.Show();
        }
    }
}
