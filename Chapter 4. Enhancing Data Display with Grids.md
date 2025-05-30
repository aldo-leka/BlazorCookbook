```csharp
@key
```
gives each element a unique identity so blazor's diffing algo can track it across renders and prevents unnecessary DOM recreation by telling blazor that this is the same element, just moved / updated. It's especially beneficial when adding / removing items from list, reordering, sorting, filtering lists, blazor moves existing DOM elements instead of destroying and recreating everything.

Adding the async keyword on a function provides overhead with task scheduling and context switching. If you want to have an async task define it like this and return a Task.CompletedTask:
```csharp
public Task LoadAsync(PaginateEventArgs args)
{
    Set = Data
        .Skip((args.Page - 1) * args.Size)
        .Take(args.Size);
    return Task.CompletedTask;
}
```