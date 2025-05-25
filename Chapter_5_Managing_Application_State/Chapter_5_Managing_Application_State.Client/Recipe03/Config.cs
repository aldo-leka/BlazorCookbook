using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Chapter_5_Managing_Application_State.Client.Recipe03;

internal static class Config
{
    public static readonly IComponentRenderMode
        PrerenderDisabled = new
            InteractiveWebAssemblyRenderMode(
                prerender: false);
}
