using DemoModel;

namespace Presentation
{
    public interface IDemoTreePresenter : IPresenter
    {
        void SetDemoTree(DemoUniversalModel demo);
    }
}
