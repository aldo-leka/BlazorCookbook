namespace Chapter_2_Synchronous_and_Asynchronous_Data_Binding.Client.Data;

public sealed class SuggestionsApi
{
    private const StringComparison _comparer
        = StringComparison.InvariantCultureIgnoreCase;

    private readonly DataSeed _data = new();

    public async Task<IList<string>> FindAsync(string phrase)
    {
        //fake delay
        await Task.Delay(300);

        return _data
            .Names
            .Where(it => it.StartsWith(phrase, _comparer))
            .Take(5)
            .ToList();
    }
}