using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS54____ASP.NET_Razor_05__TagHelper_và_HtmlHelper.Pages;


public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [DisplayName("Ten nguoi dung")]
    public string UserName { get; set; } = "HoangMao";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
