using Microsoft.EntityFrameworkCore;
using MVCSportStore.Data;
using MVCSportStore.Data.DefaultData;

var builder = WebApplication.CreateBuilder(args);
//consstring 
var connString = builder.Configuration.GetConnectionString("SportStoreConnection");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connString));
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
SeedData.EnsurePopulated(app);
app.Run();
