using Presentation;
using View;

namespace DemoDescriptionPresenter
{
    public class DemoDescriptionPresenter : IDemoDescriptionPresenter
    {
        private readonly IDemoDescriptionView _demoDescriptionView;

        public DemoDescriptionPresenter(IDemoDescriptionView demoDescriptionView)
        {
            _demoDescriptionView = demoDescriptionView;
        }

        public void Run()
        {
            _demoDescriptionView.Show();
        }

        public void SetDescriptor(object descriptor)
        {
            _demoDescriptionView.SetDescriptor(descriptor);
        }
    }
}
