using Chapter_4_Enhancing_Data_Display_with_Grids.Client.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<TicketsApi>();

await builder.Build().RunAsync();