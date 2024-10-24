using System;
using System.IO;
using DotNetEnv;

namespace WinFormsMA
{
    internal class Utils
    {
        public static void LoadEnvFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string projectRoot = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;
            string envFilePath = Path.Combine(projectRoot, ".env");

            Env.Load(envFilePath);
        }

        public static string GetEnvVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? string.Empty;
        }
    }
}