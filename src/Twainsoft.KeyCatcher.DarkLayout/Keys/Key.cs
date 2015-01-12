using System.Drawing;
using System.Windows.Forms;

namespace Twainsoft.KeyCatcher.DarkLayout.Keys
{
    public class Key
    {
        public bool Hit { get; set; }

        public Key(string name, int x, int y)
        {
            text = name.ToLower();
            rectangle = new Rectangle(x, y, 30, 30);
        }

        public Rectangle Region()
        {
            return rectangle;
        }

        private string text;
        private Rectangle rectangle;

        public void ModifierUp(KeyEventArgs args)
        {
            if (args.KeyCode == System.Windows.Forms.Keys.LShiftKey)
            {
                text = text.ToLower();
            }
        }

        public void ModifierDown(KeyEventArgs args)
        {
            if (args.KeyCode == System.Windows.Forms.Keys.LShiftKey)
            {
                text = text.ToUpper();
            }
        }


        public void Paint(PaintEventArgs args)
        {
            if (Hit)
            {
                args.Graphics.FillRectangle(Brushes.White, rectangle);
                args.Graphics.DrawString(text, new Font("Arial", 12), Brushes.Black, rectangle.X + 6, rectangle.Y + 6);
            }
            else
            {
                args.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(56, 56, 56)), rectangle);
                args.Graphics.DrawString(text, new Font("Arial", 12), Brushes.White, rectangle.X + 6, rectangle.Y + 6);
            }
        }
    }
}
