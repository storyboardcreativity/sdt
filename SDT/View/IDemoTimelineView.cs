using System;
using DemoModel;

namespace View
{
    public interface IDemoTimelineView : IView
    {
        /// <summary>
        /// ������ �����.
        /// </summary>
        DemoUniversalModel DemoModel { get; set; }

        /// <summary>
        /// ����� ������� �� ������� ��������� (����������� ��������� �����).
        /// </summary>
        float TimeMinBorder { get; set; }

        /// <summary>
        /// ������ ������� �� ������� ��������� (������������ ��������� �����).
        /// </summary>
        float TimeMaxBorder { get; set; }

        /// <summary>
        /// ������� ����� ��� �������� (������� �������).
        /// </summary>
        float CursorPosition { get; set; }

        /// <summary>
        /// ���� (����������) ������������ ����� �� ����.
        /// </summary>
        float ZoomPercent { get; set; }

        /// <summary>
        /// ������������ ����� ���������.
        /// </summary>
        float Length { get; }

        /// <summary>
        /// ������� �� ��������� ������ �� �����.
        /// </summary>
        event EventHandler<object> SelectionChanged;
    }
}