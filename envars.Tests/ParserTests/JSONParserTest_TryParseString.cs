using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class JSONParserTest_TryPaseString
  {
    private readonly JSONParser _envParser;
    public JSONParserTest_TryPaseString()
    {
      _envParser = new JSONParser();
    }

    [Theory]
    [InlineData(new string[] { "{\"Key\":\"Value\",\"Key2\":\"Value2\"}", "{\"Key1\":\"Value1\"}" }, "Value1")]
    public void TryParse_ShouldPass(string[] lines, string expected)
    {
      var parsed = _envParser.TryParseStrings(lines, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result["Key1"]);
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParseStrings(new string[] { "Invalid JSON string" }, out var result);

      Assert.False(parsed);
      Assert.Null(result);
    }
  }
}
