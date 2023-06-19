using Microsoft.EntityFrameworkCore;
using razorweb.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MyBlogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyBlogContext"));
});

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

/*
   CREATE, READ, UPDATE, DELETE (CRUD)

   dotnet aspnet-codegenerator razorpage -m razorweb.models.Article -dc razorweb.models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries

   Lỗi scaffolding failed do các package khác phiên bản
*/