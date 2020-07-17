using System.Collections.Generic;

using System.Text.Json;

namespace envars.Parsers
{
  public class JSONParser : IStringParser
  {
    public bool TryParse(string json, out Dictionary<string, string> jObject)
    {
      try
      {
        jObject = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        return true;
      }
      catch
      {
        jObject = null;
        return false;
      }
    }
  }
}