using System.Text;

namespace VpassUtil;

public class VPassApiClient : IDisposable
{
    private readonly string _cookie;
    public static readonly string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36";
    private readonly HttpClient _httpClient;
    public VPassApiClient(string cookie)
    {
        _cookie = cookie;
        _httpClient = new HttpClient();
    }
    public async Task<string> FetchDetailCsvAsync(int year, int month)
    {
        var request = CreateHistoryRequest(year, month);
        using var response = await _httpClient.SendAsync(request);
        return Encoding.GetEncoding("SJIS").GetString(await response.Content.ReadAsByteArrayAsync());
    }
    public HttpRequestMessage CreateHistoryRequest(int year, int month)
    {
        const string baseUrl = "https://www.smbc-card.com/memapi/jaxrs/dl/web_meisai/web_meisai_csv_exec/v1";
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}?downloadKey=4&seikyuym={year}{month.ToString().PadLeft(2, '0')}&sk=&downloadtype=csv&mk=1");
        httpRequestMessage.Headers.Add("Cookie", _cookie);
        httpRequestMessage.Headers.Add("User-Agent", UserAgent);
        httpRequestMessage.Headers.Add("Accept-Language", "ja");
        return httpRequestMessage;
    }
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}