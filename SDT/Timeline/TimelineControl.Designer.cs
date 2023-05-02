namespace Timeline
{
    partial class TimelineControl
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
            this._timelineDrawingRect = new System.Windows.Forms.PictureBox();
            this._timelineScrollBar = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this._timelineDrawingRect)).BeginInit();
            this.SuspendLayout();
            // 
            // _timelineDrawingRect
            // 
            this._timelineDrawingRect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._timelineDrawingRect.Location = new System.Drawing.Point(0, 0);
            this._timelineDrawingRect.Name = "_timelineDrawingRect";
            this._timelineDrawingRect.Size = new System.Drawing.Size(1058, 137);
            this._timelineDrawingRect.TabIndex = 1;
            this._timelineDrawingRect.TabStop = false;
            this._timelineDrawingRect.Click += new System.EventHandler(this.OnClick);
            this._timelineDrawingRect.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this._timelineDrawingRect.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this._timelineDrawingRect.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this._timelineDrawingRect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // _timelineScrollBar
            // 
            this._timelineScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._timelineScrollBar.LargeChange = 50;
            this._timelineScrollBar.Location = new System.Drawing.Point(0, 140);
            this._timelineScrollBar.Name = "_timelineScrollBar";
            this._timelineScrollBar.Size = new System.Drawing.Size(1058, 17);
            this._timelineScrollBar.TabIndex = 2;
            this._timelineScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnScroll);
            // 
            // TimelineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._timelineScrollBar);
            this.Controls.Add(this._timelineDrawingRect);
            this.Name = "TimelineControl";
            this.Size = new System.Drawing.Size(1058, 157);
            ((System.ComponentModel.ISupportInitialize)(this._timelineDrawingRect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _timelineDrawingRect;
        private System.Windows.Forms.HScrollBar _timelineScrollBar;
    }
}
