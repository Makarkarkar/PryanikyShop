namespace PryanikyShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, string info, decimal price)
    {
        Id = id;
        Name = name;
        Info = info;
        Price = price;
    }
}