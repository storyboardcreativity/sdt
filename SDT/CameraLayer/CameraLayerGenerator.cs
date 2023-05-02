namespace CameraLayer
{
    public static class CameraLayerGenerator
    {
        public static CameraLayer CreateLayer()
        {
            var layer = new CameraLayer();
            layer.Editor = new CameraLayerEditor(layer);
            return layer;
        }
    }
}
