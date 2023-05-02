using System.Windows.Forms;
using DemoModel;

namespace ConsoleCommandLayer
{
    public partial class ConsoleCommandsLayerEditorForm : Form
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ConsoleCommandsLayerEditorForm(ConsoleCommandsLayer layer)
        {
            InitializeComponent();
            consoleCommandBindingSource.DataSource = layer.Commands;
        }

        private void OkButton_OnClick(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
