using Microsoft.EntityFrameworkCore;
using MVCFifa.Data;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
var sb = new StringBuilder();
sb.Append("Server=(localdb)\\mssqllocaldb;");
sb.Append("Database=fifaDb;");
sb.Append("Trusted_Connection=true;");
sb.Append("MultipleActiveResultSets=true;");
var connString = sb.ToString();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
