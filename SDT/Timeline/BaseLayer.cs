using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using Aga.Controls.Tree;
using DemoModel.Interfaces;

namespace Timeline
{
    public class BaseLayer
    {
        #region Properties

        /// <summary>
        /// Имя (текст на экране).
        /// </summary>
        [DisplayName(@"Название"), Description("Пользовательское название слоя"), Category("Параметры слоя")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyModel();
            }
        }
        private string _name;

        /// <summary>
        /// Цвет слоя.
        /// </summary>
        [DisplayName(@"Цвет"), Description("Цвет маркировки слоя на временной линии"), Category("Параметры слоя")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyModel();
            }
        }
        private Color _color;

        /// <summary>
        /// Слой демо, привязанный к отображению.
        /// </summary>
        public readonly IDemoLayer DemoLayer;

        /// <summary>
        /// Модель, к которой привязан слой.
        /// </summary>
        [Browsable(false)] public readonly LayerTreeModel Model;

        #endregion

        /// <summary>
        /// Конструктор.
        /// </summary>
        public BaseLayer(LayerTreeModel model, IDemoLayer demoLayer)
        {
            Name = "";
            Model = model;
            DemoLayer = demoLayer;
        }

        protected void NotifyModel()
        {
            if (Model != null)
            {
                TreePath path = Model.GetPath(Model.Root);
                if (path != null)
                {
                    TreeModelEventArgs args = new TreeModelEventArgs(path, new[] { Model.Layers.IndexOf(this) }, new object[] { this });
                    Model.OnNodesChanged(args);
                }
            }
        }
    }
}