public class ProductService
{
    private List<Product> products = new List<Product>();

    public ProductService()
    {
        LoadProduct();
    }

    public Product Find(int id)
    {
        var qr = from p in products
                 where p.Id == id
                 select p;
        return qr.FirstOrDefault();
    }

    public List<Product> AllProuct() => products;
    public void LoadProduct()
    {
        products.Clear();

        products.Add(new Product()
        {
            Id = 1,
            Name = "Iphone",
            Price = 900,
            Description = "Dien thoai Iphone"
        });
        products.Add(new Product()
        {
            Id = 2,
            Name = "SamSung",
            Price = 500,
            Description = "Dien thoai SamSung"
        });
        products.Add(new Product()
        {
            Id = 3,
            Name = "OPPO",
            Price = 600,
            Description = "Dien thoai OPPO"
        });
    }
}