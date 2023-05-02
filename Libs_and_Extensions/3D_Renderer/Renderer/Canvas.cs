using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Renderer.VectorLib;

namespace Renderer
{
    public sealed partial class Canvas : UserControl
    {
        public Collection<IDrawable3DObject> ObjectsToDraw { get; }

        public ActionMode Action
        {
            get { return _action; }
            set { _action = value; }
        }
        private ActionMode _action;
        
        Camera _camera;
        Point _origin;
        CoordinateAxes _axes;
        AxesPosition _axesPlacement;
        double _theta;
        double _phi;
        int _x;
        int _y;
        
        double _tx = 0;
        double _ty = 0;
        double _tz = 0;
        
        public Canvas()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            UpdateStyles();
            
            _camera = new Camera();
            
            _origin = new Point
            {
                X = Width/2,
                Y = Height/2
            };
            _axes = new CoordinateAxes(_origin);

            // Цвет фона
            BackColor = Color.White;

            // Позиция осей по умолчанию
            _axesPlacement = AxesPosition.TopRight;

            // Инициализируем массив графических объектов
            ObjectsToDraw = new Collection<IDrawable3DObject>(new List<IDrawable3DObject>());
            
            _action = ActionMode.Rotate;
            
        }   
        protected override void OnPaint(PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsContainer a= e.Graphics.BeginContainer();
            e.Graphics.TranslateTransform(_origin.X, _origin.Y);
            _camera.Project(_theta,_phi,_tx,_ty,_tz);
            
            DrawData(e);
            e.Graphics.EndContainer(a);
            base.OnPaint(e);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _origin.X = Width / 2;
            _origin.Y = Height / 2;
            SetAxesPosition(_axesPlacement);
            Invalidate();
        }
        private void DrawData(PaintEventArgs e)
        {
            DrawAxes(e.Graphics);
            foreach (IDrawable3DObject obj in ObjectsToDraw)
                obj.Render(e.Graphics, _camera.ProjectedMatrix);
        }

        private void DrawAxes(Graphics graphics)
        {
            _axes.Draw(graphics, _camera.ProjectedMatrix);
        }
        public void SetView(ViewTypes view)
        {
            _camera.View = view;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _x = e.X;
            _y = e.Y;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left && _action == ActionMode.Rotate)
            {
                if(_x-e.X>0)
                _theta = _theta + Math.Abs(_x-e.X);
                else
                    _theta = _theta - Math.Abs(_x - e.X) ;
                if (_y - e.Y > 0)
                    _phi = _phi + Math.Abs(_y - e.Y);
                else
                    _phi = _phi - Math.Abs(_y - e.Y);
                _x = e.X;
                _y = e.Y;
                Invalidate();
            }
            if (e.Button == MouseButtons.Left && _action == ActionMode.Pan)
            {
                if (_x - e.X > 0)
                    _tx = _tx + Math.Abs(_x - e.X);
                else
                    _tx = _tx - Math.Abs(_x - e.X);
                if (_y - e.Y > 0)
                    _ty = _ty + Math.Abs(_y - e.Y);
                else
                    _ty = _ty - Math.Abs(_y - e.Y);
                _x = e.X;
                _y = e.Y;
                Invalidate();
            }
        }

        /// <summary>
        /// Устанавливает позицию осей координат.
        /// </summary>
        /// <param name="position">Позиция.</param>
        public void SetAxesPosition(AxesPosition position)
        {
            _axesPlacement = position;
            switch (_axesPlacement)
            {
                case AxesPosition.TopLeft:
                    _axes.SetPosition( -(Width/2-60), -(Height/2-60));
                    break;

                case AxesPosition.TopRight:
                    _axes.SetPosition((Width / 2 - 60), -(Height / 2 - 60));
                    break;

                case AxesPosition.BottomLeft:
                    _axes.SetPosition(-(Width / 2 - 60), (Height / 2 - 60));
                    break;

                case AxesPosition.BottomRight:
                    _axes.SetPosition((Width / 2 - 60), (Height / 2 - 60));
                    break;

                case AxesPosition.Center:
                    _axes.SetPosition(0,0);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(position));
            }
        }
    }

    public enum ActionMode
    {
        Pan,
        Select,
        Rotate,
        Zoom
    }
}
