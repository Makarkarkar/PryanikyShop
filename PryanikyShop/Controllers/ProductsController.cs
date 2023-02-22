using System.Collections;
using Microsoft.AspNetCore.Mvc;
using PryanikyShop.Models;

namespace PryanikyShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public static IEnumerable<Product> ProductsCollection()
    {
        yield return new Product(1, "Milk", "Volume: 1L", 60);
        yield return new Product(2, "Pork", "Weight: 1kg", 400);
        yield return new Product(3, "Potato chips", "Weight: 0.1kg", 100);
        yield return new Product(4, "Coca cola", "Volume: 2L", 120);
        yield return new Product(5, "Sprite", "Volume: 2L", 110);
        yield return new Product(6, "Fanta", "Volume: 2L", 115);

    }

    [HttpGet]
    public IActionResult GetAllProducts() => Ok(ProductsCollection().ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (ProductsCollection().FirstOrDefault(p => p.Id == id) == null)
        {
            return BadRequest("No such product");
        }
        else
        {
            return Ok(ProductsCollection()
                .First(p => p.Id == id));
        }
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (ProductsCollection().FirstOrDefault(p => p.Id == product.Id) != null)
        {
            return BadRequest("Such product already exist");
        }
        else
        {
            ProductsCollection().Append(product);
            return Ok(ProductsCollection());
        }
    }

}