using System.Diagnostics;

namespace AntiRKN
{
    public partial class KillProcesses : Form
    {
        internal List<string> processesName = new List<string>();
        public KillProcesses()
        {
            InitializeComponent();
        }

        private void KillProcesses_Load(object sender, EventArgs e)
        {
            killZapret();
            progressBar1.Value = 10;
            killOtherVPN();
            progressBar1.Value = 100;
            this.Close();

        }

        private void killZapret()
        {
            Process[] processes = Process.GetProcessesByName("winws");
            foreach (Process process in processes)
            {
                process.Kill();
                process.Dispose();
            }
        }

        private void killOtherVPN()
        {
            foreach (var name in processesName)
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.Dispose();
                }
            }
        }
    }
}
