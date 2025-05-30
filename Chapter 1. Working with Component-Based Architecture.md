```csharp
@attribute [ExcludeFromInteractiveRouting]
```
Is handy when you have global interactive mode and you want to exclude a component from it.

Every blazor component has a RendererInfo object to tell the component's rendering state.
The RendererInfo.Name property can be:
 - Static (no interactivity),
 - Server (component is running on the server and will be interactive after it fully loads),
 - WebAssembly (component is running in the client's browser and will be interactive after loading),
 - WebView (dedicated to .NET MAUI and native devices).
RendererInfo.IsInteractive shows if component is in interactive state (such as during pre-rendering or static server side rendering - SSR).

From claude:
SSR (static server-side rendering) is like old-school web pages with no interactivity generated on the server as plain html (no javascript).
Pre-rendering is when server generates the initial html so users see content immediately but then hydrates it by loading interactive javascript afterwards.. like server gives a "screenshot" of the app and make it functional after everything loads.
Interactive state means javascript is running and component is alive.

EventCallback is a blazor specific struct that automatically calls StateHasChanged.

```csharp
[Parameter, EditorRequired]
```
EditorRequired makes the parameter required at compile time.
Coupling that with the WarningsAsErrors section in .csproj and including the RZ2012 code within, raises build time errors for missing parameters that are required.

InvokeAsync that calls StateHasChanged is like saying: When you get the chance, please re-render this components instead of direct call: Stop everything and re-render right now. InvokeAsync is for UI thread safety, not db concurrency protection. InvokeAsync is useful when StateHasChanged is called from async callbacks or event handlers, timers, background tasks, external events (SignalR, websockets), or run outside the component's normal lifecycle, otherwise you don't need it (e.g. if same thread).

CascadingValue passes data down to all child components in the component tree. CascadingParameter receives the data without explicitly passing them through every component level.

The RenderFragment feature represents a segment of UI content. It allows components to accept arbitrary HTML markup as a parameter.
How it looks like: 
```csharp
[Parameter, EditorRequired]
public RenderFragment ChildContent { get; set; }
```
ChildContent is a special reserved name in Blazor where you don't need to say ```<ChildContent>``` when using it but can just put the content between the component tags.

With ```@typeparam T```, you can make a component generic.

In Blazor WebAssembly, you can see your logs in the browser console, not in the IDE console.

Context parameter is available on any component that has ```RenderFragment<T>``` parameters. It's used to be more explicit with the naming of the context and to tell contexts apart when there can be clashes (multiple potential contexts).

DynamicComponent is used to render a component at runtime based on a Type parameter.
Sample usage:
```html
@if (AlertType is null) return;
<DynamicComponent Type="@AlertType" Parameters="@AlertParams" />
```
```csharp
@code {
protected Type AlertType;
protected Dictionary<string, object> AlertParams;
// AlertType can be SoldOut or AddedToCard etc
// AlertParams contains parameters for the SoldOut alert type.
}
```