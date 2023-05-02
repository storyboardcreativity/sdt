using System;
using System.Drawing;

namespace Aga.Controls.Tree.NodeControls
{
    public class NodeColorControl : BindableControl
    {
        public override Size MeasureSize(TreeNodeAdv node)
        {
            return new Size(16,16);
        }

        public override void Draw(TreeNodeAdv node, DrawContext context)
        {
            var color = (Color) GetColor(node);
            Rectangle clipRect = context.Bounds;
            clipRect.Y += 4; clipRect.Height -= 8;
            clipRect.X += 4; clipRect.Width -= 8;
            context.Graphics.FillRectangle(new SolidBrush(color), clipRect);
            context.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
        }
        
        protected virtual void SetColor(TreeNodeAdv node, Color value)
        {
            SetValue(node, value);
        }

        public event EventHandler ColorChanged;
        protected void OnColorChanged()
        {
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }
        
        protected virtual Color? GetColor(TreeNodeAdv node)
        {
            if (node.Tag != null)
            {
                if (string.IsNullOrEmpty(DataPropertyName))
                    return null;

                object obj = GetValue(node);
                if (obj != null)
                    return (Color)obj;
            }
            return null;
        }
    }
}