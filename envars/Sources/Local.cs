using System;
using System.Collections.Generic;

namespace envars.Sources
{
  public class Local : ISource
  {
    private string _config;
    public Local(string config)
    {
      _config = config;
    }

    public Dictionary<string, string> GetVariables(string path)
    {
      ISource source = this;
      return source.GetConfig(path);
    }
  }
}