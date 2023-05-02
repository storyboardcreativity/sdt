using System.Collections.Generic;

namespace DemoTypes.DemoTimelineConversion
{
    public class DemoTimelineConversionLayer
    {
        /// <summary>
        /// Название слоя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список событий слоя.
        /// </summary>
        public List<DemoTimelineConversionNodeKeyFrame> Events { get; set; }

        /// <summary>
        /// Список дочерних слоёв.
        /// </summary>
        public List<DemoTimelineConversionLayer> Children { get; set; }
    }
}