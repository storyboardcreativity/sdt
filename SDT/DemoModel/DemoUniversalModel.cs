using System.Collections.ObjectModel;
using System.ComponentModel;
using DemoModel.Interfaces;

namespace DemoModel
{
    /// <summary>
    /// Интерфейс модели любой демки в памяти.
    /// </summary>
    public class DemoUniversalModel
    {
        /// <summary>
        /// Слои демки.
        /// </summary>
        public Collection<IDemoLayer> Layers { get; }

        public DemoUniversalModel()
        {
            Layers = new BindingList<IDemoLayer>();
        }
    }
}