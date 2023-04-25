namespace VpassUtil;

public class PaymentDetail
{
    public PaymentDetail(DateTime timestamp)
    {
        Timestamp = timestamp;
    }

    public DateTime Timestamp { set; get; }
    public string StoreName { set; get; } = "";
    public int Amount { set; get; }
    public int PaymentAmount { set; get; }
}