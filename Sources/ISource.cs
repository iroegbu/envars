using System.Collections.Generic;
using System.IO;

namespace envars.Sources
{
  interface ISource
  {
    Dictionary<string, string> GetVariables(string path);

    string GetConfigPath(string path)
    {
      string finalPath = "";
      if (File.Exists(path))
      {
        return Path.GetFullPath(path);
      }
      // check other default paths
      return finalPath;
    }

    Dictionary<string, string> GetConfig(string path)
    {
      string configPath = GetConfigPath(path);
      // Parse file (YAML or env)

      return new Dictionary<string, string>();
    }
  }
}