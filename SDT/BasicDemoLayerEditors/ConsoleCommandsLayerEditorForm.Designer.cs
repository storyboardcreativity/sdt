namespace ConsoleCommandLayer
{
    partial class ConsoleCommandsLayerEditorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleCommandsLayerEditorForm));
            this._okButton = new System.Windows.Forms.Button();
            this._commandListGridView = new System.Windows.Forms.DataGridView();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consoleCommandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._commandListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consoleCommandBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(612, 347);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(92, 34);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "ОК";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButton_OnClick);
            // 
            // _commandListGridView
            // 
            this._commandListGridView.AllowUserToResizeRows = false;
            this._commandListGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._commandListGridView.AutoGenerateColumns = false;
            this._commandListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._commandListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._commandListGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestampDataGridViewTextBoxColumn,
            this.commandDataGridViewTextBoxColumn});
            this._commandListGridView.DataSource = this.consoleCommandBindingSource;
            this._commandListGridView.Location = new System.Drawing.Point(12, 12);
            this._commandListGridView.MultiSelect = false;
            this._commandListGridView.Name = "_commandListGridView";
            this._commandListGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._commandListGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._commandListGridView.Size = new System.Drawing.Size(692, 329);
            this._commandListGridView.TabIndex = 1;
            this._commandListGridView.Tag = "";
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.FillWeight = 45.68528F;
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Время исполнения (с.)";
            this.timestampDataGridViewTextBoxColumn.MinimumWidth = 45;
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            // 
            // commandDataGridViewTextBoxColumn
            // 
            this.commandDataGridViewTextBoxColumn.DataPropertyName = "Command";
            this.commandDataGridViewTextBoxColumn.FillWeight = 154.3147F;
            this.commandDataGridViewTextBoxColumn.HeaderText = "Команда клиенту";
            this.commandDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
            // 
            // consoleCommandBindingSource
            // 
            this.consoleCommandBindingSource.DataSource = typeof(ConsoleCommandLayer.ConsoleCommand);
            // 
            // ConsoleCommandsLayerEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 393);
            this.Controls.Add(this._commandListGridView);
            this.Controls.Add(this._okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsoleCommandsLayerEditorForm";
            this.ShowInTaskbar = false;
            this.Text = "Редактирование слоя команд клиенту";
            ((System.ComponentModel.ISupportInitialize)(this._commandListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consoleCommandBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.DataGridView _commandListGridView;
        private System.Windows.Forms.BindingSource consoleCommandBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;
    }
}