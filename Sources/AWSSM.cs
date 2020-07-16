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
      var configPath = source.GetConfig(path);

      throw new NotImplementedException();
    }
  }
}