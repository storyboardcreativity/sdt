using System.Collections.ObjectModel;
using System.ComponentModel;
using DemoModel.Interfaces;

namespace ConsoleCommandLayer
{
    public class ConsoleCommandsLayer : IDemoLayer
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ConsoleCommandsLayer()
        {
            Commands = new BindingList<ConsoleCommand>();
        }

        /// <summary>
        /// Список консольных команд.
        /// </summary>
        public Collection<ConsoleCommand> Commands { get; }

        #region IDemoLayer Realization

        public IDemoLayerEditor Editor { get; set; }

        #endregion
    }
}
