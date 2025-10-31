using Microsoft.Win32;
using System.Diagnostics;

namespace RKN_Fix
{
    public partial class Form1 : Form
    {
        List<string[]> otherVPNList = new List<string[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            updateUI();
        }

        private void updateUI()
        {
            checkedListBoxLists.Items.Clear();
            listBoxConfigs.Items.Clear();
            listBoxVPN.Items.Clear();
            List<string> selectedLists = new List<string>();
            foreach (var listName in File.ReadLines("lists/selected.txt"))
            {
                selectedLists.Add(listName);
            }
            foreach (var file in Directory.GetFiles("lists"))
            {
                string fileName = file.Substring(6);
                if (fileName != "selected.txt" && fileName != "rules.txt")
                {
                    checkedListBoxLists.Items.Add(fileName);
                    if (selectedLists.Contains(fileName))
                    {
                        checkedListBoxLists.SetItemChecked(checkedListBoxLists.Items.Count - 1, true);
                    }
                }
            }
            foreach (var file in Directory.GetFiles("pre-configs"))
            {
                listBoxConfigs.Items.Add(file.Substring(12));
            }
            foreach (var vpns in otherVPNList)
            {
                listBoxVPN.Items.Add(!string.IsNullOrEmpty(vpns[0]) ? vpns[0] : vpns[1]);
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
            File.WriteAllText("lists/selected.txt", textForFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "\"" + Application.StartupPath + "lists\\\"");
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
            Process.Start(Application.StartupPath + @"pre-configs\" + textBoxSelect.Text);
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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultConfig))
            {
                Process.Start(Application.StartupPath + @"pre-configs\" + Properties.Settings.Default.defaultConfig);
            }
            else
            {
                MessageBox.Show("Конфиг по умолчанию не выбран! \nНажмите ЛКМ по полю с выбранным конфигом.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Исполнительный файл (*.exe)|*.exe|Батники (*.bat)|*.bat|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = dialog.FileName;
                textBoxName.Text = Path.GetFileName(dialog.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string inFile = textBoxName.Text + "\t" + textBoxPath.Text + "\t" + textBoxArg.Text;
            Properties.Settings.Default.otherVPNs += inFile;
            string[] strings = { textBoxName.Text, textBoxPath.Text, textBoxArg.Text };
            otherVPNList.Add(strings);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteVPN_Click(object sender, EventArgs e)
        {
            int index = listBoxVPN.SelectedIndex;
            if (index < 0) return;
            otherVPNList.RemoveAt(index);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Подтвердите сброс настроек.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Properties.Settings.Default.Reset();
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
            Properties.Settings.Default.autostart = checkBoxAutoStart.Checked;
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (checkBoxAutoStart.Checked)
            {
                rkApp.SetValue("RKN_Fix", Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue("RKN_Fix");
            }
        }
    }
}
