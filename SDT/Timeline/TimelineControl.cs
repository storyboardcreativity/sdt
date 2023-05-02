using System;
using System.Drawing;
using System.Windows.Forms;

namespace Timeline
{
    public partial class TimelineControl : UserControl
    {
        /// <summary>
        /// Модель древа слоёв.
        /// </summary>
        public LayerTreeModel Model { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TimelineControl()
        {
            InitializeComponent();

            _timelineDrawingRect.MouseWheel += OnMouseWheel;

            _timer.Tick += Timer_Tick;
            _timer.Interval = 30;
            _timer.Enabled = true;
            _timer.Start();
        }
        
        /// <summary>
        /// Обновляет вид таймлайна на экране, исходя из zoomPercent.
        /// </summary>
        private void RefreshViewZone()
        {
            // Доля таймлайна для отобраения
            float zoomModif = ZoomPercent / 100.0f;

            // Настроим границы отображения
            if (ObservingCursorPosition - (zoomModif * Length) / 2 < TimeMinBorder)
            {
                _currentMaxBorder = _currentMinBorder + zoomModif * Length;
                _currentMinBorder = TimeMinBorder;
            }
            else
            {
                _currentMinBorder = ObservingCursorPosition - (zoomModif * Length) / 2;
                if (ObservingCursorPosition + (zoomModif * Length) / 2 > TimeMaxBorder)
                {
                    _currentMaxBorder = TimeMaxBorder;
                    _currentMinBorder = _currentMaxBorder - zoomModif * Length;
                }
                else
                    _currentMaxBorder = ObservingCursorPosition + (zoomModif * Length) / 2;
            }

            // Потребуем перерисовать таймлайн
            _timelineDrawingRect?.Invalidate();
        }

        /// <summary>
        /// Преобразует положение времени в координату на области рисования.
        /// </summary>
        /// <param name="timeCoord">Временная координата.</param>
        /// <returns>Координата X.</returns>
        private float TimeToPixelCoord(float timeCoord)
        {
            // Отношение к ширине (доля)
            float offset = (timeCoord - _currentMinBorder) / (_currentMaxBorder - _currentMinBorder);

            // Возвращаем часть от Width (м.б. отрицательной)
            return offset * _timelineDrawingRect.Width;
        }

        /// <summary>
        /// Преобразует пиксель на области рисования в положение времени.
        /// </summary>
        /// <param name="pixelCoord">Координата X.</param>
        /// <returns>Временная координата.</returns>
        private float PixelToTimeCoord(float pixelCoord)
        {
            // Отношение к ширине (доля)
            float offset = pixelCoord / _timelineDrawingRect.Width;

            return _currentMinBorder + offset * (_currentMaxBorder - _currentMinBorder);
        }

        /// <summary>
        /// Перерисовка области каждый тик таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timelineDrawingRect.Invalidate();
        }
        private readonly Timer _timer = new Timer();

        

        /// <summary>
        /// 
        /// </summary>
        public float TimeMinBorder
        {
            get { return _timeMinBorder; }
            set
            {
                _timeMinBorder = value;
                RefreshViewZone();
            }
        }
        private float _timeMinBorder = 0.0f;
        
        /// <summary>
        /// 
        /// </summary>
        public float TimeMaxBorder
        {
            get { return _timeMaxBorder; }
            set
            {
                _timeMaxBorder = value;
                RefreshViewZone();
            }
        }
        private float _timeMaxBorder = 100.0f;

        /// <summary>
        /// 
        /// </summary>
        public float CursorPosition
        {
            get { return _cursorPosition; }
            set
            {
                if (value < TimeMinBorder || TimeMaxBorder < value)
                    throw new Exception("Невозможно установить курсор за пределы рабочей области.");
                _cursorPosition = value;
                RefreshViewZone();
            }
        }
        private float _cursorPosition = 50.0f;

