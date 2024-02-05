using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bank_Simulation.Data;
using Microsoft.Extensions.Options;
using Bank_Simulation.Repositories;
using Bank_simulation.Models;
using Bank_Simulation.Controllers;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<Bank_SimulationContext>(options =>
  //  options.UseSqlServer(builder.Configuration.GetConnectionString("Server=PB_MASTER\\SQLEXPRESS_HOME;Database=Bank_Data;Trusted_Connection=true;Encrypt=False")));

// Add services to the container.
builder.Services.AddTransient<IActionRepository,ActionsRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Bank_SimulationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Bank_SimulationContext")));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
