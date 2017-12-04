namespace Search
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroShell1 = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroAppButton1 = new DevComponents.DotNetBar.Metro.MetroAppButton();
            this.create_graph = new DevComponents.DotNetBar.ButtonItem();
            this.open_graph = new DevComponents.DotNetBar.ButtonItem();
            this.save_graph = new DevComponents.DotNetBar.ButtonItem();
            this.save_report = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tracetxt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.postdelay = new DevComponents.Editors.IntegerInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.predelay = new DevComponents.Editors.IntegerInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.delay = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.goal_node = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.start_node = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.algorithms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.wpfHost = new System.Windows.Forms.Integration.ElementHost();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd_trace = new System.Windows.Forms.SaveFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.rfd = new System.Windows.Forms.SaveFileDialog();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postdelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).BeginInit();
            this.SuspendLayout();
            // 
            // metroShell1
            // 
            this.metroShell1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell1.CaptionVisible = true;
            this.metroShell1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroShell1.ForeColor = System.Drawing.Color.Black;
            this.metroShell1.HelpButtonText = null;
            this.metroShell1.HelpButtonVisible = false;
            this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroAppButton1,
            this.buttonItem3,
            this.buttonItem1});
            this.metroShell1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.metroShell1.Location = new System.Drawing.Point(1, 1);
            this.metroShell1.Name = "metroShell1";
            this.metroShell1.SettingsButtonVisible = false;
            this.metroShell1.Size = new System.Drawing.Size(1085, 50);
            this.metroShell1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell1.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell1.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell1.SystemText.QatDialogOkButton = "OK";
            this.metroShell1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell1.TabIndex = 1;
            this.metroShell1.TabStripFont = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell1.Text = "metroShell1";
            // 
            // metroAppButton1
            // 
            this.metroAppButton1.AutoExpandOnClick = true;
            this.metroAppButton1.CanCustomize = false;
            this.metroAppButton1.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.metroAppButton1.ImagePaddingHorizontal = 0;
            this.metroAppButton1.ImagePaddingVertical = 0;
            this.metroAppButton1.Name = "metroAppButton1";
            this.metroAppButton1.ShowSubItems = false;
            this.metroAppButton1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.create_graph,
            this.open_graph,
            this.save_graph,
            this.save_report});
            this.metroAppButton1.Text = "&File";
            // 
            // create_graph
            // 
            this.create_graph.Name = "create_graph";
            this.create_graph.Text = "New graph";
            this.create_graph.Click += new System.EventHandler(this.create_graph_Click);
            // 
            // open_graph
            // 
            this.open_graph.Name = "open_graph";
            this.open_graph.Text = "Open";
            this.open_graph.Click += new System.EventHandler(this.open_graph_Click);
            // 
            // save_graph
            // 
            this.save_graph.Name = "save_graph";
            this.save_graph.Text = "Save";
            this.save_graph.Click += new System.EventHandler(this.save_graph_Click);
            // 
            // save_report
            // 
            this.save_report.Name = "save_report";
            this.save_report.Text = "Save Full Trace";
            this.save_report.Click += new System.EventHandler(this.save_report_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Add node";
            this.buttonItem3.Click += new System.EventHandler(this.add_node_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "Add edge";
            this.buttonItem1.Click += new System.EventHandler(this.add_edge_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tracetxt);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(1, 492);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1085, 111);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // tracetxt
            // 
            this.tracetxt.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tracetxt.Border.Class = "TextBoxBorder";
            this.tracetxt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tracetxt.DisabledBackColor = System.Drawing.Color.White;
            this.tracetxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tracetxt.ForeColor = System.Drawing.Color.Black;
            this.tracetxt.Location = new System.Drawing.Point(0, 0);
            this.tracetxt.Multiline = true;
            this.tracetxt.Name = "tracetxt";
            this.tracetxt.PreventEnterBeep = true;
            this.tracetxt.ReadOnly = true;
            this.tracetxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tracetxt.Size = new System.Drawing.Size(1085, 111);
            this.tracetxt.TabIndex = 0;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.superTabControl1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx2.Location = new System.Drawing.Point(775, 51);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(311, 441);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 6;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(311, 441);
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.buttonX2);
            this.superTabControlPanel2.Controls.Add(this.buttonX1);
            this.superTabControlPanel2.Controls.Add(this.postdelay);
            this.superTabControlPanel2.Controls.Add(this.labelX6);
            this.superTabControlPanel2.Controls.Add(this.predelay);
            this.superTabControlPanel2.Controls.Add(this.labelX5);
            this.superTabControlPanel2.Controls.Add(this.delay);
            this.superTabControlPanel2.Controls.Add(this.labelX4);
            this.superTabControlPanel2.Controls.Add(this.goal_node);
            this.superTabControlPanel2.Controls.Add(this.labelX3);
            this.superTabControlPanel2.Controls.Add(this.start_node);
            this.superTabControlPanel2.Controls.Add(this.labelX2);
            this.superTabControlPanel2.Controls.Add(this.algorithms);
            this.superTabControlPanel2.Controls.Add(this.labelX1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 23);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(311, 418);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonX2.Location = new System.Drawing.Point(0, 348);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(311, 36);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 14;
            this.buttonX2.Text = "Benchmark All Algorithms";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonX1.Location = new System.Drawing.Point(0, 312);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(311, 36);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 13;
            this.buttonX1.Text = "Run";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // postdelay
            // 
            this.postdelay.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.postdelay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.postdelay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.postdelay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.postdelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.postdelay.ForeColor = System.Drawing.Color.Black;
            this.postdelay.Location = new System.Drawing.Point(0, 292);
            this.postdelay.Name = "postdelay";
            this.postdelay.ShowUpDown = true;
            this.postdelay.Size = new System.Drawing.Size(311, 20);
            this.postdelay.TabIndex = 12;
            this.postdelay.UseWaitCursor = true;
            this.postdelay.Value = 400;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(0, 260);
            this.labelX6.Name = "labelX6";
            this.labelX6.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX6.Size = new System.Drawing.Size(311, 32);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "Node Post-Visit Delay";
            // 
            // predelay
            // 
            this.predelay.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.predelay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.predelay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.predelay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.predelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.predelay.ForeColor = System.Drawing.Color.Black;
            this.predelay.Location = new System.Drawing.Point(0, 240);
            this.predelay.Name = "predelay";
            this.predelay.ShowUpDown = true;
            this.predelay.Size = new System.Drawing.Size(311, 20);
            this.predelay.TabIndex = 10;
            this.predelay.Value = 400;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(0, 208);
            this.labelX5.Name = "labelX5";
            this.labelX5.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX5.Size = new System.Drawing.Size(311, 32);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Node Pre-Visit Delay";
            // 
            // delay
            // 
            this.delay.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.delay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.delay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.delay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.delay.Dock = System.Windows.Forms.DockStyle.Top;
            this.delay.ForeColor = System.Drawing.Color.Black;
            this.delay.Location = new System.Drawing.Point(0, 188);
            this.delay.Name = "delay";
            this.delay.ShowUpDown = true;
            this.delay.Size = new System.Drawing.Size(311, 20);
            this.delay.TabIndex = 8;
            this.delay.Value = 400;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(0, 156);
            this.labelX4.Name = "labelX4";
            this.labelX4.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX4.Size = new System.Drawing.Size(311, 32);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Node Visit Delay";
            // 
            // goal_node
            // 
            this.goal_node.DisplayMember = "Text";
            this.goal_node.Dock = System.Windows.Forms.DockStyle.Top;
            this.goal_node.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.goal_node.ForeColor = System.Drawing.Color.Black;
            this.goal_node.FormattingEnabled = true;
            this.goal_node.ItemHeight = 14;
            this.goal_node.Location = new System.Drawing.Point(0, 136);
            this.goal_node.Name = "goal_node";
            this.goal_node.Size = new System.Drawing.Size(311, 20);
            this.goal_node.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.goal_node.TabIndex = 6;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(0, 104);
            this.labelX3.Name = "labelX3";
            this.labelX3.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX3.Size = new System.Drawing.Size(311, 32);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Final State (Node)";
            // 
            // start_node
            // 
            this.start_node.DisplayMember = "Text";
            this.start_node.Dock = System.Windows.Forms.DockStyle.Top;
            this.start_node.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.start_node.ForeColor = System.Drawing.Color.Black;
            this.start_node.FormattingEnabled = true;
            this.start_node.ItemHeight = 14;
            this.start_node.Location = new System.Drawing.Point(0, 84);
            this.start_node.Name = "start_node";
            this.start_node.Size = new System.Drawing.Size(311, 20);
            this.start_node.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.start_node.TabIndex = 4;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(0, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX2.Size = new System.Drawing.Size(311, 32);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Initial State (Node)";
            // 
            // algorithms
            // 
            this.algorithms.DisplayMember = "Text";
            this.algorithms.Dock = System.Windows.Forms.DockStyle.Top;
            this.algorithms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.algorithms.ForeColor = System.Drawing.Color.Black;
            this.algorithms.FormattingEnabled = true;
            this.algorithms.ItemHeight = 14;
            this.algorithms.Location = new System.Drawing.Point(0, 32);
            this.algorithms.Name = "algorithms";
            this.algorithms.Size = new System.Drawing.Size(311, 20);
            this.algorithms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.algorithms.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.SingleLineColor = System.Drawing.Color.Transparent;
            this.labelX1.Size = new System.Drawing.Size(311, 32);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Search Algorithm";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "Execution";
            // 
            // wpfHost
            // 
            this.wpfHost.BackColor = System.Drawing.Color.White;
            this.wpfHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfHost.ForeColor = System.Drawing.Color.Black;
            this.wpfHost.Location = new System.Drawing.Point(1, 51);
            this.wpfHost.Name = "wpfHost";
            this.wpfHost.Size = new System.Drawing.Size(774, 441);
            this.wpfHost.TabIndex = 10;
            this.wpfHost.Text = "elementHost1";
            this.wpfHost.Child = null;
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "txt";
            this.ofd.Filter = "Text Files|*.txt|Xml Files|*.xml";
            // 
            // sfd_trace
            // 
            this.sfd_trace.Filter = "Text Files|*.txt";
            // 
            // sfd
            // 
            this.sfd.Filter = "Text Files|*.txt|Xml Files|*.xml";
            // 
            // rfd
            // 
            this.rfd.Filter = "PDF Files|*.pdf";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 604);
            this.Controls.Add(this.wpfHost);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.metroShell1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Search Algorithms Demo";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.postdelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Metro.MetroShell metroShell1;
        private DevComponents.DotNetBar.Metro.MetroAppButton metroAppButton1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.ButtonItem create_graph;
        private DevComponents.DotNetBar.ButtonItem open_graph;
        private DevComponents.DotNetBar.ButtonItem save_graph;
        private DevComponents.DotNetBar.ButtonItem save_report;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private System.Windows.Forms.Integration.ElementHost wpfHost;
        private System.Windows.Forms.OpenFileDialog ofd;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx algorithms;
        private DevComponents.DotNetBar.Controls.ComboBoxEx goal_node;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx start_node;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput delay;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IntegerInput postdelay;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IntegerInput predelay;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tracetxt;
        private System.Windows.Forms.SaveFileDialog sfd_trace;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.SaveFileDialog sfd;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.SaveFileDialog rfd;
    }
}

