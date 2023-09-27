using HPlusSportTDD.API.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportTDD.Core.Tests;

public class APITests
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void ShouldReturnAllArticles()
    {
        var controller = new ArticlesController();

        var result = controller.GetAll();
        
        Assert.AreEqual(3, result.Count());
    }
    
    [Test]
    public void ShouldReturnArticle()
    {
        var controller = new ArticlesController();

        var result = controller.GetSingle(3);
        
        Assert.IsInstanceOf(typeof(OkObjectResult), result);
    }
    
    [Test]
    public void ShouldReturn404OnMissingArticle()
    {
        var controller = new ArticlesController();

        var result = controller.GetSingle(5151515);

        Assert.AreEqual((result as StatusCodeResult)?.StatusCode, 404);
    }
}