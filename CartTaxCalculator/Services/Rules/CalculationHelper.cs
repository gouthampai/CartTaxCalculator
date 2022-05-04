namespace CartTaxCalculator.Services.Rules
{
  public static class CalculationHelper
  {
    private static decimal RoundValueToNearestFiveCents(decimal input) => Math.Ceiling(input * 20) / 20;

    public static decimal CalculateRoundedTax(decimal cost, int quantity, decimal taxPercentage)
    {
      if (taxPercentage == 0m)
        return cost;

      return RoundValueToNearestFiveCents(quantity * cost * taxPercentage / 100);
    }
  }
}
