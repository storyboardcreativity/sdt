using System;

namespace View
{
    public interface ISaturatedDemoToolsView : IView
    {
        event Action<string> EventFileOpen;
        event Action<string> EventFileSave;
    }
}
