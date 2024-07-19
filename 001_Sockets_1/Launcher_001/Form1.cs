using System.Diagnostics;

namespace Launcher_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLaunchServer_Click(object sender, EventArgs e)
        {
            var serverPath = Properties.Settings.Default.ServerPath;
            Process.Start(serverPath);
        }

        private void cmdLaunchClient_Click(object sender, EventArgs e)
        {
            var clientPath = Properties.Settings.Default.ClientPath;
            Process.Start(clientPath);
        }
    }
}
