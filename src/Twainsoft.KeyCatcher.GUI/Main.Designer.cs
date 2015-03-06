namespace Twainsoft.KeyCatcher.GUI
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
            this.showSessionGroupBox = new System.Windows.Forms.GroupBox();
            this.saveSession = new System.Windows.Forms.Button();
            this.continueSession = new System.Windows.Forms.Button();
            this.discardSession = new System.Windows.Forms.Button();
            this.notifyIconContextMenu.SuspendLayout();
            this.activeSessionGroupBox.SuspendLayout();
            this.overallSessionsGroupBox.SuspendLayout();
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
            this.activeSessionGroupBox.Controls.Add(this.discardSession);
            this.activeSessionGroupBox.Controls.Add(this.continueSession);
            this.activeSessionGroupBox.Controls.Add(this.sessionStartDate);
            this.activeSessionGroupBox.Controls.Add(this.keyStrokeCount);
            this.activeSessionGroupBox.Controls.Add(this.saveSession);
            this.activeSessionGroupBox.Location = new System.Drawing.Point(12, 88);
            this.activeSessionGroupBox.Name = "activeSessionGroupBox";
            this.activeSessionGroupBox.Size = new System.Drawing.Size(330, 104);
            this.activeSessionGroupBox.TabIndex = 3;
            this.activeSessionGroupBox.TabStop = false;
            this.activeSessionGroupBox.Text = "Active Session";
            // 
            // overallSessionsGroupBox
            // 
            this.overallSessionsGroupBox.Controls.Add(this.overallKeysCatched);
            this.overallSessionsGroupBox.Controls.Add(this.sessionsRecorded);
            this.overallSessionsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.overallSessionsGroupBox.Name = "overallSessionsGroupBox";
            this.overallSessionsGroupBox.Size = new System.Drawing.Size(330, 70);
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
            // showSessionGroupBox
            // 
            this.showSessionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showSessionGroupBox.Location = new System.Drawing.Point(12, 198);
            this.showSessionGroupBox.Name = "showSessionGroupBox";
            this.showSessionGroupBox.Size = new System.Drawing.Size(330, 75);
            this.showSessionGroupBox.TabIndex = 5;
            this.showSessionGroupBox.TabStop = false;
            this.showSessionGroupBox.Text = "Session Infos";
            // 
            // saveSession
            // 
            this.saveSession.Location = new System.Drawing.Point(249, 17);
            this.saveSession.Name = "saveSession";
            this.saveSession.Size = new System.Drawing.Size(75, 23);
            this.saveSession.TabIndex = 6;
            this.saveSession.Text = "&Save";
            this.saveSession.UseVisualStyleBackColor = true;
            // 
            // continueSession
            // 
            this.continueSession.Location = new System.Drawing.Point(249, 75);
            this.continueSession.Name = "continueSession";
            this.continueSession.Size = new System.Drawing.Size(75, 23);
            this.continueSession.TabIndex = 7;
            this.continueSession.Text = "&Continue";
            this.continueSession.UseVisualStyleBackColor = true;
            // 
            // discardSession
            // 
            this.discardSession.Location = new System.Drawing.Point(249, 46);
            this.discardSession.Name = "discardSession";
            this.discardSession.Size = new System.Drawing.Size(75, 23);
            this.discardSession.TabIndex = 8;
            this.discardSession.Text = "&Discard";
            this.discardSession.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 285);
            this.Controls.Add(this.showSessionGroupBox);
            this.Controls.Add(this.overallSessionsGroupBox);
            this.Controls.Add(this.activeSessionGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox showSessionGroupBox;
        private System.Windows.Forms.Button saveSession;
        private System.Windows.Forms.Button continueSession;
        private System.Windows.Forms.Button discardSession;
    }
}

