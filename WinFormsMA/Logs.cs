using WinFormsMA.Logic.Entities;

namespace WinFormsMA
{
    public partial class Logs : BaseForm
    {
        private List<Center> centers;

        public Logs(List<Center> centers)
        {
            InitializeComponent();
            this.centers = centers;
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..")); // Puja tres nivells
                string logPath = Path.Combine(projectPath, "Logs");

                if (!Directory.Exists(logPath))
                {
                    MessageBox.Show("No s'ha trobat la carpeta de logs.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] logFiles = Directory.GetFiles(logPath, "*.txt");

                if (logFiles.Length == 0)
                {
                    MessageBox.Show("No s'han trobat fitxers de logs.", "Informació", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                textBoxLogs.Clear();

                List<string> allLogLines = new List<string>(); // Llista per guardar totes les línies de tots els fitxers

                foreach (string file in logFiles)
                {
                    // Obre el fitxer en mode només lectura
                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            // Afegeix les línies tal com estan al fitxer
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                allLogLines.Add(line);
                            }
                        }
                    }
                }

                // Ordena les línies per mostrar les més recents primer
                foreach (string logLine in allLogLines.AsEnumerable().Reverse())
                {
                    textBoxLogs.AppendText(logLine + Environment.NewLine);
                }

                textBoxLogs.AppendText(Environment.NewLine + "--------------------------------" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant els logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectAdminMode selectAdminMode = new SelectAdminMode(centers);
            selectAdminMode.Show();
        }
    }
}