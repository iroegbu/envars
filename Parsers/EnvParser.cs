using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace envars.Parsers
{
  public class EnvParser
  {
    public static bool TryParse(string[] envStrings, out Dictionary<string, string> jObject)
    {
      try
      {
        jObject = ParseLines(envStrings);
        return true;
      }
      catch
      {
        jObject = null;
        return false;
      }
    }

    private static KeyValuePair<string, string> ParseLine(string line)
    {
      var regex = new Regex("( *: *)|( *= *)|( +)", RegexOptions.IgnoreCase);
      if (regex.IsMatch(line))
      {
        var parts = regex.Split(line, 2);
        parts = parts.Select(s => s.Trim()).ToArray();
        return new KeyValuePair<string, string>(parts[0], parts[1]);
      }
      throw new FormatException($"Line does not contain valid separators. Valid separators are ':', '=' and spaces. Line value was: {line}");
    }

    private static Dictionary<string, string> ParseLines(string[] lines, bool throwOnInvalidValues = true)
    {
      var result = new Dictionary<string, string>();
      foreach (var line in lines)
      {
        if (!String.IsNullOrWhiteSpace(line))
        {
          try
          {
            var lineResult = ParseLine(line);
            result.Add(lineResult.Key, lineResult.Value);
          }
          catch (FormatException exception)
          {
            if (throwOnInvalidValues) throw exception;
          }
          catch (Exception exception)
          {
            throw exception;
          }
        }
      }
      return result;
    }
  }
}