using System.Diagnostics;

namespace AntiRKN
{
    public partial class Form1 : Form
    {
        List<string[]> otherVPNList = new List<string[]>();
        string pathConfigs = Application.StartupPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "pre-configs"))
                pathConfigs += "pre-configs\\";
            this.notifyIcon1.Visible = false;
            readSettings();
            updateUI();

            checkBoxTheme.Checked = !Properties.Settings.Default.isDark;
            if (checkBoxTheme.Checked)
                ApplyLightTheme();
            else
                ApplyDarkTheme();
            
            checkBoxAutoStart.Checked = Properties.Settings.Default.autostart;

            checkBoxQuiet.Checked = Properties.Settings.Default.quietStart;
            if (Properties.Settings.Default.quietStart)
                hideForm();

            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.buttonSearchConf, "Активна, если в вашей сборке есть \"АВТО - ПОИСК пре - конфига.exe\"");
            toolTip1.SetToolTip(this.buttonAutoConfig, "Активна, если в вашей сборке есть \"Установить как службу в АВТОЗАПУСК v2.exe\"");
            toolTip1.SetToolTip(groupBox1, "Выбор списков доступен для сборок поддерживающих эту функцию");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updateUI();
        }

        private void updateUI()
        {
            updateBoxLists();
            updateConfigList();
            updateVPNList();
            updateContextMenuNotify();
        }

        private void updateContextMenuNotify()
        {
            if (otherVPNList.Count == 0) return;
            for (int i = 0; i < otherVPNList.Count; i++)
            {
                ToolStripMenuItem toolStripButton = new ToolStripMenuItem();
                toolStripButton.Text =
                    !string.IsNullOrEmpty(otherVPNList[i][0].Trim()) ? otherVPNList[i][0]
                                           : Path.GetFileName(otherVPNList[i][1]);
                toolStripButton.Tag = i;
                toolStripButton.Click += otherVPNinContMenu_Click;
                contextMenuStripNotify.Items.Insert(i + 2, toolStripButton);
            }
        }

        private void updateBoxLists()
        {
            checkedListBoxLists.Items.Clear();
            List<string> selectedLists = new List<string>();
            if (File.Exists(Application.StartupPath + "lists/selected.txt"))
            {
                foreach (var listName in File.ReadLines(Application.StartupPath + "lists/selected.txt"))
                {
                    selectedLists.Add(listName);
                }
            }
            
            foreach (var file in Directory.GetFiles(Application.StartupPath + "lists"))
            {
                string fileName = Path.GetFileName(file);
                if (fileName != "selected.txt" && fileName != "rules.txt")
                {
                    checkedListBoxLists.Items.Add(fileName);
                    if (selectedLists.Contains(fileName))
                    {
                        checkedListBoxLists.SetItemChecked(checkedListBoxLists.Items.Count - 1, true);
                    }
                }
            }
        }

        private void updateConfigList()
        {
            listBoxConfigs.Items.Clear();
            textBoxSelect.Text = string.Empty;
            foreach (var file in Directory.GetFiles(pathConfigs, "*.bat"))
            {
                listBoxConfigs.Items.Add(Path.GetFileName(file));
            }
        }

        private void updateVPNList()
        {
            listBoxVPN.Items.Clear();
            textBoxArg.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxPath.Text = string.Empty;
            foreach (var vpns in otherVPNList)
            {
                listBoxVPN.Items.Add(!string.IsNullOrEmpty(vpns[0].Trim()) ? vpns[0] : Path.GetFileName(vpns[1]));
            }
        }

        private void hideForm()
        {
            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            this.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openForm();
        }

        private void открытьМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm();
        }

        private void openForm()
        {
            this.notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.None)
            {
                e.Cancel = true;
                hideForm();
                return;
            }
            saveListVPN();
            Properties.Settings.Default.Save();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Show();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonSaveLists_Click(object sender, EventArgs e)
        {
            var lists = checkedListBoxLists.CheckedItems;
            string textForFile = "";
            foreach (string list in lists)
            {
                textForFile += list + "\n";
            }
            File.WriteAllText(Application.StartupPath + "lists/selected.txt", textForFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", "\"" + Application.StartupPath + "lists\\\"");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxConfigs.SelectedIndex;
            if (index < 0) return;
            textBoxSelect.Text = listBoxConfigs.SelectedItem.ToString();
        }

        private void buttonStartZap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSelect.Text))
            {
                MessageBox.Show("Выберете конфиг!");
                return;
            }
            try
            {
                Process.Start(pathConfigs + textBoxSelect.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void сделатьПоУмолчаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSelect.Text))
            {
                Properties.Settings.Default.defaultConfig = textBoxSelect.Text;
            }
            else
            {
                MessageBox.Show("Конфиг не выбран!");
            }
        }

        private void buttonStartZapDef_Click(object sender, EventArgs e)
        {
            startDefConf();
        }

        private void startDefConf()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultConfig))
            {
                try
                {
                    Process.Start(pathConfigs + Properties.Settings.Default.defaultConfig);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Конфиг по умолчанию не выбран! \nНажмите ЛКМ по полю с выбранным конфигом.");
            }
        }

        private void buttonOpenExplorer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Исполнительный файл (*.exe)|*.exe|Батники (*.bat)|*.bat|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dialog.FileName;
                textBoxName.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void buttonSaveVPN_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text == "") return;
            string inFile = textBoxName.Text + "\t" + textBoxPath.Text + "\t" + textBoxArg.Text;
            Properties.Settings.Default.otherVPNs += inFile;
            string[] strings = { textBoxName.Text, textBoxPath.Text, textBoxArg.Text };
            otherVPNList.Add(strings);
            updateVPNList();
        }

        private void listBoxVPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxVPN.SelectedIndex;
            if (index < 0) return;
            textBoxName.Text = otherVPNList[index][0];
            textBoxPath.Text = otherVPNList[index][1];
            textBoxArg.Text = otherVPNList[index][2];

        }

        private void buttonStartVPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPath.Text)) return;
            try
            {
                Process.Start(textBoxPath.Text, textBoxArg.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonDeleteVPN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление записи.", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            int index = listBoxVPN.SelectedIndex;
            if (index < 0) return;
            otherVPNList.RemoveAt(index);
            updateVPNList();
        }

        private void checkBoxTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTheme.Checked)
            {
                Properties.Settings.Default.isDark = false;
                ApplyLightTheme();
            }
            else
            {
                Properties.Settings.Default.isDark = true;
                ApplyDarkTheme();
            }
        }

        private void buttonResetSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердите сброс настроек.", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            otherVPNList.Clear();
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();

        }

        internal void readSettings()
        {
            string[] strings = Properties.Settings.Default.otherVPNs.Split('\n');
            foreach (string line in strings)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                otherVPNList.Add(line.Split('\t'));
            }
        }

        internal void saveListVPN()
        {
            string text = "";
            foreach (var list in otherVPNList)
            {
                text += list[0] + "\t" + list[1] + "\t" + list[2] + "\n";
            }
            Properties.Settings.Default.otherVPNs = text;
        }

        private void checkBoxQuiet_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.quietStart = checkBoxQuiet.Checked;
        }

        private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            Properties.Settings.Default.autostart = checkBoxAutoStart.Checked;
            if (checkBoxAutoStart.Checked)
            {
                rkApp.SetValue("AntiRKN", Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue("AntiRKN");
            }              
        }

        private void otherVPNinContMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item.Tag == null) return;
            int index = (int)item.Tag;
            string path = otherVPNList[index][1];
            string arg = otherVPNList[index][2];
            try
            {
                Process.Start(path, arg);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            int mode = Convert.ToInt32((sender as Button).Tag);
            KillProcesses killProcesses = new KillProcesses();
            foreach (var item in otherVPNList)
            {
                killProcesses.processesName.Add(Path.GetFileName(item[1]).Replace(".exe", ""));
            }
            killProcesses.ShowDialog();
        }

        private void buttonSearchConf_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "АВТО-ПОИСК пре-конфига.exe")) return;
            try
            {
                Process.Start(Application.StartupPath + "АВТО-ПОИСК пре-конфига.exe");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonAutoConfig_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "Установить как службу в АВТОЗАПУСК v2.exe")) return;
            try
            {
                Process.Start(Application.StartupPath + "Установить как службу в АВТОЗАПУСК v2.exe");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
