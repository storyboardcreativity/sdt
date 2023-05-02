namespace DemoTypes.DemoTimelineConversion
{
    public class DemoTimelineConversionNodeKeyFrame
    {
        /// <summary>
        /// Описатель кейфрейма.
        /// </summary>
        public object Descriptor { get; set; }

        /// <summary>
        /// Время возникновения события.
        /// </summary>
        public float Timestamp { get; set; }

        /// <summary>
        /// Длительность события (по умолчанию - 0).
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// Номер кадра события.
        /// </summary>
        public uint Frame { get; set; }
    }
}