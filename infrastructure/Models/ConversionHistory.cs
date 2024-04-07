namespace infrastructure.Models;

public class ConversionHistory
{
    public int Id { get; set; }
    public string SourceCurrency { get; set; }
    public string TargetCurrency { get; set; }
    public decimal Amount { get; set; }
    public decimal ConvertedAmount { get; set; }
    public DateTime Timestamp { get; set; }
}