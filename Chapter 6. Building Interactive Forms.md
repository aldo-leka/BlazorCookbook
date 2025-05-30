```csharp
[SupplyParameterFromForm]
```
enables Blazor to automatically populate the **Model** object with values from the associated form.

Adding ```Enhanced``` to an EditForm means no full page reload on submit form while keeping the benefits of SSR.

From claude:
Benefits of SSR and Enhanced forms:
* Fast initial load
* Smooth form submissions
* No JavaScript bundle required

You can also use plain HTML form like this and add the data-enhance attribute to achieve the same results:
```html
<form method="post"
      @onsubmit="@Save"
      @formname="event-form" 
      data-enhance>
    @* form body *@
</form>
```

To keep forms narrow for nested properties you can utilize the ```@inherits Editor<T>``` construct in a nested form component where T is the nested object type. And you can attach the nested form component to the main EditForm like this:
```html
<NestedFormComponent @bind-Value="@Model.NestedObject" />
```

Blazor's provided ```InputFile``` component includes drag and drop functionality although you need to style it yourself to look like a drop zone.

Embedding an **anti-forgery** token in your forms practically creates a unique key sent with each post request. The server checks this token upon receiving a request; if the token is not present or is incorrect, the request is rejected, thus preventing unauthorized actions.
It's only needed within plain HTML ```<form>``` tags.

We leverage the ```app.UseAntiforgery()``` extension method within the middleware area. The order of middleware registration is crucial; you must position the anti-forgery middleware thoughtfully based on other middleware in use. If your application includes authentication and authorization, ensure ```app.UseAntiforgery()``` is placed after ```app.UseAuthentication()``` and ```app.UseAuthorization()```. 

If you have routing configured, place anti-forgery middleware after ```app.UseRouting()```, but before ```app.UseEndpoints()``` if you register endpoint middleware.