        /// <summary>
        /// 
        /// </summary>
        public float MouseCursorPosition
        {
            get { return _mouseCursorPosition; }
            set
            {
                if (value < TimeMinBorder || TimeMaxBorder < value)
                    throw new Exception("Невозможно установить курсор за пределы рабочей области.");
                _mouseCursorPosition = value;
            }
        }
        private float _mouseCursorPosition = 50.0f;

        /// <summary>
        /// 
        /// </summary>
        public float ObservingCursorPosition
        {
            get { return _observingCursorPosition; }
            set
            {
                if (value < TimeMinBorder || TimeMaxBorder < value)
                    throw new Exception("Невозможно установить курсор за пределы рабочей области.");
                _observingCursorPosition = value;

                float pos = (value / Length) * ((float)_timelineScrollBar.Maximum - _timelineScrollBar.Minimum) -
                            _timelineScrollBar.LargeChange / 2.0f;
                _timelineScrollBar.Value = pos >= _timelineScrollBar.Minimum ? (int)pos : _timelineScrollBar.Minimum;
                RefreshViewZone();
            }
        }
        private float _observingCursorPosition = 50.0f;

        /// <summary>
        /// Доля (процентная) отображаемой шкалы от всей.
        /// </summary>
        public float ZoomPercent
        {
            get { return _zoomPercent; }
            set
            {
                if (value <= 0.0 || value > 100.0)
                    throw new Exception($"Невозможно установить отображаемую область больше, чем доступный промежуток времени. (value = {value})");
                _zoomPercent = value;
                _timelineScrollBar.LargeChange = (int)((_zoomPercent / 100.0f) * (_timelineScrollBar.Maximum - _timelineScrollBar.Minimum));
                RefreshViewZone();
            }
        }
        private float _zoomPercent = 100.0f;

        /// <summary>
        /// 
        /// </summary>
        public float Length => TimeMaxBorder - TimeMinBorder;

        /// <summary>
        /// Длина блока детализации в секундах.
        /// </summary>
        private float _timeBlockWidth = 10.0f;

        /// <summary>
        /// Ручка для рисования.
        /// </summary>
        Pen _pen = new Pen(Color.Black);

        /// <summary>
        /// Браш для рисования.
        /// </summary>
        Brush _brush = new SolidBrush(Color.Black);

        /// <summary>
        /// Шрифт.
        /// </summary>
        Font _font = new Font("Courier New", 8, FontStyle.Regular);
        
        /// <summary>
        /// Текущая левая граница по времени.
        /// </summary>
        private float _currentMinBorder = 0.0f;
        /// <summary>
        /// Текущая правая граница по времени.
        /// </summary>
        private float _currentMaxBorder = 100.0f;
        /// <summary>
        /// Множитель зума.
        /// </summary>
        private float _zoomK = 0.8f;

