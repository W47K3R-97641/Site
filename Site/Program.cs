using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Repositories.Interfaces;
using Site.Repositories;
using Site.Services.Interfaces;
using Site.Services;
using System.Security.Principal;
using Blazorise;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Pages and Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configure Blazorise
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

// Load connection string from appsettings or environment variable
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                     

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

Console.WriteLine($"Using connection string: {connectionString}");

// Register Repositories and Services
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

// Configure Middleware and Endpoints
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
