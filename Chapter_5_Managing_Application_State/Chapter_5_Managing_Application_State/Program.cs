using Chapter_5_Managing_Application_State.Client.Data;
using Chapter_5_Managing_Application_State.Client.Recipe04;
using Chapter_5_Managing_Application_State.Client.Recipe07;
using Chapter_5_Managing_Application_State.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<Api>();
builder.Services.AddScoped<OverlayState>();
builder.Services.AddTransient<Chapter_5_Managing_Application_State.Client.Recipe05.BrowserStorage>();
builder.Services.AddTransient<Chapter_5_Managing_Application_State.Client.Recipe06.BrowserStorage>();
builder.Services
    .AddCascadingValue(it => new CartState());
builder.Services.AddTransient<Chapter_5_Managing_Application_State.Client.Recipe07.BrowserStorage>();

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


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Chapter_5_Managing_Application_State.Client._Imports).Assembly);

app.Run();