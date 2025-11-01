using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiRKN
{
    public partial class KillProcesses : Form
    {
        internal int mode = 0;
        internal List<string> processesName = new List<string>();
        public KillProcesses()
        {
            InitializeComponent();
        }

        private void KillProcesses_Load(object sender, EventArgs e)
        {
            switch (mode)
            {
                case 0:
                    {
                        killZapret();
                        progressBar1.Value = 10;
                        killOtherVPN(90);
                        break;
                    }
                case 2:
                    {
                        killZapret();
                        break;
                    }
                case 1:
                    {
                        killOtherVPN(100);
                        break;
                    }
                default:
                    {
                        
                        break;
                    }
            }
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

        private void killOtherVPN(int ostBar)
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
