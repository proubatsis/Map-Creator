namespace Map_Creator
{
    partial class mainForm
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
            this.topMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.addAreaButton = new System.Windows.Forms.Button();
            this.addRoadButton = new System.Windows.Forms.Button();
            this.destNodeList = new System.Windows.Forms.ListBox();
            this.sourceNodeList = new System.Windows.Forms.ListBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.infoTreeView = new System.Windows.Forms.TreeView();
            this.configurationPanel = new System.Windows.Forms.Panel();
            this.areasPanel = new System.Windows.Forms.Panel();
            this.trafficUpDown = new System.Windows.Forms.NumericUpDown();
            this.trafficCostLabel = new System.Windows.Forms.Label();
            this.roadsPanel = new System.Windows.Forms.Panel();
            this.costUpDown = new System.Windows.Forms.NumericUpDown();
            this.roadCostLabel = new System.Windows.Forms.Label();
            this.invisibleRoadCheckBox = new System.Windows.Forms.CheckBox();
            this.nodesPanel = new System.Windows.Forms.Panel();
            this.areasLabel = new System.Windows.Forms.Label();
            this.addAreaToNodeButton = new System.Windows.Forms.Button();
            this.areaUpDown = new System.Windows.Forms.NumericUpDown();
            this.areasList = new System.Windows.Forms.ListBox();
            this.invisbileNodeCheckBox = new System.Windows.Forms.CheckBox();
            this.exportJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuStrip.SuspendLayout();
            this.itemsPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.configurationPanel.SuspendLayout();
            this.areasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trafficUpDown)).BeginInit();
            this.roadsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costUpDown)).BeginInit();
            this.nodesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenuStrip
            // 
            this.topMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.topMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.topMenuStrip.Name = "topMenuStrip";
            this.topMenuStrip.Size = new System.Drawing.Size(923, 24);
            this.topMenuStrip.TabIndex = 0;
            this.topMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportJSONToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // itemsPanel
            // 
            this.itemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsPanel.BackColor = System.Drawing.Color.Red;
            this.itemsPanel.Controls.Add(this.addAreaButton);
            this.itemsPanel.Controls.Add(this.addRoadButton);
            this.itemsPanel.Controls.Add(this.destNodeList);
            this.itemsPanel.Controls.Add(this.sourceNodeList);
            this.itemsPanel.Controls.Add(this.itemNameTextBox);
            this.itemsPanel.Controls.Add(this.itemNameLabel);
            this.itemsPanel.Location = new System.Drawing.Point(0, 454);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(588, 168);
            this.itemsPanel.TabIndex = 1;
            // 
            // addAreaButton
            // 
            this.addAreaButton.Location = new System.Drawing.Point(12, 115);
            this.addAreaButton.Name = "addAreaButton";
            this.addAreaButton.Size = new System.Drawing.Size(186, 44);
            this.addAreaButton.TabIndex = 6;
            this.addAreaButton.Text = "Add Area";
            this.addAreaButton.UseVisualStyleBackColor = true;
            this.addAreaButton.Click += new System.EventHandler(this.addAreaButton_Click);
            // 
            // addRoadButton
            // 
            this.addRoadButton.Location = new System.Drawing.Point(506, 12);
            this.addRoadButton.Name = "addRoadButton";
            this.addRoadButton.Size = new System.Drawing.Size(75, 147);
            this.addRoadButton.TabIndex = 5;
            this.addRoadButton.Text = "Add Road";
            this.addRoadButton.UseVisualStyleBackColor = true;
            this.addRoadButton.Click += new System.EventHandler(this.addRoadButton_Click);
            // 
            // destNodeList
            // 
            this.destNodeList.FormattingEnabled = true;
            this.destNodeList.Location = new System.Drawing.Point(355, 12);
            this.destNodeList.Name = "destNodeList";
            this.destNodeList.Size = new System.Drawing.Size(145, 147);
            this.destNodeList.TabIndex = 4;
            // 
            // sourceNodeList
            // 
            this.sourceNodeList.FormattingEnabled = true;
            this.sourceNodeList.Location = new System.Drawing.Point(204, 12);
            this.sourceNodeList.Name = "sourceNodeList";
            this.sourceNodeList.Size = new System.Drawing.Size(145, 147);
            this.sourceNodeList.TabIndex = 3;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(56, 12);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.itemNameTextBox.TabIndex = 2;
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Location = new System.Drawing.Point(12, 15);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(38, 13);
            this.itemNameLabel.TabIndex = 1;
            this.itemNameLabel.Text = "Name:";
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.White;
            this.mapPanel.Location = new System.Drawing.Point(12, 27);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(571, 403);
            this.mapPanel.TabIndex = 2;
            this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel_Paint);
            this.mapPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPanel_MouseClick);
            // 
            // infoPanel
            // 
            this.infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoPanel.BackColor = System.Drawing.Color.Lime;
            this.infoPanel.Controls.Add(this.infoTreeView);
            this.infoPanel.Location = new System.Drawing.Point(594, 27);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(157, 595);
            this.infoPanel.TabIndex = 3;
            // 
            // infoTreeView
            // 
            this.infoTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTreeView.Location = new System.Drawing.Point(3, 3);
            this.infoTreeView.Name = "infoTreeView";
            this.infoTreeView.Size = new System.Drawing.Size(151, 585);
            this.infoTreeView.TabIndex = 0;
            this.infoTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.infoTreeView_AfterSelect);
            // 
            // configurationPanel
            // 
            this.configurationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationPanel.BackColor = System.Drawing.Color.Blue;
            this.configurationPanel.Controls.Add(this.areasPanel);
            this.configurationPanel.Controls.Add(this.roadsPanel);
            this.configurationPanel.Controls.Add(this.nodesPanel);
            this.configurationPanel.Location = new System.Drawing.Point(757, 27);
            this.configurationPanel.Name = "configurationPanel";
            this.configurationPanel.Size = new System.Drawing.Size(157, 595);
            this.configurationPanel.TabIndex = 4;
            // 
            // areasPanel
            // 
            this.areasPanel.BackColor = System.Drawing.Color.White;
            this.areasPanel.Controls.Add(this.trafficUpDown);
            this.areasPanel.Controls.Add(this.trafficCostLabel);
            this.areasPanel.Location = new System.Drawing.Point(4, 274);
            this.areasPanel.Name = "areasPanel";
            this.areasPanel.Size = new System.Drawing.Size(150, 59);
            this.areasPanel.TabIndex = 1;
            this.areasPanel.Visible = false;
            // 
            // trafficUpDown
            // 
            this.trafficUpDown.Location = new System.Drawing.Point(5, 26);
            this.trafficUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.trafficUpDown.Name = "trafficUpDown";
            this.trafficUpDown.Size = new System.Drawing.Size(130, 20);
            this.trafficUpDown.TabIndex = 5;
            this.trafficUpDown.ValueChanged += new System.EventHandler(this.trafficUpDown_ValueChanged);
            // 
            // trafficCostLabel
            // 
            this.trafficCostLabel.AutoSize = true;
            this.trafficCostLabel.Location = new System.Drawing.Point(5, 9);
            this.trafficCostLabel.Name = "trafficCostLabel";
            this.trafficCostLabel.Size = new System.Drawing.Size(64, 13);
            this.trafficCostLabel.TabIndex = 4;
            this.trafficCostLabel.Text = "Traffic Cost:";
            // 
            // roadsPanel
            // 
            this.roadsPanel.BackColor = System.Drawing.Color.White;
            this.roadsPanel.Controls.Add(this.costUpDown);
            this.roadsPanel.Controls.Add(this.roadCostLabel);
            this.roadsPanel.Controls.Add(this.invisibleRoadCheckBox);
            this.roadsPanel.Location = new System.Drawing.Point(4, 192);
            this.roadsPanel.Name = "roadsPanel";
            this.roadsPanel.Size = new System.Drawing.Size(150, 76);
            this.roadsPanel.TabIndex = 1;
            this.roadsPanel.Visible = false;
            // 
            // costUpDown
            // 
            this.costUpDown.Location = new System.Drawing.Point(5, 44);
            this.costUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.costUpDown.Name = "costUpDown";
            this.costUpDown.Size = new System.Drawing.Size(130, 20);
            this.costUpDown.TabIndex = 3;
            this.costUpDown.ValueChanged += new System.EventHandler(this.costUpDown_ValueChanged);
            // 
            // roadCostLabel
            // 
            this.roadCostLabel.AutoSize = true;
            this.roadCostLabel.Location = new System.Drawing.Point(5, 27);
            this.roadCostLabel.Name = "roadCostLabel";
            this.roadCostLabel.Size = new System.Drawing.Size(130, 13);
            this.roadCostLabel.TabIndex = 2;
            this.roadCostLabel.Text = "Cost (Leave at 0 for auto):";
            // 
            // invisibleRoadCheckBox
            // 
            this.invisibleRoadCheckBox.AutoSize = true;
            this.invisibleRoadCheckBox.Location = new System.Drawing.Point(5, 3);
            this.invisibleRoadCheckBox.Name = "invisibleRoadCheckBox";
            this.invisibleRoadCheckBox.Size = new System.Drawing.Size(121, 17);
            this.invisibleRoadCheckBox.TabIndex = 1;
            this.invisibleRoadCheckBox.Text = "Invisible Jump Road";
            this.invisibleRoadCheckBox.UseVisualStyleBackColor = true;
            this.invisibleRoadCheckBox.CheckedChanged += new System.EventHandler(this.invisibleRoadCheckBox_CheckedChanged);
            // 
            // nodesPanel
            // 
            this.nodesPanel.BackColor = System.Drawing.Color.White;
            this.nodesPanel.Controls.Add(this.areasLabel);
            this.nodesPanel.Controls.Add(this.addAreaToNodeButton);
            this.nodesPanel.Controls.Add(this.areaUpDown);
            this.nodesPanel.Controls.Add(this.areasList);
            this.nodesPanel.Controls.Add(this.invisbileNodeCheckBox);
            this.nodesPanel.Location = new System.Drawing.Point(4, 4);
            this.nodesPanel.Name = "nodesPanel";
            this.nodesPanel.Size = new System.Drawing.Size(150, 184);
            this.nodesPanel.TabIndex = 0;
            this.nodesPanel.Visible = false;
            // 
            // areasLabel
            // 
            this.areasLabel.AutoSize = true;
            this.areasLabel.Location = new System.Drawing.Point(5, 41);
            this.areasLabel.Name = "areasLabel";
            this.areasLabel.Size = new System.Drawing.Size(37, 13);
            this.areasLabel.TabIndex = 9;
            this.areasLabel.Text = "Areas:";
            // 
            // addAreaToNodeButton
            // 
            this.addAreaToNodeButton.Enabled = false;
            this.addAreaToNodeButton.Location = new System.Drawing.Point(69, 149);
            this.addAreaToNodeButton.Name = "addAreaToNodeButton";
            this.addAreaToNodeButton.Size = new System.Drawing.Size(65, 20);
            this.addAreaToNodeButton.TabIndex = 8;
            this.addAreaToNodeButton.Text = "Add";
            this.addAreaToNodeButton.UseVisualStyleBackColor = true;
            this.addAreaToNodeButton.Click += new System.EventHandler(this.addAreaToNodeButton_Click);
            // 
            // areaUpDown
            // 
            this.areaUpDown.Enabled = false;
            this.areaUpDown.Location = new System.Drawing.Point(5, 149);
            this.areaUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.areaUpDown.Name = "areaUpDown";
            this.areaUpDown.Size = new System.Drawing.Size(60, 20);
            this.areaUpDown.TabIndex = 7;
            // 
            // areasList
            // 
            this.areasList.FormattingEnabled = true;
            this.areasList.Location = new System.Drawing.Point(5, 60);
            this.areasList.Name = "areasList";
            this.areasList.Size = new System.Drawing.Size(129, 82);
            this.areasList.TabIndex = 6;
            // 
            // invisbileNodeCheckBox
            // 
            this.invisbileNodeCheckBox.AutoSize = true;
            this.invisbileNodeCheckBox.Location = new System.Drawing.Point(4, 4);
            this.invisbileNodeCheckBox.Name = "invisbileNodeCheckBox";
            this.invisbileNodeCheckBox.Size = new System.Drawing.Size(133, 17);
            this.invisbileNodeCheckBox.TabIndex = 0;
            this.invisbileNodeCheckBox.Text = "Invisible Routing Node";
            this.invisbileNodeCheckBox.UseVisualStyleBackColor = true;
            this.invisbileNodeCheckBox.CheckedChanged += new System.EventHandler(this.invisbileNodeCheckBox_CheckedChanged);
            // 
            // exportJSONToolStripMenuItem
            // 
            this.exportJSONToolStripMenuItem.Name = "exportJSONToolStripMenuItem";
            this.exportJSONToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportJSONToolStripMenuItem.Text = "Export JSON";
            this.exportJSONToolStripMenuItem.Click += new System.EventHandler(this.exportJSONToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 620);
            this.Controls.Add(this.configurationPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.itemsPanel);
            this.Controls.Add(this.topMenuStrip);
            this.MainMenuStrip = this.topMenuStrip;
            this.Name = "mainForm";
            this.Text = "Map Creator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.topMenuStrip.ResumeLayout(false);
            this.topMenuStrip.PerformLayout();
            this.itemsPanel.ResumeLayout(false);
            this.itemsPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.configurationPanel.ResumeLayout(false);
            this.areasPanel.ResumeLayout(false);
            this.areasPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trafficUpDown)).EndInit();
            this.roadsPanel.ResumeLayout(false);
            this.roadsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costUpDown)).EndInit();
            this.nodesPanel.ResumeLayout(false);
            this.nodesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.TreeView infoTreeView;
        private System.Windows.Forms.Panel configurationPanel;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Button addRoadButton;
        private System.Windows.Forms.ListBox destNodeList;
        private System.Windows.Forms.ListBox sourceNodeList;
        private System.Windows.Forms.Panel areasPanel;
        private System.Windows.Forms.Panel roadsPanel;
        private System.Windows.Forms.Panel nodesPanel;
        private System.Windows.Forms.NumericUpDown costUpDown;
        private System.Windows.Forms.Label roadCostLabel;
        private System.Windows.Forms.CheckBox invisibleRoadCheckBox;
        private System.Windows.Forms.CheckBox invisbileNodeCheckBox;
        private System.Windows.Forms.NumericUpDown trafficUpDown;
        private System.Windows.Forms.Label trafficCostLabel;
        private System.Windows.Forms.ListBox areasList;
        private System.Windows.Forms.Label areasLabel;
        private System.Windows.Forms.Button addAreaToNodeButton;
        private System.Windows.Forms.NumericUpDown areaUpDown;
        private System.Windows.Forms.Button addAreaButton;
        private System.Windows.Forms.ToolStripMenuItem exportJSONToolStripMenuItem;
    }
}

