In a markupless component you can still leverage the Authorize attribute like this:
```csharp
[Route("/ch08r02")]
[Authorize]
public class Settings : ComponentBase
{
    // ...
}
```

Apart from ```ChildContent```, ```AuthorizeView``` supports providing the ```Authorized```, ```Authorizing```, and ```NotAuthorized``` fragments explicitly. With that, you can define distinct content for authenticated and unauthenticated users within the same component.

Example:
```html
<h3>Settings</h3>
<AuthorizeView>
    <Authorized>
        <p>You're authorized to see settings.</p>
    </Authorized>
    <Authorizing>
        <p>Give us a few moments...</p>
    </Authorizing>
    <NotAuthorized>
        <p>You can't be here, sorry.</p>
    </NotAuthorized>
</AuthorizeView>
```