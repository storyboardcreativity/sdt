using System.Drawing;

namespace View
{
    public class LayerCommonEventArgs
    {
        /// <summary>
        /// �������� ����.
        /// </summary>
        public string LayerName { get; set; }

        /// <summary>
        /// ���� ����.
        /// </summary>
        public Color LayerColor { get; set; }
    }
}