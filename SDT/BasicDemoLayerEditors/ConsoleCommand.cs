using System.ComponentModel;
using System.Runtime.CompilerServices;
using DemoModel.Annotations;

namespace ConsoleCommandLayer
{
    public class ConsoleCommand : INotifyPropertyChanged
    {
        /// <summary>
        /// Точное время исполнения команды.
        /// </summary>
        [DisplayName(@"Время исполнения (с.)")]
        public double Timestamp
        {
            get { return _timestamp; }
            set
            {
                _timestamp = value;
                OnPropertyChanged(nameof(Timestamp));
            }
        }
        private double _timestamp;

        /// <summary>
        /// Значение команды.
        /// </summary>
        [DisplayName(@"Команда клиенту")]
        public string Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged(nameof(Command));
            }
        }
        private string _command;

        #region INotifyPropertyChanged Realization

        /// <summary>
        /// Событие об изменении объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Возбудитель события об изменении объекта.
        /// </summary>
        /// <param name="propertyName">Название изменённого свойства.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}