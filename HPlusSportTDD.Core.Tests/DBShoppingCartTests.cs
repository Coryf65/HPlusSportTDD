using Moq;
using Moq.EntityFrameworkCore;

namespace HPlusSportTDD.Core.Tests;

public class DBShoppingCartTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void ShouldReturnArticlesInCart()
    {
        // Arrange
        var initialItems = new AddToCartItem[]
        {
            new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            }
        };

        var mockContext = new Mock<ShoppingCartContext>();

        mockContext.Setup(ctx => ctx.Items).ReturnsDbSet(initialItems);
        
        var manager = new DBShoppingCartManager(mockContext.Object);

        var items = manager.GetCart();
        
        // Assert
        Assert.AreEqual(initialItems, items);
    }
}