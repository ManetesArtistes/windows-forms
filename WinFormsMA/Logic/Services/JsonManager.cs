using Newtonsoft.Json;
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

            // Pujar un nivell per sortir de bin\Debug
            string solutionDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\.."));

            // Assegura't que la carpeta Json existeix
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
                    var jsonObject = JsonConvert.DeserializeObject<JsonBase>(jsonData); // Deserialitza directament a JsonBase
                    Centers = jsonObject?.Centers ?? new List<Center>(); // Assigna la llista de centres
                }
                else
                {
                    Console.WriteLine("Local JSON file does not exist.");
                    Centers = new List<Center>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
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
                // Descarrega el fitxer del servidor FTP a la ruta local
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

        public void AddCenter(Center newCenter)
        {
            Centers.Add(newCenter);
            SaveToJson();
        }

        public void EditCenter(int centerId, string newName)
        {
            var center = Centers.FirstOrDefault(c => c.Id == centerId);
            if (center != null)
            {
                center.Name = newName;
                SaveToJson();
            }
            else
            {
                Console.WriteLine("Center not found.");
            }
        }

        public void RemoveCenter(int centerId)
        {
            var center = Centers.FirstOrDefault(c => c.Id == centerId);
            if (center != null)
            {
                Centers.Remove(center);
                SaveToJson();
            }
            else
            {
                Console.WriteLine("Center not found.");
            }
        }
    }
}