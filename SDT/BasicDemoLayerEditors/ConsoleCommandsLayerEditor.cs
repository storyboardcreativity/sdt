using DemoModel.Interfaces;

namespace ConsoleCommandLayer
{
    public class ConsoleCommandsLayerEditor : IDemoLayerEditor
    {
        private readonly ConsoleCommandsLayer _layer;

        public ConsoleCommandsLayerEditor(ConsoleCommandsLayer layer)
        {
            _layer = layer;
        }

        public void Show()
        {
            var form = new ConsoleCommandsLayerEditorForm(_layer);
            form.Show();
        }
    }
}