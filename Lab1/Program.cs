using Lab1.Data;
using Lab1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICourse, CourseMoc>();
builder.Services.AddScoped<IDepartment, DepartmentMoc>();
builder.Services.AddScoped<IStudent, StudentMoc>();
builder.Services.AddDbContext<ASPCoreMVCDbContext>( a =>
{
    a.UseSqlServer("Server=.; Database=ASPCoreMVCDbLabV2; Trusted_Connection=True;");
});

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
