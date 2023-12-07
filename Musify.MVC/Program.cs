using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Musify.MVC.Data;
using Musify.MVC.Infrastructure.IdentityService;
using Musify.MVC.Infrastructure.MailService;
using Musify.MVC.Models.Entities;
using Musify.MVC.Persistance;
using Musify.MVC.Repositories;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



//configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();  //??

builder.Services.AddSingleton(Log.Logger);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MusifyDbContext>(opt => opt.UseSqlServer((builder.Configuration["ConnectionStrings:DefaultString"])));


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MusifyDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(Genaricepository<>));
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumReposioty>();
builder.Services.AddScoped<IALLForOne, ALLForOne>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


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
app.UseAuthentication();
app.UseAuthorization();

SeedDBInitializer.PopulateData(app);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
