using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Services.Rules;

namespace CartTaxCalculator.Services
{
  public class TaxCalculationService : ITaxCalculationService
  {
    private readonly IEnumerable<IRule> rules;

    public TaxCalculationService(IEnumerable<IRule> rules)
    {
      this.rules = rules;
    }
    public decimal CalculateTaxForCartItem(CartItem item)
    {
      if (item == null)
      {
        throw new ArgumentNullException("Cart item to calculate tax for is null");
      }
      
      var eligibleRules = rules.Where(rule => rule.IsEligibleForItem(item)).ToList();
      var totalTax = eligibleRules.Select(rule => rule.ApplyTax(item)).Sum();
      return totalTax;
    }
  }
}
