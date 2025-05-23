namespace Chapter_1_Working_with_Component_Based_Architecture.Client.Recipe06;

public class Cart(Action onStateHasChanged)
{
    public List<string> Content { get; init; } = [];
    public decimal Value { get; private set; }
    public int Volume => Content.Count;
    public void Add(string tariff, decimal price)
    {
        Content.Add(tariff);
        Value += price;
        onStateHasChanged.Invoke();
    }
}