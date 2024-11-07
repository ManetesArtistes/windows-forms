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
        public JsonManagement()
        {
            InitializeComponent();

            exampleImport();
        }

        private void exampleImport()
        {
            dataGridViewJson.Rows.Add("Alice", 25);
            dataGridViewJson.Rows.Add("Bob", 30);
            dataGridViewJson.Rows.Add("Charlie", 35);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode SelectForm = new SelectAdminMode();
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