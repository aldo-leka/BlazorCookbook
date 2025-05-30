```csharp
@bind
```
attribute enables two way data binding. Two-way data binding means the UI (html element) value is set together with the C# variable.

From claude:
This:
```html
<input @bind="User" />
```
Is equivalent to this:
```html
<input value="@User" @onchange="@((e) => User = e.Value.ToString())" />
```

Singleton services are created once per application and shared across components and requests.
Transient services are created anew each time they are requested, which makes them perfect for lightweight, stateless services, such as API integrations.
Scoped services behave like Singleton services in client-side applications because there is no connection context to differentiate sessions. That changes if the component inherits from OwningComponentBase in its partial class because that guarantees there's always fresh injected services for that component.
From claude: Normally scoped services means one instance per HTTP request (e.g. in Web API). In case of blazor web assembly, there's one instance per application lifetime (acts like a singleton) because there's no HTTP request concept, just one user session in the browser which lives until the user closes/refreshes the page.
In Blazor server, there's one instance of a scoped service per SignalR connection/circuit which dies when the user disconnects.
In short:
Web API: scope = HTTP request
Blazor Server: scope = user connection
Blazor WebAssembly: scope = entire app (effectively a singleton)
OwningComponentBase artificially creates component-level scopes where there normally wouldn't be any.

In case of Auto projects (Server and WebAssembly) with an App and App.Client project, you need to register your services in both projects because Blazor first renders the component on the server (pre-rendering), then switches to WebAssembly. It needs to find the services during both phases.
From claude: This is the recommended approach when building Blazor apps because of:
- Fast initial load (server pre-rendering shows content immediately)
- Rich interactivity (WebAssembly takes over for smooth UX)
- Best of both worlds (SEO-friendly + fast + interactive)
  Pure server approach requires constant connection.
  
On the App (Server) project goes:
- API controllers
- Authentication / Authorization - JWT, cookies etc.
- Database services - EF, repositories
- Server only services - email, file I/O, external APIs with secrets
- Static/non-interactive components - layouts, headers, footers that don't need JavaScript.
  
On the App.Client project goes:
- Interactive pages/components - anything with @onclick, state management.
- Client-side services - Http clients, local storage, browser APIs.
- Viewmodels/DTOs - data structures for UI binding.
- Client-side logic - validation, formatting, UI state.
  
Register services in both projects when used during pre-rendering and client-side. Register only in server when db access, file I/O, secrets, auth providers. Register only in client when browser-specific APIs (local storage, geolocation), pure UI services (toast notifications, modals). Put the shared stuff in a Common or Shared library. The key is: server handles data/security, client handles interactivity.

From claude: WebAssembly and JavaScript run side by side, with WA being faster (closer to native speed).  Compute-heavy tasks: WA wins by 2-10x. DOM manipulation: JS wins (direct browser API access). Blazor has overhead from the .NET runtime in WASM. Blazor WA has a larger initial load (~2 MB for the .NET runtime) but runs C# code at near-native speeds.

At this code:
```csharp
[Inject] private SuggestionsApi Api { get; init; }
```
From claude:
init is a newer C# 9 feature that sets the object only during object initialization, then becomes read-only forever. It's an extra thing to be careful about immutability.

When working in a code-behind fashion, you can use constructor injection pattern to set the services without using attributes like ```[Injection]``` like so:
```public partial class IntroduceYourself(SuggestionsApi Api) { }```

When binding you can do ```@bind:event``` to bind to an event such as oncopy, onpaste, onblur, oninput etc.
```@bind:after``` executes code after the binding has happened. Useful for autocompletion after the input value is bound.
```@bind:set``` is used in conjunction with ```@bind:get``` similarly to do things after the value is set. Use ```@bind:after``` when you need to do asynchronous tasks. Use ```@bind:set``` when you need to validate the input.

The pairing of a value of type T and a matching EventCallback<T> handler forms the basis of the bind-Value pattern. Similar to recognizing ChildContent implicitly, when working with RenderFragment, Blazor's code generators recognize T and EventCallback<T> and compile the ```@bind-Value``` directive.
- Example, at Form.razor:
```html
<input class="form-control w-50 mb-1" @bind="@Name"
@bind:event="oninput"
@bind:after=@OnNameChanged />
```

```csharp
[Parameter]
public string Name { get; set; }
[Parameter]
public EventCallback<string> NameChanged { get; set; }
```
- At Page.razor:
```html
<Form @bind-Name="@Name" />
```

```csharp
protected string Name { get; set; }
```