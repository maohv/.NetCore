using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.models;

namespace App.Admin.Role
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, MyBlogContext myBlogContext) : base(roleManager, myBlogContext)
        {
        }

        //Khai bao 1 property co kieu la danh sach List
        public List<IdentityRole> roles { get; set; }
        public async Task OnGet()
        {
            roles = await _roleManager.Roles.OrderByDescending(r => r.Name).ToListAsync();
        }
        public void OnPost() => RedirectToPage();
    }
}
