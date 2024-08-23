using Demo.Contexts;
using Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews().AddCookieTempDataProvider(); // Default
builder.Services.AddControllersWithViews(); //.AddSessionStateTempDataProvider(); // Store at server


// Add Db Services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// Register User
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
     {
         // Default Password settings.
         options.Password.RequireDigit = true;
         options.Password.RequireLowercase = true;
         options.Password.RequireNonAlphanumeric = true;
         options.Password.RequireUppercase = true;
         options.Password.RequiredLength = 6;
         options.Password.RequiredUniqueChars = 1;

     }).AddEntityFrameworkStores<ApplicationDbContext>();







builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
