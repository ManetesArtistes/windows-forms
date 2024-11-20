using Newtonsoft.Json;

namespace WinFormsMA.Logic
{
    public class JsonManager
    {
        private readonly string localFilePath;
        private readonly Ftp ftpClient;

        public List<Center> Centers { get; private set; }

        public JsonManager(string localFilePath, Ftp ftpClient)
        {
            this.localFilePath = localFilePath;
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
                    var jsonObject = JsonConvert.DeserializeObject<JsonBase.Root>(jsonData);
                    Centers = jsonObject?.Centers ?? new List<Center>();
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
                var jsonObject = new JsonBase.Root { Centers = Centers };
                string jsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                File.WriteAllText(localFilePath, jsonData);
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
                Console.WriteLine("JSON file downloaded from FTP.");
                LoadFromJson();
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