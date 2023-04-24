using System.Text;
using Spectre.Console;
using Spectre.Console.Cli;
using VpassUtil.Cli.Helpers;
using VpassUtil.Cli.Settings;

namespace VpassUtil.Cli.Commands
{
    public class DownloadCommand : AsyncCommand<DownloadSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, DownloadSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.Cookie)) settings.Cookie = AnsiConsole.Ask<string>("Cookieを入力してください、ブラウザのF12を押してネットワークタブから取得してください");
            if (string.IsNullOrWhiteSpace(settings.Start)) settings.Start = AnsiConsole.Ask<string>("開始を表すyyyy-mmを入力してください");
            if (string.IsNullOrWhiteSpace(settings.End)) settings.End = AnsiConsole.Ask<string>("終了を表すyyyy-mmを入力してください");

            var directoryInfo = Directory.CreateDirectory(settings.OutputDirectory);
            using var vpass = new VPassApiClient(settings.Cookie);

            for (var dateTime = DateTime.Parse(settings.Start); dateTime < DateTime.Parse(settings.End); dateTime = dateTime.AddMonths(1))
            {
                var history = await vpass.FetchDetailCsvAsync(dateTime.Year, dateTime.Month);
                var filePath = Path.Combine(directoryInfo.FullName, $"{dateTime.Year}{dateTime.Month.ToString().PadLeft(2, '0')}.csv");
                await File.WriteAllBytesAsync(filePath, Encoding.UTF8.GetBytes(history));

                AnsiConsoleHelper.MarkupLine(filePath);
                await Task.Delay(settings.IntervalMs);
            }
            return 0;
        }
    }
}
