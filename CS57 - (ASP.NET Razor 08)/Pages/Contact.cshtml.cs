using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactModel : PageModel
{
    [BindProperty]
    public CustomerInfo customerInfo { get; set; }
    public void OnGet()
    {
    }

    public string thongbao { get; set; }
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            thongbao = "Dữ liệu gửi đến phù hợp";
        }
        else
        {
            thongbao = "Dữ liệu gửi đến không phù hợp";
        }
    }
}