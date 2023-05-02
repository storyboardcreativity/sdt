using EnvironmentInterfaces;

namespace BinaryStreamFactory
{
    public static class BinaryStreamFactory
    {
        public static IBinaryStream CreateStream(string fileName)
        {
            return new FileBinaryStream.FileBinaryStream(fileName);
        }
    }
}
