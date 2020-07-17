using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class EnvParserTest_ParseLine
  {
    private readonly EnvParser _envParser;
    public EnvParserTest_ParseLine()
    {
      _envParser = new EnvParser();
    }

    [Theory]
    [InlineData("Key=Value", "Key")]
    [InlineData("Key:Value", "Key")]
    [InlineData("Key Value", "Key")]
    public void ParseLine_ShouldPassCheckKey(string line, string expected)
    {
      var result = _envParser.ParseLine(line);

      Assert.Equal(expected, result.Key);
      Assert.Equal("Value", result.Value);
    }

    [Theory]
    [InlineData("Key=Value", "Value")]
    [InlineData("Key:Value", "Value")]
    [InlineData("Key Value", "Value")]
    public void ParseLine_ShouldPassCheckValue(string line, string expected)
    {
      var result = _envParser.ParseLine(line);

      Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData("Key*Value")]
    [InlineData("Key_Value")]
    [InlineData("KeyValue")]
    public void ParseLine_ShouldFail(string line)
    {
      Assert.Throws<FormatException>(() => _envParser.ParseLine(line));
    }
  }
}
