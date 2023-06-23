var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ProductService>();

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
    PageModel, Model Binding
    dotnet new page
    - ProductPage
    dotnet new page -n ProductPage -o Pages - na (ten namespace)

    - ModelBinding: Liên kết dữ liệu
    Nguồn:
        - Form HTML (post):             HttpRequest.Form["key]
        - Query (form html - get):      HttpRequest.Query["key]
        - Header:                       HttpRequest.Header["key]
        - Route Data:                   HttpRequest.RouteValues["key]
        - UpLoad
        - Body

    Đọc dữ liệu: HttpRequest (Controller, PageModel, View)

    - Attributes: Parameter Binding, Proerty Binding

    *Parameters Binding: 

    *Proerty Binding: 
        [BindProperty]
*/