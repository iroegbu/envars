using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace envars
{
  class Program
  {
    public static async Task<int> Main() =>
    await new CliApplicationBuilder()
        .AddCommandsFromThisAssembly()
        .Build()
        .RunAsync();
  }

  [Command]
  public class Fetch : ICommand
  {
    [CommandOption("source", 's', Description = "Source of secrets (awssm, local). \n \t\t\t awssm: fetches variables from AWS Secrets Manager \n \t\t\t local: loads variables from local .env file. \n")]
    public string Source { get; set; } = "";

    [CommandOption("config", 'c', Description = "Config file containing required configurations to load")]
    public string ConfigFile { get; set; } = ".";

    public ValueTask ExecuteAsync(IConsole console)
    {
      console.Output.WriteLine($"Source of environment variables is {Source}");

      return default;
    }
  }
}
