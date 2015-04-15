using System.Windows.Forms;
using Twainsoft.KeyCatcher.Core.Model.Repositories;

namespace Twainsoft.KeyCatcher.GUI.Session
{
    public partial class SessionsOverview : Form
    {
        private IKeyboardSessions KeyboardSessions { get; set; }

        public SessionsOverview(IKeyboardSessions keyboardSessions)
        {
            InitializeComponent();

            KeyboardSessions = keyboardSessions;
            
            LoadSessions();
        }

        private void LoadSessions()
        {
            
        }
    }
}
