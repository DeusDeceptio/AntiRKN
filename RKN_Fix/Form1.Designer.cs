namespace AntiRKN
{
    partial class Form1
    {
        private void ApplyLightTheme()
        {
            // Стандартные системные цвета
            Color defaultBackColor = SystemColors.Control;
            Color defaultForeColor = SystemColors.ControlText;
            Color defaultWindowColor = SystemColors.Window;
            Color defaultControlColor = SystemColors.Control;
            Color defaultTextColor = SystemColors.WindowText;
            Color defaultBorderColor = SystemColors.ActiveBorder;

            // Применение стандартных цветов к форме
            this.BackColor = defaultBackColor;
            this.ForeColor = defaultForeColor;

            // ContextMenuStrip
            if (contextMenuStripNotify != null)
            {
                contextMenuStripNotify.BackColor = defaultBackColor;
                contextMenuStripNotify.ForeColor = defaultForeColor;
                contextMenuStripNotify.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                contextMenuStripNotify.Renderer = null; 
            }

            if (contextMenuStripTextBoxSelect != null)
            {
                contextMenuStripTextBoxSelect.BackColor = defaultBackColor;
                contextMenuStripTextBoxSelect.ForeColor = defaultForeColor;
                contextMenuStripTextBoxSelect.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                contextMenuStripTextBoxSelect.Renderer = null;
            }

            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.BackColor = defaultBackColor;
                contextMenuStrip1.ForeColor = defaultForeColor;
                contextMenuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                contextMenuStrip1.Renderer = null;
            }

            // Кнопки 
            var buttons = new[] { buttonClose, buttonSaveLists, button2, buttonUpdate, buttonStartZapDef,
                         buttonStartZap, buttonOpenExplorer, buttonSaveVPN, buttonDeleteVPN, buttonStartVPN, buttonResetSettings, 
                         buttonAutoConfig, buttonSearchConf, buttonStopAll, buttonStopVPN, buttonStopZapret};
            foreach (var button in buttons)
            {
                if (button != null)
                {
                    button.BackColor = defaultControlColor;
                    button.ForeColor = defaultForeColor;
                    button.FlatStyle = FlatStyle.Standard;
                    button.UseVisualStyleBackColor = true;
                }
            }

            // GroupBox
            var groupBoxes = new[] { groupBox1, groupBox2, groupBox3, groupBox4 };
            foreach (var groupBox in groupBoxes)
            {
                if (groupBox != null)
                {
                    groupBox.BackColor = defaultBackColor;
                    groupBox.ForeColor = defaultForeColor;
                }
            }

            // TextBox 
            var textBoxes = new[] { textBoxSelect, textBoxArg, textBoxPath, textBoxName };
            foreach (var textBox in textBoxes)
            {
                if (textBox != null)
                {
                    textBox.BackColor = defaultWindowColor;
                    textBox.ForeColor = defaultTextColor;
                    textBox.BorderStyle = BorderStyle.Fixed3D;
                }
            }

            // ListBox и CheckedListBox
            var listBoxes = new[] { checkedListBoxLists, listBoxConfigs, listBoxVPN };
            foreach (var listBox in listBoxes)
            {
                if (listBox != null)
                {
                    listBox.BackColor = defaultWindowColor;
                    listBox.ForeColor = defaultTextColor;
                    listBox.BorderStyle = BorderStyle.Fixed3D;
                }
            }

            // Label
            var labels = new[] { label1, label2, label3, label4 };
            foreach (var label in labels)
            {
                if (label != null)
                {
                    label.BackColor = defaultBackColor;
                    label.ForeColor = defaultForeColor;
                    label.UseCompatibleTextRendering = false;
                }
            }

            // CheckBox
            var checkBoxes = new[] { checkBoxQuiet, checkBoxAutoStart, checkBoxTheme };
            foreach (var checkBox in checkBoxes)
            {
                if (checkBox != null)
                {
                    checkBox.BackColor = defaultBackColor;
                    checkBox.ForeColor = defaultForeColor;
                    checkBox.UseCompatibleTextRendering = false;
                }
            }

            // ToolStripMenuItem
            var menuItems = new[] { открытьМенюToolStripMenuItem, выходToolStripMenuItem,
                           toolStripMenuItem1, toolStripMenuItem2, сделатьПоУмолчаниюToolStripMenuItem };
            foreach (var menuItem in menuItems)
            {
                if (menuItem != null)
                {
                    menuItem.BackColor = defaultBackColor;
                    menuItem.ForeColor = defaultForeColor;
                }
            }
        }

        private void ApplyDarkTheme()
        {
            // Основной цвет фона и текста
            Color backColor = Color.FromArgb(32, 32, 32);
            Color foreColor = Color.White;
            Color controlDark = Color.FromArgb(64, 64, 64);
            Color controlLight = Color.FromArgb(48, 48, 48);
            Color borderColor = Color.FromArgb(80, 80, 80);
            Color highlightColor = Color.FromArgb(0, 120, 215);

            // Применение цветов к основным элементам
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            // ContextMenuStrip
            if (contextMenuStripNotify != null)
            {
                contextMenuStripNotify.BackColor = controlDark;
                contextMenuStripNotify.ForeColor = foreColor;
                contextMenuStripNotify.RenderMode = ToolStripRenderMode.Professional;
                contextMenuStripNotify.Renderer = new DarkToolStripRenderer();
            }

            if (contextMenuStripTextBoxSelect != null)
            {
                contextMenuStripTextBoxSelect.BackColor = controlDark;
                contextMenuStripTextBoxSelect.ForeColor = foreColor;
                contextMenuStripTextBoxSelect.RenderMode = ToolStripRenderMode.Professional;
                contextMenuStripTextBoxSelect.Renderer = new DarkToolStripRenderer();
            }

            if (contextMenuStrip1 != null)
            {
                contextMenuStrip1.BackColor = controlDark;
                contextMenuStrip1.ForeColor = foreColor;
                contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
                contextMenuStrip1.Renderer = new DarkToolStripRenderer();
            }

            // Кнопки
            var buttons = new[] { buttonClose, buttonSaveLists, button2, buttonUpdate, buttonStartZapDef,
                         buttonStartZap, buttonOpenExplorer, buttonSaveVPN, buttonDeleteVPN, buttonStartVPN, buttonResetSettings,
                         buttonAutoConfig, buttonSearchConf, buttonStopAll, buttonStopVPN, buttonStopZapret };
            foreach (var button in buttons)
            {
                if (button != null)
                {
                    button.BackColor = controlDark;
                    button.ForeColor = foreColor;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = borderColor;
                    button.FlatAppearance.MouseOverBackColor = controlLight;
                    button.FlatAppearance.MouseDownBackColor = highlightColor;
                }
            }

            // GroupBox
            var groupBoxes = new[] { groupBox1, groupBox2, groupBox3, groupBox4 };
            foreach (var groupBox in groupBoxes)
            {
                if (groupBox != null)
                {
                    groupBox.BackColor = backColor;
                    groupBox.ForeColor = foreColor;
                }
            }

            // TextBox
            var textBoxes = new[] { textBoxSelect, textBoxArg, textBoxPath, textBoxName };
            foreach (var textBox in textBoxes)
            {
                if (textBox != null)
                {
                    textBox.BackColor = controlDark;
                    textBox.ForeColor = foreColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // ListBox и CheckedListBox
            var listBoxes = new[] { checkedListBoxLists, listBoxConfigs, listBoxVPN };
            foreach (var listBox in listBoxes)
            {
                if (listBox != null)
                {
                    listBox.BackColor = controlDark;
                    listBox.ForeColor = foreColor;
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // Label
            var labels = new[] { label1, label2, label3, label4 };
            foreach (var label in labels)
            {
                if (label != null)
                {
                    label.BackColor = backColor;
                    label.ForeColor = foreColor;
                }
            }

            // CheckBox
            var checkBoxes = new[] { checkBoxQuiet, checkBoxAutoStart, checkBoxTheme };
            foreach (var checkBox in checkBoxes)
            {
                if (checkBox != null)
                {
                    checkBox.BackColor = backColor;
                    checkBox.ForeColor = foreColor;
                }
            }

            // ToolStripMenuItem
            var menuItems = new[] { открытьМенюToolStripMenuItem, выходToolStripMenuItem,
                           toolStripMenuItem1, toolStripMenuItem2, сделатьПоУмолчаниюToolStripMenuItem };
            foreach (var menuItem in menuItems)
            {
                if (menuItem != null)
                {
                    menuItem.BackColor = controlDark;
                    menuItem.ForeColor = foreColor;
                }
            }
        }

        public class DarkToolStripRenderer : ToolStripProfessionalRenderer
        {
            public DarkToolStripRenderer() : base(new DarkColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Color.White;
                base.OnRenderItemText(e);
            }
        }

        public class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color MenuStripGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color MenuItemSelected => Color.FromArgb(0, 120, 215);
            public override Color MenuItemBorder => Color.FromArgb(0, 120, 215);
            public override Color MenuBorder => Color.FromArgb(80, 80, 80);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(0, 120, 215);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(0, 120, 215);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(30, 30, 30);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(30, 30, 30);
            public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 45);
            public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 45);
            public override Color SeparatorDark => Color.FromArgb(80, 80, 80);
            public override Color SeparatorLight => Color.FromArgb(80, 80, 80);
        }

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStripNotify = new ContextMenuStrip(components);
            открытьМенюToolStripMenuItem = new ToolStripMenuItem();
            конфигПоУмолчаниюToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            buttonClose = new Button();
            checkedListBoxLists = new CheckedListBox();
            groupBox1 = new GroupBox();
            button2 = new Button();
            buttonSaveLists = new Button();
            buttonUpdate = new Button();
            listBoxConfigs = new ListBox();
            groupBox2 = new GroupBox();
            buttonStopZapret = new Button();
            label1 = new Label();
            buttonStartZapDef = new Button();
            buttonStartZap = new Button();
            textBoxSelect = new TextBox();
            contextMenuStripTextBoxSelect = new ContextMenuStrip(components);
            сделатьПоУмолчаниюToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            groupBox3 = new GroupBox();
            buttonStopVPN = new Button();
            buttonStartVPN = new Button();
            label4 = new Label();
            buttonDeleteVPN = new Button();
            textBoxName = new TextBox();
            listBoxVPN = new ListBox();
            buttonOpenExplorer = new Button();
            buttonSaveVPN = new Button();
            label3 = new Label();
            label2 = new Label();
            textBoxArg = new TextBox();
            textBoxPath = new TextBox();
            groupBox4 = new GroupBox();
            buttonAutoConfig = new Button();
            buttonSearchConf = new Button();
            buttonStopAll = new Button();
            buttonResetSettings = new Button();
            checkBoxTheme = new CheckBox();
            checkBoxAutoStart = new CheckBox();
            checkBoxQuiet = new CheckBox();
            contextMenuStripNotify.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            contextMenuStripTextBoxSelect.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStripNotify;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStripNotify
            // 
            contextMenuStripNotify.Items.AddRange(new ToolStripItem[] { открытьМенюToolStripMenuItem, конфигПоУмолчаниюToolStripMenuItem, выходToolStripMenuItem });
            contextMenuStripNotify.Name = "contextMenuStrip1";
            contextMenuStripNotify.Size = new Size(203, 70);
            // 
            // открытьМенюToolStripMenuItem
            // 
            открытьМенюToolStripMenuItem.Name = "открытьМенюToolStripMenuItem";
            открытьМенюToolStripMenuItem.Size = new Size(202, 22);
            открытьМенюToolStripMenuItem.Text = "Открыть меню";
            открытьМенюToolStripMenuItem.Click += открытьМенюToolStripMenuItem_Click;
            // 
            // конфигПоУмолчаниюToolStripMenuItem
            // 
            конфигПоУмолчаниюToolStripMenuItem.Name = "конфигПоУмолчаниюToolStripMenuItem";
            конфигПоУмолчаниюToolStripMenuItem.Size = new Size(202, 22);
            конфигПоУмолчаниюToolStripMenuItem.Text = "Конфиг по умолчанию";
            конфигПоУмолчаниюToolStripMenuItem.Click += buttonStartZapDef_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(202, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += close_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(656, 73);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(100, 25);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Выход";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += close_Click;
            // 
            // checkedListBoxLists
            // 
            checkedListBoxLists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBoxLists.FormattingEnabled = true;
            checkedListBoxLists.Location = new Point(6, 22);
            checkedListBoxLists.Name = "checkedListBoxLists";
            checkedListBoxLists.Size = new Size(238, 400);
            checkedListBoxLists.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(buttonSaveLists);
            groupBox1.Controls.Add(checkedListBoxLists);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 460);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выбор листов для Zapret";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(144, 429);
            button2.Name = "button2";
            button2.Size = new Size(100, 25);
            button2.TabIndex = 3;
            button2.Text = "Открыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonSaveLists
            // 
            buttonSaveLists.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSaveLists.Location = new Point(6, 429);
            buttonSaveLists.Name = "buttonSaveLists";
            buttonSaveLists.Size = new Size(100, 25);
            buttonSaveLists.TabIndex = 2;
            buttonSaveLists.Text = "Сохранить";
            buttonSaveLists.UseVisualStyleBackColor = true;
            buttonSaveLists.Click += buttonSaveLists_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(518, 22);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(100, 25);
            buttonUpdate.TabIndex = 3;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // listBoxConfigs
            // 
            listBoxConfigs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxConfigs.FormattingEnabled = true;
            listBoxConfigs.Location = new Point(6, 22);
            listBoxConfigs.Name = "listBoxConfigs";
            listBoxConfigs.Size = new Size(238, 349);
            listBoxConfigs.TabIndex = 4;
            listBoxConfigs.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonStopZapret);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(buttonStartZapDef);
            groupBox2.Controls.Add(buttonStartZap);
            groupBox2.Controls.Add(textBoxSelect);
            groupBox2.Controls.Add(listBoxConfigs);
            groupBox2.Location = new Point(268, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 460);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Конфиги Zapret";
            // 
            // buttonStopZapret
            // 
            buttonStopZapret.Location = new Point(162, 375);
            buttonStopZapret.Name = "buttonStopZapret";
            buttonStopZapret.Size = new Size(80, 20);
            buttonStopZapret.TabIndex = 16;
            buttonStopZapret.Tag = "2";
            buttonStopZapret.Text = "Остановить";
            buttonStopZapret.UseVisualStyleBackColor = true;
            buttonStopZapret.Click += buttonStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 381);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 6;
            label1.Text = "Выбранно:";
            // 
            // buttonStartZapDef
            // 
            buttonStartZapDef.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonStartZapDef.Font = new Font("Segoe UI", 7.5F);
            buttonStartZapDef.Location = new Point(114, 429);
            buttonStartZapDef.Name = "buttonStartZapDef";
            buttonStartZapDef.Size = new Size(130, 25);
            buttonStartZapDef.TabIndex = 1;
            buttonStartZapDef.Text = "Запуск по умолчанию";
            buttonStartZapDef.UseVisualStyleBackColor = true;
            buttonStartZapDef.Click += buttonStartZapDef_Click;
            // 
            // buttonStartZap
            // 
            buttonStartZap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonStartZap.Location = new Point(6, 429);
            buttonStartZap.Name = "buttonStartZap";
            buttonStartZap.Size = new Size(100, 25);
            buttonStartZap.TabIndex = 4;
            buttonStartZap.Text = "Запустить";
            buttonStartZap.UseVisualStyleBackColor = true;
            buttonStartZap.Click += buttonStartZap_Click;
            // 
            // textBoxSelect
            // 
            textBoxSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSelect.ContextMenuStrip = contextMenuStripTextBoxSelect;
            textBoxSelect.Location = new Point(6, 399);
            textBoxSelect.Name = "textBoxSelect";
            textBoxSelect.ReadOnly = true;
            textBoxSelect.Size = new Size(238, 23);
            textBoxSelect.TabIndex = 5;
            // 
            // contextMenuStripTextBoxSelect
            // 
            contextMenuStripTextBoxSelect.Items.AddRange(new ToolStripItem[] { сделатьПоУмолчаниюToolStripMenuItem });
            contextMenuStripTextBoxSelect.Name = "contextMenuStripTextBoxSelect";
            contextMenuStripTextBoxSelect.Size = new Size(199, 26);
            // 
            // сделатьПоУмолчаниюToolStripMenuItem
            // 
            сделатьПоУмолчаниюToolStripMenuItem.Font = new Font("Segoe UI", 8F);
            сделатьПоУмолчаниюToolStripMenuItem.Name = "сделатьПоУмолчаниюToolStripMenuItem";
            сделатьПоУмолчаниюToolStripMenuItem.Size = new Size(198, 22);
            сделатьПоУмолчаниюToolStripMenuItem.Text = "Сделать по умолчанию";
            сделатьПоУмолчаниюToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            сделатьПоУмолчаниюToolStripMenuItem.Click += сделатьПоУмолчаниюToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(157, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(156, 22);
            toolStripMenuItem1.Text = "Открыть меню";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(156, 22);
            toolStripMenuItem2.Text = "Выход";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonStopVPN);
            groupBox3.Controls.Add(buttonStartVPN);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(buttonDeleteVPN);
            groupBox3.Controls.Add(textBoxName);
            groupBox3.Controls.Add(listBoxVPN);
            groupBox3.Controls.Add(buttonOpenExplorer);
            groupBox3.Controls.Add(buttonSaveVPN);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(textBoxArg);
            groupBox3.Controls.Add(textBoxPath);
            groupBox3.Location = new Point(524, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 460);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Прочие обходы";
            // 
            // buttonStopVPN
            // 
            buttonStopVPN.Location = new Point(144, 428);
            buttonStopVPN.Name = "buttonStopVPN";
            buttonStopVPN.Size = new Size(100, 25);
            buttonStopVPN.TabIndex = 9;
            buttonStopVPN.Tag = "1";
            buttonStopVPN.Text = "Остановить";
            buttonStopVPN.UseVisualStyleBackColor = true;
            buttonStopVPN.Click += buttonStop_Click;
            // 
            // buttonStartVPN
            // 
            buttonStartVPN.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonStartVPN.Location = new Point(6, 429);
            buttonStartVPN.Name = "buttonStartVPN";
            buttonStartVPN.Size = new Size(100, 25);
            buttonStartVPN.TabIndex = 15;
            buttonStartVPN.Text = "Запустить";
            buttonStartVPN.UseVisualStyleBackColor = true;
            buttonStartVPN.Click += buttonStartVPN_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 329);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 13;
            label4.Text = "Название";
            // 
            // buttonDeleteVPN
            // 
            buttonDeleteVPN.Location = new Point(6, 257);
            buttonDeleteVPN.Name = "buttonDeleteVPN";
            buttonDeleteVPN.Size = new Size(100, 25);
            buttonDeleteVPN.TabIndex = 14;
            buttonDeleteVPN.Text = "Удалить";
            buttonDeleteVPN.UseVisualStyleBackColor = true;
            buttonDeleteVPN.Click += buttonDeleteVPN_Click;
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.ContextMenuStrip = contextMenuStripTextBoxSelect;
            textBoxName.Location = new Point(6, 347);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(238, 23);
            textBoxName.TabIndex = 12;
            // 
            // listBoxVPN
            // 
            listBoxVPN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxVPN.FormattingEnabled = true;
            listBoxVPN.Location = new Point(6, 22);
            listBoxVPN.Name = "listBoxVPN";
            listBoxVPN.Size = new Size(238, 229);
            listBoxVPN.TabIndex = 7;
            listBoxVPN.SelectedIndexChanged += listBoxVPN_SelectedIndexChanged;
            // 
            // buttonOpenExplorer
            // 
            buttonOpenExplorer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOpenExplorer.Font = new Font("Segoe UI", 9F);
            buttonOpenExplorer.Location = new Point(219, 302);
            buttonOpenExplorer.Name = "buttonOpenExplorer";
            buttonOpenExplorer.Size = new Size(25, 25);
            buttonOpenExplorer.TabIndex = 7;
            buttonOpenExplorer.Text = "...";
            buttonOpenExplorer.UseVisualStyleBackColor = true;
            buttonOpenExplorer.Click += buttonOpenExplorer_Click;
            // 
            // buttonSaveVPN
            // 
            buttonSaveVPN.Location = new Point(144, 257);
            buttonSaveVPN.Name = "buttonSaveVPN";
            buttonSaveVPN.Size = new Size(100, 25);
            buttonSaveVPN.TabIndex = 11;
            buttonSaveVPN.Text = "Сохранить";
            buttonSaveVPN.UseVisualStyleBackColor = true;
            buttonSaveVPN.Click += buttonSaveVPN_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 373);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 10;
            label3.Text = "Аргументы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 285);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 8;
            label2.Text = "Путь";
            // 
            // textBoxArg
            // 
            textBoxArg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxArg.ContextMenuStrip = contextMenuStripTextBoxSelect;
            textBoxArg.Location = new Point(6, 391);
            textBoxArg.Name = "textBoxArg";
            textBoxArg.Size = new Size(238, 23);
            textBoxArg.TabIndex = 9;
            // 
            // textBoxPath
            // 
            textBoxPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPath.ContextMenuStrip = contextMenuStripTextBoxSelect;
            textBoxPath.Location = new Point(6, 303);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(212, 23);
            textBoxPath.TabIndex = 7;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(buttonAutoConfig);
            groupBox4.Controls.Add(buttonSearchConf);
            groupBox4.Controls.Add(buttonStopAll);
            groupBox4.Controls.Add(buttonResetSettings);
            groupBox4.Controls.Add(checkBoxTheme);
            groupBox4.Controls.Add(checkBoxAutoStart);
            groupBox4.Controls.Add(checkBoxQuiet);
            groupBox4.Controls.Add(buttonClose);
            groupBox4.Controls.Add(buttonUpdate);
            groupBox4.Location = new Point(12, 472);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(762, 107);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Настройки";
            // 
            // buttonAutoConfig
            // 
            buttonAutoConfig.Font = new Font("Segoe UI", 9F);
            buttonAutoConfig.Location = new Point(144, 73);
            buttonAutoConfig.Name = "buttonAutoConfig";
            buttonAutoConfig.Size = new Size(130, 25);
            buttonAutoConfig.TabIndex = 10;
            buttonAutoConfig.Text = "Автозапуск конфига";
            buttonAutoConfig.UseVisualStyleBackColor = true;
            buttonAutoConfig.Click += buttonAutoConfig_Click;
            // 
            // buttonSearchConf
            // 
            buttonSearchConf.Font = new Font("Segoe UI", 8F);
            buttonSearchConf.Location = new Point(144, 22);
            buttonSearchConf.Name = "buttonSearchConf";
            buttonSearchConf.Size = new Size(130, 25);
            buttonSearchConf.TabIndex = 9;
            buttonSearchConf.Text = "Авто-поиск конфига";
            buttonSearchConf.UseVisualStyleBackColor = true;
            buttonSearchConf.Click += buttonSearchConf_Click;
            // 
            // buttonStopAll
            // 
            buttonStopAll.Location = new Point(518, 73);
            buttonStopAll.Name = "buttonStopAll";
            buttonStopAll.Size = new Size(100, 25);
            buttonStopAll.TabIndex = 8;
            buttonStopAll.Tag = "0";
            buttonStopAll.Text = "Остановить все";
            buttonStopAll.UseVisualStyleBackColor = true;
            buttonStopAll.Click += buttonStop_Click;
            // 
            // buttonResetSettings
            // 
            buttonResetSettings.Location = new Point(656, 22);
            buttonResetSettings.Name = "buttonResetSettings";
            buttonResetSettings.Size = new Size(100, 25);
            buttonResetSettings.TabIndex = 7;
            buttonResetSettings.Text = "Сбросить";
            buttonResetSettings.UseVisualStyleBackColor = true;
            buttonResetSettings.Click += buttonResetSettings_Click;
            // 
            // checkBoxTheme
            // 
            checkBoxTheme.AutoSize = true;
            checkBoxTheme.Location = new Point(15, 82);
            checkBoxTheme.Name = "checkBoxTheme";
            checkBoxTheme.Size = new Size(99, 19);
            checkBoxTheme.TabIndex = 6;
            checkBoxTheme.Text = "Светлая тема";
            checkBoxTheme.UseVisualStyleBackColor = true;
            checkBoxTheme.CheckedChanged += checkBoxTheme_CheckedChanged;
            // 
            // checkBoxAutoStart
            // 
            checkBoxAutoStart.AutoSize = true;
            checkBoxAutoStart.Location = new Point(15, 52);
            checkBoxAutoStart.Name = "checkBoxAutoStart";
            checkBoxAutoStart.Size = new Size(88, 19);
            checkBoxAutoStart.TabIndex = 5;
            checkBoxAutoStart.Text = "Автозапуск";
            checkBoxAutoStart.UseVisualStyleBackColor = true;
            checkBoxAutoStart.CheckedChanged += checkBoxAutoStart_CheckedChanged;
            // 
            // checkBoxQuiet
            // 
            checkBoxQuiet.AutoSize = true;
            checkBoxQuiet.Location = new Point(15, 22);
            checkBoxQuiet.Name = "checkBoxQuiet";
            checkBoxQuiet.Size = new Size(98, 19);
            checkBoxQuiet.TabIndex = 4;
            checkBoxQuiet.Text = "Тихий запуск";
            checkBoxQuiet.UseVisualStyleBackColor = true;
            checkBoxQuiet.CheckedChanged += checkBoxQuiet_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 591);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(802, 630);
            MinimumSize = new Size(802, 630);
            Name = "Form1";
            Text = "AntiRKN";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStripNotify.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            contextMenuStripTextBoxSelect.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private Button buttonClose;
        private ContextMenuStrip contextMenuStripNotify;
        private ToolStripMenuItem открытьМенюToolStripMenuItem;
        private CheckedListBox checkedListBoxLists;
        private ToolStripMenuItem выходToolStripMenuItem;
        private GroupBox groupBox1;
        private Button buttonSaveLists;
        private Button button2;
        private Button buttonUpdate;
        private ListBox listBoxConfigs;
        private GroupBox groupBox2;
        private Button buttonStartZapDef;
        private Button buttonStartZap;
        private TextBox textBoxSelect;
        private Label label1;
        private ContextMenuStrip contextMenuStripTextBoxSelect;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem сделатьПоУмолчаниюToolStripMenuItem;
        private GroupBox groupBox3;
        private Button buttonSaveVPN;
        private Label label3;
        private TextBox textBoxArg;
        private Button buttonOpenExplorer;
        private Label label2;
        private TextBox textBoxPath;
        private Label label4;
        private TextBox textBoxName;
        private ListBox listBoxVPN;
        private Button buttonDeleteVPN;
        private Button buttonStartVPN;
        private GroupBox groupBox4;
        private CheckBox checkBoxTheme;
        private CheckBox checkBoxAutoStart;
        private CheckBox checkBoxQuiet;
        private Button buttonResetSettings;
        private ToolStripMenuItem конфигПоУмолчаниюToolStripMenuItem;
        private Button buttonStopAll;
        private Button buttonStopVPN;
        private Button buttonStopZapret;
        private Button buttonSearchConf;
        private Button buttonAutoConfig;
    }
}
