using CartTaxCalculator.Models.Cart;

namespace CartTaxCalculator.Services
{
  public interface ITaxCalculationService
  {
    decimal CalculateTaxForCartItem(CartItem item);
  }
}
