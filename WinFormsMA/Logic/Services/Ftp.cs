using System.Net;

namespace WinFormsMA.Logic.Services
{
    public class Ftp
    {
        private readonly string ftpUrl;
        private readonly string username;
        private readonly string password;

        public Ftp(string ftpUrl, string username, string password)
        {
            this.ftpUrl = ftpUrl;
            this.username = username;
            this.password = password;
        }

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
    }
}