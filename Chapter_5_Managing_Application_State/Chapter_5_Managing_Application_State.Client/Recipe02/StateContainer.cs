namespace Chapter_5_Managing_Application_State.Client.Recipe02;

public class StateContainer<T>
{
    private readonly Dictionary<Guid, T> _container = [];
    
    public void Persist(Guid key, T value)
        => _container.TryAdd(key, value);
    public T Resolve(Guid key) => _container[key];
}
