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
    public partial class NewClass : BaseForm
    {
        private List<JsonBase.Center> centers;
        private JsonBase.Center selectedCenter;
        public NewClass(List<JsonBase.Center> centers, JsonBase.Center selectedCenter)
        {
            InitializeComponent();
            this.centers = centers;
            this.selectedCenter = selectedCenter;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Stats statsForm = new Stats(centers);
            statsForm.Show();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxNewClass.Text))
            {
                MessageBox.Show("Afegeix una classe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (selectedCenter.Groups.Any(g => g.GroupName.Equals(textBoxNewClass.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Ja existeix una classe amb aquest nom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    JsonBase.Group newGroup = new JsonBase.Group
                    {
                        GroupName = textBoxNewClass.Text.Trim(),
                        Students = new List<JsonBase.Student>(new JsonBase.Student[16])
                    };

                    for (int i = 0; i < 16; i++)
                    {
                        var textBox = this.Controls.Find($"textBoxStudent{i + 1}", true).FirstOrDefault() as TextBox;

                        if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            newGroup.Students[i] = new JsonBase.Student
                            {
                                StudentName = textBox.Text.Trim(),
                                StudentId = i
                            };
                        }
                    }

                    selectedCenter.Groups.Add(newGroup);
                    MessageBox.Show("Classe creada correctament");

                    this.Hide();
                    Stats statsForm = new Stats(centers);
                    statsForm.Show();
                }
            }
        }
    }
}
