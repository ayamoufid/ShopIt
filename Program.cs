using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using commerceProjet.Data;
using commerceProjet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<commerceProjetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("commerceProjetContext") ?? throw new InvalidOperationException("Connection string 'commerceProjetContext' not found.")));

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout duration
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
    options.Cookie.IsEssential = true; // Make the session cookie essential for the application
});

// Enregistrement du service CategoryService
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session before authorization
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
