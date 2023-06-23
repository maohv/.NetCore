using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS51____ASP.NET_Razor_02__Cú_pháp_cơ_bản_trong_ASP.NET_Razor.Pages;

public class IndexModel : PageModel
{
    public string Abc { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        this.Abc = "OnGet ksfsasdasd";
    }
}
