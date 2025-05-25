using Chapter_5_Managing_Application_State.Client.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<Api>();

await builder.Build().RunAsync();