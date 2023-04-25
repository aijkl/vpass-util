namespace VpassUtil;

/// <summary>
/// CSVの解析中にキャッチした無視する事が出来ないエラーをラップ
/// </summary>
public class CsvParseException : Exception
{
    internal CsvParseException(string message, Exception? innerException = null) : base(message, innerException)
    {
    }
}

public sealed class CsvMapper : CsvHelper.Configuration.ClassMap<PaymentDetail>
{
    public CsvMapper()
    {
        Map(x => x.Timestamp).Index(0).Convert(args =>
        {
            DateTime.TryParse(args.Row.GetField<string>(0), out var result);
            return result;
        });
        Map(x => x.StoreName).Index(1).Convert(args => args.Row.GetField<string>(1) ?? string.Empty);
        Map(x => x.Amount).Index(2).Convert(args => args.Row.GetField<int>(2));
        Map(x => x.PaymentAmount).Index(5).Convert(args => args.Row.GetField<int>(5));
    }   
}