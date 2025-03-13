using Microsoft.EntityFrameworkCore;
using ELNET01.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configure services
builder.Services.AddControllersWithViews();

// 🔹 Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// 🔹 Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🔹 Ensure HTTPS Redirection
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 🔹 Explicitly set URLs to listen on HTTP and HTTPS
app.Urls.Add("http://localhost:5165");
app.Urls.Add("https://localhost:7270");

// 🔹 Set up default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// 🔹 Map the About page
app.MapControllerRoute(
    name: "about",
    pattern: "Home/About",
    defaults: new { controller = "Home", action = "About" }
);

app.Run();
