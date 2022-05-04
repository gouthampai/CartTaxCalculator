namespace CartTaxCalculator.Models.Cart
{
  public class CartItem
  {
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public ItemCategory Category { get; set; }
    public ItemOrigin Origin { get; set; }
  }
}
