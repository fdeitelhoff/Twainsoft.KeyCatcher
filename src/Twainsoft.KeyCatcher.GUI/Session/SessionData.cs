using System.Drawing;
using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core.Model.Sessions;

namespace Twainsoft.KeyCatcher.GUI.Session
{
    public partial class SessionData : Form
    {
        public ClosingReason ClosingReason { get; private set; }

        private int MaxSessionNameLength { get; set; }

        public string SessionName
        {
            get { return sessionName.Text.Trim(); }
        }

        private SessionData()
        {
            InitializeComponent();

            MaxSessionNameLength = 40;

            charactersLeft.Text = string.Format(charactersLeft.Text, MaxSessionNameLength);
        }

        public SessionData(string name, bool exitApplication, KeyboardSession keyboardSession)
            : this()
        {
            sessionName.Text = name;
            startDateTime.Text = string.Format(startDateTime.Text, keyboardSession.Start);
            overallKeystrokes.Text = string.Format(overallKeystrokes.Text, keyboardSession.KeyPressCount);

            buttonContinue.Enabled = !exitApplication;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            ClosingReason = ClosingReason.Save;

            Close();
        }

        private void buttonDiscard_Click(object sender, System.EventArgs e)
        {
            ClosingReason = ClosingReason.Discard;

            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            ClosingReason = ClosingReason.Continue;

            Close();
        }

        private void sessionName_TextChanged(object sender, System.EventArgs e)
        {
            var charsLeft = MaxSessionNameLength - sessionName.Text.Length;

            charactersLeft.Text = string.Format("{0} Chars left", charsLeft);
            charactersLeft.ForeColor = charsLeft < 0 ? Color.DarkRed : Color.Black;

            buttonSave.Enabled = charsLeft >= 0;
        }
    }
}
