using System;
using System.Linq;
using CartTaxCalculator.Models.Cart;
using CartTaxCalculator.Services;
using Moq;
using Xunit;

namespace CartTaxCalculator.UnitTests
{
    public class InvoiceServiceTests
    {
        [Fact]
        public void GenerateInvoiceFromCart_ThrowsExceptionWhenCartIsNull()
        {
            var service = new InvoiceService(null);
            Assert.Throws<ArgumentNullException>(() => service.GenerateInvoiceFromCart(null));
        }

        [Fact]
        public void GenerateInvoiceFromCart_ThrowsExceptionWhenCartItemsAreNull()
        {
            var service = new InvoiceService(null);
            Assert.Throws<ArgumentNullException>(() => service.GenerateInvoiceFromCart(new Cart() { Items = null }));
        }

        [Fact]
        public void GenerateInvoiceFromCart_GeneratesInvoiceTotals()
        {
            var mockCalculationService = new Mock<ITaxCalculationService>();
            mockCalculationService
            .Setup(x => x.CalculateTaxForCartItem(It.Is<CartItem>(y => y.Category == ItemCategory.Books)))
            .Returns(66.00m);
            mockCalculationService
            .Setup(x => x.CalculateTaxForCartItem(It.Is<CartItem>(y => y.Category == ItemCategory.Electronics)))
            .Returns(500.55m);
            var service = new InvoiceService(mockCalculationService.Object);
            var fakeCart = new Cart();
            fakeCart.Items.Add(new CartItem()
            {
                Name = "Book",
                Quantity = 1,
                UnitCost = 99.99m,
                Category = ItemCategory.Books
            });
            fakeCart.Items.Add(new CartItem()
            {
                Name = "TV",
                Quantity = 2,
                UnitCost = 3560m,
                Category = ItemCategory.Electronics
            });
            var result = service.GenerateInvoiceFromCart(fakeCart);

            Assert.Equal(7786.54m, result.TotalOwed);
            Assert.Equal(566.55m, result.TotalSalesTax);
            var bookItem = result.Items.FirstOrDefault(x => x.Name == "Book");
            Assert.NotNull(bookItem);
            Assert.Equal("Book", bookItem.Name);
            Assert.Equal(1, bookItem.Quantity);
            Assert.Equal(165.99m, bookItem.TotalPrice);
            Assert.Equal(66.00m, bookItem.TotalSalesTax);

            var tvItem = result.Items.FirstOrDefault(x => x.Name == "TV");
            Assert.NotNull(tvItem);
            Assert.Equal("TV", tvItem.Name);
            Assert.Equal(2, tvItem.Quantity);
            Assert.Equal(7620.55m, tvItem.TotalPrice);
            Assert.Equal(500.55m, tvItem.TotalSalesTax);
        }
    }
}
