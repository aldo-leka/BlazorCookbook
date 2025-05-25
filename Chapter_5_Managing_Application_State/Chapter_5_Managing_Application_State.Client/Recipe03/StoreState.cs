namespace Chapter_5_Managing_Application_State.Client.Recipe03;

public sealed class StoreState
{
    public event Func<StateArgs, Task> OnChanged;
    public Task Notify(StateArgs args)
        => OnChanged?.Invoke(args);
}
