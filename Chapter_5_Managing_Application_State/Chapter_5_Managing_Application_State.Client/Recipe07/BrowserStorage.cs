using System.Text.Json;
using Microsoft.JSInterop;

namespace Chapter_5_Managing_Application_State.Client.Recipe07;

public class BrowserStorage
{
    private readonly IJSRuntime _js;
    public BrowserStorage(IJSRuntime js)
    {
        _js = js;
    }
    
    private const string
        _setFunc = "browserStorage.set",
        _local = "localStorage",
        _session = "sessionStorage";
    
    private const string _getFunc = "browserStorage.get";
    
    public ValueTask PersistAsync<T>(
        StorageValue<T> @object)
    {
        var json = JsonSerializer
            .Serialize(@object.Value);
        var storage = @object is LocalStorageValue<T>
            ? _local : _session;
        return _js.InvokeVoidAsync(_setFunc,
            storage, @object.Key, json);
    }
    
    public async ValueTask<T> ResolveAsync<T>(
        StorageValue<T> @object)
    {
        var storage = @object is LocalStorageValue<T>
            ? _local : _session;
        var value = await _js.InvokeAsync<string>(
            _getFunc, storage, @object.Key);
        return JsonSerializer.Deserialize<T>(value);
    }
}