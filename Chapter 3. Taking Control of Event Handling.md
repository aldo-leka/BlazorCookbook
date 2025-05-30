Blazor offers ```@onclick```, ```@ondrag```, ```@oncopy``` and other integrations for HTML events. 

Blazor automatically converts lambda expressions like ```@onclick="() => DoSomething()"``` into EventCallback objects that trigger StateHasChanged internally and in turn the UI updates immediately when the event fires.

EventCallback is a building block of most interactivity in Blazor.
It is also a null-safe object that doesn't throw null reference exception but it safely skips.

When attaching a method to the ```@onkeydown``` event of an input, you can bypass the default behavior of onkeydown by also providing ```@onkeydown:preventDefault``` to the input field. ```@onkeydown``` has default behaviors which vary on the key pressed, e.g. enter submits form, or creates new lines in text areas, tab key moves focus to the next element, backspace deletes characters, arrow keys move cursor, space scrolls page down, etc.

When interactive mode is Server, you must know that every event trigger will travel to the server and than back and than reflected on the UI which can create flaky and unstable behavior of the UI.

When building international apps, you may need to support composing keys to make a special character in another language. You can use KeyboardEventArgs.IsComposing for that:
```csharp
private void MonitorCreation(KeyboardEventArgs args)
{
    if (args.IsComposing) return;
    //rest of the processing logic obscured for simplicity
}
```

You also have the stopPropagation attribute which is helpful for example when you have a nested element that has onclick as well as the parent and the onclick on the child would normally propagate to the parent and 2 actions would fire which can lead to unexpected results. You can append the
```csharp
@onclick:stopPropagation
```
to the child elements and that way only their event will fire as the click won't be propagated to the parent.

Adding a .js file within the wwwroot directory, adhering to a specific naming convention
```
{ASSEMBLY NAME}.lib.module.js
```
or
```
{PACKAGE ID}.lib.module.js
```
is used for handling custom events that Blazor doesn't natively support such as
```csharp
@onlongpress
```
```csharp
@onswipe
``` 
or 
```csharp
@onscroll
```
That file must have the afterWebStarted function with a parameter named blazor (lowercase to differentiate with the globally available Blazor object). Then you use the registerCustomEventType API to register the event with a custom name and options that provide browserEventName that you want to handle etc.

Rule of thumb for when to use a:
- Loading indicator: operations with unpredictable completion times, such as fetching data from an API
- Progress indicator: for operations with known results, such as submitting data changes or sending notifications.