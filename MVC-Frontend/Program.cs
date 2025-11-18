using MVC_Frontend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("gateway", client =>
{
    client.BaseAddress = new Uri("http://localhost:5183/");
});
builder.Services.AddScoped<ProductApiService>();
builder.Services.AddScoped<InventoryApiService>();
builder.Services.AddScoped<OrderApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
