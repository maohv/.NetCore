using AppMVC.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FirstController> _logger;

        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService)
        {
            _logger = logger;
            _env = env;
            _productService = productService;
        }
        public string Index()
        {
            return "Toi la index cua First";
        }

        public IActionResult Bird()
        {
            string contentRootPath = _env.ContentRootPath;
            string filePath = Path.Combine(contentRootPath, "File", "bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone",
                    Price = 1000
                }
            );
        }
        public IActionResult Google()
        {
            var url = "http://www.google.com";
            return Redirect(url);
        }

        public IActionResult HelloView()
        {
            //View -> Razor Engine, doc .cshtml (teamplate)
            return View("");
        }

        [TempData]
        public string StatusMessage { get; set; }
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                //TempData["StatusMessage"] = "Sản phẩm bạn yêu cầu không có";
                StatusMessage = "Sản phẩm bạn yêu cầu không có";
                return Redirect(Url.Action("Index", "Home"));
            }
            //View/First/ViewProduct.cshtml
            return View(product);
        }
    }
}