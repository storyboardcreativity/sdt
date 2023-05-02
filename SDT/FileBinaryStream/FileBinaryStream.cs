using System.IO;
using EnvironmentInterfaces;

namespace FileBinaryStream
{
    public class FileBinaryStream : IBinaryStream
    {
        /// <summary>
        /// Поток чтения из файла
        /// </summary>
        private readonly FileStream _fileStream;

        /// <summary>
        /// Бинарное чтение поверх потока _fileStream
        /// </summary>
        private readonly BinaryReader _fileReader;

        public FileBinaryStream(string fileName)
        {
            _fileStream = new FileStream(fileName, FileMode.Open);
            _fileReader = new BinaryReader(_fileStream);
        }

        public void Seek(long size) => _fileStream.Seek(size, SeekOrigin.Current);
        public void Seek(ulong offset, long size) => _fileStream.Seek((long)(offset + (ulong)size), SeekOrigin.Begin);

        public ulong Position() => (ulong)_fileStream.Position;
        public ulong Length() => (ulong)_fileStream.Length;

        public byte ReadByte() => _fileReader.ReadByte();
        public sbyte ReadSByte() => _fileReader.ReadSByte();
        public ushort ReadUInt16() => _fileReader.ReadUInt16();
        public short ReadInt16() => _fileReader.ReadInt16();
        public uint ReadUInt32() => _fileReader.ReadUInt32();
        public int ReadInt32() => _fileReader.ReadInt32();
        public float ReadFloat() => _fileReader.ReadSingle();
        public byte[] ReadBytes(uint length) => _fileReader.ReadBytes((int)length);
        public void Close()
        {
            _fileStream.Close();
        }
    }
}
