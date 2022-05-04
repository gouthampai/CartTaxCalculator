using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Services.Rules;
using Xunit;

namespace CartTaxCalculator.UnitTests;

public class ImportTaxRuleTests
{
    [Fact]
    public void IsEligibleForItem_ShouldReturnFalseForDomesticItem()
    {
        var item = new CartItem()
        {
            Origin = ItemOrigin.Domestic
        };

        var rule = new ImportTaxRule();

        var result = rule.IsEligibleForItem(item);
        Assert.False(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnFalseForItemOfUnknownOrigin()
    {
        var item = new CartItem()
        {
            Origin = ItemOrigin.Unknown
        };

        var rule = new ImportTaxRule();

        var result = rule.IsEligibleForItem(item);
        Assert.False(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnFalseForNullItem()
    {
        var rule = new ImportTaxRule();

        var result = rule.IsEligibleForItem(null);
        Assert.False(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnTrueForNonExemptItem()
    {
        var item = new CartItem()
        {
            Origin = ItemOrigin.Imported
        };

        var rule = new ImportTaxRule();

        var result = rule.IsEligibleForItem(item);
        Assert.True(result);
    }

    [Fact]
    public void ApplyTax_ShouldReturnExpectedTaxValueForSingleItem()
    {
        var item = new CartItem()
        {
            UnitCost = 1.99m,
            Quantity = 1
        };

        var rule = new ImportTaxRule();

        var result = rule.ApplyTax(item);
        Assert.Equal(.10m, result);
    }

    [Fact]
    public void ApplyTax_ShouldReturnExpectedTaxValueForMultipleQuantity()
    {
        var item = new CartItem()
        {
            UnitCost = 1.99m,
            Quantity = 1337
        };

        var rule = new ImportTaxRule();

        var result = rule.ApplyTax(item);
        Assert.Equal(133.05m, result);
    }
}