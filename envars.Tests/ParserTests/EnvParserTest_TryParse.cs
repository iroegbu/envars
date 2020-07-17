using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class EnvParserTest_TryParse
  {
    private readonly EnvParser _envParser;
    public EnvParserTest_TryParse()
    {
      _envParser = new EnvParser();
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, 1)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2" }, 2)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2", "Key3=Value3" }, 3)]
    public void TryParse_ShouldPass_Count(string[] lines, int expected)
    {
      var parsed = _envParser.TryParse(lines, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result.Count);
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, "Value")]
    [InlineData(new string[] { "Key=Value1", "Key2=Value2" }, "Value1")]
    [InlineData(new string[] { "Key=Value2", "Key2=Value2", "Key3=Value3" }, "Value2")]
    public void TryParse_ShouldPass_GetValue(string[] lines, string expected)
    {
      var parsed = _envParser.TryParse(lines, out var result);

      Assert.True(parsed);
      Assert.Equal(expected, result["Key"]);
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParse(new string[] { "Key=Value", "Key2*Value2" }, out var result);
      Assert.False(parsed);
    }
  }
}
