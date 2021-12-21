using Application;
using Application.Constants.Persistence;
using Identity;
using Identity.Models;
using Identity.Seed;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Persistence.Seed;
using WebApp.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// DbInitializer
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WebAppIdentityDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        DbIdentityInitializer .InitializeUsersAsync(context, userManager).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WebAppDbContext>();
        var userRepository = services.GetRequiredService<IUserRepository>();
        DbInitializer.InitializeUserAccountsAsync(context, userRepository).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UserStateInitializer>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();