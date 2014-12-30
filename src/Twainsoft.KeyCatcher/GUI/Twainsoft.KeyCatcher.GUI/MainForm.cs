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
    }
}