        private void OnPaint(object sender, PaintEventArgs e)
        {
            // Номер блока, с которого начинается рисование
            uint needBlockCount = (uint) ((_currentMinBorder - TimeMinBorder)/_timeBlockWidth);

            // Размер блока мелких делений в пикселях
            float timeBlockPixelWidth = TimeToPixelCoord(_currentMinBorder + _timeBlockWidth);

            // Начальная позиция времени
            float time = needBlockCount*_timeBlockWidth;

            // Рисуем шкалу
            for (float position = TimeToPixelCoord(time);
                position < _timelineDrawingRect.Width;
                position += timeBlockPixelWidth)
            {
                e.Graphics.DrawLine(_pen, position, 3.0f, position, 20.0f);
                e.Graphics.DrawString($"{time:0.00}", _font, _brush, position, 0.0f);

                for (float subpos = position;
                    subpos < position + timeBlockPixelWidth;
                    subpos += timeBlockPixelWidth/10.0f)
                    e.Graphics.DrawLine(_pen, subpos, 15.0f, subpos, 5.0f + 15.0f);

                time += _timeBlockWidth;
            }
            
            // Рисуем слои
            if (Model != null)
            {
                var layersEnumerator = Model.Layers.GetEnumerator();
                for (float position = 28.0f;
                    position < _timelineDrawingRect.Height && layersEnumerator.MoveNext();
                    position += 16)
                {
                    e.Graphics.FillRectangle(new SolidBrush(layersEnumerator.Current.Color), 0.0f, position,
                        _timelineDrawingRect.Width, 16.0f);

                    // Рисуем объекты на слое
                    /*
                    var objectsEnumerator = layersEnumerator.Current.Objects.GetEnumerator();
                    while (objectsEnumerator.MoveNext())
                    {
                        float leftCoord = TimeToPixelCoord(objectsEnumerator.Current.StartTime);
                        float rightCoord =
                            TimeToPixelCoord(objectsEnumerator.Current.StartTime + objectsEnumerator.Current.Length);
                        e.Graphics.DrawLine(_pen, leftCoord, position, rightCoord, position + 16.0f);
                    }
                    */
                }
            }
            
            // Рисуем курсор
            if (DateTime.Now.Second % 2 == 0)
                _pen.Color = Color.White;
            e.Graphics.DrawLine(_pen, TimeToPixelCoord(CursorPosition), 0, TimeToPixelCoord(CursorPosition), _timelineDrawingRect.Height);

            _pen.Color = Color.Red;
            e.Graphics.DrawLines(_pen, new[]
            {
                new Point((int)(TimeToPixelCoord(CursorPosition) - 5), 7),
                new Point((int)(TimeToPixelCoord(CursorPosition) - 5), 0),
                new Point((int)(TimeToPixelCoord(CursorPosition) + 5), 0),
                new Point((int)(TimeToPixelCoord(CursorPosition) + 5), 7),
                new Point((int)(TimeToPixelCoord(CursorPosition)), 17),
                new Point((int)(TimeToPixelCoord(CursorPosition) - 5), 7),
            });

            _pen.Color = Color.Black;

            // <DEBUG>
            //e.Graphics.DrawLine(_pen, TimeToPixelCoord(MouseCursorPosition), 0, TimeToPixelCoord(MouseCursorPosition), _timelineDrawingRect.Height);
            //e.Graphics.DrawLine(_pen, TimeToPixelCoord(ObservingCursorPosition), 0, TimeToPixelCoord(ObservingCursorPosition), _timelineDrawingRect.Height);
        }
        private void OnMouseEnter(object sender, EventArgs e)
        {
            _timelineDrawingRect.Focus();
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            // TODO FIXME: КОСТЫЛЬ!!! ПРИДУМАТЬ АДЕКВАТНОЕ РЕШЕНИЕ ПРОБЛЕМЫ ФОКУСА И КОЛЕСА МЫШИ!!!
            _timelineScrollBar.Focus();
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseCursorPosition = PixelToTimeCoord(e.X);
        }
        private void OnClick(object sender, EventArgs e)
        {
            CursorPosition = MouseCursorPosition;
        }
        private void OnScroll(object sender, ScrollEventArgs e)
        {
            ObservingCursorPosition = Length *
                             ((float)(_timelineScrollBar.Value + _timelineScrollBar.LargeChange / 2) /
                              (_timelineScrollBar.Maximum - _timelineScrollBar.Minimum));
        }
        void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (_timelineDrawingRect.Focused && (e.X > 0 && e.Y > 0 && e.X < _timelineDrawingRect.Width && e.Y < _timelineDrawingRect.Height))
            {
                // Получим позицию курсора на timeline
                var cursorTime = PixelToTimeCoord(e.X);

                if (e.Delta > 0)
                    ZoomPercent = (ZoomPercent * _zoomK) < 1.0f ? 1.0f : ZoomPercent * _zoomK;
                else
                {
                    if (ZoomPercent / _zoomK > 100.0)
                        ZoomPercent = 100.0f;
                    else
                        ZoomPercent /= _zoomK;
                }

                _timeBlockWidth = 10.0f / ((1 << (int)(100 - ZoomPercent) % 2));

                ObservingCursorPosition = CursorPosition;
            }
        }
    }
}
