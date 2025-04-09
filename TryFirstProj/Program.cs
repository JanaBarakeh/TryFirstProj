using Microsoft.EntityFrameworkCore;
using TryFirstProj.Data;
using TryFirstProj.Repositry;
using TryFirstProj.Repositry.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// connection to mysql server 
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")
    ));
// Add services to the Repositry.
builder.Services.AddTransient(typeof(IRepositry<>), typeof(MainRepositry<>));

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
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
