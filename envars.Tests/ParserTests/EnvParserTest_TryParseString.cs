using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class EnvParserTest_TryParseString
  {
    private readonly EnvParser _envParser;
    public EnvParserTest_TryParseString()
    {
      _envParser = new EnvParser();
    }

    [Theory]
    [InlineData("Key=Value", 1)]
    [InlineData("Key: Value", 1)]
    [InlineData("Key Value", 1)]
    public void TryParse_ShouldPass_Count(string line, int expected)
    {
      var parsed = _envParser.TryParseString(line, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result.Count);
    }

    [Theory]
    [InlineData("Key=Value", "Value")]
    [InlineData("Key: Value2", "Value2")]
    [InlineData("Key Value3", "Value3")]
    public void TryParse_ShouldPass_GetValue(string line, string expected)
    {
      var parsed = _envParser.TryParseString(line, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result["Key"]);
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParseString("Key2*Value2", out var result);
      Assert.False(parsed);
    }
  }
}
