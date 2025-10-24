using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartEdu.Shared.Services;
using SmartEdu.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the SmartEdu.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
