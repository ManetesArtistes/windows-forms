using Newtonsoft.Json;
using WinFormsMA.Forms;
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

        /// <summary>
        /// This method loads the name of the centers from the centers list
        /// in the comboBoxCenter
        /// 
        /// </summary>
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

        /// <summary>
        /// This method loads the name of the groups from the center selected
        /// in the comboBoxGroups
        /// 
        /// </summary>
        /// <param name="selectedCenter"></param>
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

        /// <summary>
        /// This method loads the name of the students from the group selected
        /// in the dataGridViewJson
        /// 
        /// </summary>
        /// <param name="selectedCenter"></param>
        /// <param name="selectedClassName"></param>
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

        /// <summary>
        /// This method takes the centers list and converts it into a json
        /// file to upload to the ftp server
        /// 
        /// </summary>
        private void SaveJsonToFile()
        {
            try
            {
                // Defineix el camí absolut al directori "Json" dins el projecte
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\.."));
                string jsonDirectory = Path.Combine(solutionDirectory, "Json");

                // Defineix el camí complet del fitxer JSON
                string localFilePath = Path.Combine(jsonDirectory, "manetes_artistes.json");

                // Crea la carpeta si no existeix
                if (!Directory.Exists(jsonDirectory))
                {
                    Directory.CreateDirectory(jsonDirectory);
                }

                // Comprova que la llista conté les dades correctes
                Console.WriteLine($"Contingut de centers abans de desar: {JsonConvert.SerializeObject(centers, Formatting.Indented)}");

                // Serialitza la llista de centres
                var jsonBase = new JsonBase { Centers = centers };
                string jsonData = JsonConvert.SerializeObject(jsonBase, Formatting.Indented);

                // Desa el JSON al fitxer
                File.WriteAllText(localFilePath, jsonData);

                Console.WriteLine($"Fitxer JSON desat correctament a: {localFilePath}");

                // Pujar el fitxer al servidor FTP
                UploadJsonToFtp(localFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error desant el fitxer JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This methods upload the json file into the ftp server
        /// 
        /// </summary>
        /// <param name="localFilePath"></param>
        private void UploadJsonToFtp(string localFilePath)
        {
            try
            {
                // Defineix el camí remot al servidor FTP
                string remoteFilePath = "json/manetes_artistes.json";

                // Obtenir les credencials FTP
                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                // Pujar el fitxer
                ftpClient.UploadFile(localFilePath, remoteFilePath);

                Console.WriteLine($"Fitxer JSON pujat correctament al servidor FTP a: {remoteFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pujant el fitxer JSON al servidor FTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This method creates a unique name for the file that is uploaded to the ftp server
        /// 
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <return ></returns>
        private string GenerateUniqueFileName(string originalFileName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileExtension = Path.GetExtension(originalFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);

            return $"{fileNameWithoutExtension}_{timestamp}{fileExtension}";
        }

        /// <summary>
        /// This method shows the groups in the comboBoxClasses depending
        /// on the center we select in the comboBoxCenter
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// This method shows the students in the dataGriedViewJson depending
        /// on the group we select in the comboBoxClasses
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// This method returns you to the form before
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode selectForm = new SelectAdminMode(centers);
            selectForm.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                // Obté la fila seleccionada i l'objecte `Student` associat
                var selectedRow = dataGridViewJson.SelectedRows[0];
                string studentName = selectedRow.Cells[0].Value?.ToString();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    MessageBox.Show("Selecciona un estudiant vàlid per modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obté el `Center` i el `Group` seleccionats
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);
                var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == selectedClassName);

                if (selectedCenter == null || selectedGroup == null)
                {
                    MessageBox.Show("Error trobant el centre o el grup seleccionat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var studentToModify = selectedGroup.Students.FirstOrDefault(student => student.Name == studentName);

                if (studentToModify == null)
                {
                    MessageBox.Show("No s'ha trobat l'estudiant seleccionat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obrir la finestra per editar l'estudiant
                EditJson formEditJson = new EditJson(JsonConvert.SerializeObject(studentToModify, Formatting.Indented));

                if (formEditJson.ShowDialog() == DialogResult.OK)
                {
                    // Recupera el JSON modificat i actualitza l'objecte
                    string modifiedJson = formEditJson.JsonMod;
                    var modifiedStudent = JsonConvert.DeserializeObject<Student>(modifiedJson);

                    if (modifiedStudent != null)
                    {
                        // Actualitza les propietats de l'estudiant original
                        studentToModify.Name = modifiedStudent.Name;
                        studentToModify.Id = modifiedStudent.Id;
                        studentToModify.Stats = modifiedStudent.Stats;

                        SaveJsonToFile(); // Torna a desar els canvis al fitxer

                        MessageBox.Show("Canvis guardats correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadStudents(selectedCenter, selectedGroup.Name); // Refresca la vista
                    }
                }
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per modificar.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewJson.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewJson.SelectedRows[0];
                string studentName = selectedRow.Cells[0].Value?.ToString();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    MessageBox.Show("Selecciona un estudiant vàlid per eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);
                var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == selectedClassName);

                if (selectedGroup != null)
                {
                    var studentToRemove = selectedGroup.Students.FirstOrDefault(student => student.Name == studentName);
                    if (studentToRemove != null)
                    {
                        selectedGroup.Students.Remove(studentToRemove); // Elimina l'estudiant de la llista
                        SaveJsonToFile(); // Desa els canvis localment
                        MessageBox.Show("Estudiant eliminat correctament.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Puja el fitxer JSON actualitzat al servidor FTP
                        try
                        {
                            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\.."));
                            string jsonDirectory = Path.Combine(solutionDirectory, "Json");
                            string localFilePath = Path.Combine(jsonDirectory, "manetes_artistes.json");

                            UploadJsonToFtp(localFilePath); // Pujar el fitxer al servidor FTP
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error pujant el fitxer JSON al servidor FTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LoadStudents(selectedCenter, selectedGroup.Name); // Refresca la vista
                    }
                }
                else
                {
                    MessageBox.Show("No s'ha trobat el grup seleccionat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Si us plau, selecciona una fila per eliminar.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog()) // Crea el diàleg per seleccionar la carpeta
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

        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog()) // Crea el diàleg per seleccionar el fitxer
                {
                    openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    openFileDialog.Title = "Selecciona un fitxer JSON per importar";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Obté el camí complet del fitxer seleccionat
                        string selectedFilePath = openFileDialog.FileName;

                        // Obté el nom del fitxer seleccionat
                        string originalFileName = Path.GetFileName(selectedFilePath);

                        // Genera un nom únic per al servidor
                        string newFileName = GenerateUniqueFileName(originalFileName);

                        // Defineix el camí complet al servidor FTP
                        string remotePath = $"imports/{newFileName}";

                        // Obtenir les credencials FTP
                        var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                        Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                        // Pujar el fitxer al servidor FTP
                        ftpClient.UploadFile(selectedFilePath, remotePath);

                        MessageBox.Show($"Fitxer pujat correctament al servidor:\n{remotePath}", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pujant el fitxer JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}