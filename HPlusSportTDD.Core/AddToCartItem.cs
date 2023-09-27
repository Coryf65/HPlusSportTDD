
namespace HPlusSportTDD.Core.Tests;

public record AddToCartItem
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int Quantity { get; set; }
}