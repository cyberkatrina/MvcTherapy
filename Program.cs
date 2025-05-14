using Microsoft.EntityFrameworkCore;
using MvcTherapy.Data;
using MvcTherapy.Models;

var builder = WebApplication.CreateBuilder(args); // initializes a builder object to configure the app


if (builder.Environment.IsDevelopment())
{
    // When in development, the app uses SQLite with a connection string from appsettings.json (it’s fetched using GetConnectionString("MvcTherapyContext")
    builder.Services.AddDbContext<MvcTherapyContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcTherapyContext") ?? throw new InvalidOperationException("Connection string 'MvcTherapyContext' not found.")));
}
else
{
    // When in production, the app uses SQL Server with a different connection string ("ProductionMvcTherapyContext")
    builder.Services.AddDbContext<MvcTherapyContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcTherapyContext")));
}

// Add MVC services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build(); // build the web app

using (var scope = app.Services.CreateScope()) // creates a scope for resolving services
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services); //seed the database with initial data
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforces HTTP Strict Transport Security for (HTTPS)
}

app.UseHttpsRedirection(); // ensures that all HTTP requests are redirected to HTTPS, forces app to use a secure connection
app.UseRouting(); // allows the app to route requests to controllers or endpoints based on the URL

app.UseAuthorization();

app.MapStaticAssets(); // enable the serving of static files like wwwroot content

// defines the default routing pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") // Controller/Action/Id (optional)
    .WithStaticAssets(); // ensures static files are handled in the routing system

app.Run(); // starts the web application
