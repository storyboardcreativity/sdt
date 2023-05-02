using MainControl;
using View;

namespace SaturatedDemoToolsControlFactory
{
    public static class SaturatedDemoToolsControlFactory
    {
        public static ISaturatedDemoToolsView CreateControl(IDemoTimelineView demoTimelineView, IDemoTreeView demoTreeView, IDemoDescriptionView demoDescriptionView)
        {
            return new SaturatedDemoToolsControl(demoTimelineView, demoTreeView, demoDescriptionView);
        }
    }
}
