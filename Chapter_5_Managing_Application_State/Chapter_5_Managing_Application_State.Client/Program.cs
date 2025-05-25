using Chapter_5_Managing_Application_State.Client.Data;
using Chapter_5_Managing_Application_State.Client.Recipe02;
using Chapter_5_Managing_Application_State.Client.Recipe03;
using Chapter_5_Managing_Application_State.Client.Recipe04;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<Api>();
builder.Services.AddScoped<StateContainer<Event>>();
builder.Services.AddScoped<StoreState>();
builder.Services.AddScoped<OverlayState>();

await builder.Build().RunAsync();