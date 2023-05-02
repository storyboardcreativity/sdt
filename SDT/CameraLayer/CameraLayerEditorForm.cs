using System.Windows.Forms;
using Renderer;
using Renderer.VectorLib;
using VectorLib;

namespace CameraLayer
{
    public partial class CameraLayerEditorForm : Form
    {
        private readonly CameraLayer _layer;

        public CameraLayerEditorForm(CameraLayer layer)
        {
            InitializeComponent();
            _layer = layer;

            var lineStrip = new LineStrip();

            foreach (var cameraEvent in layer.Events)
            {
                var position = cameraEvent.Position;
                lineStrip.Vertex.Add(new Point3D(position.X, position.Z, position.Y));
            }

            _sceneView.ObjectsToDraw.Add(lineStrip);
        }
    }
}
