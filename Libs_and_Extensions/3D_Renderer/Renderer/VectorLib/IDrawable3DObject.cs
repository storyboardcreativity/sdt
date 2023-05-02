using System.Drawing;
using VectorLib;

namespace Renderer.VectorLib
{
    /// <summary>
    /// ��������� ������������ 3D �������.
    /// </summary>
    public interface IDrawable3DObject
    {
        /// <summary>
        /// ������ ������.
        /// </summary>
        /// <param name="g">������ �������.</param>
        /// <param name="projMatrix">������� ��������.</param>
        void Render(Graphics g, Matrix3D projMatrix);
    }
}