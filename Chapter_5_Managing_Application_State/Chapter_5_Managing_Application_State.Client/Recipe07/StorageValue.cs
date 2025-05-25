namespace Chapter_5_Managing_Application_State.Client.Recipe07;

public abstract record StorageValue<T>
{
    public string Key { get; init; }
    public T Value { get; init; }
}

public record LocalStorageValue<T> : StorageValue<T>;
public record SessionStorageValue<T> :
    StorageValue<T>;