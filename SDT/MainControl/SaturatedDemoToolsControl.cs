using System;
using System.Windows.Forms;
using View;

namespace MainControl
{
    public sealed partial class SaturatedDemoToolsControl : UserControl, ISaturatedDemoToolsView
    {
        private readonly IDemoTimelineView _demoTimelineView;
        private readonly IDemoTreeView _demoTreeView;
        private readonly IDemoDescriptionView _demoDescriptionView;

        public SaturatedDemoToolsControl(IDemoTimelineView demoTimelineView, IDemoTreeView demoTreeView, IDemoDescriptionView demoDescriptionView)
        {
            _demoTimelineView = demoTimelineView;
            _demoTreeView = demoTreeView;
            _demoDescriptionView = demoDescriptionView;
            InitializeComponent();

            Dock = DockStyle.Fill;

            _demoTimelinePanel.Controls.Add((Control)demoTimelineView);
            _demoTreePanel.Controls.Add((Control)demoTreeView);
            _demoInfoPanel.Controls.Add((Control)demoDescriptionView);
        }

        public event Action<string> EventFileOpen;

        public event Action<string> EventFileSave;

        private void _openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы демок (*.dem) | *.dem";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                EventFileOpen?.Invoke(openFileDialog.FileName);
        }

        private void _saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы демок (*.dem) | *.dem";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                EventFileSave?.Invoke(saveFileDialog.FileName);
        }
    }
}
