using System;
using DemoModel;
using Presentation;
using View;

namespace DemoEditCore
{
    public class SaturatedDemoToolsPresenter : ISaturatedDemoToolsPresenter
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SaturatedDemoToolsPresenter(ISaturatedDemoToolsView view, IDemoTimelinePresenter demoTimelinePresenter, IDemoDescriptionPresenter demoDescriptionPresenter, IDemoTreePresenter demoTreePresenter)
        {
            _demoTimelinePresenter = demoTimelinePresenter;
            _demoDescriptionPresenter = demoDescriptionPresenter;
            _demoTreePresenter = demoTreePresenter;
            _view = view;

            view.EventFileOpen += ViewOnEventFileOpen;
            view.EventFileSave += ViewOnEventFileSave;

            _demoTimelinePresenter.SelectionChanged += OnEventSelectedSomething;
        }

        private void ViewOnEventFileSave(string fileName)
        {
            throw new NotImplementedException();
        }

        private void ViewOnEventFileOpen(string fileName)
        {
            _demo = DemoLoader.DemoLoader.LoadDemo(fileName);
            //_demoTreePresenter.SetDemoTree(_demo);
            _demoTimelinePresenter.SetDemoTimeline(_demo);
        }

        private void OnEventSelectedSomething(object sender, object descriptor)
        {
            _demoDescriptionPresenter.SetDescriptor(descriptor);
        }

        private ISaturatedDemoToolsView _view = null;
        private readonly IDemoTimelinePresenter _demoTimelinePresenter;
        private readonly IDemoDescriptionPresenter _demoDescriptionPresenter;
        private readonly IDemoTreePresenter _demoTreePresenter;
        private DemoUniversalModel _demo;
        public void Run()
        {
            _demoTimelinePresenter.Run();
            _demoDescriptionPresenter.Run();
            _demoTreePresenter.Run();

            _view.Show();
        }
    }
}
