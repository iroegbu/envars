using System;
using envars.Utilities;
using Xunit;
using System.IO;

namespace envars.Tests.UtilitiesTests
{
    public class ConfigurationLocatorTest
    {
        public ConfigurationLocatorTest()
        {
        }

        [Theory]
        [InlineData("./")]
        public void LocateConfigFileValue_ShouldPass(string ConfigPath)
        {
            var expected = Path.Combine(".", ".envars");
            var result = ConfigurationLocator.LocateConfigFile(ConfigPath);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("etc")]
        public void LocateConfigFileEmpty_ShouldPass(string ConfigPath)
        {
            var expected = Path.Combine("etc", ".envars");
            var result = ConfigurationLocator.LocateConfigFile(ConfigPath);

            Assert.Equal(expected, result);
        }
    }
}
