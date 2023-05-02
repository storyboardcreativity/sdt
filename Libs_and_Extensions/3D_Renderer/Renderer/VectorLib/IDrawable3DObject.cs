using System.Drawing;
using VectorLib;

namespace Renderer.VectorLib
{
    /// <summary>
    /// Интерфейс графического 3D объекта.
    /// </summary>
    public interface IDrawable3DObject
    {
        /// <summary>
        /// Рисует объект.
        /// </summary>
        /// <param name="g">Объект графики.</param>
        /// <param name="projMatrix">Матрица проекции.</param>
        void Render(Graphics g, Matrix3D projMatrix);
    }
}