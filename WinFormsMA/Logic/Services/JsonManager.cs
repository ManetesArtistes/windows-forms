using Newtonsoft.Json;
using Serilog;
using WinFormsMA.Logic.Entities;
using WinFormsMA.Logic.Utilities;

namespace WinFormsMA.Logic.Services
{
    public class JsonManager
    {
        private readonly string localFilePath;
        private readonly Ftp ftpClient;

        public List<Center> Centers { get; private set; }

        public JsonManager(Ftp ftpClient)
        {
            // Obtén el directori base del projecte
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Pujar tres nivells per sortir de bin\Debug
            string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\.."));

            // Assegura que la carpeta Json existeix i la crea
            string jsonDirectory = Path.Combine(solutionDirectory, "Json");
            Directory.CreateDirectory(jsonDirectory);

            // Assigna el camí complet al fitxer JSON
            localFilePath = Path.Combine(jsonDirectory, "manetes_artistes.json");
            this.ftpClient = ftpClient;

            Centers = new List<Center>();
        }

        public void LoadFromJson()
        {
            try
            {
                if (File.Exists(localFilePath))
                {
                    string jsonData = File.ReadAllText(localFilePath);
                    var jsonObject = JsonConvert.DeserializeObject<JsonBase>(jsonData); // Deserialitza directament
                    Centers = jsonObject?.Centers ?? new List<Center>();
                }
                else
                {
                    Console.WriteLine("El fitxer JSON local no existeix.");
                    Centers = new List<Center>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error carregant el JSON: {ex.Message}");
            }
        }

        public void SaveToJson()
        {
            try
            {
                var jsonObject = new JsonBase { Centers = Centers }; // Construeix un JsonBase
                string jsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(localFilePath, jsonData); // Desa el fitxer
                Console.WriteLine("Local JSON file saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON: {ex.Message}");
            }
        }

        public void DownloadJsonFromFtp(string remotePath)
        {
            try
            {
                ftpClient.DownloadFile(remotePath, localFilePath);
                Console.WriteLine($"JSON file downloaded from FTP to {localFilePath}");
                LoadFromJson(); // Carrega el JSON a la memòria
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading JSON from FTP: {ex.Message}");
            }
        }

        public void UploadJsonToFtp(string remotePath)
        {
            try
            {
                SaveToJson();
                ftpClient.UploadFile(localFilePath, remotePath);
                Console.WriteLine("JSON file uploaded to FTP.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading JSON to FTP: {ex.Message}");
            }
        }

        public List<Center> LoadCentersFromFtp(string remoteFilePath)
        {
            try
            {
                DownloadJsonFromFtp(remoteFilePath);
                LoadFromJson();

                if (Centers == null || Centers.Count == 0)
                {
                    Log.Warning("No s'han trobat centres al fitxer JSON.");
                    return null;
                }
                Log.Information("S'han carregat {Count} centres des del JSON.", Centers.Count);
                return Centers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error carregant els centres des del fitxer JSON.");
                throw; // Torna a llançar l'excepció perquè el formulari la gestioni
            }
        }

        public List<Center> LoadCentersFromFtp(string remoteFilePath)
        {
            try
            {
                DownloadJsonFromFtp(remoteFilePath);
                LoadFromJson();

                if (Centers == null || Centers.Count == 0)
                {
                    Log.Warning("No s'han trobat centres al fitxer JSON.");
                    return null;
                }
                Log.Information("S'han carregat {Count} centres des del JSON.", Centers.Count);
                return Centers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error carregant els centres des del fitxer JSON.");
                throw; // Torna a llançar l'excepció perquè el formulari la gestioni
            }
        }
    }
}