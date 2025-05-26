Reusable pre-rendering off interactive web assembly mode:
```csharp
internal static class Config
{
    public static readonly IComponentRenderMode
        PrerenderDisabled = new
            InteractiveWebAssemblyRenderMode(
                prerender: false);
}
```
…useful when having in-memory state as there would be exceptions when pre-rendering on the server as the in-memory state is inaccessible there…

Services depending on the ```csharp
IJSRuntime
``` cannot be singletons as the ```csharp
IJSRuntime
``` requires access to each user's browser session. 
From claude:
This is a problem for InteractiveServer mode because a singleton instance is reused for all the clients which would create chaos when it comes to the ```csharp
IJSRuntime
``` while transient or scoped is fine because they are bound to a user / client.