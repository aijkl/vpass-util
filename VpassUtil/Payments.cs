namespace VpassUtil;

public class PaymentDetail
{
    public DateTime Timestamp { set; get; }
    public string StoreName { set; get; } = "";
    public int Amount { set; get; }
    public int PaymentAmount { set; get; }
}