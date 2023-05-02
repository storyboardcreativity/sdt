using System.ComponentModel;
using System.Runtime.CompilerServices;
using DemoModel.Annotations;

namespace CameraLayer
{
    public class CameraEvent : INotifyPropertyChanged
    {
        /// <summary>
        /// Точное время исполнения команды.
        /// </summary>
        [DisplayName(@"Время кадра (с.)")]
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
        /// Положение камеры.
        /// </summary>
        [DisplayName(@"Положение камеры")]
        public Vector3D Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        private Vector3D _position;

        /// <summary>
        /// Углы поворота камеры.
        /// </summary>
        [DisplayName(@"Углы поворота камеры")]
        public Vector3D Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
                OnPropertyChanged(nameof(Rotation));
            }
        }
        private Vector3D _rotation;

        /// <summary>
        /// Угол обзора камеры.
        /// </summary>
        [DisplayName(@"Угол обзора камеры")]
        public float Fov
        {
            get { return _fov; }
            set
            {
                _fov = value;
                OnPropertyChanged(nameof(Fov));
            }
        }
        private float _fov;

        #region INotifyPropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}