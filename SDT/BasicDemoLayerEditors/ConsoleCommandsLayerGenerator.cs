namespace ConsoleCommandLayer
{
    public static class ConsoleCommandsLayerGenerator
    {
        public static ConsoleCommandsLayer CreateLayer()
        {
            var layer = new ConsoleCommandsLayer();
            layer.Editor = new ConsoleCommandsLayerEditor(layer);
            return layer;
        }
    }
}
