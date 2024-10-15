using System.Diagnostics;
using EmployeeManagement.Models;
using EmployeeManagement.Services.EmployeeRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContextPool<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbConnection")));

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddScoped<IEmployeeService, SQLEmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} 

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
