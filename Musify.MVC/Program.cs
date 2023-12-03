using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Persistance;
using Musify.MVC.Profiles;
using Musify.MVC.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MusifyDbContext>(opt => opt.UseSqlServer((builder.Configuration["ConnectionStrings:DefaultString"])));


builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(Genaricepository<>));
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumReposioty>();
builder.Services.AddScoped<IALLForOne, ALLForOne>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


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

SeedDBInitializer.PopulateData(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
