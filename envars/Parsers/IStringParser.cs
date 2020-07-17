using System.Collections.Generic;

interface IStringParser
{
  bool TryParse(string envStrings, out Dictionary<string, string> jObject);
}