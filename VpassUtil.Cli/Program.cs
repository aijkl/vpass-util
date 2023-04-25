using System.Text;
using Spectre.Console.Cli;
using VpassUtil.Cli.Commands;

namespace VpassHack
{
    internal abstract class Program
    {
        private static async Task<int> Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var commandApp = new CommandApp();
            commandApp.Configure(x =>
            {
                x.AddCommand<DownloadCommand>("download");
            });
            return await commandApp.RunAsync(args);
        }
    }
}