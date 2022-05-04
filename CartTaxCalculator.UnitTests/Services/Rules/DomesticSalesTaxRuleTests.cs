using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Services.Rules;
using Xunit;

namespace CartTaxCalculator.UnitTests;

public class DomesticSalesTaxRuleTests
{
    [Theory]
    [InlineData(ItemCategory.Books)]
    [InlineData(ItemCategory.Food)]
    [InlineData(ItemCategory.Medication)]
    public void IsEligibleForItem_ShouldReturnFalseForExemptCategories(ItemCategory category)
    {
        var item = new CartItem()
        {
            Category = category
        };

        var rule = new DomesticSalesTaxRule();

        var result = rule.IsEligibleForItem(item);
        Assert.False(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnFalseForNullItem()
    {
        var rule = new DomesticSalesTaxRule();

        var result = rule.IsEligibleForItem(null);
        Assert.False(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnTrueForNonExemptItem()
    {
        var item = new CartItem()
        {
            Category = ItemCategory.Electronics
        };

        var rule = new DomesticSalesTaxRule();

        var result = rule.IsEligibleForItem(item);
        Assert.True(result);
    }

    [Fact]
    public void IsEligibleForItem_ShouldReturnTrueForUnknownItem()
    {
        var item = new CartItem()
        {
            Category = ItemCategory.Unknown
        };

        var rule = new DomesticSalesTaxRule();

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

        var rule = new DomesticSalesTaxRule();

        var result = rule.ApplyTax(item);
        Assert.Equal(.20m, result);
    }

    [Fact]
    public void ApplyTax_ShouldReturnExpectedTaxValueForMultipleQuantity()
    {
        var item = new CartItem()
        {
            UnitCost = 1.99m,
            Quantity = 1337
        };

        var rule = new DomesticSalesTaxRule();

        var result = rule.ApplyTax(item);
        Assert.Equal(266.10m, result);
    }
}