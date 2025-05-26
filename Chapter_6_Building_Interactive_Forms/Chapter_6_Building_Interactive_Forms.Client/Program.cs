using Chapter_6_Building_Interactive_Forms.Client.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTransient<FileStorage>();
await builder.Build().RunAsync();