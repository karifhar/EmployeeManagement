using System.Diagnostics;
using System.Net;
using EmployeeManagement.Models;
using EmployeeManagement.Services.EmployeeRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContextPool<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt => {
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddMvc(opt => {
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();
builder.Services.AddScoped<IEmployeeService, SQLEmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} 

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.MapGet("/", async context => 
// {
//     await Task.Run(() => context.Response.Redirect("/Account/Login"));
// });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
