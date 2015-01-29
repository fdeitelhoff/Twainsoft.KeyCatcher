using System.Windows.Forms;

namespace Twainsoft.KeyCatcher.GUI
{
    public partial class SessionData : Form
    {
        public ClosingReason ClosingReason { get; private set; }

        public string SessionName
        {
            get { return sessionName.Text.Trim(); }
        }

        private SessionData()
        {
            InitializeComponent();
        }

        public SessionData(string name, bool exitApplication)
            : this()
        {
            sessionName.Text = name;

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
    }
}
