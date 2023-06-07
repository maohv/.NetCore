using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
    public string title { get; set; } = "Chao mung ban toi trang web cua toi";

    string Welcome(string name)
    {
        return $"Chao Mung {name} den voi website";
    }
}