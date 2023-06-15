using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
public class ProductPageModel : PageModel
{
    private readonly ILogger<ProductPageModel> _logger;

    public readonly ProductService productService;
    public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
    {
        _logger = logger;
        productService = _productService;
    }

    public Product product { set; get; }
    public void OnGet(int? id, [Bind("Id", "Name")] Product sanpham)
    {
        //var data = this.Request.Form["id"];
        //var data = this.Request.Query["id"];
        //var data = this.Request.RouteValues["id"];
        //var data = this.Request.Headers["id"];

        var data = this.Request.Query["id"];

        if (!string.IsNullOrEmpty(data))
        {
            Console.WriteLine(data.ToString());
            int i = int.Parse(data.ToString());
        }


        if (id != null)
        {
            ViewData["Title"] = $"San pham (ID = {id.Value})";
            product = productService.Find(id.Value);
        }
        else
        {
            ViewData["Title"] = "Danh sach san pham";

        }
    }
    // /product/{id:int?}?handler=lastproduct
    public IActionResult OnGetLastProduct()
    {
        ViewData["Title"] = $"San pham cuoi)";
        product = productService.AllProuct().LastOrDefault();
        if (product != null)
        {
            return Page();
        }
        else
        {
            return this.Content("Không tìm thấy sản phẩm");
        }
    }

    public IActionResult OngetRemoveAll()
    {
        productService.AllProuct().Clear();

        return RedirectToPage("ProductPage");
    }

    public IActionResult OngetLoad()
    {
        productService.LoadProduct();

        return RedirectToPage("ProductPage");
    }
    public IActionResult OnPostDelete(int? id)
    {
        if (id != null)
        {
            product = productService.Find(id.Value);
            if (product != null)
            {
                productService.AllProuct().Remove(product);
            }
        }
        return this.RedirectToPage("ProductPage", new { id = string.Empty });
    }
}

