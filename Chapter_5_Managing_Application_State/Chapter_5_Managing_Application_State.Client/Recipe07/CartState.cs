namespace Chapter_5_Managing_Application_State.Client.Recipe07;

public sealed class CartState
{
    public DateTime UpdateTime { get; set; }
    public void Add() => UpdateTime = DateTime.UtcNow;
}