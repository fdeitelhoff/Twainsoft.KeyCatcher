using System;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core;

namespace Twainsoft.KeyCatcher.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            new KeyboardCatcher();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                Hide();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                notifyIcon.Visible = false;
            }
        }
    }
}
