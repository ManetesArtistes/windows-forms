using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsMA
{
    internal class Utils
    {
        public static string GetEnvVariable(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? string.Empty;
        }
    }
}
