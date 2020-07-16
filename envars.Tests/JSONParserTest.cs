using System;
using envars.Parsers;
using Xunit;

namespace envars.Tests
{
  public class JSONParserTest
  {
    private readonly JSONParser _envParser;
    public JSONParserTest()
    {
      _envParser = new JSONParser();
    }

    [Fact]
    public void TryParse_ShouldPass()
    {
      var parsed = _envParser.TryParse("{\"Key\":\"Value\",\"Key2\":\"Value2\"}", out var result);

      Assert.Equal(parsed, true);
      Assert.Equal(result["Key"], "Value");
    }

    [Fact]
    public void TryParse_ShouldFail()
    {
      var parsed = _envParser.TryParse("Invalid JSON string", out var result);

      Assert.Equal(parsed, false);
      Assert.Equal(result, null);
    }
  }
}
