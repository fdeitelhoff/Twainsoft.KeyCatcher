namespace Twainsoft.KeyCatcher.GUI.App
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyStrokeCount = new System.Windows.Forms.Label();
            this.sessionStartDate = new System.Windows.Forms.Label();
            this.activeSessionGroupBox = new System.Windows.Forms.GroupBox();
            this.overallSessionsGroupBox = new System.Windows.Forms.GroupBox();
            this.overallKeysCatched = new System.Windows.Forms.Label();
            this.sessionsRecorded = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualKeyboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.startSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discardSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconContextMenu.SuspendLayout();
            this.activeSessionGroupBox.SuspendLayout();
            this.overallSessionsGroupBox.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "The KeyCatcher was minimized to tray!";
            this.notifyIcon.BalloonTipTitle = "Twainsoft KeyCatcher";
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Twainsoft KeyCatcher";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizeToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(125, 76);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.maximizeToolStripMenuItem.Text = "&Maximize";
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.maximizeToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.minimizeToolStripMenuItem.Text = "M&inimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // keyStrokeCount
            // 
            this.keyStrokeCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyStrokeCount.AutoSize = true;
            this.keyStrokeCount.Location = new System.Drawing.Point(6, 48);
            this.keyStrokeCount.Name = "keyStrokeCount";
            this.keyStrokeCount.Size = new System.Drawing.Size(113, 13);
            this.keyStrokeCount.TabIndex = 0;
            this.keyStrokeCount.Text = "Current Key Strokes: --";
            this.keyStrokeCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sessionStartDate
            // 
            this.sessionStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sessionStartDate.AutoSize = true;
            this.sessionStartDate.Location = new System.Drawing.Point(6, 22);
            this.sessionStartDate.Name = "sessionStartDate";
            this.sessionStartDate.Size = new System.Drawing.Size(119, 13);
            this.sessionStartDate.TabIndex = 1;
            this.sessionStartDate.Text = "Session Active Since: --";
            this.sessionStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // activeSessionGroupBox
            // 
            this.activeSessionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeSessionGroupBox.Controls.Add(this.sessionStartDate);
            this.activeSessionGroupBox.Controls.Add(this.keyStrokeCount);
            this.activeSessionGroupBox.Location = new System.Drawing.Point(12, 103);
            this.activeSessionGroupBox.Name = "activeSessionGroupBox";
            this.activeSessionGroupBox.Size = new System.Drawing.Size(270, 74);
            this.activeSessionGroupBox.TabIndex = 3;
            this.activeSessionGroupBox.TabStop = false;
            this.activeSessionGroupBox.Text = "Active Session";
            // 
            // overallSessionsGroupBox
            // 
            this.overallSessionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overallSessionsGroupBox.Controls.Add(this.overallKeysCatched);
            this.overallSessionsGroupBox.Controls.Add(this.sessionsRecorded);
            this.overallSessionsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.overallSessionsGroupBox.Name = "overallSessionsGroupBox";
            this.overallSessionsGroupBox.Size = new System.Drawing.Size(270, 70);
            this.overallSessionsGroupBox.TabIndex = 4;
            this.overallSessionsGroupBox.TabStop = false;
            this.overallSessionsGroupBox.Text = "KeyCatcher Statistics";
            // 
            // overallKeysCatched
            // 
            this.overallKeysCatched.AutoSize = true;
            this.overallKeysCatched.Location = new System.Drawing.Point(6, 48);
            this.overallKeysCatched.Name = "overallKeysCatched";
            this.overallKeysCatched.Size = new System.Drawing.Size(113, 13);
            this.overallKeysCatched.TabIndex = 1;
            this.overallKeysCatched.Text = "Overall keys caught: --";
            // 
            // sessionsRecorded
            // 
            this.sessionsRecorded.AutoSize = true;
            this.sessionsRecorded.Location = new System.Drawing.Point(6, 22);
            this.sessionsRecorded.Name = "sessionsRecorded";
            this.sessionsRecorded.Size = new System.Drawing.Size(106, 13);
            this.sessionsRecorded.TabIndex = 0;
            this.sessionsRecorded.Text = "Sessions recorded: --";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionsToolStripMenuItem,
            this.keyboardToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(294, 24);
            this.mainMenu.TabIndex = 5;
            // 
            // sessionsToolStripMenuItem
            // 
            this.sessionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSessionMenuItem,
            this.stopSessionMenuItem,
            this.discardSessionMenuItem,
            this.toolStripMenuItem1,
            this.showAllToolStripMenuItem});
            this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
            this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.sessionsToolStripMenuItem.Text = "&Sessions";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showAllToolStripMenuItem.Text = "&Overview";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // keyboardToolStripMenuItem
            // 
            this.keyboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.virtualKeyboardToolStripMenuItem});
            this.keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            this.keyboardToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.keyboardToolStripMenuItem.Text = "&Keyboard";
            // 
            // virtualKeyboardToolStripMenuItem
            // 
            this.virtualKeyboardToolStripMenuItem.Name = "virtualKeyboardToolStripMenuItem";
            this.virtualKeyboardToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.virtualKeyboardToolStripMenuItem.Text = "&Virtual Keyboard";
            this.virtualKeyboardToolStripMenuItem.Click += new System.EventHandler(this.virtualKeyboardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // startSessionMenuItem
            // 
            this.startSessionMenuItem.Name = "startSessionMenuItem";
            this.startSessionMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.J)));
            this.startSessionMenuItem.Size = new System.Drawing.Size(185, 22);
            this.startSessionMenuItem.Text = "St&art";
            this.startSessionMenuItem.Click += new System.EventHandler(this.startSessionMenuItem_Click);
            // 
            // stopSessionMenuItem
            // 
            this.stopSessionMenuItem.Name = "stopSessionMenuItem";
            this.stopSessionMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.K)));
            this.stopSessionMenuItem.Size = new System.Drawing.Size(185, 22);
            this.stopSessionMenuItem.Text = "St&op";
            this.stopSessionMenuItem.Click += new System.EventHandler(this.stopSessionMenuItem_Click);
            // 
            // discardSessionMenuItem
            // 
            this.discardSessionMenuItem.Name = "discardSessionMenuItem";
            this.discardSessionMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.discardSessionMenuItem.Size = new System.Drawing.Size(185, 22);
            this.discardSessionMenuItem.Text = "&Discard";
            this.discardSessionMenuItem.Click += new System.EventHandler(this.discardSessionMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 190);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.overallSessionsGroupBox);
            this.Controls.Add(this.activeSessionGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twainsoft KeyCatcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.notifyIconContextMenu.ResumeLayout(false);
            this.activeSessionGroupBox.ResumeLayout(false);
            this.activeSessionGroupBox.PerformLayout();
            this.overallSessionsGroupBox.ResumeLayout(false);
            this.overallSessionsGroupBox.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label keyStrokeCount;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label sessionStartDate;
        private System.Windows.Forms.GroupBox activeSessionGroupBox;
        private System.Windows.Forms.GroupBox overallSessionsGroupBox;
        private System.Windows.Forms.Label overallKeysCatched;
        private System.Windows.Forms.Label sessionsRecorded;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem virtualKeyboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSessionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSessionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem discardSessionMenuItem;
    }
}

