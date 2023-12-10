using AcademiX.Data;
using AcademiX.Helpers;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    // With IdleTimeout you can change the number of seconds after which the session expires.
    // The seconds reset every time you access the session.
    // This only applies to the session, not the cookie.
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


//Services
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();

//Repositories
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

// Helpers 
builder.Services.AddTransient<ModelMapper>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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