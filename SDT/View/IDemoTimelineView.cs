using System;
using DemoModel;

namespace View
{
    public interface IDemoTimelineView : IView
    {
        /// <summary>
        /// Модель демки.
        /// </summary>
        DemoUniversalModel DemoModel { get; set; }

        /// <summary>
        /// Левая граница по времени таймлайна (минимальное доступное время).
        /// </summary>
        float TimeMinBorder { get; set; }

        /// <summary>
        /// Правая граница по времени таймлайна (максимальное доступное время).
        /// </summary>
        float TimeMaxBorder { get; set; }

        /// <summary>
        /// Текущее время под курсором (позиция курсора).
        /// </summary>
        float CursorPosition { get; set; }

        /// <summary>
        /// Доля (процентная) отображаемой шкалы от всей.
        /// </summary>
        float ZoomPercent { get; set; }

        /// <summary>
        /// Длительность всего таймлайна.
        /// </summary>
        float Length { get; }

        /// <summary>
        /// Событие об изменении выбора на форме.
        /// </summary>
        event EventHandler<object> SelectionChanged;
    }
}