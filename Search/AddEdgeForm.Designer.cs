namespace Search
{
    partial class AddEdgeForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.source = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.target = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.doubleInput1 = new DevComponents.Editors.DoubleInput();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(438, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Source";
            // 
            // source
            // 
            this.source.DisplayMember = "Text";
            this.source.Dock = System.Windows.Forms.DockStyle.Top;
            this.source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.source.ForeColor = System.Drawing.Color.Black;
            this.source.FormattingEnabled = true;
            this.source.ItemHeight = 14;
            this.source.Location = new System.Drawing.Point(0, 23);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(438, 20);
            this.source.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.source.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(0, 43);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(438, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Target";
            // 
            // target
            // 
            this.target.DisplayMember = "Text";
            this.target.Dock = System.Windows.Forms.DockStyle.Top;
            this.target.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.target.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.target.ForeColor = System.Drawing.Color.Black;
            this.target.FormattingEnabled = true;
            this.target.ItemHeight = 14;
            this.target.Location = new System.Drawing.Point(0, 66);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(438, 20);
            this.target.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.target.TabIndex = 3;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(363, 143);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "Add";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(0, 86);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(438, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Weight";
            // 
            // doubleInput1
            // 
            this.doubleInput1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.doubleInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput1.Dock = System.Windows.Forms.DockStyle.Top;
            this.doubleInput1.ForeColor = System.Drawing.Color.Black;
            this.doubleInput1.Increment = 1D;
            this.doubleInput1.Location = new System.Drawing.Point(0, 109);
            this.doubleInput1.Name = "doubleInput1";
            this.doubleInput1.ShowUpDown = true;
            this.doubleInput1.Size = new System.Drawing.Size(438, 20);
            this.doubleInput1.TabIndex = 6;
            // 
            // AddEdgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 170);
            this.Controls.Add(this.doubleInput1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.target);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.source);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEdgeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add edge";
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx source;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx target;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DoubleInput doubleInput1;
    }
}