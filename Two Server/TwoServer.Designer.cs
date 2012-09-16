namespace Two_Server
{
    partial class TwoServerWindow
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
            this.logBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.topCardLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this._pauseButton = new System.Windows.Forms.Button();
            this._resumeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logBox.Location = new System.Drawing.Point(2, 1);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBox.Size = new System.Drawing.Size(767, 597);
            this.logBox.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(784, 27);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(120, 60);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(784, 110);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(120, 52);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset Game";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(781, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Top Card:";
            // 
            // topCardLabel
            // 
            this.topCardLabel.AutoSize = true;
            this.topCardLabel.Location = new System.Drawing.Point(841, 258);
            this.topCardLabel.Name = "topCardLabel";
            this.topCardLabel.Size = new System.Drawing.Size(35, 13);
            this.topCardLabel.TabIndex = 4;
            this.topCardLabel.Text = "label2";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(784, 222);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(120, 27);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // _pauseButton
            // 
            this._pauseButton.Location = new System.Drawing.Point(788, 309);
            this._pauseButton.Name = "_pauseButton";
            this._pauseButton.Size = new System.Drawing.Size(114, 31);
            this._pauseButton.TabIndex = 6;
            this._pauseButton.Text = "Pause";
            this._pauseButton.UseVisualStyleBackColor = true;
            this._pauseButton.Click += new System.EventHandler(this._pauseButton_Click);
            // 
            // _resumeButton
            // 
            this._resumeButton.Location = new System.Drawing.Point(784, 310);
            this._resumeButton.Name = "_resumeButton";
            this._resumeButton.Size = new System.Drawing.Size(120, 30);
            this._resumeButton.TabIndex = 7;
            this._resumeButton.Text = "Resume";
            this._resumeButton.UseVisualStyleBackColor = true;
            this._resumeButton.Visible = false;
            this._resumeButton.Click += new System.EventHandler(this._resumeButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(787, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 57);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Location = new System.Drawing.Point(784, 363);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(120, 55);
            this.OptionsButton.TabIndex = 9;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // TwoServerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(911, 604);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._resumeButton);
            this.Controls.Add(this._pauseButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.topCardLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.logBox);
            this.Name = "TwoServerWindow";
            this.Text = "Two! Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label topCardLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button _pauseButton;
        private System.Windows.Forms.Button _resumeButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OptionsButton;
    }
}

