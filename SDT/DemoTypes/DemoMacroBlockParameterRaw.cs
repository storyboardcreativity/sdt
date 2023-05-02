namespace DemoTypes
{
    /// <summary>
    /// ������������ �������� ���������� ����� Quake1-based �����.
    /// </summary>
    public struct DemoMacroBlockParameterRaw
    {
        /// <summary>
        /// ��� ���������.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// �������� ���������.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ���������, � ������� ��������� ��������.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// ������-��������� ���������.
        /// </summary>
        public object Object { get; set; }
    }
}