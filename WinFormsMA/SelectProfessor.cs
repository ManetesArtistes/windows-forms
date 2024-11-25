using Serilog;
using System.Text.RegularExpressions;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Services;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA
{
    public partial class SelectProfessor : BaseForm
    {
        private List<Center> centers;
        private JsonManager jsonManager;
        private System.Windows.Forms.Timer refreshTimer;

        public SelectProfessor(JsonManager jsonManager)
        {
            InitializeComponent();
            this.jsonManager = jsonManager;

            try
            {
                centers = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json");

                if (centers == null || centers.Count == 0) // Comprova si s'han carregat centres abans de continuar
                {
                    MessageBox.Show("No s'han trobat centres al fitxer JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCenters(); // Carrega els centres al ComboBox

                // Timer per actualitzar les ComboBox
                refreshTimer = new System.Windows.Forms.Timer();
                refreshTimer.Interval = 10000; // Actualitza cada 5 segons
                refreshTimer.Tick += RefreshData; // Vincula el Tick amb la funció
                refreshTimer.Start(); // Comença el temporitzador
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els centres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void RefreshData(object sender, EventArgs e)
        {
            try
            {
                var updatedCenters = jsonManager.LoadCentersFromFtp("json/manetes_artistes.json"); // Torna a carregar els centres del JSON al servidor FTP

                if (updatedCenters != null && !updatedCenters.SequenceEqual(centers))
                {
                    centers = updatedCenters;
                    LoadCenters(); // Actualitza el ComboBox dels centres

                    // Si hi ha un centre seleccionat, actualitza les seves classes
                    if (comboBoxCenter.SelectedIndex > 0)
                    {
                        string selectedCenterName = comboBoxCenter.SelectedItem.ToString();
                        var selectedCenter = centers.FirstOrDefault(c => c.Name == selectedCenterName);

                        if (selectedCenter != null)
                        {
                            LoadClasses(selectedCenter);
                        }
                    }

                    Log.Information("Dades refrescades automàticament.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error refrescant les dades.");
            }
        }

        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(""); // Element buit inicial
            comboBox.SelectedIndex = 0;
        }

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

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }

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

        private void buttonClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());

            if (selectedCenter != null)
            {
                refreshTimer.Stop(); // Desactiva el temporitzador per evitar interferències

                var newClassForm = new NewClass(jsonManager, centers, selectedCenter);

                if (newClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha creat una nova classe per al centre {CenterName}.", selectedCenter.Name);
                    LoadClasses(selectedCenter); // Refresca les classes del centre seleccionat
                }

                refreshTimer.Start(); // Torna a activar el temporitzador
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap centre per afegir una classe.");
                MessageBox.Show("Selecciona un centre abans de crear una classe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditClass_Click(object sender, EventArgs e)
        {
            var selectedCenter = centers.FirstOrDefault(center => center.Name == comboBoxCenter.SelectedItem.ToString());
            var selectedGroup = selectedCenter?.Groups.FirstOrDefault(group => group.Name == comboBoxClass.SelectedItem.ToString());

            if (selectedGroup != null && selectedCenter != null)
            {
                refreshTimer.Stop(); // Parar el temporitzador abans d'obrir el formulari

                // Crear i mostrar el formulari d'edició
                var editClassForm = new EditClass(jsonManager, centers, selectedGroup, selectedCenter);

                if (editClassForm.ShowDialog() == DialogResult.OK)
                {
                    Log.Information("S'ha editat la classe {ClassName} del centre {CenterName}.", selectedGroup.Name, selectedCenter.Name);
                    LoadClasses(selectedCenter); // Refrescar les classes del centre seleccionat
                }

                refreshTimer.Start(); // Reiniciar el temporitzador després de tancar el formulari
            }
            else
            {
                Log.Warning("No s'ha seleccionat cap classe per editar.");
                MessageBox.Show("Selecciona una classe per modificar.", "Advertència", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                refreshTimer.Stop(); // Desactiva el temporitzador per evitar interferències

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
                refreshTimer.Start(); // Torna a activar el temporitzador
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durant la descàrrega de les imatges: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}