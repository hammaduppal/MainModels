namespace MainModels.DTOModels
{
    public class InvoiceChartDto
    {
        public List<string> Months { get; set; }
        public List<decimal> Sales { get; set; }
        public List<decimal> Profit { get; set; }
    }
    public class DailySalesChartDto
    {
        public List<string> Days { get; set; } = new();
        public List<decimal> Sales { get; set; } = new();
    }

    public class DonutChartDto
    {
        public List<string> Labels { get; set; } = new();
        public List<decimal> Values { get; set; } = new();
    }

    // Included for reference if you haven't defined it yet from your monthly chart
    public class LowStockItemDto
    {
        public Guid ProductId { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
    }
}
