using System;
using BasicDemoLayerEditors;
using DemoModel;
using DemoModel.Interfaces;

namespace DemoLayerFactory
{
    public static class DemoLayerFactory
    {
        public enum LayerType
        {
            ConsoleCommands
        }

        public static IDemoLayer GenerateLayer(LayerType typeToCreate)
        {
            switch (typeToCreate)
            {
                case LayerType.ConsoleCommands:
                    var layer = new ConsoleCommandsLayer();
                    layer.Editor = new ConsoleCommandsLayerEditor(layer);
                    break;
            }
            throw new ArgumentOutOfRangeException(nameof(typeToCreate), typeToCreate, null);
        }
    }
}
