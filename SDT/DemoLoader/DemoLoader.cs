using System;
using DemoLoader.Loaders;
using DemoModel;

namespace DemoLoader
{
    /// <summary>
    /// Загрузчик демо-файлов
    /// </summary>
    public static class DemoLoader
    {
        public static DemoUniversalModel LoadDemo(string fileName)
        {
            var file = BinaryStreamFactory.BinaryStreamFactory.CreateStream(fileName);
            string magic = System.Text.Encoding.UTF8.GetString(file.ReadBytes(8)).TrimEnd('\0');
            file.Seek(0, 0);

            DemoUniversalModel demoUniversal;
            switch (magic)
            {
                case "HLDEMO":
                    demoUniversal = HalfLifeDemoLoader.LoadDemo(file);
                    break;

                default:
                    throw new Exception($"Нет подходящей реализации для magic = {magic}");
            }
            file.Close();
            return demoUniversal;
        }
    }
}
