using System;
using envars.Utilities;
using Xunit;

namespace envars.Tests.UtilitiesTests
{
    public class ConfigurationLocatorTest
    {
        public ConfigurationLocatorTest()
        {
        }

        [Theory]
        [InlineData("./", "./.envars")]
        [InlineData("/var", "/var/.envars")]
        public void LocateConfigFile_ShouldPass(string ConfigPath, string expected)
        {
            var result = ConfigurationLocator.LocateConfigFile(ConfigPath);

            Assert.Equal(expected, result);
        }
    }
}
