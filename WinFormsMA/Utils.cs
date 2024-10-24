using System;
using System.IO;
using DotNetEnv;

namespace WinFormsMA
{
    internal class Utils
    {
        public static bool EnvLoaded { get; private set; } = false;
        public static void LoadEnvFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string envFilePath = Path.Combine(projectRoot, ".env");

            if (File.Exists(envFilePath))
            {
                Env.Load(envFilePath);
                EnvLoaded = true;
            }
            else
            {
                EnvLoaded = false;
                MessageBox.Show("No s'ha trobat el fitxer .env. Es faran servir valors per defecte.");
            }
        }

        public static string GetEnvVariable(string key)
        {
            return EnvLoaded ? Environment.GetEnvironmentVariable(key) ?? string.Empty : string.Empty;
        }
    }
}