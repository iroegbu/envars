using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class JSONParserTest_TryPaseStrings
  {
    private readonly JSONParser _envParser;
    public JSONParserTest_TryPaseStrings()
    {
      _envParser = new JSONParser();
    }

    [Theory]
    [InlineData("{\"Key\":\"Value\",\"Key2\":\"Value2\"}", "Value")]
    public void TryParse_ShouldPass(string line, string expected)
    {
      var parsed = _envParser.TryParseString(line, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result["Key"]);
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParseString("Invalid JSON string", out var result);

      Assert.False(parsed);
      Assert.Null(result);
    }
  }
}
