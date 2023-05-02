using System.Windows.Forms;
using View;

namespace DemoTree
{
    public sealed partial class DemoTree : UserControl, IDemoTreeView
    {
        public DemoTree()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        public void AddNodeToRoot(string nodeName)
        {
            _tree.Nodes.Add(new TreeNode(nodeName));
        }
    }
}
