namespace CameraLayer
{
    partial class CameraLayerEditorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._sceneView = new Renderer.Canvas();
            this.SuspendLayout();
            // 
            // _sceneView
            // 
            this._sceneView.Action = Renderer.ActionMode.Rotate;
            this._sceneView.BackColor = System.Drawing.Color.White;
            this._sceneView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sceneView.Location = new System.Drawing.Point(0, 0);
            this._sceneView.Name = "_sceneView";
            this._sceneView.Size = new System.Drawing.Size(918, 522);
            this._sceneView.TabIndex = 0;
            // 
            // CameraLayerEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 522);
            this.Controls.Add(this._sceneView);
            this.Name = "CameraLayerEditorForm";
            this.Text = "CameraLayerEditorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Renderer.Canvas _sceneView;
    }
}