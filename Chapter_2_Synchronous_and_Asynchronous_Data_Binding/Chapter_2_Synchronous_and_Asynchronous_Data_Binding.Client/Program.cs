using Chapter_2_Synchronous_and_Asynchronous_Data_Binding.Client.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<SuggestionsApi>();

await builder.Build().RunAsync();