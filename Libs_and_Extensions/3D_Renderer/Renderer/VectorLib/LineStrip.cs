using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using VectorLib;

namespace Renderer.VectorLib
{
    public class LineStrip : IDrawable3DObject
    {
        /// <summary>
        /// Вершины.
        /// </summary>
        public Collection<Point3D> Vertex { get; }

        /// <summary>
        /// Ручка для рисования линий.
        /// </summary>
        public Pen Pen { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public LineStrip()
        {
            Vertex = new Collection<Point3D>(new List<Point3D>());
            Pen = new Pen(Color.Black);
        }

        public void Render(Graphics g, Matrix3D projMatrix)
        {
            // Готовим массив для вывода графики
            var list = new List<Point>(Vertex.Count * 2);
            for (int i = 0; i < Vertex.Count - 1; ++i)
            {
                var pointA = Vertex[i];
                var pointB = Vertex[i + 1];
                pointA = projMatrix.ApplyTransformToPt(pointA.X, pointA.Y, pointA.Z, 1.0);
                pointB = projMatrix.ApplyTransformToPt(pointB.X, pointB.Y, pointB.Z, 1.0);
                list.Add(new Point((int)pointA.X, -(int)pointA.Y));
                list.Add(new Point((int)pointB.X, -(int)pointB.Y));
            }

            // Сохраним состояние графики
            //var state = g.Save();
            //var container = g.BeginContainer();
            /* ====== Рисование ====== */
            g.DrawLines(Pen, list.ToArray());
            /* === Конец рисования === */
            //g.EndContainer(container);
            //g.Restore(state);
        }
    }
}