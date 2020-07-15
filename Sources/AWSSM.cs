using System;
using System.Collections.Generic;

namespace envars.Sources
{
  public class AWSSM : ISource
  {
    private string _config;
    public AWSSM(string config)
    {
      _config = config;
    }

    public Dictionary<string, string> GetVariables(string path)
    {
      ISource source = this;
      string configPath = source.GetConfigPath(path);

      // parse file content (YAML, JSON or .env parser)
      throw new NotImplementedException();
    }
  }
}