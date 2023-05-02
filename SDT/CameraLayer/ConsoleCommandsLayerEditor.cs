using DemoModel.Interfaces;

namespace CameraLayer
{
    public class CameraLayerEditor : IDemoLayerEditor
    {
        private readonly CameraLayer _layer;

        public CameraLayerEditor(CameraLayer layer)
        {
            _layer = layer;
        }

        public void Show()
        {
            var form = new CameraLayerEditorForm(_layer);
            form.Show();
        }
    }
}