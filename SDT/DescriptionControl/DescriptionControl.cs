using System.Windows.Forms;
using View;

namespace DescriptionControl
{
    public partial class DescriptionControl : UserControl, IDemoDescriptionView
    {
        public DescriptionControl()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        public void SetDescriptor(object descriptor)
        {
            _propertyGrid.SelectedObject = descriptor;
        }
    }
}
