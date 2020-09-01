using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using envars.Parsers;
using envars.Utilities;

namespace envars.Commands
{
    [Command]
    public class Fetch : ICommand
    {
        [CommandOption("source", 's', Description = "Source of secrets (awssm, local). \n \t\t\t awssm: fetches variables from AWS Secrets Manager \n \t\t\t local: loads variables from local .env file. \n")]
        public string Source { get; set; } = "local";

        [CommandOption("config", 'c', Description = "Config file containing required configurations to load")]
        public string ConfigFilePath { get; set; } = "";

        public ValueTask ExecuteAsync(IConsole console)
        {
            try
            {
                console.Output.WriteLine($"Source of environment variables: {Source} \nWhere to find configuration file: {ConfigFilePath}");
                var envarsConfig = ReadEnvarConfig(ConfigFilePath);

                switch (Source)
                {
                    case "local":
                        SetEnvironmentVariables.Set(envarsConfig);
                        break;
                    case "awssm":
                        // get from secret manager
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                console.Error.WriteLine(ex.Message);
            }

            return default;
        }

        private Dictionary<string, string> ReadEnvarConfig(string ConfigFilePath)
        {
            var ConfigPath = ConfigurationLocator.LocateConfigFile(ConfigFilePath);
            var Success = new EnvParser().TryParseStrings(File.ReadAllLines(ConfigPath), out var ConfigFile);
            if (Success)
            {
                return ConfigFile;
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
}
