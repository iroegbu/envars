using System.Collections.Generic;

interface IArrayParser
{
  bool TryParse(string[] envStrings, out Dictionary<string, string> jObject);
}