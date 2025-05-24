using Microsoft.AspNetCore.Components;

namespace Chapter_3_Taking_Control_of_Event_Handling.Client.Recipe06;

public class PreventedCopyEventArgs : EventArgs
{
    public DateTime Stamp { get; init; }
}

[EventHandler("onpreventcopy",
    typeof(PreventedCopyEventArgs))]
public static class EventHandlers { }