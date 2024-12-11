using Newtonsoft.Json;
using Serilog;
using System.Text.RegularExpressions;
using WinFormsMA.Forms;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class SelectProfessor : BaseForm
    {
        private List<Center> centers;
        private JsonManager jsonManager;
        private List<DrawImage> drawImages;

        /// <summary>
        /// This method starts the form
        /// 
        /// </summary>
        /// <param name="jsonManager"></param>
        public SelectProfessor(JsonManager jsonManager)
        {
            InitializeComponent();
            this.jsonManager = jsonManager;

            InitialzeData();
        }

        /// <summary>
        /// This method initializes the form data
        /// </summary>
        private void InitialzeData()
        {
            //Carrega el centres desde el Json
            LoadCentersFromJson();

            //Carrega la lista de imatges dels dibuixos
            LoadDrawImages();

            //Descarrega el jsons de stats
            DownloadStatsJson();

            //Actualitza les stats del estudiants
            UpdateStudentStats();

        }

        /// <summary>
        /// This method try to download the centers json from the ftp server
        /// 
        /// </summary>
        private void LoadCentersFromJson()
        {
            try
            {
                centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");

                if (centers == null || centers.Count == 0) // Comprova si s'han carregat centres abans de continuar
                {
                    MessageBox.Show("No s'han trobat centres al fitxer JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCenters(); // Carrega els centres al ComboBox

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This method takes the name of the draw images from a json file
        /// and creates a class list of them
        /// </summary>
        private void LoadDrawImages()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
            string jsonFilePath = Path.Combine(basePath, "Draws", "draws.json");
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show("El arxiu no existeix en la ruta especificada");
                    drawImages = new List<DrawImage>();
                    return;
                }

                string jsonContent = File.ReadAllText(jsonFilePath);
                if (string.IsNullOrEmpty(jsonContent))
                {
                    MessageBox.Show("El arxiu json esta buit");
                    drawImages = new List<DrawImage>();
                    return;
                }

                drawImages = JsonConvert.DeserializeObject<List<DrawImage>>(jsonContent) ?? new List<DrawImage>();
            }
            catch (JsonException jsonEx)
            {
                MessageBox.Show("Error Json");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al carregar la lista de imatges");
                drawImages = new List<DrawImage>();
            }
        }

        /// <summary>
        /// This method try to download all the jsons files from the Stats folder from the 
        /// ftp server and if any it creates the stats folder in the application
        /// </summary>
        private void DownloadStatsJson()
        {
            try
            {
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
                string localStatsFolder = Path.Combine(basePath, "Stats");

                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                ftpClient.DownloadStatsJsons(localStatsFolder);
            }
            catch (Exception e)
            {
                MessageBox.Show("No s'han pogut descarregar els jsons de Stats");
            }
        }

        /// <summary>
        /// This method tries to check if there are json filen in the stats folder, and
        /// if there are it checks that each students of each json file exists in the centers list,
        /// if they exists it replaces the student stats from the centers list with those of the json file
        /// 
        /// </summary>
        private void UpdateStudentStats()
        {
            try
            {
                // Ruta de la carpeta on hi han els jsons de Stats
                string statsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Stats");
                // Agafa el nom de tots els json de la carpeta Stats
                string[] statsFiles = Directory.GetFiles(statsFolderPath, "stats_*.json");

                foreach (var statsFile in statsFiles)
                {
                    string statsJson = File.ReadAllText(statsFile);

                    List<Center> statsData = JsonConvert.DeserializeObject<List<Center>>(statsJson);

                    if (statsData != null)
                    {
                        foreach (var center in statsData)
                        {
                            foreach (var group in center.Groups)
                            {
                                foreach (var studentData in group.Students)
                                {
                                    // Aquí estamos buscando el estudiante dentro de los centros previamente cargados, no en statsData
                                    var student = FindStudentById(centers, studentData.Id);

                                    student.Stats = studentData.Stats;


                                    if (studentData.Stats.Score == null)
                                    {
                                        student.Stats.Score = [0];
                                    }
                                }
                            }
                        }
                    }
                }
                var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                foreach (var statsFile in statsFiles)
                {
                    string fileName = Path.GetFileName(statsFile);

                    ftpClient.DeleteFiles($"stats/{fileName}");
                    File.Delete(statsFile);
                }

                if (Directory.Exists(statsFolderPath) && Directory.GetFiles(statsFolderPath).Length == 0)
                {
                    Directory.Delete(statsFolderPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar las estadísticas: {ex.Message}");
            }
        }

        /// <summary>
        /// This method searches if there is any student with the same center id,
        /// group id and student id in the centers list with the one in json file
        /// 
        /// </summary>
        /// <param name="centers"></param>
        /// <param name="studentId"></param>
        /// <returns student or null></returns>
        private Student FindStudentById(List<Center> centers, int studentId)
        {
            foreach (var center in centers)
            {
                foreach (var group in center.Groups)
                {
                    var student = group.Students.FirstOrDefault(s => s.Id == studentId);
                    if (student != null)
                    {
                        return student;
                    }

                }
            }
            return null;
        }

        /// <summary>
        /// This method loads the name of the groups from the center selected
        /// in the comboBoxGroups
        /// 
        /// </summary>
        /// <param name="selectedCenter"></param>
        private void LoadCenters()
        {
            try
            {
                if (centers == null || centers.Count == 0)
                {
                    MessageBox.Show("No s'han trobat centres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ClearComboBox(comboBoxCenter);

                foreach (var center in centers)
                {
                    comboBoxCenter.Items.Add(center.Name); // Afegeix el nom del centre al ComboBox
                }

                if (comboBoxCenter.Items.Count > 0)
                {
                    comboBoxCenter.SelectedIndex = 0;
                }
                else
                {
                    Log.Warning("No hi ha centres disponibles per carregar.");
                    MessageBox.Show("No s'han trobat centres disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error carregant els centres.");
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                centers = new List<Center>(); // Llista buida per evitar errors
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
            ClearComboBox(comboBoxClass);

            if (selectedCenter?.Groups != null)
            {
                comboBoxClass.Enabled = true;

                foreach (var group in selectedCenter.Groups)
                {
                    comboBoxClass.Items.Add(group.Name); // Afegeix el nom del grup al ComboBox
                }

                if (comboBoxClass.Items.Count > 0)
                {
                    comboBoxClass.SelectedIndex = 0;
                }

                Log.Information("S'han carregat {Count} classes per al centre {CenterName}.",
                    selectedCenter.Groups.Count, selectedCenter.Name);
            }
            else
            {
                Log.Warning("El centre {CenterName} no té classes.", selectedCenter.Name);
                comboBoxClass.Enabled = false;
            }
        }

        /// <summary>
        /// This method loads the name of the students from the group selected
        /// in the comboBoxStudents
        /// 
        /// </summary>
        /// <param name="selectedCenter"></param>
        /// <param name="selectedClassName"></param
        private void LoadStudents(Center selectedCenter, string selectedClassName)
        {
            ClearComboBox(comboBoxStudent);

            var selectedGroup = selectedCenter?.Groups?.FirstOrDefault(group => group.Name == selectedClassName); // `Name` en lloc de `GroupName`

            if (selectedGroup?.Students != null)
            {
                foreach (var student in selectedGroup.Students)
                {
                    if (!string.IsNullOrEmpty(student?.Name)) // `Name` en lloc de `StudentName`
                    {
                        comboBoxStudent.Items.Add(student.Name);
                    }
                }

                if (comboBoxStudent.Items.Count > 0)
                {
                    comboBoxStudent.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// This method deletes all the content of a comboBox
        /// </summary>
        /// <param name="comboBox"></param>
        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(""); // Element buit inicial
            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// This method disables the comboBoxClass if there's no center selected and
        /// if there's one it shows its groups in the comboBoxClass
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCenter.SelectedIndex == 0)
            {
                ClearComboBox(comboBoxClass);
                comboBoxClass.Enabled = false;
                buttonClass.Enabled = false;
                buttonEditClass.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);

                if (selectedCenter != null)
                {
                    LoadClasses(selectedCenter);
                    comboBoxClass.Enabled = true;
                    buttonClass.Enabled = true;
                    buttonEditClass.Enabled = true;
                }
            }
        }

        /// <summary>
        /// This method disables the comboBoxStudent if there's no group selected and
        /// if tehre's one it shows its students in the comboBoxStudents
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClass.SelectedIndex == 0)
            {
                ClearComboBox(comboBoxStudent);
                comboBoxStudent.Enabled = false;
            }
            else
            {
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                if (selectedCenter != null)
                {
                    LoadStudents(selectedCenter, selectedClassName);
                    comboBoxStudent.Enabled = true;
                }
            }
        }

        /// <summary>
        /// This method shows the stats of the selected student and 
        /// enables the comboBoxDraws in case it has
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedIndex == 0)
            {
                StatsEnable(false);
            }
            else
            {
                StatsEnable(true);
                string studentName = comboBoxStudent.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());
                var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == comboBoxClass.SelectedItem.ToString());
                var selectedStudent = selectedGroup?.Students.FirstOrDefault(student => student.Name == studentName);

                if (selectedStudent?.Stats != null)
                {

                    if (selectedStudent.Stats.Score.Any())
                    {
                        //Mostra el score del Simon
                        int highestScore = selectedStudent.Stats.Score.Max();
                        labelSimon.Text = highestScore.ToString();
                        labelSimonTotal.Text = string.Join(",", selectedStudent.Stats.Score);
                    }
                    else
                    {
                        labelSimon.Text = "---";
                        labelSimonTotal.Text = "---";
                    }

                    comboBoxDraws.Items.Clear();
                    foreach (var draw in selectedStudent.Stats?.Draws ?? new List<Draw>())
                    {
                        comboBoxDraws.Items.Add($"Draw {draw.Id}");
                    }
                    labelDraws.Text = $"{selectedStudent.Stats.Draws?.Count ?? 0}";

                    ResetDrawStatsLabels();

                    if (selectedStudent.Stats.Draws?.Count > 0)
                    {
                        comboBoxDraws.Enabled = true;
                        comboBoxDraws.SelectedIndex = 0;

                    }
                    else
                    {
                        comboBoxDraws.Enabled = false;
                        pictureBoxDraw.Image = null;
                        pictureBoxDraw.BackgroundImage = Properties.Resources.background_square_landscape;
                    }
                }
                else
                {
                    labelSimon.Text = "";
                    labelSimonTotal.Text = "";
                    comboBoxDraws.Items.Clear();
                    labelDraws.Text = "0";
                    ResetDrawStatsLabels();
                }
            }
        }

        /// <summary>
        /// This method put enable true or false the stats
        /// </summary>
        /// <param name="enable"></param>
        private void StatsEnable(bool enable)
        {
            //Fa que es les stats siguin visibles o no
            pictureBoxSimon.Visible = enable;
            labelSimon.Visible = enable;
            labelSimonTotal.Visible = enable;

            comboBoxDraws.Visible = enable;
            pictureBoxDraw.Visible = enable;
            labelDrawsDone.Visible = enable;
            labelDraws.Visible = enable;
            labelTimestamp.Visible = enable;
            labelTimestampNum.Visible = enable;
            labelDuration.Visible = enable;
            labelDurationNum.Visible = enable;
            labelUsedColors.Visible = enable;
            labelUsedColorsNum.Visible = enable;

        }

        /// <summary>
        /// This method reset de draws stats
        /// </summary>
        private void ResetDrawStatsLabels()
        {
            labelTimestampNum.Text = "---";
            labelDurationNum.Text = "---";
            labelUsedColorsNum.Text = "---";
        }

        /// <summary>
        /// This method displays the stats for the selected draw of selected student.
        /// Also shows the image of the selected draw with that of the image list
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDraws_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxDraw.Image = null;
            pictureBoxDraw.BackgroundImage = null;

            if (comboBoxDraws.SelectedIndex >= 0)
            {
                string studentName = comboBoxStudent.SelectedItem.ToString();
                var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());
                var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == comboBoxClass.SelectedItem.ToString());
                var selectedStudent = selectedGroup?.Students.FirstOrDefault(student => student.Name == studentName);


                if (selectedStudent?.Stats?.Draws != null)
                {
                    var selectedDraw = selectedStudent.Stats.Draws[comboBoxDraws.SelectedIndex];

                    if (selectedDraw.Timestamp != 0)
                    {
                        DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(selectedDraw.Timestamp).DateTime;
                        labelTimestampNum.Text = dateTime.ToString("dd/MM/yyyy");
                    }
                    labelDurationNum.Text = selectedDraw.Duration != 0 ? selectedDraw.Duration.ToString() : "";
                    labelUsedColorsNum.Text = selectedDraw.UsedColors > 0 ? selectedDraw.UsedColors.ToString() : "0";


                    var drawImage = drawImages.FirstOrDefault(di => di.id == selectedDraw.Id);

                    if (drawImage != null)
                    {
                        try
                        {
                            var imageResource = Properties.Resources.ResourceManager.GetObject(drawImage.image) as Image;
                            var backgroundResource = Properties.Resources.ResourceManager.GetObject(drawImage.background) as Image;

                            pictureBoxDraw.Image = imageResource;
                            pictureBoxDraw.BackgroundImage = backgroundResource;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al carregar les imatges del dibuix");
                            pictureBoxDraw.Image = null;
                            pictureBoxDraw.BackgroundImage = null;
                        }
                    }
                }
                else
                {
                    ResetDrawStatsLabels();
                    pictureBoxDraw.Image = null;
                    pictureBoxDraw.BackgroundImage = null;
                }
            }

        }

        /// <summary>
        /// This method returns you to the form before
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

        /// <summary>
        /// This method open a form to create a new center
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCentre_Click(object sender, EventArgs e)
        {
            var newCenterForm = new NewCenter(jsonManager, centers);

            if (newCenterForm.ShowDialog() == DialogResult.OK)
            {
                Log.Information("S'ha creat un nou centre.");

                // Tornem a carregar els centres del JSON actualitzat
                centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");
                LoadCenters(); // Refresquem la ComboBox amb els nous centres
            }
        }

        /// <summary>
        /// This method open a form to edit the selected center
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditCenter_Click(object sender, EventArgs e)
        {
            string selectedCenterName = comboBoxCenter.Text;
            var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);

            if (selectedCenter != null)
            {
                var editCenterForm = new EditCenter(jsonManager, centers, selectedCenter);

                if (editCenterForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha editat el centre {CenterName}.", selectedCenter.Name);

                    // Tornem a carregar els centres del JSON actualitzat
                    centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");
                    LoadCenters(); // Refresquem la ComboBox amb els centres actualitzats
                }
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap centre per editar.");
                MessageBox.Show("Selecciona un centre per modificar.", "Advertència", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// This method open a form to create a new class in the selected center
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());

            if (selectedCenter != null)
            {

                var newClassForm = new NewClass(jsonManager, centers, selectedCenter);

                if (newClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha creat una nova classe per al centre {CenterName}.", selectedCenter.Name);
                    LoadClasses(selectedCenter); // Refresca les classes del centre seleccionat
                }

            }
            else
            {
                Log.Warning("No s'ha seleccionat cap centre per afegir una classe.");
                MessageBox.Show("Selecciona un centre abans de crear una classe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// This method open a form to edit the selected class in the selected center
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());
            var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == comboBoxClass.SelectedItem.ToString());

            if (selectedGroup != null && selectedCenter != null)
            {

                // Crear i mostrar el formulari d'edició
                var editClassForm = new EditClass(jsonManager, centers, selectedGroup, selectedCenter);

                if (editClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha editat la classe {ClassName} del centre {CenterName}.", selectedGroup.Name, selectedCenter.Name);
                    LoadClasses(selectedCenter); // Refrescar les classes del centre seleccionat
                }

            }
            else
            {
                Log.Warning("No s'ha seleccionat cap classe per editar.");
                MessageBox.Show("Selecciona una classe per modificar.", "Advertència", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// This method connects to the download all the images of all the students of
        /// the selected class and center in the directory that we choose
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {

                // Validació prèvia: que s'hagin seleccionat el centre i la classe
                if (comboBoxCenter.SelectedIndex == 0 || comboBoxClass.SelectedIndex == 0)
                {
                    MessageBox.Show("Selecciona un centre i una classe abans de descarregar les imatges.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obté el centre i el grup seleccionats
                string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                string selectedClassName = comboBoxClass.SelectedItem.ToString();

                var selectedCenter = centers.FirstOrDefault(center => center.Name == selectedCenterName);
                var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == selectedClassName);

                if (selectedCenter == null || selectedGroup == null)
                {
                    MessageBox.Show("No s'han trobat dades per al centre o la classe seleccionats.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obté IDs per filtrar les imatges
                int cid = selectedCenter.Id;
                int gid = selectedGroup.Id;
                var students = selectedGroup.Students;

                // Obre un diàleg perquè l'usuari triï una carpeta de descàrrega
                using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
                {
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        string localFolderPath = folderBrowser.SelectedPath;

                        // Connexió al servidor FTP
                        var (ftpUrl, ftpUsername, ftpPassword) = Utils.GetFtpVariables();
                        Ftp ftpClient = new Ftp(ftpUrl, ftpUsername, ftpPassword);

                        // Obté tots els fitxers de la carpeta /images/ al servidor FTP
                        var files = ftpClient.ListDirectory("images");

                        // Filtra els fitxers que coincideixen amb el patró i els IDs seleccionats
                        var matchingFiles = files.Where(file =>
                        {
                            // Patró del nom del fitxer: cid_X_gid_X_sid_X_drawid_X.png
                            var match = Regex.Match(file, @"cid_(\d+)_gid_(\d+)_sid_(\d+)_drawid_\d+\.png");
                            if (match.Success)
                            {
                                int fileCid = int.Parse(match.Groups[1].Value);
                                int fileGid = int.Parse(match.Groups[2].Value);
                                int fileSid = int.Parse(match.Groups[3].Value);

                                return fileCid == cid && fileGid == gid && students.Any(student => student.Id == fileSid);
                            }
                            return false;
                        }).ToList();

                        // Descarrega els fitxers filtrats amb el canvi de nom
                        foreach (var file in matchingFiles)
                        {
                            // Obté els IDs des del nom del fitxer
                            var match = Regex.Match(file, @"cid_(\d+)_gid_(\d+)_sid_(\d+)_drawid_\d+\.png");
                            int sid = int.Parse(match.Groups[3].Value);

                            // Troba l'estudiant corresponent
                            var student = students.FirstOrDefault(s => s.Id == sid);
                            if (student == null) continue;

                            // Compta quantes imatges del mateix estudiant ja s'han descarregat
                            int imageCount = Directory.GetFiles(localFolderPath, $"{student.Name}_{selectedGroup.Name}_{selectedCenter.Name}_*.png").Length + 1;

                            // Genera el nou nom local amb número seqüencial
                            string newFileName = $"{student.Name}_{selectedGroup.Name}_{selectedCenter.Name}_{imageCount}.png";
                            string remoteFilePath = $"images/{file}";
                            string localFilePath = Path.Combine(localFolderPath, newFileName);

                            try
                            {
                                ftpClient.DownloadFile(remoteFilePath, localFilePath);
                            }
                            catch (Exception ex)
                            {
                                Log.Error($"Error descarregant {file}: {ex.Message}");
                            }
                        }
                        MessageBox.Show($"S'han descarregat {matchingFiles.Count} imatges a la carpeta seleccionada.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durant la descàrrega de les imatges: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}