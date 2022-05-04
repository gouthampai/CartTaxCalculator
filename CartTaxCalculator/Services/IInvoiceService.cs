using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Models.Invoice;

namespace CartTaxCalculator.Services
{
  public interface IInvoiceService
  {
    Invoice GenerateInvoiceFromCart(Cart cart);
  }
}
