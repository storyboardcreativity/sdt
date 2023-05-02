using System.Collections.Generic;

namespace DemoTypes
{
    /// <summary>
    /// Базовый класс любой Quake1-based демки (в сыром виде).
    /// </summary>
    public class DemoRaw
    {
        /// <summary>
        /// Магическая строка-идентификатор демки (для HL, к примеру, "HLDEMO").
        /// </summary>
        public string Magic { get; set; }

        /// <summary>
        /// Протокол демки.
        /// </summary>
        public uint DemoProtocol { get; set; }

        /// <summary>
        /// Сетевой протокол, пакеты стандарта которого лежат в этой демке.
        /// </summary>
        public uint NetworkProtocol { get; set; }

        /// <summary>
        /// Название первой карты из всех, на которых происходит действие.
        /// Важно отметить, что демка может содержать более, чем одну игру (действие может быть на разных картах).
        /// </summary>
        public string MapName { get; set; }

        /// <summary>
        /// Название директории мода, поддержка которого необходима для декодирования информации из демки.
        /// </summary>
        public string GameFolder { get; set; }

        /// <summary>
        /// Контрольная сумма файла карты.
        /// </summary>
        public uint MapChecksum { get; set; }

        /// <summary>
        /// Директории демки со всем содержимым.
        /// </summary>
        public List<DemoDirectoryRaw> Directories { get; set; }
    }
}
