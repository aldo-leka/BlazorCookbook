using Chapter_5_Managing_Application_State.Client.Data;
using Chapter_5_Managing_Application_State.Client.Recipe02;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<Api>();
builder.Services.AddScoped<StateContainer<Event>>();

await builder.Build().RunAsync();