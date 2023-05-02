using System;
using System.Collections.Generic;
using System.Drawing;
using Aga.Controls.Tree;
using DemoModel;

namespace Timeline
{
    public class LayerTreeModel : ITreeModel
    {
        /// <summary>
        /// Модель демки.
        /// </summary>
        public DemoUniversalModel DemoModel
        {
            get { return _demoModel; }
            set
            {
                _demoModel = value;
                foreach (var demoLayer in _demoModel.Layers)
                {
                    Layers.Add(new BaseLayer(this, demoLayer)
                    {
                        Color = Color.FromArgb(_random.Next(200, 255), _random.Next(200, 255), _random.Next(200, 255)),
                        Name = demoLayer.GetType().ToString()
                    });

                    OnNodeInserted(Root, Layers.Count - 1, Layers[Layers.Count - 1]);
                }
            }
        }

        /// <summary>
        /// Рандомщик.
        /// </summary>
        private readonly Random _random = new Random();

        public List<BaseLayer> Layers
        {
            get { return _layers; }
        }
        private readonly List<BaseLayer> _layers = new List<BaseLayer>();

        public BaseLayer Root
        {
            get { return _root; }
        }
        private BaseLayer _root;
        private DemoUniversalModel _demoModel;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public LayerTreeModel()
        {
            _root = new BaseLayer(this, null) { Name = "Invisible Root Node" };
        }
        
        public TreePath GetPath(BaseLayer node)
        {
            if (node == Root)
                return TreePath.Empty;
            return new TreePath(new object[] { node });
        }

        #region ITreeModel Realization

        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            if (Layers.Count > 0)
                // Если путь пуст - вернём корень
                if (treePath.IsEmpty())
                    foreach (var baseLayer in Layers)
                        yield return baseLayer;
        }

        public bool IsLeaf(TreePath treePath)
        {
            return treePath.LastNode != Root;
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;

        #endregion

        public virtual void OnNodesChanged(TreeModelEventArgs e)
        {
            NodesChanged?.Invoke(this, e);
        }
        public virtual void OnNodesInserted(TreeModelEventArgs e)
        {
            NodesInserted?.Invoke(this, e);
        }
        public virtual void OnNodesRemoved(TreeModelEventArgs e)
        {
            NodesRemoved?.Invoke(this, e);
        }
        public virtual void OnStructureChanged(TreePathEventArgs e)
        {
            StructureChanged?.Invoke(this, e);
        }
        public void OnNodeInserted(BaseLayer parent, int index, BaseLayer node)
        {
            TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
            OnNodesInserted(args);
        }
        public void OnNodeRemoved(BaseLayer parent, int index, BaseLayer node)
        {
            TreeModelEventArgs args = new TreeModelEventArgs(GetPath(parent), new int[] { index }, new object[] { node });
            OnNodesRemoved(args);
        }
    }
}
