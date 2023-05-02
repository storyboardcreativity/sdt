using System.Collections.Generic;

namespace DemoTypes.DemoTimelineConversion
{
    public class DemoTimelineConversion
    {
        /// <summary>
        /// Время старта демки.
        /// </summary>
        public float StartTime { get; set; }

        /// <summary>
        /// Длительность демки.
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// Число кадров в демке.
        /// </summary>
        public uint FrameCount { get; set; }

        /// <summary>
        /// Список слоёв демки.
        /// </summary>
        public List<DemoTimelineConversionLayer> Layers { get; set; }
    }
}
