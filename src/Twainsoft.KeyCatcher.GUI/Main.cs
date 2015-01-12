﻿using System;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core.Keyboard;
using Twainsoft.KeyCatcher.Core.Keyboard.Events;
using Twainsoft.KeyCatcher.GUI.Properties;

namespace Twainsoft.KeyCatcher.GUI
{
    public partial class Main : Form
    {
        private KeyboardCatcher KeyboardCatcher { get; set; }

        public Main()
        {
            InitializeComponent();

            KeyboardCatcher = new KeyboardCatcher();
            KeyboardCatcher.SessionStarting += KeyboardCatcherOnSessionStarting;
            KeyboardCatcher.SessionStarted += KeyboardCatcherOnSessionStarted;
            KeyboardCatcher.SessionStopping += KeyboardCatcherOnSessionStopping;
            KeyboardCatcher.SessionStopped += KeyboardCatcherOnSessionStopped;
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

        private void KeyboardCatcherOnSessionStarting(object sender, SessionStartingEventArgs sessionStartingEventArgs)
        {
            // Ask the user if the current active session should be stopped.
            if (MessageBox.Show(this, Resources.MainForm_KeyboardCatcherOnSessionStarting_Active_Session_Message,
                Resources.MainForm_KeyboardCatcherOnSessionStarting_Active_Session_Title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                sessionStartingEventArgs.SessionStart = false;
            }
        }

        private void KeyboardCatcherOnSessionStarted(object sender, SessionStartedEventArgs sessionStartedEventArgs)
        {
            sessionStartDate.Text = string.Format("Session Active Since: {0}",
                sessionStartedEventArgs.KeyboardSession.Start);
            keyStrokeCount.Text = string.Format("Current Key Strokes: {0}",
                sessionStartedEventArgs.KeyboardSession.KeyPressCount);

            notifyIcon.ShowBalloonTip(500, "Session started", "A session was started. All keyboard input will be caught now!", 
                ToolTipIcon.Info);
        }

        private void KeyboardCatcherOnSessionStopping(object sender, SessionStoppingEventArgs sessionStoppingEventArgs)
        {
            using (var sessionData = new SessionData(sessionStoppingEventArgs.SessionName))
            {
                sessionData.TopMost = true;
                sessionData.ShowDialog();

                sessionStoppingEventArgs.SessionName = sessionData.SessionName;
            }
        }

        private void KeyboardCatcherOnSessionStopped(object sender, SessionStoppedEventArgs sessionStoppedEventArgs)
        {
            sessionStartDate.Text = string.Format("Session Active Since: --");
            keyStrokeCount.Text = string.Format("Current Key Strokes: --");

            notifyIcon.ShowBalloonTip(500, "Session stopped",
                string.Format("The session '{0}' was stopped. The keyboard input will no longer be caught!", sessionStoppedEventArgs.KeyboardSession.Name),
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