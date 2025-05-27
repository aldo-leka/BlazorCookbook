two form-backing variables: ```csharp
EditContext
``` and ```csharp
ValidationMessageStore
```. The ```csharp
EditContext
``` instance tracks changes to form inputs and manages the validation state, while ```csharp
ValidationMessageStore
``` holds and displays validation messages, simplifying the validation process.
See https://github.com/aldo-leka/BlazorCookbook/blob/main/Chapter_7_Validating_User_Input_Forms/Chapter_7_Validating_User_Input_Forms.Client/Recipe01/EventManager.razor

```csharp
DataAnnotationsValidator
``` enables full model validation with ssr and field validation with interactive mode when you focus out of an input for immediate feedback.

In a class inheriting from ```csharp
ValidationAttribute
```, you can reach dependency injection through the ```csharp
ValidationContext
``` parameter which provides all the standard dependency injection methods in .net. For example:
```csharp
protected override ValidationResult IsValid(object value,
    ValidationContext validationContext)
{
    var api = validationContext.GetRequiredService<Api>();
    //...
}
```

Custom validation attributes do not support async validation. This is to ensure performance and UX are not negatively affected.

The ```csharp
ObjectGraphDataAnnotationsValidator
``` component from experimental package Microsoft.AspNetCore.Components.DataAnnotations.Validation is an advanced component capable of validating nested object graphs, allowing Blazor to trigger validation on every part of our complex **Event** model.
See https://github.com/aldo-leka/BlazorCookbook/blob/main/Chapter_7_Validating_User_Input_Forms/Chapter_7_Validating_User_Input_Forms.Client/Recipe04/EventManager.razor

EditContext has a caveat that when user changes an input field for example it marks the form as IsModified but if user reverts the input value to its previous value it's still considered IsModified. If you want to handle this situation you have to implement an equality comparer inheriting from ```csharp
IEqualityComparer<T>
``` and check _initialModel != Model.