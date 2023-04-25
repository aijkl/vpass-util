using Spectre.Console.Cli;

namespace VpassUtil.Cli.Settings;

public class DownloadSettings : CommandSettings
{
    [CommandOption("--out-directory")] 
    public string OutputDirectory { set; get; } = "csv";

    [CommandOption("--cookie")]
    public string? Cookie { set; get; }

    [CommandOption("--start")]
    public string? Start { set; get; }

    [CommandOption("--end")]
    public string? End { set; get; }

    [CommandOption("--interval-ms")] 
    public int IntervalMs { set; get; } = 3000;
}