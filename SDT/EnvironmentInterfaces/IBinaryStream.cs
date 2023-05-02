using System;

namespace EnvironmentInterfaces
{
    /// <summary>
    /// Интерфейс любого конечного потока с информацией, предоставляющего возможность чтения из него.
    /// </summary>
    public interface IBinaryStream
    {
        /// <summary>
        /// Смещается по потоку от текущей позиции на size байт.
        /// </summary>
        /// <param name="size">Знаковое смещение в байтах</param>
        void Seek(Int64 size);

        /// <summary>
        /// Смещается по потоку от позиции offset на size байт.
        /// </summary>
        /// <param name="offset">Беззнаковое смещение в байтах, с которого будет производиться отсчёт</param>
        /// <param name="size">Знаковое смещение в байтах</param>
        void Seek(UInt64 offset, Int64 size);

        /// <summary>
        /// Возвращает текущее беззнаковое смещение от начала потока.
        /// </summary>
        /// <returns>Беззнаковое смещение от начала потока в байтах</returns>
        UInt64 Position();

        /// <summary>
        /// Возвращает длину всего текущего потока.
        /// </summary>
        /// <returns>Беззнаковый размер текущего потока в байтах</returns>
        UInt64 Length();

        /// <summary>
        /// Читает из потока 1 байт (беззнаковый) со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное беззнаковое значение</returns>
        byte ReadByte();

        /// <summary>
        /// Читает из потока 1 байт (знаковый) со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное знаковое значение</returns>
        sbyte ReadSByte();

        /// <summary>
        /// Читает из потока 2 байта в виде беззнакового числа со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное беззнаковое значение</returns>
        ushort ReadUInt16();

        /// <summary>
        /// Читает из потока 2 байта в виде знакового числа со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное знаковое значение</returns>
        short ReadInt16();

        /// <summary>
        /// Читает из потока 4 байта в виде беззнакового числа со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное беззнаковое значение</returns>
        uint ReadUInt32();

        /// <summary>
        /// Читает из потока 4 байта в виде знакового числа со смещением каретки.
        /// </summary>
        /// <returns>Прочитанное знаковое значение</returns>
        int ReadInt32();

        /// <summary>
        /// Читает из потока 4 байта со смещением каретки и преобразует их в число с плавающей запятой (IEEE-754).
        /// </summary>
        /// <returns>Прочитанное и преобразованное число с плавающей запятой одинарной точности</returns>
        float ReadFloat();

        /// <summary>
        /// Читает из потока length байт со смещением каретки.
        /// </summary>
        /// <param name="length">Беззнаковое целое число байт, которые следует прочитать</param>
        /// <returns>Массив прочитанных байтов</returns>
        byte[] ReadBytes(uint length);

        /// <summary>
        /// Остановка работы потока.
        /// </summary>
        void Close();
    }
}
