using EncycloBook.Data;
using EncycloBook.Data.Models;
using EncycloBookProject.Hubs;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using EncycloBook.Services.FoodServices.Contracts;
using EncycloBook.Data.Models.Properties;
using EncycloBook.Services.FoodServices;
using EncycloBook.Services.PostServices;
using EncycloBook.Services.PostServices.Contracts;
using EncycloBook.Services.AllPostsServices.Contracts;
using EncycloBook.Services.AllPostsServices;
using EncycloBook.Services.SymptomServices.Contracts;
using EncycloBook.Services.SymptomServices;
using EncycloBook.Services.EditServices.Contracts;
using EncycloBook.Services.EditServices;
using EncycloBook.Services.UserServices.Contracts;
using EncycloBook.Services.UserServices;
using EncycloBook.Services.CommentServices.Contracts;
using EncycloBook.Services.CommentServices;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IFoodServices, FoodServices>();
builder.Services.AddScoped<ISymptomServices, SymptomServces>();
builder.Services.AddScoped<IEditServices, EditServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IAllPostServices, AllPostServices>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapHub<CommentHub>("/commentHub");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Apply any pending migrations
    dbContext.SeedData(); // Seed initial data
}
app.Run();
