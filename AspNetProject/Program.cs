using AspNetProject.Data;
using AspNetProject.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, AnimalsRepository>();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

var app = builder.Build();


//if(app.Environment.IsStaging() || app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Animal/index");
//}

app.UseStaticFiles();

using(var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.MapControllerRoute("Default", "{controller=Animal}/{action=index}/{id?}");


app.Run();
