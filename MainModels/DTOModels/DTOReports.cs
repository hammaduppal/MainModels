namespace MainModels.DTOModels
{
    public class InvoiceChartDto
    {
        public List<string> Months { get; set; }
        public List<decimal> Sales { get; set; }
        public List<decimal> Profit { get; set; }
    }
}
