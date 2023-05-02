using System.Collections.Generic;

namespace DemoTypes
{
    /// <summary>
    /// Отдельная директория любой Quake1-based демки.
    /// </summary>
    public class DemoDirectoryRaw
    {
        /// <summary>
        /// Название директории.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Флаги-параметры директории.
        /// </summary>
        public uint Flags { get; set; }

        /// <summary>
        /// Номер CD-трека для воспроизведения.
        /// </summary>
        public int CdTrack { get; set; }

        /// <summary>
        /// Длительность директории.
        /// </summary>
        public float Time { get; set; }

        /// <summary>
        /// Количество кадров в директории.
        /// </summary>
        public uint FrameCount { get; set; }

        /// <summary>
        /// Макроблоки директории со всем содержимым.
        /// </summary>
        public List<DemoMacroBlockRaw> MacroBlocks { get; set; }
    }
}