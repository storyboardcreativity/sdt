namespace Timeline
{
    sealed partial class DemoTimeline
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._verticalSplitter = new System.Windows.Forms.SplitContainer();
            this._layerTree = new Aga.Controls.Tree.TreeViewAdv();
            this._layerColor = new Aga.Controls.Tree.NodeControls.NodeColorControl();
            this._layerName = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._timelineControl = new Timeline.TimelineControl();
            this._treeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._layerAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this._layerRename = new System.Windows.Forms.ToolStripMenuItem();
            this._layerRemove = new System.Windows.Forms.ToolStripMenuItem();
            this._nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitter)).BeginInit();
            this._verticalSplitter.Panel1.SuspendLayout();
            this._verticalSplitter.Panel2.SuspendLayout();
            this._verticalSplitter.SuspendLayout();
            this._treeContextMenuStrip.SuspendLayout();
            this._nodeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _verticalSplitter
            // 
            this._verticalSplitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._verticalSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._verticalSplitter.Location = new System.Drawing.Point(0, 0);
            this._verticalSplitter.Name = "_verticalSplitter";
            // 
            // _verticalSplitter.Panel1
            // 
            this._verticalSplitter.Panel1.Controls.Add(this._layerTree);
            this._verticalSplitter.Panel1.Controls.Add(this.label1);
            // 
            // _verticalSplitter.Panel2
            // 
            this._verticalSplitter.Panel2.Controls.Add(this._timelineControl);
            this._verticalSplitter.Size = new System.Drawing.Size(1147, 334);
            this._verticalSplitter.SplitterDistance = 238;
            this._verticalSplitter.TabIndex = 2;
            this._verticalSplitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this._verticalSplitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this._verticalSplitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // _layerTree
            // 
            this._layerTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._layerTree.BackColor = System.Drawing.SystemColors.Menu;
            this._layerTree.Cursor = System.Windows.Forms.Cursors.Default;
            this._layerTree.DragDropMarkColor = System.Drawing.Color.Black;
            this._layerTree.LineColor = System.Drawing.SystemColors.ControlDark;
            this._layerTree.Location = new System.Drawing.Point(7, 27);
            this._layerTree.Model = null;
            this._layerTree.Name = "_layerTree";
            this._layerTree.NodeControls.Add(this._layerColor);
            this._layerTree.NodeControls.Add(this._layerName);
            this._layerTree.SelectedNode = null;
            this._layerTree.Size = new System.Drawing.Size(224, 285);
            this._layerTree.TabIndex = 2;
            this._layerTree.Text = "treeViewAdv1";
            this._layerTree.NodeMouseDoubleClick += new System.EventHandler<Aga.Controls.Tree.TreeNodeAdvMouseEventArgs>(this.LayerTree_OnNodeMouseDoubleClick);
            this._layerTree.SelectionChanged += new System.EventHandler(this.TreeModel_SelectionChanged);
            this._layerTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeModel_MouseClick);
            // 
            // _layerColor
            // 
            this._layerColor.DataPropertyName = "Color";
            // 
            // _layerName
            // 
            this._layerName.DataPropertyName = "Name";
            this._layerName.EditEnabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Timeline";
            // 
            // _timelineControl
            // 
            this._timelineControl.CursorPosition = 50F;
            this._timelineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._timelineControl.Location = new System.Drawing.Point(0, 0);
            this._timelineControl.Model = null;
            this._timelineControl.MouseCursorPosition = 50F;
            this._timelineControl.Name = "_timelineControl";
            this._timelineControl.ObservingCursorPosition = 50F;
            this._timelineControl.Size = new System.Drawing.Size(901, 330);
            this._timelineControl.TabIndex = 0;
            this._timelineControl.TimeMaxBorder = 100F;
            this._timelineControl.TimeMinBorder = 0F;
            this._timelineControl.ZoomPercent = 100F;
            // 
            // _treeContextMenuStrip
            // 
            this._treeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._layerAddItem});
            this._treeContextMenuStrip.Name = "_treeContextMenuStrip";
            this._treeContextMenuStrip.Size = new System.Drawing.Size(157, 26);
            // 
            // _layerAddItem
            // 
            this._layerAddItem.Name = "_layerAddItem";
            this._layerAddItem.Size = new System.Drawing.Size(156, 22);
            this._layerAddItem.Text = "Добавить слой";
            this._layerAddItem.Click += new System.EventHandler(this.TreeContextMenu_AddItemClick);
            // 
            // _layerRename
            // 
            this._layerRename.Name = "_layerRename";
            this._layerRename.Size = new System.Drawing.Size(161, 22);
            this._layerRename.Text = "Переименовать";
            this._layerRename.Click += new System.EventHandler(this.NodeContextMenu_LayerRename_Click);
            // 
            // _layerRemove
            // 
            this._layerRemove.Name = "_layerRemove";
            this._layerRemove.Size = new System.Drawing.Size(161, 22);
            this._layerRemove.Text = "Удалить";
            this._layerRemove.Click += new System.EventHandler(this.NodeContextMenu_LayerRemove_Click);
            // 
            // _nodeContextMenuStrip
            // 
            this._nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._layerRename,
            this._layerRemove});
            this._nodeContextMenuStrip.Name = "_nodeContextMenuStrip";
            this._nodeContextMenuStrip.Size = new System.Drawing.Size(162, 48);
            // 
            // DemoTimeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._verticalSplitter);
            this.Name = "DemoTimeline";
            this.Size = new System.Drawing.Size(1147, 334);
            this._verticalSplitter.Panel1.ResumeLayout(false);
            this._verticalSplitter.Panel1.PerformLayout();
            this._verticalSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitter)).EndInit();
            this._verticalSplitter.ResumeLayout(false);
            this._treeContextMenuStrip.ResumeLayout(false);
            this._nodeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer _verticalSplitter;
        private System.Windows.Forms.Label label1;
        private Aga.Controls.Tree.TreeViewAdv _layerTree;
        private Aga.Controls.Tree.NodeControls.NodeTextBox _layerName;
        private Aga.Controls.Tree.NodeControls.NodeColorControl _layerColor;
        private TimelineControl _timelineControl;
        private System.Windows.Forms.ContextMenuStrip _treeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _layerAddItem;
        private System.Windows.Forms.ToolStripMenuItem _layerRename;
        private System.Windows.Forms.ToolStripMenuItem _layerRemove;
        private System.Windows.Forms.ContextMenuStrip _nodeContextMenuStrip;
    }
}
