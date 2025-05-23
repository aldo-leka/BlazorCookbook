namespace Chapter_1_Working_with_Component_Based_Architecture.Client.Data;

public class TicketViewModel
{
    public Guid Id { get; init; }

    public string Tariff { get; init; }

    public string Price { get; init; }

    public int AvailableSeats { get; init; }

    public TicketViewModel(string tariff, decimal price, int availableSeats)
    {
        Id = Guid.NewGuid();
        Tariff = tariff;
        AvailableSeats = availableSeats;

        Price = price > 0 ?
            price.ToString("0.00 $")
            : string.Empty;
    }
}