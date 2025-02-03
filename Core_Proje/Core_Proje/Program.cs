using Core_Proje.Areas.Writer.Models;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddIdentity<WriterUser,WriterRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<TurkishIdentityErrorDescriber>();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(); // Razor Runtime Compilation'ı ekler
builder.Services.AddDbContext<Context>();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
//builder.Services.AddAuthentication(
//    CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(x =>
//    {
//        x.LoginPath = "/AdminLogin/Index";
//    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Writer/Login/Index";
    options.LogoutPath = "/AdminLogin/Logout";
    options.AccessDeniedPath = "/ErrorPage/Index";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = System.TimeSpan.FromMinutes(100);
    options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
    {
        HttpOnly = true,
        Name = ".CoreProje.Security.Cookie",
        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
    };
});

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

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Defauıt}/{action=Index}/{id?}"
    );
});



app.Run();