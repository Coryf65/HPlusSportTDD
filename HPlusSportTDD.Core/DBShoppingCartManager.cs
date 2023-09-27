namespace HPlusSportTDD.Core.Tests;

public class DBShoppingCartManager : IShoppingCartManager
{
    private readonly ShoppingCartContext _db;
    
    public DBShoppingCartManager(ShoppingCartContext context)
    {
        this._db = context;
    }
    
    public AddToCartResponse AddToCart(AddToCartRequest request)
    {
        var item = _db.Items.FirstOrDefault(i => i.ArticleId == request.Item.ArticleId);
        if (item != null)
        {
            item.Quantity += request.Item.Quantity;
        }
        else
        {
            _db.Items.Add(request.Item);
        }
        _db.SaveChanges();

        return new AddToCartResponse()
        {
            Items = _db.Items.ToArray()
        };
    }

    public IEnumerable<AddToCartItem> GetCart()
    {
        return this._db.Items.ToList();
    }
}