using Newtonsoft.Json;
using WinFormsMA.Logic;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class JsonManagement : BaseForm
    {
        private List<Center> centers;

        public JsonManagement(List<Center> centers)
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
                comboBoxCenter.Items.Add(center.Name); // `Name` en lloc de `CenterName`
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
                Center selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName); // `Name` en lloc de `CenterName`

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                }
            }
        }

        private void LoadClasses(Center selectedCenter)
        {
            comboBoxClass.Items.Clear();
            comboBoxClass.Items.Add("");

            foreach (var group in selectedCenter.Groups)
            {
                comboBoxClass.Items.Add(group.Name); // `Name` en lloc de `GroupName`
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
                Center selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName); // `Name` en lloc de `CenterName`
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                }
            }
        }

        private void LoadStudents(Center selectedCenter, string selectedClassName)
        {
            dataGridViewJson.Rows.Clear();

            var selectedGroup = selectedCenter.Groups.FirstOrDefault(group => group.Name == selectedClassName); // `Name` en lloc de `GroupName`

            if (selectedGroup != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    dataGridViewJson.Rows.Add(student.Name, null); // `Name` en lloc de `StudentName`
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode selectForm = new SelectAdminMode(centers);
            selectForm.Show();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                // Obté la fila seleccionada i crea l'objecte `Student`
                var selectedRow = dataGridViewJson.SelectedRows[0];
                var studentName = selectedRow.Cells[0].Value?.ToString();

                var student = new Student { Name = studentName }; // Crear l'objecte `Student`

                // Serialitza el `Student` a JSON
                string jsonStudent = JsonConvert.SerializeObject(student, Formatting.Indented);

                EditJson formEditJson = new EditJson(jsonStudent);
                if (formEditJson.ShowDialog() == DialogResult.OK)
                {
                    // Implementa els canvis necessaris després d'editar
                }
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per modificar.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Comprova si hi ha alguna fila seleccionada
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewJson.SelectedRows[0];

                DialogResult dialogResult = MessageBox.Show("Estàs segur que vols esborrar l'element seleccionat?", "Confirmar Esborrat", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridViewJson.Rows.Remove(selectedRow);

                    // Implementa la lògica per esborrar l'estudiant també de la font de dades
                }
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per esborrar.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear el diàleg per seleccionar la carpeta
                using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    folderBrowser.ShowNewFolderButton = true;

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        // Obté el directori seleccionat
                        string selectedPath = folderBrowser.SelectedPath;

                        // Defineix el nom del fitxer JSON
                        string fileName = "manetes_artistes.json";
                        string fullFilePath = Path.Combine(selectedPath, fileName);

                        // Descarrega el fitxer JSON des del servidor FTP
                        string remotePath = "json/manetes_artistes.json";

                        var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                        Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                        ftpClient.DownloadFile(remotePath, fullFilePath);

                        MessageBox.Show($"Fitxer descarregat correctament a:\n{fullFilePath}", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error descarregant el fitxer JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}