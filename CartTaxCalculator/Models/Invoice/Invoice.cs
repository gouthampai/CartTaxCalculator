namespace CartTaxCalculator.Models.Invoice
{
  public class Invoice
  {
    public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    public decimal TotalSalesTax { get; set; }
    public decimal TotalOwed { get; set; }
  }
}
