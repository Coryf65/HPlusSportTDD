namespace HPlusSportTDD.Core.Tests;

public class ShoppingCartTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void ShouldReturnArticleAddedToCart()
    {
        // Arrange
        var item = new AddToCartItem()
        {
            ArticleId = 42,
            Quantity = 5
        };

        var request = new AddToCartRequest()
        {
            Item = item
        };

        var manager = new ShoppingCartManager();
        
        // Act
        AddToCartResponse response = manager.AddToCart(request);
        
        // Assert
        Assert.NotNull(response);
        Assert.Contains(item, response.Items);
    }
}