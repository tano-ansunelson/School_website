using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Schoolwebsite.Data;
using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.Services;


var builder = WebApplication.CreateBuilder(args);

// ---- MVC ----
builder.Services.AddControllersWithViews();

// ---- Configuration-backed options ----
builder.Services.Configure<SchoolInfo>(builder.Configuration.GetSection("School"));

// ---- Database (SQL Server / LocalDB) ----
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---- ASP.NET Core Identity (admin login) ----
// Relaxed password rules below because this is a single-admin school
// project, not a public registration system — tighten these if that changes.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login";
    options.AccessDeniedPath = "/Admin/Account/Login";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.Cookie.Name = "SchoolWebsite.AdminAuth";
});

// ---- Repositories ----
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IStudentRepositoty, StudentRepository>();

// ---- Services ----
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// ---- Apply migrations + seed sample data (and the admin account) on startup ----
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DbSeeder.Seed(db);
}

// ---- HTTP pipeline ----
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
    name: "admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
