using System;
using System.IO;

namespace envars.Utilities
{
    public static class ConfigurationLocator
    {
        private static string[] _configPaths = { AppDomain.CurrentDomain.BaseDirectory, "/etc", "/$HOME" };

        public static string LocateConfigFile(string ConfigPath)
        {
            if (ConfigPath != "")
            {
                return Path.Combine(ConfigPath, ".envars");
            }
            return FindConfigFile();
        }

        public static string FindConfigFile()
        {
            foreach (var dirPath in _configPaths)
            {
                if (File.Exists(Path.Combine(dirPath, ".envars")))
                {
                    return Path.Combine(dirPath, ".envars");
                }
            }
            throw new FileNotFoundException();
        }
    }
}
