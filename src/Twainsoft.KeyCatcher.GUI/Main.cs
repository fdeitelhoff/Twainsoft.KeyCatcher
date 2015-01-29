using System;
using System.Threading;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core.Keyboard;
using Twainsoft.KeyCatcher.Core.Keyboard.EventsArgs;
using Twainsoft.KeyCatcher.Core.Keyboard.Sessions;
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
            // TODO: Move the Starting/Started events into the status changed event? Strictly speaking those are status changes too!
            KeyboardCatcher.SessionStarting += KeyboardCatcherOnSessionStarting;
            KeyboardCatcher.SessionStarted += KeyboardCatcherOnSessionStarted;
            KeyboardCatcher.SessionStatusChanging += KeyboardCatcherOnSessionStatusChanging;
            KeyboardCatcher.SessionStatusChanged += KeyboardCatcherOnSessionStatusChanged;

            // Catch all key strokes (KeyDown + KeyUp).
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
            // Ask the user if the current active session should be stopped for the new one.
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

        private void KeyboardCatcherOnSessionStatusChanging(object sender, SessionStatusChangingEventArgs sessionStoppingEventArgs)
        {
            // We need to invoke the stopping event within a new thread.
            // The reason is: if its in the same thread we have a 4-5 seconds blocking and the session data windows isn't accessible.
            new Thread(ShowSessionDataWindow).Start(sessionStoppingEventArgs);
        }

        private void ShowSessionDataWindow(object parameter)
        {
            var eventArgs = parameter as SessionStatusChangingEventArgs;

            if (eventArgs == null)
            {
                throw new ArgumentNullException("parameter");
            }

            using (var sessionData = new SessionData(eventArgs.SessionName, eventArgs.ExitApplication))
            {
                sessionData.BringToFront();
                sessionData.ShowDialog();

                switch (sessionData.ClosingReason)
                {
                    case ClosingReason.Save:
                        KeyboardCatcher.SaveSession(sessionData.SessionName);
                        break;
                    case ClosingReason.Discard:
                        KeyboardCatcher.DiscardSession();
                        break;
                    case ClosingReason.Continue:
                        KeyboardCatcher.ContinueSession();
                        break;
                }
            }
        }

        private void KeyboardCatcherOnSessionStatusChanged(object sender, SessionStatusChangedEventArgs sessionStatusChangedEventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<SessionStatusChangedEventArgs>(KeyboardCatcherOnSessionStatusChanged), sender,
                    sessionStatusChangedEventArgs);
            }

            if (sessionStatusChangedEventArgs.ExitApplication)
            {
                Close();
            }
            else switch (sessionStatusChangedEventArgs.StatusChange)
            {
                case SessionStatus.Saved:
                    sessionStartDate.Text = string.Format("Session Active Since: --");
                    keyStrokeCount.Text = string.Format("Current Key Strokes: --");
                    notifyIcon.ShowBalloonTip(500, "Session saved",
                        string.Format(
                            "The session '{0}' was stopped and saved. The keyboard input will no longer be caught!",
                            sessionStatusChangedEventArgs.KeyboardSession.Name),
                        ToolTipIcon.Info);
                    break;
                case SessionStatus.Discarded:
                    sessionStartDate.Text = string.Format("Session Active Since: --");
                    keyStrokeCount.Text = string.Format("Current Key Strokes: --");
                    notifyIcon.ShowBalloonTip(500, "Session discarded",
                        "The session was discarded and therefore deleted. The keyboard input will no longer be caught!",
                        ToolTipIcon.Info);
                    break;
                case SessionStatus.Continued:
                    notifyIcon.ShowBalloonTip(500, "Session continued",
                        "The session was continued. All keyboard input is caught again!", ToolTipIcon.Info);
                    break;
            }
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KeyboardCatcher.IsSessionActive)
            {
                // TODO: The cancellation is invalid due to the events. The form get's closed in the background.
                if (MessageBox.Show(this,
                    "There's currently an active session. Would you like to close the application and end the session?",
                    "Session Active", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                    DialogResult.Yes)
                {
                    KeyboardCatcher.CancelSession(true);
                }

                e.Cancel = true;
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
