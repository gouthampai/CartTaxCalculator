using CartTaxCalculator.Models.Cart;

namespace CartTaxCalculator.Services.Rules
{
  public class ImportTaxRule : IRule
  {
    private decimal IMPORT_DUTY = 5;

    public ImportTaxRule()
    {
    }

    public bool IsEligibleForItem(CartItem item)
    {
      return item != null && item.Origin == ItemOrigin.Imported;
    }

    public decimal ApplyTax(CartItem item)
    {
      return CalculationHelper.CalculateRoundedTax(item.UnitCost, item.Quantity, IMPORT_DUTY);
    }
  }
}
