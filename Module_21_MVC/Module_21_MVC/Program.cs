using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module_21_MVC.Dal;
using Module_21_MVC.Dal.Interfaces;
using Module_21_MVC.Dal.Repositories;
using Module_21_MVC.Service.Implementations;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.Entity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddMvc();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IBaseRepository<Worker>, WorkerRepositoryApi>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Worker}/{action=GetWorkers}/{id?}");

app.Run();

