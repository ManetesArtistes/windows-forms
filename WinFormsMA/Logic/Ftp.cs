using System;
using System.IO;
using System.Net;
using DotNetEnv;

namespace WinFormsMA.Logic
{
    internal class Ftp
    {
        private string ftpUrl;
        private string username;
        private string password;

        public Ftp(string ftpUrl, string username, string password)
        {
            Utils.LoadEnvFile();

            this.ftpUrl = Env.GetString("FTP_URL");
            this.username = Env.GetString("FTP_USERNAME");
            this.password = Env.GetString("FTP_PASSWORD");
        }

        public bool TestConnection()
        {
            try
            {
                // Crear una petició FTP a l'URL del servidor
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{ftpUrl}");
                request.Method = WebRequestMethods.Ftp.ListDirectory;  // Comanda LIST per comprovar la connexió
                request.Credentials = new NetworkCredential(username, password);

                // Obtenir la resposta del servidor
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // Si arribem aquí, la connexió és correcta
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
    }
}