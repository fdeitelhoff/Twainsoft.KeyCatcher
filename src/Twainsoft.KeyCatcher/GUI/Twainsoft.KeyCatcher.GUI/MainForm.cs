﻿using System;
using System.Windows.Forms;
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
            KeyboardCatcher.SessionStarted += KeyboardCatcherOnSessionStarted;
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
                Hide();
            }
        }

        private void KeyboardCatcherOnSessionStarted(object sender, SessionStartedEventArgs sessionStartedEventArgs)
        {
            sessionStartDate.Text = string.Format("Session Active Since: {0}",
                sessionStartedEventArgs.KeyboardSession.StartDate);
            keyStrokeCount.Text = string.Format("Current Key Strokes: {0}",
                sessionStartedEventArgs.KeyboardSession.KeyPressCount);

            notifyIcon.ShowBalloonTip(500, "Session started", "A session was started. All keyboard input will be caught now!", 
                ToolTipIcon.Info);
        }

        private void KeyboardCatcherOnKeyStroked(object sender, KeyStrokeEventArgs keyStrokeEventArgs)
        {
            keyStrokeCount.Text = string.Format("Current Key Strokes: {0}",
                keyStrokeEventArgs.KeyboardSession.KeyPressCount);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO: I don't exactly know if thats needed. Test it out later.
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                notifyIcon = null;
            }
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
