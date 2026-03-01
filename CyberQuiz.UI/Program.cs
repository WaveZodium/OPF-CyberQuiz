using CyberQuiz.Infrastructure.Data;//NY
using CyberQuiz.Infrastructure.Data.Seed;//NY
using CyberQuiz.Infrastructure.Entities;//NY
using CyberQuiz.UI.Components;
using CyberQuiz.UI.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options => {
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();
//OBS!ÄNDRINGAR
//=====================================================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.MigrationsAssembly("CyberQuiz.Infrastructure")));//NY

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;//ändrar till false för att inte kräva bekräftelse av e-postadress vid registrering
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

//=========OBS! NYTT IGEN=====================
// Skapa testkontot automatiskt när appen startar, så vi alltid kan logga in vid test/demo.
// Detta körs bara när servern startar (inte i webbläsaren).
// Koden kollar först om användaren redan finns – annars skapas den.

if (app.Environment.IsDevelopment())//Kör den här seed-koden bara när appen körs i utvecklingsläge (Development)
{
    using var scope = app.Services.CreateScope();//Skapar ett “tillfälligt rum” där appen kan hämta saker som ska leva kort tid
    await IdentitySeeder.SeedRequiredUserAsync(scope.ServiceProvider);
}
//===========================================

app.Run();
