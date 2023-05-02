using System.Collections.Generic;

namespace DemoTypes
{
    /// <summary>
    /// Макроблок любой Quake1-based демки.
    /// </summary>
    public class DemoMacroBlockRaw
    {
        /// <summary>
        /// Тип макроблока.
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// Точное время макроблока.
        /// </summary>
        public float Timestamp { get; set; }

        /// <summary>
        /// Номер кадра макроблока.
        /// </summary>
        public uint FrameNumber { get; set; }

        /// <summary>
        /// Динамическая область макроблока.
        /// </summary>
        public List<DemoMacroBlockParameterRaw> DynamicData { get; set; }
    }
}