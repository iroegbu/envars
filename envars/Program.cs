using System.Threading.Tasks;
using CliFx;

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
}
