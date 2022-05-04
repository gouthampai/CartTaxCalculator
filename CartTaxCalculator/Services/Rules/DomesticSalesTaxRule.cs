using CartTaxCalculator.Models.Cart;

namespace CartTaxCalculator.Services.Rules
{
  public class DomesticSalesTaxRule : IRule
  {
    private HashSet<ItemCategory> exemptCategories = new HashSet<ItemCategory>()
    {
      ItemCategory.Books,
      ItemCategory.Food,
      ItemCategory.Medication
    };

    private decimal DOMESTIC_SALES_TAX = 10;

    public DomesticSalesTaxRule()
    {
    }

    public bool IsEligibleForItem(CartItem item)
    {
      return item != null && !exemptCategories.Contains(item.Category);
    }

    public decimal ApplyTax(CartItem item)
    {
      return CalculationHelper.CalculateRoundedTax(item.UnitCost, item.Quantity, DOMESTIC_SALES_TAX);
    }
  }
}
