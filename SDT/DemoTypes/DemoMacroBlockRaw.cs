using System.Collections.Generic;

namespace DemoTypes
{
    /// <summary>
    /// ��������� ����� Quake1-based �����.
    /// </summary>
    public class DemoMacroBlockRaw
    {
        /// <summary>
        /// ��� ����������.
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// ������ ����� ����������.
        /// </summary>
        public float Timestamp { get; set; }

        /// <summary>
        /// ����� ����� ����������.
        /// </summary>
        public uint FrameNumber { get; set; }

        /// <summary>
        /// ������������ ������� ����������.
        /// </summary>
        public List<DemoMacroBlockParameterRaw> DynamicData { get; set; }
    }
}