From claude:
During SSR period: Navigation triggers full HTTP requests to the server for each route change, causing complete page reloads.
In Interactive modes: Navigation is handled client-side - the router intercepts link clicks, updates the browser URL, and renders the new component without full page refreshes (SPA-style navigation).
In WebAssembly mode, your C# code runs in WebAssembly but **Blazor still uses JavaScript for DOM manipulation and browser APIs like routing interception**.
In InteractiveServer mode, there's no WebAssembly involved at all. C# runs on the server. The flow is like this:
* User clicks link -> JavaScript intercepts
* SignalR (JavaScript client) sends event to server
* C# code runs on the server
* Server determines new component to render
* SignalR sends DOM updates back to the browser
* JavaScript applies the changes to DOM (Document Object Model).

You can implement a catch em all pattern to intercept route parameters like this:
```csharp
@page "/ch09r02/{*path}"
@code {
    [Parameter] public string Path {get; set; }
}
```

The use of query parameters is useful for filtering data, pagination, and passing user-specific information without altering the URL structure significantly.

How to handle query parameters in code:
```csharp
[SupplyParameterFromQuery]
public DateTime Date { get; set; }
```

If parameter name in code is different from query parameter, or you want to capture all values when query key is there multiple times, you need to use this code:
```csharp
[SupplyParameterFromQuery(Name = "seat")]
public string[] Seats { get; set; }
```

Also important when dealing with dates, globalization: https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-9.0#globalization