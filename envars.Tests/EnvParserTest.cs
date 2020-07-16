using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class EnvParserTest
  {
    private readonly EnvParser _envParser;
    public EnvParserTest()
    {
      _envParser = new EnvParser();
    }

    [Theory]
    [InlineData("Key=Value")]
    [InlineData("Key:Value")]
    [InlineData("Key Value")]
    public void ParseLine_ShouldPass(string line)
    {
      var result = _envParser.ParseLine(line);

      var expected = "Key";
      Assert.Equal(result.Key, expected);
      Assert.Equal(result.Value, "Value");
    }

    [Theory]
    [InlineData("Key*Value")]
    [InlineData("Key_Value")]
    [InlineData("KeyValue")]
    public void ParseLine_ShouldFail(string line)
    {
      Assert.Throws<FormatException>(() => _envParser.ParseLine(line));
    }

    [Fact]
    public void ParseLines_ShouldPass()
    {
      var result = _envParser.ParseLines(new string[] { "Key=Value", "Key2=Value2" });

      Assert.Equal(result.Count, 2);
      Assert.Equal(result["Key"], "Value");
      Assert.Equal(result["Key2"], "Value2");
    }

    [Fact]
    public void ParseLines_ShouldThrow()
    {
      Assert.Throws<FormatException>(() => _envParser.ParseLines(new string[] { "Key=Value", "Key2*Value2" }, true));
    }

    [Fact]
    public void ParseLines_ShouldSkipFailed()
    {
      var result = _envParser.ParseLines(new string[] { "Key=Value", "Key2*Value2" }, false);

      Assert.Equal(result.Count, 1);
      Assert.Equal(result["Key"], "Value");
      Assert.Equal(result.TryGetValue("Key2", out var value), false);
    }

    [Fact]
    public void TryParse_ShouldPass()
    {
      var parsed = _envParser.TryParse(new string[] { "Key=Value", "Key2=Value2" }, out var result);

      Assert.Equal(parsed, true);
      Assert.Equal(result.Count, 2);
      Assert.Equal(result["Key"], "Value");
      Assert.Equal(result["Key2"], "Value2");
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParse(new string[] { "Key=Value", "Key2*Value2" }, out var result);
      var expected = false;
      Assert.Equal(parsed, expected);
    }
  }
}
