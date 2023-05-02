namespace MainControl
{
    sealed partial class SaturatedDemoToolsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaturatedDemoToolsControl));
            this._horizontalSplitter = new System.Windows.Forms.SplitContainer();
            this._verticalSplitter = new System.Windows.Forms.SplitContainer();
            this._demoTreePanel = new System.Windows.Forms.Panel();
            this._demoInfoPanel = new System.Windows.Forms.Panel();
            this._demoTimelinePanel = new System.Windows.Forms.Panel();
            this._sdtToolStrip = new System.Windows.Forms.ToolStrip();
            this._openFileButton = new System.Windows.Forms.ToolStripButton();
            this._saveFileButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._horizontalSplitter)).BeginInit();
            this._horizontalSplitter.Panel1.SuspendLayout();
            this._horizontalSplitter.Panel2.SuspendLayout();
            this._horizontalSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitter)).BeginInit();
            this._verticalSplitter.Panel1.SuspendLayout();
            this._verticalSplitter.Panel2.SuspendLayout();
            this._verticalSplitter.SuspendLayout();
            this._sdtToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _horizontalSplitter
            // 
            this._horizontalSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._horizontalSplitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._horizontalSplitter.Location = new System.Drawing.Point(0, 22);
            this._horizontalSplitter.Name = "_horizontalSplitter";
            this._horizontalSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _horizontalSplitter.Panel1
            // 
            this._horizontalSplitter.Panel1.Controls.Add(this._verticalSplitter);
            // 
            // _horizontalSplitter.Panel2
            // 
            this._horizontalSplitter.Panel2.Controls.Add(this._demoTimelinePanel);
            this._horizontalSplitter.Size = new System.Drawing.Size(687, 400);
            this._horizontalSplitter.SplitterDistance = 291;
            this._horizontalSplitter.TabIndex = 0;
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
            this._verticalSplitter.Panel1.Controls.Add(this._demoTreePanel);
            // 
            // _verticalSplitter.Panel2
            // 
            this._verticalSplitter.Panel2.Controls.Add(this._demoInfoPanel);
            this._verticalSplitter.Size = new System.Drawing.Size(687, 291);
            this._verticalSplitter.SplitterDistance = 229;
            this._verticalSplitter.TabIndex = 0;
            // 
            // _demoTreePanel
            // 
            this._demoTreePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._demoTreePanel.Location = new System.Drawing.Point(0, 0);
            this._demoTreePanel.Name = "_demoTreePanel";
            this._demoTreePanel.Size = new System.Drawing.Size(225, 287);
            this._demoTreePanel.TabIndex = 0;
            // 
            // _demoInfoPanel
            // 
            this._demoInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._demoInfoPanel.Location = new System.Drawing.Point(0, 0);
            this._demoInfoPanel.Name = "_demoInfoPanel";
            this._demoInfoPanel.Size = new System.Drawing.Size(450, 287);
            this._demoInfoPanel.TabIndex = 0;
            // 
            // _demoTimelinePanel
            // 
            this._demoTimelinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._demoTimelinePanel.Location = new System.Drawing.Point(0, 0);
            this._demoTimelinePanel.Name = "_demoTimelinePanel";
            this._demoTimelinePanel.Size = new System.Drawing.Size(683, 101);
            this._demoTimelinePanel.TabIndex = 0;
            // 
            // _sdtToolStrip
            // 
            this._sdtToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._sdtToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openFileButton,
            this._saveFileButton});
            this._sdtToolStrip.Location = new System.Drawing.Point(0, 0);
            this._sdtToolStrip.Name = "_sdtToolStrip";
            this._sdtToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._sdtToolStrip.Size = new System.Drawing.Size(687, 25);
            this._sdtToolStrip.TabIndex = 1;
            this._sdtToolStrip.Text = "toolStrip1";
            // 
            // _openFileButton
            // 
            this._openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._openFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_openFileButton.Image")));
            this._openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._openFileButton.Name = "_openFileButton";
            this._openFileButton.Size = new System.Drawing.Size(23, 22);
            this._openFileButton.Click += new System.EventHandler(this._openFileButton_Click);
            // 
            // _saveFileButton
            // 
            this._saveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_saveFileButton.Image")));
            this._saveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveFileButton.Name = "_saveFileButton";
            this._saveFileButton.Size = new System.Drawing.Size(23, 22);
            this._saveFileButton.Click += new System.EventHandler(this._saveFileButton_Click);
            // 
            // SaturatedDemoToolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._sdtToolStrip);
            this.Controls.Add(this._horizontalSplitter);
            this.Name = "SaturatedDemoToolsControl";
            this.Size = new System.Drawing.Size(687, 422);
            this._horizontalSplitter.Panel1.ResumeLayout(false);
            this._horizontalSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._horizontalSplitter)).EndInit();
            this._horizontalSplitter.ResumeLayout(false);
            this._verticalSplitter.Panel1.ResumeLayout(false);
            this._verticalSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitter)).EndInit();
            this._verticalSplitter.ResumeLayout(false);
            this._sdtToolStrip.ResumeLayout(false);
            this._sdtToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer _horizontalSplitter;
        private System.Windows.Forms.SplitContainer _verticalSplitter;
        private System.Windows.Forms.Panel _demoTreePanel;
        private System.Windows.Forms.Panel _demoInfoPanel;
        private System.Windows.Forms.Panel _demoTimelinePanel;
        private System.Windows.Forms.ToolStrip _sdtToolStrip;
        private System.Windows.Forms.ToolStripButton _openFileButton;
        private System.Windows.Forms.ToolStripButton _saveFileButton;
    }
}
