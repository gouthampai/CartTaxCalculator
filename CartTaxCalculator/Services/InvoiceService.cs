using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Models.Invoice;

namespace CartTaxCalculator.Services
{
  public class InvoiceService : IInvoiceService
  {
    private readonly ITaxCalculationService taxCalculationService;

    public InvoiceService(ITaxCalculationService taxCalculationService)
    {
      this.taxCalculationService = taxCalculationService;
    }

    public Invoice GenerateInvoiceFromCart(Cart cart)
    {
      if (cart?.Items == null || !cart.Items.Any())
      {
        throw new ArgumentNullException("cart or cart items are null");
      }

      var response = new Invoice();
      var invoiceTotal = 0m;
      var invoiceTotalTax = 0m;

      foreach (var item in cart.Items)
      {
        var tax = taxCalculationService.CalculateTaxForCartItem(item);
        var totalPrice = item.UnitCost * item.Quantity + tax;
        invoiceTotalTax += tax;
        invoiceTotal += totalPrice;
        response.Items.Add(MapToInvoiceItem(item, totalPrice, tax));
      }

      response.TotalOwed = invoiceTotal;
      response.TotalSalesTax = invoiceTotalTax;
      return response;
    }

    private InvoiceItem MapToInvoiceItem(CartItem item, decimal totalPrice, decimal totalTax)
    {
      return new InvoiceItem()
      {
        Name = item.Name,
        Quantity = item.Quantity,
        TotalPrice = totalPrice,
        TotalSalesTax = totalTax
      };
    }
  }
}
