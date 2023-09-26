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
    
    [Test]
    public void ShouldReturnArticlesAddedToCart()
    {
        // Arrange
        var manager = new ShoppingCartManager();
        
        var item1 = new AddToCartItem()
        {
            ArticleId = 42,
            Quantity = 5
        };
        var item2 = new AddToCartItem()
        {
            ArticleId = 78,
            Quantity = 2
        };

        var request = new AddToCartRequest()
        {
            Item = item1
        };
        
        // Assert
        AddToCartResponse response = manager.AddToCart(request);

        request = new AddToCartRequest()
        {
            Item = item2
        };
        
        response = manager.AddToCart(request);
        
        // Assert
        Assert.NotNull(response);
        Assert.Contains(item1, response.Items);
        Assert.Contains(item2, response.Items);
    }

    [Test]
    public void ShouldAddQuantitiesToTotal()
    {
        // Arrange
        var manager = new ShoppingCartManager();
        
        var item1 = new AddToCartItem()
        {
            ArticleId = 10,
            Quantity = 1
        };
        
        var item2 = new AddToCartItem()
        {
            ArticleId = 10,
            Quantity = 1
        };
        
        var request = new AddToCartRequest()
        {
            Item = item1
        };
        
        // Act
        AddToCartResponse response = manager.AddToCart(request);
        
        request = new AddToCartRequest()
        {
            Item = item2
        };
        
        response = manager.AddToCart(request);
        
        // Assert
        Assert.NotNull(response);
        Assert.That(Array.Exists(response.Items, item => 
            item.ArticleId == 10 
            && item.Quantity == 2));
    }
    
}