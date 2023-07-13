using AppMVC.Net.Models;

namespace AppMVC.Net.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){Id = 1, Name = "Iphone X", Price = 1000},
                new ProductModel(){Id = 2, Name = "Iphone X1", Price = 2000},
                new ProductModel(){Id = 3, Name = "Iphone X2", Price = 3000},
                new ProductModel(){Id = 4, Name = "Iphone X3", Price = 4000},

            });
        }
    }
}