using App.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using razorweb.models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MyBlogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyBlogContext"));
});

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true);

builder.Services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MyBlogContext>()
                .AddDefaultTokenProviders();



//Mail
builder.Services.AddOptions();
var mailsetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsetting);
builder.Services.AddSingleton<IEmailSender, SendMailService>();


// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
    options.SignIn.RequireConfirmedAccount = true;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/";
    options.LogoutPath = "/Logout/";
    options.LogoutPath = "/khongduoctruycap.html";

});
//dang nhap bang google
builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    var gconfig = builder.Configuration.GetSection("Authentication:Google");
                    options.ClientId = gconfig["ClientId"];
                    options.ClientSecret = gconfig["ClientSecret"];
                    options.CallbackPath = "/dang-nhap-tu-google";
                });
//dang ki dich vu error cua IdentityErrorDescriber thay bang AppIdentityErrorDescriber
builder.Services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//fix loi Exception: Correlation failed.
app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax
});


app.Run();


//IdentityDbContext

/*
   CREATE, READ, UPDATE, DELETE (CRUD)

   dotnet aspnet-codegenerator razorpage -m razorweb.models.Article -dc razorweb.models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries

   Lỗi scaffolding failed do các package khác phiên bản

   Identity:
        - Athentication: Xác định danh tính -> Login, Logout...
        - Authorization: Xác thực quyền truy cập
         - Role-Based Authentication - Xác định quyền truy cập
          - role (vai trò): (Admin, Editor, Member...)

          Areas/Admin/Pages/Role       
          Index
          Create
          Edit
          Delete

          dotnet new page --name Index -o Areas/Admin/Pages/Role --namespace App.Admin.Role
          dotnet new page --name Create -o Areas/Admin/Pages/Role --namespace App.Admin.Role

        - Quản lí User: Sign up, User, Role ...

        [Authorize] - Controller, Action, Page-Model -> User phai dang nhap
        

   dotnet aspnet-codegenerator identity -dc razorweb.models.MyBlogContext


   //CallbackPatch
   //http://localhost:5170/dang-nhap-tu-google
*/