using Newtonsoft.Json;

class Product
{
    public string Name { get; set; }

    public DateTime Expiry { get; set; }
    public string[] Sizes { get; set; }




}
internal class Program
{
    // dotnet add package name
    // dotnet remove package name
    // dotnet restore
    // dotnet add tenduan.csproj thuvien.csproj
    // C:\Users\Hoang Mao\source\repos\C#\.NetCore\CS31_uspackage\CS31_uspackage.csproj reference C:\Users\Hoang Mao\source\repos\C#\.NetCore\Utils\Utils.csproj
    static void Main(string[] args)
    {
        // Product product = new Product();
        // product.Name = "Apple";
        // product.Expiry = new DateTime(2008, 12, 28);
        // product.Sizes = new string[] { "Small" };

        // string json = JsonConvert.SerializeObject(product);

        // Console.WriteLine(json);
        // // {
        // //   "Name": "Apple",
        // //   "Expiry": "2008-12-28T00:00:00",
        // //   "Sizes": [
        // //     "Small"
        // //   ]
        // // }

        string json = @"{
            ""Name"": ""Dien thoai iphone"",
            ""Expriry"": ""2008-12-28T00:00:00"",
            ""Size"":[""Large"",""Small""]
        }";

        var product = JsonConvert.DeserializeObject<Product>(json);
        Console.WriteLine(product.Name);
        Console.WriteLine(product.Expiry.ToLongDateString());
    }
}