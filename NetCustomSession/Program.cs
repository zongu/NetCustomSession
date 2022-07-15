using NetCustomSession.Domain.Sessoin;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddFreeRedisCache(option =>
{
    option.Configuration = "localhost:6379";
    option.InstanceName = "MyWebSite_";
});

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromSeconds(86400);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
