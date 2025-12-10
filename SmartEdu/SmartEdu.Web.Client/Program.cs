using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartEdu.Shared.Services;
using SmartEdu.Web.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the SmartEdu.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7194/") });

builder.Services.AddScoped<ILocationService, WebLocationService>();
builder.Services.AddSingleton<INetworkService, WebNetworkService>();

await builder.Build().RunAsync();
