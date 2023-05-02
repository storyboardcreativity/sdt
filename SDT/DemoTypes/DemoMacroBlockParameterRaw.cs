namespace DemoTypes
{
    /// <summary>
    /// Динамический параметр макроблока любой Quake1-based демки.
    /// </summary>
    public struct DemoMacroBlockParameterRaw
    {
        /// <summary>
        /// Тип параметра.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название параметра.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Категория, к которой относится параметр.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Объект-описатель параметра.
        /// </summary>
        public object Object { get; set; }
    }
}