namespace Search
{
    partial class AddVertexForm
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
            this.node_name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.node_heuristic = new DevComponents.DotNetBar.LabelX();
            this.node_heuris = new DevComponents.Editors.DoubleInput();
            this.addbtn = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.node_heuris)).BeginInit();
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
            this.labelX1.Size = new System.Drawing.Size(413, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Node key";
            // 
            // node_name
            // 
            this.node_name.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.node_name.Border.Class = "TextBoxBorder";
            this.node_name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.node_name.DisabledBackColor = System.Drawing.Color.White;
            this.node_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.node_name.ForeColor = System.Drawing.Color.Black;
            this.node_name.Location = new System.Drawing.Point(0, 23);
            this.node_name.Name = "node_name";
            this.node_name.PreventEnterBeep = true;
            this.node_name.Size = new System.Drawing.Size(413, 20);
            this.node_name.TabIndex = 1;
            // 
            // node_heuristic
            // 
            this.node_heuristic.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.node_heuristic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.node_heuristic.Dock = System.Windows.Forms.DockStyle.Top;
            this.node_heuristic.ForeColor = System.Drawing.Color.Black;
            this.node_heuristic.Location = new System.Drawing.Point(0, 43);
            this.node_heuristic.Name = "node_heuristic";
            this.node_heuristic.Size = new System.Drawing.Size(413, 24);
            this.node_heuristic.TabIndex = 2;
            this.node_heuristic.Text = "Heuristic Value";
            // 
            // node_heuris
            // 
            this.node_heuris.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.node_heuris.BackgroundStyle.Class = "DateTimeInputBackground";
            this.node_heuris.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.node_heuris.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.node_heuris.Dock = System.Windows.Forms.DockStyle.Top;
            this.node_heuris.ForeColor = System.Drawing.Color.Black;
            this.node_heuris.Increment = 1D;
            this.node_heuris.Location = new System.Drawing.Point(0, 67);
            this.node_heuris.Name = "node_heuris";
            this.node_heuris.ShowUpDown = true;
            this.node_heuris.Size = new System.Drawing.Size(413, 20);
            this.node_heuris.TabIndex = 3;
            // 
            // addbtn
            // 
            this.addbtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.addbtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.addbtn.Location = new System.Drawing.Point(303, 93);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(101, 23);
            this.addbtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.addbtn.TabIndex = 4;
            this.addbtn.Text = "Add";
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // AddVertexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 122);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.node_heuris);
            this.Controls.Add(this.node_heuristic);
            this.Controls.Add(this.node_name);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddVertexForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add node";
            ((System.ComponentModel.ISupportInitialize)(this.node_heuris)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX node_name;
        private DevComponents.DotNetBar.LabelX node_heuristic;
        private DevComponents.Editors.DoubleInput node_heuris;
        private DevComponents.DotNetBar.ButtonX addbtn;
    }
}