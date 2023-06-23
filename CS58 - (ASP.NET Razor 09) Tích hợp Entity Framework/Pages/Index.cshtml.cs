using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorweb.models;

namespace CS58____ASP.NET_Razor_09__Tích_hợp_Entity_Framework.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly MyBlogContext myBlogContext;
    public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myBlogContext)
    {
        _logger = logger;
        myBlogContext = _myBlogContext;
    }

    public void OnGet()
    {
        var posts = (from a in myBlogContext.articles
                     orderby a.Created descending
                     select a).ToList();
        ViewData["Posts"] = posts;
    }
}
