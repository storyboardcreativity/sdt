using System.Collections.ObjectModel;
using System.ComponentModel;
using DemoModel.Interfaces;

namespace CameraLayer
{
    public class CameraLayer : IDemoLayer
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public CameraLayer()
        {
            Events = new BindingList<CameraEvent>();
        }

        /// <summary>
        /// Список событий камеры.
        /// </summary>
        public Collection<CameraEvent> Events { get; }

        public IDemoLayerEditor Editor { get; set; }
    }
}
