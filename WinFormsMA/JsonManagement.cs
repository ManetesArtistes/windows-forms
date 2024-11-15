using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WinFormsMA.Logic;

namespace WinFormsMA
{
    public partial class JsonManagement : BaseForm
    {
        private List<JsonBase.Center> centers;
        public JsonManagement(List<JsonBase.Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
            LoadCenters();
        }

        private void LoadCenters()
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
                dataGridViewJson.DataSource = null;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                JsonBase.Center selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                }
            }
        }

        private void LoadClasses(JsonBase.Center selectedCenter)
        {
            comboBoxClass.Items.Clear();
            comboBoxClass.Items.Add("");

            foreach (var group in selectedCenter.Groups)
            {
                comboBoxClass.Items.Add(group.GroupName);
            }

            if (comboBoxClass.Items.Count > 0)
            {
                comboBoxClass.SelectedIndex = 0;
            }
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedIndex == 0)
            {
                dataGridViewJson.Rows.Clear();
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                JsonBase.Center selectedCenter = centers.FirstOrDefault(center => center.CenterName == selectedCenterName);
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                }
            }
        }

        private void LoadStudents(JsonBase.Center selectedCenter, string selectedClassName)
        {
            dataGridViewJson.Rows.Clear();

            var selectedGroup = selectedCenter.Groups.FirstOrDefault(group => group.GroupName == selectedClassName);

            if (selectedGroup != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    dataGridViewJson.Rows.Add(student.StudentName, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode SelectForm = new SelectAdminMode(centers);
            SelectForm.Show();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                var studentSelected = (Student)dataGridViewJson.SelectedRows[0].DataBoundItem;

                string jsonStudent = JsonConvert.SerializeObject(studentSelected, Formatting.Indented);

                EditJson formEditJson = new EditJson(jsonStudent);
                if (formEditJson.ShowDialog() == DialogResult.OK)
                {


                }

            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per modificar.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Comprovar si hi ha alguna fila seleccionada
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewJson.SelectedRows[0];

                DialogResult dialogResult = MessageBox.Show("Estàs segur que vols esborrar l'element seleccionat?", "Confirmar Esborrat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridViewJson.Rows.Remove(selectedRow);

                    // També esborrar l'element de la font de dades.
                }
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per esborrar.");
            }
        }
    }
}