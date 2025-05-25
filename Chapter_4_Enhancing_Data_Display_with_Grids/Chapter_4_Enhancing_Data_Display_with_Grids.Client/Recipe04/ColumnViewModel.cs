using Microsoft.AspNetCore.Components;

namespace Chapter_4_Enhancing_Data_Display_with_Grids.Client.Recipe04;

public class ColumnViewModel<T>
{
    public string Label { get; init; }
    public RenderFragment<T> Template { get; init; }
    public Func<T, object> Property { get; init; }
}