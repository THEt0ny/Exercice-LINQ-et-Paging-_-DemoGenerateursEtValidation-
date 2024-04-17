using Microsoft.EntityFrameworkCore;
using DemoGenerateursEtValidation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAutoRep, BDAutoRepository>();
builder.Services.AddDbContext<CatalogueAutoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueAutoDbContextConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

InitialiseurDB.Seed(app);

app.Run();
