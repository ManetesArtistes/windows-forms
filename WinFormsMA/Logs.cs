﻿using System.IO;

namespace WinFormsMA
{
    public partial class Logs : BaseForm
    {
        public Logs()
        {
            InitializeComponent();
            LoadLogs();
        }

        private void LoadLogs()
        {
            try
            {
                // Camí per pujar dos nivells al directori del projecte
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string projectPath = Path.GetFullPath(Path.Combine(basePath, "..", "..")); // Puja dos nivells
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

                // Llista per guardar totes les línies de tots els fitxers
                List<string> allLogLines = new List<string>();

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
            // Tanca aquest formulari i obre l'anterior (p. ex., SelectAdminMode)
            this.Hide();

            // Exemple d'obertura d'un altre formulari
            SelectAdminMode selectAdminMode = new SelectAdminMode(null); // Passa la llista de centres si és necessari
            selectAdminMode.Show();
        }
    }
}