using System.Text.Json;
using Microsoft.JSInterop;

namespace Chapter_5_Managing_Application_State.Client.Recipe05;

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
}