namespace CartTaxCalculator.Models.Invoice
{
  public class InvoiceItem
  {
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal TotalSalesTax { get; set; }
  }
}