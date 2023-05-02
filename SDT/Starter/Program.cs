using System;
using System.Windows.Forms;
using DemoEditCore;
using MainControl;
using Presentation;
using Timeline;
using View;

namespace Starter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IDemoTreeView demoTreeView = new DemoTree.DemoTree();
            IDemoDescriptionView demoDescriptionView = new DescriptionControl.DescriptionControl();
            IDemoTimelineView demoTimelineView = new DemoTimeline();
            ISaturatedDemoToolsView saturatedDemoToolsView = new SaturatedDemoToolsControl(demoTimelineView, demoTreeView, demoDescriptionView);

            var form = new Form1();
            form.Controls.Add((Control)saturatedDemoToolsView);

            IDemoDescriptionPresenter demoDescriptionPresenter = new DemoDescriptionPresenter.DemoDescriptionPresenter(demoDescriptionView);
            IDemoTreePresenter demoTreePresenter = new DemoTreePresenter.DemoTreePresenter(demoTreeView);
            IDemoTimelinePresenter demoTimelinePresenter = new DemoTimelinePresenter.DemoTimelinePresenter(demoTimelineView);
            ISaturatedDemoToolsPresenter saturatedDemoToolsPresenter = new SaturatedDemoToolsPresenter(saturatedDemoToolsView, demoTimelinePresenter, demoDescriptionPresenter, demoTreePresenter);

            saturatedDemoToolsPresenter.Run();
            Application.Run(form);
        }
    }
}
