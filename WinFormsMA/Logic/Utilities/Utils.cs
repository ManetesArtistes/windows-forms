﻿using DotNetEnv;

namespace WinFormsMA.Logic.Utilities
{
    internal class Utils
    {
        //public static bool EnvLoaded { get; private set; } = false;
        //public static void LoadEnvFile()
        //{
        //    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        //    string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
        //    string envFilePath = Path.Combine(projectRoot, ".env");

        //    if (File.Exists(envFilePath))
        //    {
        //        Env.Load(envFilePath);
        //        EnvLoaded = true;
        //    }
        //    else
        //    {
        //        EnvLoaded = false;
        //        MessageBox.Show("No s'ha trobat el fitxer .env. Es faran servir valors per defecte.");
        //    }
        //}

        //public static string GetEnvVariable(string key)
        //{
        //    return EnvLoaded ? Environment.GetEnvironmentVariable(key) ?? string.Empty : string.Empty;
        //}

        public static (string user1, string pass1, string user2, string pass2) GetEnvVariable()
        {
            string user1 = "profe";
            string pass1 = "profe";
            string user2 = "admin";
            string pass2 = "admin";

            return (user1, pass1, user2, pass2);
        }

        public static void ShowDialogError()
        {
            MessageBox.Show("Credencials Incorrectes, torna a provar-ho.");
        }

        //public static (string ftpUrl, string ftpUsername, string ftpPassword) GetFtpVariables()
        //{
        //    if (!EnvLoaded)
        //    {
        //        throw new InvalidOperationException("El fitxer .env no està carregat.");
        //    }

        //    string ftpUrl = GetEnvVariable("FTP_URL");
        //    string ftpUsername = GetEnvVariable("FTP_USERNAME");
        //    string ftpPassword = GetEnvVariable("FTP_PASSWORD");

        //    return (ftpUrl, ftpUsername, ftpPassword);
        //}

        public static (string ftpUrl, string ftpUsername, string ftpPassword) GetFtpVariables()
        {

            string ftpUrl = "ftp://ftp.onwindows-es.setupdns.net";
            string ftpUsername = "dam_03@abp-politecnics.com";
            string ftpPassword = "Politecnics2025";

            return (ftpUrl, ftpUsername, ftpPassword);
        }
    }
}