using CartTaxCalculator.Models.Cart;

namespace CartTaxCalculator.Services.Rules
{
  public interface IRule
  {
    bool IsEligibleForItem(CartItem item);
    decimal ApplyTax(CartItem item);
  }
}
