using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Site;
using Site.Data;
using Site.Repositories;
using Site.Repositories.Interfaces;
using Site.Services;
using Site.Services.Interfaces;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// Razor Pages + Blazor Server
// ----------------------------
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // for API controllers

// ----------------------------
// Blazorise Config
// ----------------------------
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

// ----------------------------
// EF Core + Identity
// ----------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie is only accessible by the server
    options.Cookie.HttpOnly = true;

    // Give it a unique name to avoid conflicts with other apps
    options.Cookie.Name = "AmaroAuth";

    // Persist login for a reasonable period
    options.ExpireTimeSpan = TimeSpan.FromDays(14);

    // Renew cookie before it expires
    options.SlidingExpiration = true;

    // Where to redirect if not authenticated
    options.LoginPath = "/login";

    // Where to redirect if authenticated but forbidden
    options.AccessDeniedPath = "/access-denied";

    
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    // Optional: Restrict cookie to same site
    options.Cookie.SameSite = SameSiteMode.Strict;
});


// ----------------------------
// Authorization & Auth State
// ----------------------------
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// ----------------------------
// Your Repositories & Services
// ----------------------------
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();



builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();


// ✅ HttpClient for calling your own API
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.Configuration["AppBaseUrl"] ?? "https://localhost:7087/") });

var app = builder.Build();

// ----------------------------
// Middleware
// ----------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Order matters: Auth before Endpoints
app.UseAuthentication();
app.UseAuthorization();

// ----------------------------
// Endpoints
// ----------------------------
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
