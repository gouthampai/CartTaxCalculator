using System;
using System.Collections.Generic;
using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Services;
using CartTaxCalculator.Services.Rules;
using Moq;
using Xunit;

namespace CartTaxCalculator.UnitTests;

public class TaxCalculationServiceTests
{
    [Fact]
    public void CalculateTaxForCartItem_ReturnsTotalTaxFromEachRule()
    {
        var mockRule1 = new Mock<IRule>();
        mockRule1.Setup(x => x.IsEligibleForItem(It.IsAny<CartItem>())).Returns(true);
        mockRule1.Setup(x => x.ApplyTax(It.IsAny<CartItem>())).Returns(100m);

        var mockRule2 = new Mock<IRule>();
        mockRule2.Setup(x => x.IsEligibleForItem(It.IsAny<CartItem>())).Returns(true);
        mockRule2.Setup(x => x.ApplyTax(It.IsAny<CartItem>())).Returns(200.95m);
        var rules = new List<IRule>() { mockRule1.Object, mockRule2.Object };
        var service = new TaxCalculationService(rules);
        var result = service.CalculateTaxForCartItem(new CartItem());
        Assert.Equal(300.95m, result);
    }

    [Fact]
    public void CalculateTaxForCartItem_ReturnsTotalTaxFromEligibleRuleOnly()
    {
        var mockRule1 = new Mock<IRule>();
        mockRule1.Setup(x => x.IsEligibleForItem(It.IsAny<CartItem>())).Returns(true);
        mockRule1.Setup(x => x.ApplyTax(It.IsAny<CartItem>())).Returns(100m);

        var mockRule2 = new Mock<IRule>();
        mockRule2.Setup(x => x.IsEligibleForItem(It.IsAny<CartItem>())).Returns(false);
        mockRule2.Setup(x => x.ApplyTax(It.IsAny<CartItem>())).Returns(200.95m);
        var rules = new List<IRule>() { mockRule1.Object, mockRule2.Object };
        var service = new TaxCalculationService(rules);
        var result = service.CalculateTaxForCartItem(new CartItem());
        Assert.Equal(100m, result);
    }

    [Fact]
    public void CalculateTaxForCartItem_ThrowsExceptionWhenItemIsNull()
    {
        var rules = new List<IRule>();
        var service = new TaxCalculationService(rules);
        Assert.Throws<ArgumentNullException>(() => service.CalculateTaxForCartItem(null));
    }
}