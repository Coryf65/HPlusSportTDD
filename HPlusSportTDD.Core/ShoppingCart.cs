namespace HPlusSportTDD.Core.Tests;

public class ShoppingCart
{
    public int Id { get; set; }
    public virtual List<AddToCartItem> Items { get; set; }
}