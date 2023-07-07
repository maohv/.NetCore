using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razorweb.models;

namespace App.Admin.Role
{
    public class RolePageModel : PageModel
    {
        //truong du lieu
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly MyBlogContext _context;

        [TempData]
        public string StatusMessage { get; set; }
        public RolePageModel(RoleManager<IdentityRole> roleManager, MyBlogContext myBlogContext)
        {
            //inject
            _roleManager = roleManager;
            _context = myBlogContext;
        }
    }
}