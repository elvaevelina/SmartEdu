using SmartEdu.Shared.Services;
using SmartEdu.Web.Components;
using SmartEdu.Web.Services;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the SmartEdu.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddScoped<HttpClient>(sp =>
{
    //var nav = sp.GetRequiredService<NavigationManager>();
    //return new HttpClient { BaseAddress = new Uri(nav.BaseUri) };
    return new HttpClient { BaseAddress = new Uri("https://localhost:7194/") };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(SmartEdu.Shared._Imports).Assembly,
        typeof(SmartEdu.Web.Client._Imports).Assembly);

app.Run();
