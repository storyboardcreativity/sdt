using System;
using DemoModel;

namespace Presentation
{
    public interface IDemoTimelinePresenter : IPresenter
    {
        void SetDemoTimeline(DemoUniversalModel demoModel);

        /// <summary>
        /// Событие об изменении выбранного объекта.
        /// </summary>
        event EventHandler<object> SelectionChanged;
    }
}