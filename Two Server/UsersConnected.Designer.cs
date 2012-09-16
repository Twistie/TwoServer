namespace Two_Server
{
    partial class UsersConnected
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
            this._playersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _playersLabel
            // 
            this._playersLabel.AutoSize = true;
            this._playersLabel.Location = new System.Drawing.Point(92, 53);
            this._playersLabel.Name = "_playersLabel";
            this._playersLabel.Size = new System.Drawing.Size(72, 13);
            this._playersLabel.TabIndex = 0;
            this._playersLabel.Text = "_playersLabel";
            // 
            // UsersConnected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 382);
            this.Controls.Add(this._playersLabel);
            this.Name = "UsersConnected";
            this.Text = "UsersConnected";
            this.Load += new System.EventHandler(this.UsersConnected_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _playersLabel;
    }
}