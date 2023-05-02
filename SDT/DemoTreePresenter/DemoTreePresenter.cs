using DemoModel;
using Presentation;
using View;

namespace DemoTreePresenter
{
    public class DemoTreePresenter : IDemoTreePresenter
    {
        public DemoTreePresenter(IDemoTreeView view)
        {
            _view = view;
        }

        private readonly IDemoTreeView _view;
        public void Run()
        {
            _view.Show();
        }

        public void SetDemoTree(DemoUniversalModel demo)
        {
            //throw new System.NotImplementedException();
        }
    }
}
