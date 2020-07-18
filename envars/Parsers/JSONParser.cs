using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace envars.Parsers
{
  public class JSONParser : IParser
  {
    public bool TryParseString(string envString, out Dictionary<string, string> jObject)
    {
      try
      {
        jObject = JsonSerializer.Deserialize<Dictionary<string, string>>(envString);
        return true;
      }
      catch
      {
        jObject = null;
        return false;
      }
    }

    public bool TryParseStrings(string[] envStrings, out Dictionary<string, string> jObject)
    {
      try
      {
        var result = envStrings.AsEnumerable().SelectMany(envString => JsonSerializer.Deserialize<Dictionary<string, string>>(envString));
        jObject = new Dictionary<string, string>(result);
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