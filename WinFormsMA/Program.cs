using Serilog;
using System.IO;

namespace WinFormsMA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Defineix el cam� dels logs al directori del projecte
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Path.Combine(basePath, "..", "..", ".."); // Pujar tres nivells
            string logPath = Path.Combine(projectPath, "Logs");

            // Crea el directori de logs si no existeix
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            // Configura Serilog per escriure els logs al fitxer
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Defineix el nivell m�nim de registre
                .WriteTo.File(Path.Combine(logPath, "log-.txt"), rollingInterval: RollingInterval.Day) // Guarda logs amb RollingInterval diari
                .CreateLogger();

            try
            {
                Log.Information("Iniciant l'aplicaci�...");

                // Inicialitza la configuraci� de l'aplicaci�
                ApplicationConfiguration.Initialize();
                Application.Run(new Login());

                Log.Information("Aplicaci� tancada correctament.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "L'aplicaci� ha finalitzat de manera inesperada.");
                MessageBox.Show("S'ha produ�t un error cr�tic. Revisa els registres per a m�s detalls.", "Error Cr�tic", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush(); // Assegura't que Serilog tanca correctament
            }
        }
    }
}