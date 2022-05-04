using CartTaxCalculator.Models.Cart;

namespace CartTaxCalculator
{
  public static class CreateCartDataHelper
  {
    public static Cart GetFirstCart()
    {
      var cart = new Cart();
      cart.Items.Add(new CartItem()
      {
        Name = "Book",
        Quantity = 1,
        UnitCost = 12.49m,
        Category = ItemCategory.Books,
        Origin = ItemOrigin.Domestic
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Music CD",
        Quantity = 1,
        UnitCost = 14.99m,
        Category = ItemCategory.Electronics,
        Origin = ItemOrigin.Domestic
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Chocolate Bar",
        Quantity = 1,
        UnitCost = 0.85m,
        Category = ItemCategory.Food,
        Origin = ItemOrigin.Domestic
      });

      return cart;
    }

    public static Cart GetSecondCart()
    {
      var cart = new Cart();
      cart.Items.Add(new CartItem()
      {
        Name = "Imported Box of Chocolates",
        Quantity = 1,
        UnitCost = 10.00m,
        Category = ItemCategory.Food,
        Origin = ItemOrigin.Imported
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Imported Bottle of Perfume",
        Quantity = 1,
        UnitCost = 47.50m,
        Category = ItemCategory.Cosmetics,
        Origin = ItemOrigin.Imported
      });

      return cart;
    }

    public static Cart GetThirdCart()
    {
      var cart = new Cart();
      cart.Items.Add(new CartItem()
      {
        Name = "Imported Bottle of Perfume",
        Quantity = 1,
        UnitCost = 27.99m,
        Category = ItemCategory.Cosmetics,
        Origin = ItemOrigin.Imported
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Bottle of Perfume",
        Quantity = 1,
        UnitCost = 18.99m,
        Category = ItemCategory.Cosmetics,
        Origin = ItemOrigin.Domestic
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Packet of Headache Pills",
        Quantity = 1,
        UnitCost = 9.75m,
        Category = ItemCategory.Medication,
        Origin = ItemOrigin.Domestic
      });

      cart.Items.Add(new CartItem()
      {
        Name = "Imported Box of Chocolates",
        Quantity = 1,
        UnitCost = 11.25m,
        Category = ItemCategory.Food,
        Origin = ItemOrigin.Imported
      });

      return cart;
    }
  }
}
