using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerFeedbackPortal.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CustomerFeedbackPortalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerFeedbackPortalContext")
    ?? throw new InvalidOperationException("Connection string 'CustomerFeedbackPortalContext' not found.")));


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();


app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();