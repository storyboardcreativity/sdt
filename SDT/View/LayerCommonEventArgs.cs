using System.Drawing;

namespace View
{
    public class LayerCommonEventArgs
    {
        /// <summary>
        /// Название слоя.
        /// </summary>
        public string LayerName { get; set; }

        /// <summary>
        /// Цвет слоя.
        /// </summary>
        public Color LayerColor { get; set; }
    }
}