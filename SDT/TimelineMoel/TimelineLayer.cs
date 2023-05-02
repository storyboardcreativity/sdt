using System.Collections.Generic;
using System.Drawing;
using DemoModel.Interfaces;

namespace Timeline
{
    /// <summary>
    /// ���� �� ���������.
    /// </summary>
    public class TimelineLayer
    {
        /// <summary>
        /// �����������.
        /// </summary>
        public TimelineLayer(IDemoLayer demoLayer, string name, Color color)
        {
            ModelLayer = demoLayer;
            Name = name;
            Color = color;
            Children = new List<TimelineLayer>();
        }

        /// <summary>
        /// ������ ����, ����������� � ����� ��� �����������.
        /// </summary>
        public IDemoLayer ModelLayer { get; }

        /// <summary>
        /// �������� ����.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ���� ����.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// �������� ����.
        /// </summary>
        public List<TimelineLayer> Children { get; }
    }
}