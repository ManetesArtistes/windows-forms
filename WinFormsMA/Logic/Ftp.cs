using System.Net;
using System.Text;
using DotNetEnv;
using Newtonsoft.Json;

namespace WinFormsMA.Logic
{
    internal class Ftp
    {
        private string ftpUrl;
        private string username;
        private string password;

        private List<JsonBase.Center> centers;

        public Ftp(string ftpUrl, string username, string password)
        {
            Utils.LoadEnvFile();

            this.ftpUrl = Env.GetString("FTP_URL");
            this.username = Env.GetString("FTP_USERNAME");
            this.password = Env.GetString("FTP_PASSWORD");

            centers = new List<JsonBase.Center>();
            LoadFTPCenters();
        }

        public bool TestConnection()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);

                // Obtenir la resposta del servidor
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"FTP connection successful, status: {response.StatusDescription}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FTP connection failed: {ex.Message}");
                return false;
            }
        }

        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}/{remoteFilePath}");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);

            byte[] fileContents = File.ReadAllBytes(localFilePath);
            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }

        public void DownloadFile(string remoteFilePath, string localFilePath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}/{remoteFilePath}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(username, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
            {
                responseStream.CopyTo(fileStream);
            }
        }

        public void TestFtpConnection()
        {
            if (string.IsNullOrEmpty(ftpUrl) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Les variables d'entorn per FTP no estan carregades correctament.");
                return;
            }

            if (TestConnection())
            {
                Console.WriteLine("Connexió FTP correcta!");
            }
            else
            {
                Console.WriteLine("No s'ha pogut establir la connexió FTP.");
            }
        }

        public void LoadFTPCenters()
        {
            try
            {
                // Defineix la ruta local on es descarregarà el fitxer JSON
                // Utilitza el directori temporal del sistema per emmagatzemar el fitxer.
                string localFilePath = Path.Combine(Path.GetTempPath(), "manetes_artistes.json");

                // Descarrega el fitxer "manetes_artistes.json" des del servidor FTP a la ruta local
                DownloadFile("json/manetes_artistes.json", localFilePath);

                // Llegeix el contingut del fitxer JSON descarregat i l'emmagatzema en una variable.
                string jsonContent = File.ReadAllText(localFilePath);

                // Deserialitza el contingut JSON a un objecte de tipus JsonBase.Root
                JsonBase.Root root = JsonConvert.DeserializeObject<JsonBase.Root>(jsonContent);

                // Comprova si la deserialització ha estat correcta
                if (root != null)
                {
                    // Si el fitxer JSON es deserialitza correctament, assigna la llista de centres
                    centers = root.Centers;
                    // Missatge d'èxit a la consola
                    Console.WriteLine("Centers carregats correctament.");
                }
                else
                {
                    // Si el fitxer JSON és buit o invàlid, mostra un missatge d'error
                    MessageBox.Show("El fitxer JSON està buit o és invàlid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura qualsevol excepció que es pugui produir durant la càrrega
                // Mostra el missatge d'error a la consola
                Console.WriteLine($"Error carregant els centres del FTP: {ex.Message}");
            }
        }

        // Obtenir la llista de centres
        public List<JsonBase.Center> GetCenters()
        {
            return centers;
        }

        public void DownloadJsonFile(string ftpUrl, string ftpUsername, string ftpPassword, string remoteFilePath, string localFilePath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + remoteFilePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Create))
                {
                    responseStream.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error descarregant el fitxer JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateCenter(JsonBase.Center center)
        {
            var jsonData = JsonConvert.SerializeObject(center); // Converteix el centre a JSON

            // Creem la petició FTP per carregar el fitxer
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}/{center.CenterName}.json");

            // Configura la petició per sobre-escriure el fitxer existent
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);

            // Especifica que el fitxer s'ha de sobreescriure
            byte[] fileContents = Encoding.UTF8.GetBytes(jsonData);

            // Escriu el contingut al fitxer
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            // Rep la resposta del servidor
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload File Complete, status: " + response.StatusDescription);
        }
    }
}