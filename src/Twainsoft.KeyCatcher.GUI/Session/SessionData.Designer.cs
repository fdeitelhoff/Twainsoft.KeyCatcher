namespace Twainsoft.KeyCatcher.GUI.Session
{
    partial class SessionData
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
            this.infoText = new System.Windows.Forms.Label();
            this.sessionName = new System.Windows.Forms.TextBox();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.startDateTime = new System.Windows.Forms.Label();
            this.overallKeystrokes = new System.Windows.Forms.Label();
            this.charactersLeft = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoText
            // 
            this.infoText.AutoSize = true;
            this.infoText.Location = new System.Drawing.Point(12, 9);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(254, 13);
            this.infoText.TabIndex = 0;
            this.infoText.Text = "Every session needs a name - so type one in please:";
            // 
            // sessionName
            // 
            this.sessionName.Location = new System.Drawing.Point(15, 25);
            this.sessionName.Name = "sessionName";
            this.sessionName.Size = new System.Drawing.Size(178, 20);
            this.sessionName.TabIndex = 1;
            this.sessionName.TextChanged += new System.EventHandler(this.sessionName_TextChanged);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonContinue.Location = new System.Drawing.Point(199, 131);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 2;
            this.buttonContinue.Text = "&Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(15, 131);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDiscard.Location = new System.Drawing.Point(107, 131);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(75, 23);
            this.buttonDiscard.TabIndex = 4;
            this.buttonDiscard.Text = "&Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInfo.Controls.Add(this.startDateTime);
            this.groupBoxInfo.Controls.Add(this.overallKeystrokes);
            this.groupBoxInfo.Location = new System.Drawing.Point(15, 51);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(259, 74);
            this.groupBoxInfo.TabIndex = 5;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Session Info";
            // 
            // startDateTime
            // 
            this.startDateTime.AutoSize = true;
            this.startDateTime.Location = new System.Drawing.Point(6, 22);
            this.startDateTime.Name = "startDateTime";
            this.startDateTime.Size = new System.Drawing.Size(61, 13);
            this.startDateTime.TabIndex = 1;
            this.startDateTime.Text = "Started: {0}";
            // 
            // overallKeystrokes
            // 
            this.overallKeystrokes.AutoSize = true;
            this.overallKeystrokes.Location = new System.Drawing.Point(6, 48);
            this.overallKeystrokes.Name = "overallKeystrokes";
            this.overallKeystrokes.Size = new System.Drawing.Size(79, 13);
            this.overallKeystrokes.TabIndex = 0;
            this.overallKeystrokes.Text = "Keystrokes: {0}";
            // 
            // charactersLeft
            // 
            this.charactersLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.charactersLeft.Location = new System.Drawing.Point(199, 25);
            this.charactersLeft.Name = "charactersLeft";
            this.charactersLeft.Size = new System.Drawing.Size(75, 20);
            this.charactersLeft.TabIndex = 6;
            this.charactersLeft.Text = "{0} Chars left";
            this.charactersLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SessionData
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonContinue;
            this.ClientSize = new System.Drawing.Size(286, 167);
            this.Controls.Add(this.charactersLeft);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.sessionName);
            this.Controls.Add(this.infoText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SessionData";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Session Data";
            this.TopMost = true;
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoText;
        private System.Windows.Forms.TextBox sessionName;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label overallKeystrokes;
        private System.Windows.Forms.Label startDateTime;
        private System.Windows.Forms.Label charactersLeft;
    }
}