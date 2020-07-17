using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class EnvParserTest_ParseLines
  {
    private readonly EnvParser _envParser;
    public EnvParserTest_ParseLines()
    {
      _envParser = new EnvParser();
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, 1)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2" }, 2)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2", "Key3=Value3" }, 3)]
    public void ParseLines_ShouldCountLines(string[] lines, int expected)
    {
      var result = _envParser.ParseLines(lines);

      Assert.Equal(result.Count, expected);
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, "Value")]
    [InlineData(new string[] { "Key=Value", "Key2=Value2" }, "Value")]
    [InlineData(new string[] { "Key=Value", "Key2=Value2", "Key3=Value3" }, "Value")]
    public void ParseLines_ShouldGetValues(string[] lines, string expected)
    {
      var result = _envParser.ParseLines(lines);

      Assert.Equal(expected, result["Key"]);
    }

    [Fact]
    public void ParseLines_ShouldThrow()
    {
      Assert.Throws<FormatException>(() => _envParser.ParseLines(new string[] { "Key=Value", "Key2*Value2" }, true));
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, 1)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2" }, 2)]
    [InlineData(new string[] { "Key=Value", "Key2=Value2", "Key3=Value3" }, 3)]
    public void ParseLines_ShouldSkipFailed_GetCount(string[] lines, int expected)
    {
      var result = _envParser.ParseLines(lines, false);

      Assert.Equal(expected, result.Count);
    }

    [Theory]
    [InlineData(new string[] { "Key=Value" }, "Value")]
    [InlineData(new string[] { "Key=Value", "Key2=Value2" }, "Value")]
    [InlineData(new string[] { "Key=Value", "Key2=Value2", "Key3=Value3" }, "Value")]
    public void ParseLines_ShouldSkipFailed_GetValue(string[] lines, string expected)
    {
      var result = _envParser.ParseLines(lines, false);

      Assert.Equal(result["Key"], expected);
    }
  }
}
