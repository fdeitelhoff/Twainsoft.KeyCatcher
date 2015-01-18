using System.Windows.Forms;

namespace Twainsoft.KeyCatcher.GUI
{
    public partial class SessionData : Form
    {
        public string SessionName
        {
            get { return sessionName.Text.Trim(); }
        }

        private SessionData()
        {
            InitializeComponent();
        }

        public SessionData(string name)
            : this()
        {
            sessionName.Text = name;
        }

        private void sessionName_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
            {
                Close();
            }*/
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonDiscard_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
