using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using envars.Parsers;

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
      if (File.Exists(configPath))
      {

        if ((new EnvParser()).TryParse(File.ReadAllLines(path), out var result))
        {
          return result;
        }
        else if ((new JSONParser()).TryParse(File.ReadAllText(path), out result))
        {
          return result;
        }
        else
        {
          throw new FormatException();
        }
      }
      else
      {
        throw new FileNotFoundException();
      }
    }
  }
}