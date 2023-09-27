namespace HPlusSportTDD.Core.Tests;

public record ShoppingCartManager : IShoppingCartManager
{
    private List<AddToCartItem> _shoppingCart;

    public ShoppingCartManager()
    {
        _shoppingCart = new List<AddToCartItem>();
    }
    
    public AddToCartResponse AddToCart(AddToCartRequest request)
    {
        // search for an item existing to add to
        var item = _shoppingCart.Find(i => i.ArticleId == request.Item.ArticleId);

        if (item != null)
            item.Quantity += request.Item.Quantity;
        else
            _shoppingCart.Add(request.Item);
        
        return new AddToCartResponse()
        {
            Items = _shoppingCart.ToArray()
        };
    }

    public IEnumerable<AddToCartItem> GetCart()
    {
        return _shoppingCart.ToArray();
    }
}