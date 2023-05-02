using System.Collections.Generic;
using System.Drawing;
using DemoModel.Interfaces;

namespace Timeline
{
    /// <summary>
    /// Слой на таймлайне.
    /// </summary>
    public class TimelineLayer
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public TimelineLayer(IDemoLayer demoLayer, string name, Color color)
        {
            ModelLayer = demoLayer;
            Name = name;
            Color = color;
            Children = new List<TimelineLayer>();
        }

        /// <summary>
        /// Модель слоя, привязанная к этому его изображению.
        /// </summary>
        public IDemoLayer ModelLayer { get; }

        /// <summary>
        /// Название слоя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цвет слоя.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Дочерние слои.
        /// </summary>
        public List<TimelineLayer> Children { get; }
    }
}