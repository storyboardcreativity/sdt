using System;
using System.Collections.Generic;
using CameraLayer;
using ConsoleCommandLayer;
using DemoModel;
using EnvironmentInterfaces;

namespace DemoLoader.Loaders
{
    public static class HalfLifeDemoLoader
    {

        public enum DemoServerMessageTypes
        {
            svc_bad = 0,
            svc_nop = 1,
            svc_disconnect = 2
        }

        public static DemoUniversalModel LoadDemo(IBinaryStream stream)
        {
            // Считаем магию
            string magic = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(8)).TrimEnd('\0');

            // Проверим магию на правильность
            if(magic != "HLDEMO")
                throw new Exception($"Данный тип нельзя читать в этом модуле (magic = \"{magic}\" вместо \"HLDEMO\")");

            // Создадим модель демки
            var demoUniversalModel = new DemoUniversalModel();

            // Создадим слои
            var consoleCommandsLayer = ConsoleCommandsLayerGenerator.CreateLayer();
            var cameraLayer = CameraLayerGenerator.CreateLayer();

            demoUniversalModel.Layers.Add(consoleCommandsLayer);
            demoUniversalModel.Layers.Add(cameraLayer);

            // Считаем базовые данные
            var demoProtocol = stream.ReadUInt32();
            var networkProtocol = stream.ReadUInt32();
            var mapName = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(260)).TrimEnd('\0');
            var gameFolder = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(260)).TrimEnd('\0');
            var mapChecksum = stream.ReadUInt32();
            //var directories = new List<DemoDirectoryRaw>();

            // Получим смещение до таблицы директорий
            var directoryEntriesOffset = stream.ReadUInt32();
            
            // === Чтение записей директорий ============================================================

            // Переходим к таблице директорий
            stream.Seek(directoryEntriesOffset, 0);

            // Читаем количество директорий
            uint directoryEntriesCount = stream.ReadUInt32();

            // Считываем информацию о директориях
            var directoriesLayout = new List<KeyValuePair<uint, uint>>();  // <offset, size>
            for (uint i = 0; i < directoryEntriesCount; ++i)
            {
                if (stream.ReadUInt32() != i)
                    throw new Exception("Порядковый номер директории в таблице директорий не соответствует номеру записи");

                // Читаем базовую информацию о директории
                var titile = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(64)).TrimEnd('\0');
                var flags = stream.ReadUInt32();
                var cdTrack = stream.ReadUInt32();
                var time = stream.ReadFloat();
                var frameCount = stream.ReadUInt32();
                /*
                var directory = new DemoDirectoryRaw
                {
                    Title = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(64)).TrimEnd('\0'),
                    Flags = stream.ReadUInt32(),
                    CdTrack = stream.ReadInt32(),
                    Time = stream.ReadFloat(),
                    FrameCount = stream.ReadUInt32(),
                    MacroBlocks = new List<DemoMacroBlockRaw>()
                };
                */
                // Читаем длину и размер
                directoriesLayout.Add(new KeyValuePair<uint, uint>(stream.ReadUInt32(), stream.ReadUInt32()));

                // Добавляем директорию
                //directories.Add(directory);
            }

            // === Чтение самих директорий ==============================================================
            for (uint i = 0; i < directoryEntriesCount; ++i)
            {
                // Смещаемся к данным директории
                stream.Seek(directoriesLayout[(int)i].Key, 0);

                // === Читаем макроблоки директории ====================================================
                while (stream.Position() < (directoriesLayout[(int)i].Key + directoriesLayout[(int)i].Value))
                {
                    // Считываем заголовочную часть макроблока
                    var macroType = stream.ReadByte();
                    var timestamp = stream.ReadFloat();
                    var frameNumber = stream.ReadUInt32();
                    /*var macroBlock = new DemoMacroBlockRaw
                    {
                        Type = stream.ReadByte(),
                        Timestamp = stream.ReadFloat(),
                        FrameNumber = stream.ReadUInt32(),
                        DynamicData = new List<DemoMacroBlockParameterRaw>()
                    };*/

                    switch (macroType)
                    {
                        // === GameData блок =================================================================================
                        case 0:
                        case 1:
                            if (networkProtocol <= 43)
                            {
                                // TODO: понять, что за UnkData1 -> разобрать 560 байт
                                var smth = stream.ReadBytes(560);
                                /*
                                macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "List<byte>", Name = "Блок данных (560 байт)", Category = "Нераспознанные блоки",
                                    Object = stream.ReadBytes(560)
                                });
                                */
                            }
                            else
                            {
                                // Info: из реверса hw.dll -> получено примерное строение заголовка:

                                /*
                                === GameDataMacroBlockInfo ===
                                char unkBuff[236];
                                char specUnkBlock0[52];
                                char specUnkBlock1[132];

                                DWORD u0;
                                DWORD u1;
                                DWORD u2;
                                DWORD u3;

                                === GameDataSequenceInfo ===
                                DWORD u4;
                                DWORD u5;
                                DWORD u6;
                                DWORD u7;
                                DWORD u8;
                                DWORD u9;
                                DWORD u10;
                                */

                                // === GameDataMacroBlockInfo ===
                                // TODO: Разобраться, что значат эти поля
                                // ====================================================================================================
                                stream.ReadBytes(220);
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "List<byte>", Name = "Неизвестный блок данных", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadBytes(220)
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Ширина окна записи в пикселях (предположительно)", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Высота окна записи в пикселях (предположительно)", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadBytes(8);
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "List<byte>", Name = "Неизвестный блок данных", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadBytes(8)
                                });*/

                                stream.ReadBytes(52);
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "List<byte>", Name = "Неизвестный блок данных", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadBytes(52)
                                });*/

                                stream.ReadBytes(132);
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "List<byte>", Name = "Неизвестный блок данных", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadBytes(132)
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataMacroBlockInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                // === GameDataSequenceInfo ===
                                // TODO: Разобраться, что значат эти поля
                                // ====================================================================================================
                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/

                                stream.ReadUInt32();
                                /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                {
                                    Type = "uint", Name = "Неизвестный DWORD", Category = "GameDataSequenceInfo",
                                    Object = stream.ReadUInt32()
                                });*/
                            }

                            // Читаем объем блока сообщений, следующих далее
                            var messageBlockLength = stream.ReadUInt32();

                            // TODO: добавить чтение сообщений
                            var msgType = stream.ReadByte();
                            switch ((DemoServerMessageTypes)msgType)
                            {
                                case DemoServerMessageTypes.svc_bad:            // 0x00
                                    throw new Exception("Caught svc_bad!");

                                case DemoServerMessageTypes.svc_nop:            // 0x01
                                    break;

                                case DemoServerMessageTypes.svc_disconnect:     // 0x02
                                    throw new Exception("Caught svc_disconnect!");
                            }
                            stream.Seek(-1);
                            stream.Seek((int)messageBlockLength);

                            break;

                        // === Неизвестный блок 02 - пропускаем ==============================================================
                        // Info: из реверса hw.dll -> блок 02 зарезервирован и просто пропускается
                        // Info 2: из реверса hw.dll -> при получении этого блока производится какая-то шняга. Надо прочекать.
                        // Info 3: из реверса hw.dll -> при получении этого блока производится установка фиксированного времени на текущее Scaled. И еще что-то. Надо прочекать.
                        case 2:
                            break;
                            
                        // === Client Command - команда клиента ==============================================================
                        // Info: из реверса hw.dll -> строка, полученная этим способом, идёт в Cbuf_AddText() (См. исходники Quake 1 - там всё аналогично)
                        case 3:
                            consoleCommandsLayer.Commands.Add(new ConsoleCommand
                            {
                                Command = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(64)).TrimEnd('\0'),
                                Timestamp = timestamp
                            });
                            break;

                        // === Неизвестный блок 04, имеющий строку - пропускаем ==============================================
                        // Info: из реверса hw.dll -> при получении этого макро-блока выполняется команда HUD_UpdateClientData(...) при её наличии.
                        // 32 байта данных - структура client_data_t.
                        /*

                        Из Half-Life SDK:
                            Структура client_data_t:

                                vec3_t origin;          // Положение
                                vec3_t viewangles;      // Углы поворота (камеры?)

                                (vec3_t - это float[3])

                                int    iWeaponBits;     // Флаги оружия
                                float  fov;             // Угол обзора

                        */
                        case 4:
                            var camEvent = new CameraEvent
                            {
                                Position = new Vector3D(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat()),
                                Rotation = new Vector3D(stream.ReadFloat(), stream.ReadFloat(), stream.ReadFloat())
                            };
                            //var posX = stream.ReadFloat();
                            //var posY = stream.ReadFloat();
                            //var posZ = stream.ReadFloat();
                            /*
                            macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "Coordinate3D",
                                Name = "Новое положение камеры",
                                Category = "Обновление состояния клиента",
                                Object = new Coordinate3D
                                {
                                    X = stream.ReadFloat(),
                                    Y = stream.ReadFloat(),
                                    Z = stream.ReadFloat()
                                }
                            });*/

                            //var rotX = stream.ReadFloat();
                            //var rotY = stream.ReadFloat();
                            //var rotZ = stream.ReadFloat();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "Coordinate3D",
                                Name = "Новое направление взгляда камеры (или углы поворота)",
                                Category = "Обновление состояния клиента",
                                Object = new Coordinate3D
                                {
                                    X = stream.ReadFloat(),
                                    Y = stream.ReadFloat(),
                                    Z = stream.ReadFloat()
                                }
                            });*/

                            var weaponFlags = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Флаги состояния оружия",
                                Category = "Обновление состояния клиента",
                                Object = stream.ReadUInt32()
                            });*/

                            camEvent.Fov = stream.ReadFloat();
                            //var fov = stream.ReadFloat();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Новый угол обзора камеры (FOV)",
                                Category = "Обновление состояния клиента",
                                Object = stream.ReadFloat()
                            });*/

                            cameraLayer.Events.Add(camEvent);
                            break;

                        // === Last In Segment - последний блок сегмента =====================================================
                        case 5:
                            break;

                        // === Неизвестный блок 06 - пропускаем ==============================================================
                        // TODO: Зареверсить движок HL и понять, что это за блок
                        case 6:
                            var a = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Неизвестный DWORD",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadUInt32()
                            });*/

                            var b = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Неизвестный DWORD",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadUInt32()
                            });*/

                            var c = stream.ReadFloat();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "float",
                                Name = "Неизвестный Float (дробное число)",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadFloat()
                            });*/

                            var d = stream.ReadBytes(72);
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "List<byte>",
                                Name = "Неизвестный блок данных",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadBytes(72)
                            });*/
                            break;

                        // === Неизвестный блок 07, имеющий два UInt32 - пропускаем ==========================================
                        // TODO: Зареверсить движок HL и понять, что это за блок
                        case 7:
                            var e = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Неизвестный DWORD",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadUInt32()
                            });*/

                            var f = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Неизвестный DWORD",
                                Category = "Нераспознанные блоки",
                                Object = stream.ReadUInt32()
                            });*/
                            break;

                        // === Play Sound - проиграть звук ===================================================================
                        /* Info: из реверса hw.dll -> найдена предположительная информация по строению данного макро-блока:

                        DWORD entchannel
                        DWORD name_length
                        char name[name_length]         (без '\0'!!!)
                        DWORD attenuation
                        DWORD volume
                        DWORD flags
                        DWORD pitch

                        */
                        case 8:
                            var channel = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Канал",
                                Category = "Информация о проигрываемом звуке",
                                Object = stream.ReadUInt32()
                            });*/

                            var soundName =
                                System.Text.Encoding.UTF8.GetString(stream.ReadBytes(stream.ReadUInt32())).TrimEnd('\0');
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "string",
                                Name = "Название звука",
                                Category = "Информация о проигрываемом звуке",
                                Object = System.Text.Encoding.UTF8.GetString(stream.ReadBytes(stream.ReadUInt32())).TrimEnd('\0')
                            });*/

                            var attenuation = stream.ReadFloat();
                            /*acroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "float",
                                Name = "Затухаемость звука",
                                Category = "Информация о проигрываемом звуке",
                                Object = stream.ReadFloat()
                            });*/

                            var volume = stream.ReadFloat();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "float",
                                Name = "Громкость звука",
                                Category = "Информация о проигрываемом звуке",
                                Object = stream.ReadFloat()
                            });*/

                            var parametersFlags = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Флаги параметров звука",
                                Category = "Информация о проигрываемом звуке",
                                Object = stream.ReadUInt32()
                            });*/

                            var pitch = stream.ReadUInt32();
                            /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                            {
                                Type = "uint",
                                Name = "Высота звука",
                                Category = "Информация о проигрываемом звуке",
                                Object = stream.ReadUInt32()
                            });*/
                            break;

                        // === Блок информации для client.dll ================================================================
                        // TODO: Зареверсить движок HL и понять, что это за блок
                        /*
                        ======================================================================
                        Info: из реверса hw.dll -> после чтения этого блока вызывается функция
                                Demo_ReadBuffer(uint size, unsigned char* buffer), где:
                                    size - размер прочитанного блока,
                                    buffer - буфер этого размера.

                        Примечание:
                            Функция Demo_ReadBuffer импортируется из client.dll в процессе работы.
                            Если эту функцию не удалось импортировать, буфер просто пропускается.

                        Примечание 2:
                            Полный исходник функции Demo_ReadBuffer можно найти в GoldSource SDK.
                        */
                        case 9:
                            // Читаем длину блока данных, следующих далее
                            var dataBlockLength = stream.ReadUInt32();

                            // Читаем тип блока данных
                            switch (stream.ReadInt32())
                            {
                                // TYPE_SNIPERDOT
                                case 0:
                                    var sniper = stream.ReadUInt32();
                                    /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                    {
                                        Type = "uint",
                                        Name = "Sniper (не ясно, что это)",
                                        Category = "Данные для client.dll движка (TYPE_SNIPERDOT)",
                                        Object = sniper
                                    });*/

                                    if (sniper != 0)
                                    {
                                        var sniperDamage = stream.ReadUInt32();
                                        /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                        {
                                            Type = "uint",
                                            Name = "SniperDamage (какой-то урон)",
                                            Category = "Данные для client.dll движка (TYPE_SNIPERDOT)",
                                            Object = stream.ReadUInt32()
                                        });*/

                                        var sniperAngleX = stream.ReadFloat();
                                        var sniperAngleY = stream.ReadFloat();
                                        var sniperAngleZ = stream.ReadFloat();
                                        /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                        {
                                            Type = "Coordinate3D",
                                            Name = "SniperAngle (направление взгляда снайпера)",
                                            Category = "Данные для client.dll движка (TYPE_SNIPERDOT)",
                                            Object = new Coordinate3D
                                            {
                                                X = stream.ReadFloat(),
                                                Y = stream.ReadFloat(),
                                                Z = stream.ReadFloat()
                                            }
                                        });*/

                                        var sniperOriginX = stream.ReadFloat();
                                        var sniperOriginY = stream.ReadFloat();
                                        var sniperOriginZ = stream.ReadFloat();
                                        /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                        {
                                            Type = "Coordinate3D",
                                            Name = "SniperOrigin (положение снайпера)",
                                            Category = "Данные для client.dll движка (TYPE_SNIPERDOT)",
                                            Object = new Coordinate3D
                                            {
                                                X = stream.ReadFloat(),
                                                Y = stream.ReadFloat(),
                                                Z = stream.ReadFloat()
                                            }
                                        });*/
                                    }
                                    break;

                                // TYPE_ZOOM
                                case 1:
                                    var zoom = stream.ReadFloat();
                                    /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                    {
                                        Type = "float",
                                        Name = "Новый уровень зума камеры клиента",
                                        Category = "Данные для client.dll движка (TYPE_ZOOM)",
                                        Object = stream.ReadFloat()
                                    });*/
                                    break;

                                // Если мы здесь, информация в блоке не относится к HL
                                default:
                                    // Возвращаемся к началу блока данных
                                    stream.Seek(-1);
                                    
                                    // Читаем неизвестный блок
                                    var blockData = stream.ReadBytes(dataBlockLength);
                                    /*macroBlock.DynamicData.Add(new DemoMacroBlockParameterRaw
                                    {
                                        Type = "List<byte>",
                                        Name = "Блок сырых данных",
                                        Category = "Данные для client.dll мода движка",
                                        Object = stream.ReadBytes(dataBlockLength)
                                    });*/
                                    break;
                            }
                            break;

                        // Если мы здесь, нужного обработчика не нашлось
                        default:
                            throw new Exception($"Не удалось найти обработчик для макроблока (Type = {macroType})");
                    }

                    //directories[(int)i].MacroBlocks.Add(macroBlock);
                }
            }

            // Вернём результат
            return demoUniversalModel;
        }
    }
}
