using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Aga.Controls.Tree;
using Aga.Controls.Tree.NodeControls;
using DemoModel;
using DemoModel.Interfaces;
using View;

namespace Timeline
{
    public sealed partial class DemoTimeline : UserControl, IDemoTimelineView
    {
        public DemoUniversalModel DemoModel
        {
            get { return _demoModel; }
            set
            {
                if (value == null)
                    return;

                _demoModel = value;
                LayerTreeModel = new LayerTreeModel();
                LayerTreeModel.DemoModel = _demoModel;
                _timelineControl.Model = LayerTreeModel;
                _layerTree.Model = LayerTreeModel;
            }
        }

        public float TimeMinBorder
        {
            get { return _timelineControl.TimeMinBorder; }
            set { _timelineControl.TimeMinBorder = value; }
        }
        public float TimeMaxBorder
        {
            get { return _timelineControl.TimeMaxBorder; }
            set { _timelineControl.TimeMaxBorder = value; }
        }
        public float CursorPosition
        {
            get { return _timelineControl.CursorPosition; }
            set { _timelineControl.CursorPosition = value; }
        }
        public float ZoomPercent
        {
            get { return _timelineControl.ZoomPercent; }
            set { _timelineControl.ZoomPercent = value; }
        }
        public float Length => _timelineControl.Length;

        private LayerTreeModel LayerTreeModel { get; set; }
        private DemoUniversalModel _demoModel;

        public event EventHandler<object> SelectionChanged;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DemoTimeline()
        {
            InitializeComponent();

            LayerTreeModel = new LayerTreeModel();

            Dock = DockStyle.Fill;
        }
        
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = true;
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            ((SplitContainer)sender).IsSplitterFixed = false;
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                if (e.Button.Equals(MouseButtons.Left))
                {
                    if (((SplitContainer) sender).Orientation.Equals(Orientation.Vertical))
                    {
                        if (e.X > 0 && e.X < ((SplitContainer) sender).Width)
                        {
                            ((SplitContainer) sender).SplitterDistance = e.X;
                            ((SplitContainer) sender).Refresh();
                        }
                    }
                    else if (e.Y > 0 && e.Y < ((SplitContainer) sender).Height)
                    {
                        ((SplitContainer) sender).SplitterDistance = e.Y;
                        ((SplitContainer) sender).Refresh();
                    }
                }
                else
                    ((SplitContainer) sender).IsSplitterFixed = false;
            }
        }
        
        private void TreeModel_SelectionChanged(object sender, EventArgs e)
        {
            if(_layerTree.SelectedNode != null)
                SelectionChanged?.Invoke(this, _layerTree.SelectedNode.Tag);
        }

        private void TreeModel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(_layerTree.SelectedNode != null)
                    _nodeContextMenuStrip.Show(MousePosition);
                else
                    _treeContextMenuStrip.Show(MousePosition);
            }
        }

        private void TreeContextMenu_AddItemClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            /*
            LayerTreeModel.Root.Children.Add(new BaseLayer
            {
                Name = "New Layer",
                Color = Color.Brown
            });*/
        }
        
        private void NodeContextMenu_LayerRemove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //((BaseLayer) _layerTree.SelectedNode.Tag).Parent.Children.Remove((BaseLayer) _layerTree.SelectedNode.Tag);
        }

        private void NodeContextMenu_LayerRename_Click(object sender, EventArgs e)
        {
            var nodeControlsEnumerator = _layerTree.NodeControls.Where(control => control.GetType() == typeof (NodeTextBox)).GetEnumerator();
            
            if(nodeControlsEnumerator.MoveNext())
                ((NodeTextBox)nodeControlsEnumerator.Current).KeyDown(new KeyEventArgs(Keys.F2));
        }

        private void LayerTree_OnNodeMouseDoubleClick(object sender, TreeNodeAdvMouseEventArgs e)
        {
            ((BaseLayer) e.Node.Tag).DemoLayer.Editor.Show();
        }
    }
}
