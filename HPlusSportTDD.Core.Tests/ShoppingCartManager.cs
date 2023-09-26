namespace HPlusSportTDD.Core.Tests;

public record ShoppingCartManager
{
    public AddToCartResponse AddToCart(AddToCartRequest request)
    {
        return new AddToCartResponse()
        {
            Items = new[] { request.Item }
        };
    }
}