using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Models.Invoice;

namespace CartTaxCalculator.Services
{
  public class ProcessCartDataService : IProcessCartDataService
  {
    private readonly IInvoiceService invoiceService;

    public ProcessCartDataService(IInvoiceService invoiceService)
    {
      this.invoiceService = invoiceService;
    }
    
    public void GetCartsAndPrintInvoices()
    {
      Console.WriteLine("Cart Invoice Calculator");
      var carts = new Cart[] { CreateCartDataHelper.GetFirstCart(), CreateCartDataHelper.GetSecondCart(), CreateCartDataHelper.GetThirdCart() };
      for(var i = 0; i < carts.Length; i++)
      {
        Console.WriteLine($"\nShopping Basket {i+1}:");
        var cart = carts[i];
        PrintCartData(cart);
        var invoice = invoiceService.GenerateInvoiceFromCart(cart);
        Console.WriteLine($"\nOutput {i+1}:");
        PrintInvoiceData(invoice);
      }
    }

    private void PrintCartData(Cart cart)
    {
      foreach(var item in cart.Items)
      {
        Console.WriteLine($"{item.Quantity} {item.Name} at {item.UnitCost:C} each");
      }
    }

    private void PrintInvoiceData(Invoice invoice)
    {
      foreach(var item in invoice.Items)
      {
        Console.WriteLine($"{item.Quantity} {item.Name}: {item.TotalPrice:C}");
      }

      Console.WriteLine($"Sales Tax: {invoice.TotalSalesTax:C}");
      Console.WriteLine($"Total: {invoice.TotalOwed:C}");
    }
  }
}
