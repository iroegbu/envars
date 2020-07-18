using System.Collections.Generic;

interface IParser
{
  bool TryParseString(string envString, out Dictionary<string, string> jObject);
  bool TryParseStrings(string[] envStrings, out Dictionary<string, string> jObject);
}