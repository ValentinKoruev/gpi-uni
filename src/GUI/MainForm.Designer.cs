namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeFillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeStrokeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparency_0 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparency_25 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparency_50 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparency_75 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeTransparency_100 = new System.Windows.Forms.ToolStripMenuItem();
			this.changeRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rotation_30_right = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.speedMenu = new System.Windows.Forms.ToolStrip();
			this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
			this.DrawEllipseButton = new System.Windows.Forms.ToolStripButton();
			this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
			this.deleteSelectionButton = new System.Windows.Forms.ToolStripButton();
			this.bringToBackButton = new System.Windows.Forms.ToolStripButton();
			this.bringToFrontButton = new System.Windows.Forms.ToolStripButton();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.colorDialog2 = new System.Windows.Forms.ColorDialog();
			this.rotation_60_right = new System.Windows.Forms.ToolStripMenuItem();
			this.rotation_90_right = new System.Windows.Forms.ToolStripMenuItem();
			this.rotation_30_left = new System.Windows.Forms.ToolStripMenuItem();
			this.rotation_60_left = new System.Windows.Forms.ToolStripMenuItem();
			this.rotation_90_left = new System.Windows.Forms.ToolStripMenuItem();
			this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupSelection = new System.Windows.Forms.ToolStripMenuItem();
			this.viewPort = new Draw.DoubleBufferedPanel();
			this.mainMenu.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.speedMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(693, 24);
			this.mainMenu.TabIndex = 1;
			this.mainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFillColorToolStripMenuItem,
            this.changeStrokeColorToolStripMenuItem,
            this.changeSizeToolStripMenuItem,
            this.changeTransparencyToolStripMenuItem,
            this.changeRotationToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// changeFillColorToolStripMenuItem
			// 
			this.changeFillColorToolStripMenuItem.Name = "changeFillColorToolStripMenuItem";
			this.changeFillColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.changeFillColorToolStripMenuItem.Text = "Change fill color";
			this.changeFillColorToolStripMenuItem.Click += new System.EventHandler(this.changeFillColorToolStripMenuItem_Click);
			// 
			// changeStrokeColorToolStripMenuItem
			// 
			this.changeStrokeColorToolStripMenuItem.Name = "changeStrokeColorToolStripMenuItem";
			this.changeStrokeColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.changeStrokeColorToolStripMenuItem.Text = "Change stroke color";
			this.changeStrokeColorToolStripMenuItem.Click += new System.EventHandler(this.changeStrokeColorToolStripMenuItem_Click);
			// 
			// changeSizeToolStripMenuItem
			// 
			this.changeSizeToolStripMenuItem.Name = "changeSizeToolStripMenuItem";
			this.changeSizeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.changeSizeToolStripMenuItem.Text = "Change size";
			this.changeSizeToolStripMenuItem.Click += new System.EventHandler(this.changeSizeToolStripMenuItem_Click);
			// 
			// changeTransparencyToolStripMenuItem
			// 
			this.changeTransparencyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeTransparency_0,
            this.changeTransparency_25,
            this.changeTransparency_50,
            this.changeTransparency_75,
            this.changeTransparency_100});
			this.changeTransparencyToolStripMenuItem.Name = "changeTransparencyToolStripMenuItem";
			this.changeTransparencyToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.changeTransparencyToolStripMenuItem.Text = "Change transparency";
			// 
			// changeTransparency_0
			// 
			this.changeTransparency_0.Name = "changeTransparency_0";
			this.changeTransparency_0.Size = new System.Drawing.Size(102, 22);
			this.changeTransparency_0.Text = "0%";
			this.changeTransparency_0.Click += new System.EventHandler(this.changeTransparency_0_Click);
			// 
			// changeTransparency_25
			// 
			this.changeTransparency_25.Name = "changeTransparency_25";
			this.changeTransparency_25.Size = new System.Drawing.Size(102, 22);
			this.changeTransparency_25.Text = "25%";
			this.changeTransparency_25.Click += new System.EventHandler(this.changeTransparency_25_Click);
			// 
			// changeTransparency_50
			// 
			this.changeTransparency_50.Name = "changeTransparency_50";
			this.changeTransparency_50.Size = new System.Drawing.Size(102, 22);
			this.changeTransparency_50.Text = "50%";
			this.changeTransparency_50.Click += new System.EventHandler(this.changeTransparency_50_Click);
			// 
			// changeTransparency_75
			// 
			this.changeTransparency_75.Name = "changeTransparency_75";
			this.changeTransparency_75.Size = new System.Drawing.Size(102, 22);
			this.changeTransparency_75.Text = "75%";
			this.changeTransparency_75.Click += new System.EventHandler(this.changeTransparency_75_Click);
			// 
			// changeTransparency_100
			// 
			this.changeTransparency_100.Name = "changeTransparency_100";
			this.changeTransparency_100.Size = new System.Drawing.Size(102, 22);
			this.changeTransparency_100.Text = "100%";
			this.changeTransparency_100.Click += new System.EventHandler(this.changeTransparency_100_Click);
			// 
			// changeRotationToolStripMenuItem
			// 
			this.changeRotationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotation_30_right,
            this.rotation_60_right,
            this.rotation_90_right,
            this.rotation_30_left,
            this.rotation_60_left,
            this.rotation_90_left});
			this.changeRotationToolStripMenuItem.Name = "changeRotationToolStripMenuItem";
			this.changeRotationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.changeRotationToolStripMenuItem.Text = "Change rotation";
			// 
			// rotation_30_right
			// 
			this.rotation_30_right.Name = "rotation_30_right";
			this.rotation_30_right.Size = new System.Drawing.Size(156, 22);
			this.rotation_30_right.Text = "30° to the right ";
			this.rotation_30_right.Click += new System.EventHandler(this.rotation_30_right_Click);
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.imageToolStripMenuItem.Text = "Image";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
			this.statusBar.Location = new System.Drawing.Point(0, 401);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(693, 22);
			this.statusBar.TabIndex = 2;
			this.statusBar.Text = "statusStrip1";
			// 
			// currentStatusLabel
			// 
			this.currentStatusLabel.Name = "currentStatusLabel";
			this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// speedMenu
			// 
			this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.DrawEllipseButton,
            this.pickUpSpeedButton,
            this.deleteSelectionButton,
            this.bringToBackButton,
            this.bringToFrontButton});
			this.speedMenu.Location = new System.Drawing.Point(0, 24);
			this.speedMenu.Name = "speedMenu";
			this.speedMenu.Size = new System.Drawing.Size(693, 25);
			this.speedMenu.TabIndex = 3;
			this.speedMenu.Text = "toolStrip1";
			// 
			// drawRectangleSpeedButton
			// 
			this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
			this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
			this.drawRectangleSpeedButton.Size = new System.Drawing.Size(23, 22);
			this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
			this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
			// 
			// DrawEllipseButton
			// 
			this.DrawEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.DrawEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawEllipseButton.Image")));
			this.DrawEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DrawEllipseButton.Name = "DrawEllipseButton";
			this.DrawEllipseButton.Size = new System.Drawing.Size(23, 22);
			this.DrawEllipseButton.Text = "toolStripButton1";
			this.DrawEllipseButton.ToolTipText = "Draw ellipse button";
			this.DrawEllipseButton.Click += new System.EventHandler(this.DrawEllipseButton_Click);
			// 
			// pickUpSpeedButton
			// 
			this.pickUpSpeedButton.CheckOnClick = true;
			this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
			this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pickUpSpeedButton.Name = "pickUpSpeedButton";
			this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
			this.pickUpSpeedButton.Text = "toolStripButton1";
			// 
			// deleteSelectionButton
			// 
			this.deleteSelectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteSelectionButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectionButton.Image")));
			this.deleteSelectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteSelectionButton.Name = "deleteSelectionButton";
			this.deleteSelectionButton.Size = new System.Drawing.Size(23, 22);
			this.deleteSelectionButton.Text = "Delete selected elements";
			this.deleteSelectionButton.Click += new System.EventHandler(this.deleteSelectionButton_Click);
			// 
			// bringToBackButton
			// 
			this.bringToBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bringToBackButton.Image = ((System.Drawing.Image)(resources.GetObject("bringToBackButton.Image")));
			this.bringToBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bringToBackButton.Name = "bringToBackButton";
			this.bringToBackButton.Size = new System.Drawing.Size(23, 22);
			this.bringToBackButton.Text = "Bring to back";
			this.bringToBackButton.ToolTipText = "Bring to back button";
			this.bringToBackButton.Click += new System.EventHandler(this.bringToBackButton_Click);
			// 
			// bringToFrontButton
			// 
			this.bringToFrontButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bringToFrontButton.Image = ((System.Drawing.Image)(resources.GetObject("bringToFrontButton.Image")));
			this.bringToFrontButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bringToFrontButton.Name = "bringToFrontButton";
			this.bringToFrontButton.Size = new System.Drawing.Size(23, 22);
			this.bringToFrontButton.Text = "Bring to front button";
			this.bringToFrontButton.Click += new System.EventHandler(this.bringToFrontButton_Click);
			// 
			// rotation_60_right
			// 
			this.rotation_60_right.Name = "rotation_60_right";
			this.rotation_60_right.Size = new System.Drawing.Size(156, 22);
			this.rotation_60_right.Text = "60° to the right ";
			this.rotation_60_right.Click += new System.EventHandler(this.rotation_60_right_Click);
			// 
			// rotation_90_right
			// 
			this.rotation_90_right.Name = "rotation_90_right";
			this.rotation_90_right.Size = new System.Drawing.Size(156, 22);
			this.rotation_90_right.Text = "90° to the right ";
			this.rotation_90_right.Click += new System.EventHandler(this.rotation_90_right_Click);
			// 
			// rotation_30_left
			// 
			this.rotation_30_left.Name = "rotation_30_left";
			this.rotation_30_left.Size = new System.Drawing.Size(156, 22);
			this.rotation_30_left.Text = "30° to the left";
			this.rotation_30_left.Click += new System.EventHandler(this.rotation_30_left_Click);
			// 
			// rotation_60_left
			// 
			this.rotation_60_left.Name = "rotation_60_left";
			this.rotation_60_left.Size = new System.Drawing.Size(156, 22);
			this.rotation_60_left.Text = "60° to the left";
			this.rotation_60_left.Click += new System.EventHandler(this.rotation_60_left_Click);
			// 
			// rotation_90_left
			// 
			this.rotation_90_left.Name = "rotation_90_left";
			this.rotation_90_left.Size = new System.Drawing.Size(156, 22);
			this.rotation_90_left.Text = "90° to the left ";
			this.rotation_90_left.Click += new System.EventHandler(this.rotation_90_left_Click);
			// 
			// groupToolStripMenuItem
			// 
			this.groupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupSelection});
			this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
			this.groupToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.groupToolStripMenuItem.Text = "Group";
			// 
			// groupSelection
			// 
			this.groupSelection.Name = "groupSelection";
			this.groupSelection.Size = new System.Drawing.Size(222, 22);
			this.groupSelection.Text = "Create group from selection";
			this.groupSelection.Click += new System.EventHandler(this.groupSelection_Click);
			// 
			// viewPort
			// 
			this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewPort.Location = new System.Drawing.Point(0, 49);
			this.viewPort.Name = "viewPort";
			this.viewPort.Size = new System.Drawing.Size(693, 352);
			this.viewPort.TabIndex = 4;
			this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
			this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
			this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
			this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(693, 423);
			this.Controls.Add(this.viewPort);
			this.Controls.Add(this.speedMenu);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.mainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Draw";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.speedMenu.ResumeLayout(false);
			this.speedMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripButton DrawEllipseButton;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.ToolStripMenuItem changeFillColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeStrokeColorToolStripMenuItem;
		private System.Windows.Forms.ColorDialog colorDialog2;
		private System.Windows.Forms.ToolStripButton deleteSelectionButton;
		private System.Windows.Forms.ToolStripMenuItem changeSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton bringToBackButton;
		private System.Windows.Forms.ToolStripButton bringToFrontButton;
		private System.Windows.Forms.ToolStripMenuItem changeTransparencyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeTransparency_0;
		private System.Windows.Forms.ToolStripMenuItem changeTransparency_25;
		private System.Windows.Forms.ToolStripMenuItem changeTransparency_50;
		private System.Windows.Forms.ToolStripMenuItem changeTransparency_75;
		private System.Windows.Forms.ToolStripMenuItem changeTransparency_100;
		private System.Windows.Forms.ToolStripMenuItem changeRotationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rotation_30_right;
		private System.Windows.Forms.ToolStripMenuItem rotation_60_right;
		private System.Windows.Forms.ToolStripMenuItem rotation_90_right;
		private System.Windows.Forms.ToolStripMenuItem rotation_30_left;
		private System.Windows.Forms.ToolStripMenuItem rotation_60_left;
		private System.Windows.Forms.ToolStripMenuItem rotation_90_left;
		private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem groupSelection;
	}
}
