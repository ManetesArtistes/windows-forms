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
    public partial class Stats : BaseForm
    {
        private List<JsonBase.Center> centers;
        public Stats(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
            LoadCenters();
        }

        public void LoadCenters()
        {
            comboBoxCenter.Items.Clear();
            comboBoxCenter.Items.Add("");

            foreach (var center in centers)
            {
                comboBoxCenter.Items.Add(center.CenterName);
            }

            if (comboBoxCenter.Items.Count > 0)
            {
                comboBoxCenter.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No s'han trobat centres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCenter.SelectedIndex == 0)
            {
                comboBoxClass.Items.Clear();
                comboBoxClass.Items.Add("");
                comboBoxClass.SelectedIndex = 0;
                comboBoxClass.Enabled = false;
                buttonClass.Enabled = false;
                buttonEditClass.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                JsonBase.Center selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                    buttonClass.Enabled = true;
                    buttonEditClass.Enabled = true;
                }
            }
        }

        private void LoadClasses(JsonBase.Center selectedCenter)
        {
            ClearComboBox(comboBoxClass);
            if (selectedCenter.Groups != null)
            {
                comboBoxCenter.Enabled = true;
                foreach (var group in selectedCenter.Groups)
                {
                    comboBoxClass.Items.Add(group.GroupName);
                }

                if (comboBoxClass.Items.Count > 0)
                {
                    comboBoxClass.SelectedIndex = 0;
                }
            } else
            {
                comboBoxClass.SelectedIndex = 0;
                comboBoxClass.Enabled = false;
            }
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedIndex == 0)
            {
                comboBoxStudent.Items.Clear();
                comboBoxStudent.Items.Add("");
                comboBoxStudent.SelectedIndex = 0;
                comboBoxStudent.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                JsonBase.Center selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);
                string selectedClassName = comboBoxClass.SelectedItem.ToString();


                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                    comboBoxStudent.Enabled = true;
                }
            }
        }

        private void LoadStudents(JsonBase.Center selectedCenter, string selectedClassName)
        {
            ClearComboBox(comboBoxStudent);

            var selectedGroup = selectedCenter.Groups.FirstOrDefault(group => group.GroupName == selectedClassName);

            if (selectedGroup != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    comboBoxStudent.Items.Add(student.StudentName);
                }
            }
        }

        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("");
            comboBox.SelectedIndex = 0;
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.Show();
        }

        private void buttonCentre_Click(object sender, EventArgs e)
        {
            NewCenter newCenterForm = new NewCenter(centers);

            if (newCenterForm.ShowDialog() == DialogResult.OK)
            {
                LoadCenters();
            }
        }

        private void buttonClass_Click(object sender, EventArgs e)
        {
            this.Hide();

            NewClass newClassForm = new NewClass(centers);
            newClassForm.Show();
        }

        private void buttonEditCenter_Click(object sender, EventArgs e)
        {
            if (comboBoxCenter.Text.Length != 0)
            {
                string selectedCenterName = comboBoxCenter.Text;
                JsonBase.Center selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);

                if (selectedCenter != null)
                {
                    EditCenter editCenterForm = new EditCenter(centers, selectedCenter);

                    if (editCenterForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCenters();
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecciona un centre per modificar.");
            }
        }

        private void buttonEditClass_Click(object sender, EventArgs e)
        {
            if (comboBoxClass.Text.Length != 0)
            {
                this.Hide();

                EditClass editClassForm = new EditClass(centers);
                editClassForm.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una classe per modificar.");
            }
        }
    }
}
