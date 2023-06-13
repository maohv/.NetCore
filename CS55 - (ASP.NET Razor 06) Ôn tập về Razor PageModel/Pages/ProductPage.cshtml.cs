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
    public void OnGet(int? id)
    {
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
    // /product/{id:int?}?handler=lasproduct
    public void OnGetLastProduct()
    {
        ViewData["Title"] = $"San pham cuoi)";
        product = productService.AllProuct().LastOrDefault();
    }
}

