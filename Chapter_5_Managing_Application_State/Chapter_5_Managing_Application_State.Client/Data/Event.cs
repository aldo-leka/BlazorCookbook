namespace Chapter_5_Managing_Application_State.Client.Data;

public sealed record Event
{
    public Guid Id { get; init; }

    public int Capacity { get; private set; }

    public IList<Ticket> Tickets { get; init; }

    public Event()
    {
        Id = Guid.NewGuid();

        var randomizer = new Random();
        Capacity = randomizer.Next(1, 100);

        var tickets = new List<Ticket>()
        {
            new(Api.StableTicketId)
        };

        for (int i = 0; i < 4; i++)
            tickets.Add(new());

        Tickets = tickets;
    }

    public Event(Guid id) : this()
    {
        Id = id;
    }

    public bool IsSoldOut
        => Capacity == 0;

    public void Sell()
        => Capacity--;
}