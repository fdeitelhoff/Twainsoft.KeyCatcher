using System;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core;
using Twainsoft.KeyCatcher.Core.Keyboard;

namespace Twainsoft.KeyCatcher.GUI
{
    public partial class MainForm : Form
    {
        private KeyboardCatcher KeyboardCatcher { get; set; }

        public MainForm()
        {
            InitializeComponent();

            KeyboardCatcher = new KeyboardCatcher();
            KeyboardCatcher.KeyStroked += KeyboardCatcherOnKeyStroked;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.ShowBalloonTip(500);
                Hide();
            }
        }

        private void KeyboardCatcherOnKeyStroked(object sender, KeyStrokeEventArgs keyStrokeEventArgs)
        {
            keyStrokeCount.Text = string.Format("Current Key Strokes: {0}", keyStrokeEventArgs.KeyStrokes);
        }
    }
}
