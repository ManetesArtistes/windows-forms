using System.Net;

namespace WinFormsMA.Logic.Services
{
    public class Ftp
    {
        private readonly string ftpUrl;
        private readonly string username;
        private readonly string password;

        /// <summary>
        /// This method create the Ftp with a ftpUrl, username and password to
        /// connect to the ftp server
        /// </summary>
        /// <param name="ftpUrl"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Ftp(string ftpUrl, string username, string password)
        {
            this.ftpUrl = ftpUrl;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// This method try to connect to de ftp using the propierties
        /// </summary>
        /// <returns>
        /// true if the connection is correct
        /// false if the connection fails
        /// </returns>
        public bool TestConnection()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password);

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

        /// <summary>
        /// This method try to download the json file from stats folder in the ftp server
        /// if exists any json file
        /// </summary>
        /// <param name="localStatsFolder"></param>
        public void DownloadStatsJsons (string localStatsFolder)
        {
            try
            {
                var files = ListDirectory("stats");

                var jsonFiles = files.Where(f => f.EndsWith(".json", StringComparison.OrdinalIgnoreCase)).ToList();

                if (!Directory.Exists(localStatsFolder))
                {
                    Directory.CreateDirectory(localStatsFolder);
                }

                foreach(var file in jsonFiles)
                {
                    string remoteFilePath = $"stats/{file}";
                    string localFilePath = Path.Combine(localStatsFolder, file);

                    DownloadFile(remoteFilePath, localFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al descargar los archivos JSON de stats");
                throw;
            }
        }

        /// <summary>
        /// This method try to upload the json file to the ftp server
        /// </summary>
        /// <param name="localFilePath"></param>
        /// <param name="remoteFilePath"></param>
        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            try
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
                    Console.WriteLine($"Upload complete, status: {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// This method tri to download the json file from the ftp server
        /// </summary>
        /// <param name="remoteFilePath"></param>
        /// <param name="localFilePath"></param>
        public void DownloadFile(string remoteFilePath, string localFilePath)
        {
            try
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

                Console.WriteLine($"Download complete: {localFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
            }
        }

        /// <summary>
        /// This method try to return a list from files on a directory
        /// </summary>
        /// <param name="remoteDirectory"></param>
        /// <returns>
        /// The files from the directory 
        /// </returns>
        public List<string> ListDirectory(string remoteDirectory)
        {
            var files = new List<string>();
            try
            {
                // Crear la petició FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}/{remoteDirectory}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(username, password); // Corregit aquí

                // Obtenir la resposta del servidor FTP
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        files.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error llistant el directori FTP: {ex.Message}");
            }
            return files;
        }

        /// <summary>
        /// This method try to delete a file from ftp server
        /// </summary>
        /// <param name="remoteFilePath"></param>
        public void DeleteFiles(string remoteFilePath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}/{remoteFilePath}");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el archivo en el servidor FTP");
            }
        }
    }
}