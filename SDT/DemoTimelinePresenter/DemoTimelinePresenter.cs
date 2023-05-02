using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using DemoModel;
using DemoModel.Interfaces;
using Presentation;
using View;

namespace DemoTimelinePresenter
{
    public class DemoTimelinePresenter : IDemoTimelinePresenter
    {
        /// <summary>
        /// View формы таймлайна.
        /// </summary>
        private readonly IDemoTimelineView _demoTimelineView;

        /// <summary>
        /// Модель демки.
        /// </summary>
        private DemoUniversalModel _demoModel;

        /// <summary>
        /// Рандомщик.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="demoTimelineView">View формы таймлайна.</param>
        public DemoTimelinePresenter(IDemoTimelineView demoTimelineView)
        {
            _demoTimelineView = demoTimelineView;

            _demoTimelineView.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, object obj)
        {
            SelectionChanged?.Invoke(this, obj);
        }
        
        public void Run()
        {
            _demoTimelineView.Show();
        }

        public void SetDemoTimeline(DemoUniversalModel demoModel)
        {
            _demoModel = demoModel;
            _demoTimelineView.DemoModel = _demoModel;
            /*
            _demoTimelineView.TimeMinBorder = _demoModel.StartTime;
            _demoTimelineView.TimeMaxBorder = _demoModel.Length > 0
                ? _demoModel.StartTime + _demoModel.Length
                : _demoModel.StartTime + 1.0f;
            _demoTimelineView.ZoomPercent = 100.0f;
            _demoTimelineView.CursorPosition = _demoModel.StartTime + _demoModel.Length / 2.0f;
            */

            // Добавляем все слои рекурсивно
            //RecursiveLayerInitialize(_demoModel.Layers, TimelineLayersRoot);
        }

        public event EventHandler<object> SelectionChanged;
        /*
        private void RecursiveLayerInitialize(Collection<IDemoLayer> layers, List<TimelineLayer> children)
        {
            foreach (IDemoLayer layer in layers)
            {
                // Создадим слой
                var timelineLayer = new TimelineLayer(layer, layer.GetType().ToString(), GetRandomColor());
                
                // Рекурсивно построим поддерево слоёв
                RecursiveLayerInitialize(layer.Children, timelineLayer.Children);

                // Добавим и этот слой тоже
                children.Add(timelineLayer);
            }
        }*/

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(200, 255), _random.Next(200, 255), _random.Next(200, 255));
        }
    }
}
