using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.models;

namespace App.Admin.User
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        public IndexModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public class UserAndRole : AppUser
        {
            public string RoleNames { get; set; }
        }
        //Khai bao 1 property co kieu la danh sach List
        public List<UserAndRole> users { get; set; }

        public const int ITEM_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public int totalUser { get; set; }
        public async Task OnGet()
        {
            // users = await _userManager.Users.OrderByDescending(r => r.UserName).ToListAsync();

            var qr = _userManager.Users.OrderBy(u => u.UserName);

            totalUser = await qr.CountAsync();

            countPages = (int)Math.Ceiling((double)totalUser / ITEM_PER_PAGE); //Làm tròn

            if (currentPage < 1)
                currentPage = 1;

            if (currentPage > countPages)
                currentPage = countPages;

            var qrn = qr
            .Skip((currentPage - 1) * ITEM_PER_PAGE)
            .Take(ITEM_PER_PAGE)
            .Select(u => new UserAndRole()
            {
                Id = u.Id,
                UserName = u.UserName,
            });

            users = await qrn.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.RoleNames = string.Join("-", roles);
            }
        }
        public void OnPost() => RedirectToPage();
    }
}
