using System.Collections.Generic;

namespace Timeline
{
    /// <summary>
    /// Объект на слое.
    /// </summary>
    public class TimelineObject
    {
        /// <summary>
        /// Время начала.
        /// </summary>
        public float StartTime { get; set; }

        /// <summary>
        /// Длительность.
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// Описатель объекта на слое.
        /// </summary>
        public object ConnectedObject { get; set; }

        /// <summary>
        /// Ключевые кадры.
        /// </summary>
        public List<object> Keys { get; set; }
    }
}