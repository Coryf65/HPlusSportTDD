using Microsoft.EntityFrameworkCore;

namespace HPlusSportTDD.Core.Tests;

public class ShoppingCartContext : DbContext
{
    public ShoppingCartContext() : base()
    {
    }
    public ShoppingCartContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<AddToCartItem> Items { get; set; }
    public virtual DbSet<ShoppingCart> Carts { get; set; }
}