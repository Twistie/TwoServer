namespace Two_Server
{
    partial class GameOptions
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
            this.PresetBox = new System.Windows.Forms.ComboBox();
            this.presetLabel = new System.Windows.Forms.Label();
            this.Drink0 = new System.Windows.Forms.RadioButton();
            this.Drink1 = new System.Windows.Forms.RadioButton();
            this.Drink2 = new System.Windows.Forms.RadioButton();
            this.DrinkBox = new System.Windows.Forms.GroupBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.NumberSpinner = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DrawSpinner = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PrincessSpinner = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PrincessDrinkSpinner = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.BoomSpinner = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PassSpinner = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.GraySpinner = new System.Windows.Forms.NumericUpDown();
            this.SetButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LightMasterSpinner = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.DrinkBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrincessSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrincessDrinkSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoomSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraySpinner)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightMasterSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // PresetBox
            // 
            this.PresetBox.FormattingEnabled = true;
            this.PresetBox.Location = new System.Drawing.Point(127, 12);
            this.PresetBox.Name = "PresetBox";
            this.PresetBox.Size = new System.Drawing.Size(209, 21);
            this.PresetBox.TabIndex = 0;
            // 
            // presetLabel
            // 
            this.presetLabel.AutoSize = true;
            this.presetLabel.Location = new System.Drawing.Point(34, 15);
            this.presetLabel.Name = "presetLabel";
            this.presetLabel.Size = new System.Drawing.Size(87, 13);
            this.presetLabel.TabIndex = 1;
            this.presetLabel.Text = "Choose a preset:";
            // 
            // Drink0
            // 
            this.Drink0.AutoSize = true;
            this.Drink0.Location = new System.Drawing.Point(22, 19);
            this.Drink0.Name = "Drink0";
            this.Drink0.Size = new System.Drawing.Size(81, 17);
            this.Drink0.TabIndex = 2;
            this.Drink0.Text = "No Drinking";
            this.Drink0.UseVisualStyleBackColor = true;
            this.Drink0.CheckedChanged += new System.EventHandler(this.Drink0_CheckedChanged);
            // 
            // Drink1
            // 
            this.Drink1.AutoSize = true;
            this.Drink1.Location = new System.Drawing.Point(158, 19);
            this.Drink1.Name = "Drink1";
            this.Drink1.Size = new System.Drawing.Size(90, 17);
            this.Drink1.TabIndex = 3;
            this.Drink1.Text = "Light Drinking";
            this.Drink1.UseVisualStyleBackColor = true;
            this.Drink1.CheckedChanged += new System.EventHandler(this.Drink1_CheckedChanged);
            // 
            // Drink2
            // 
            this.Drink2.AccessibleDescription = "z";
            this.Drink2.AutoSize = true;
            this.Drink2.Checked = true;
            this.Drink2.Location = new System.Drawing.Point(299, 19);
            this.Drink2.Name = "Drink2";
            this.Drink2.Size = new System.Drawing.Size(100, 17);
            this.Drink2.TabIndex = 4;
            this.Drink2.TabStop = true;
            this.Drink2.Text = "Normal Drinking";
            this.Drink2.UseVisualStyleBackColor = true;
            this.Drink2.CheckedChanged += new System.EventHandler(this.Drink2_CheckedChanged);
            // 
            // DrinkBox
            // 
            this.DrinkBox.Controls.Add(this.Drink2);
            this.DrinkBox.Controls.Add(this.Drink1);
            this.DrinkBox.Controls.Add(this.Drink0);
            this.DrinkBox.Location = new System.Drawing.Point(37, 74);
            this.DrinkBox.Name = "DrinkBox";
            this.DrinkBox.Size = new System.Drawing.Size(414, 47);
            this.DrinkBox.TabIndex = 5;
            this.DrinkBox.TabStop = false;
            this.DrinkBox.Text = "Drinking Level";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(37, 16);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(77, 13);
            this.numberLabel.TabIndex = 6;
            this.numberLabel.Text = "Number Cards:";
            // 
            // NumberSpinner
            // 
            this.NumberSpinner.Location = new System.Drawing.Point(127, 14);
            this.NumberSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumberSpinner.Name = "NumberSpinner";
            this.NumberSpinner.Size = new System.Drawing.Size(29, 20);
            this.NumberSpinner.TabIndex = 7;
            this.NumberSpinner.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Draw Cards:";
            // 
            // DrawSpinner
            // 
            this.DrawSpinner.Location = new System.Drawing.Point(127, 44);
            this.DrawSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.DrawSpinner.Name = "DrawSpinner";
            this.DrawSpinner.Size = new System.Drawing.Size(29, 20);
            this.DrawSpinner.TabIndex = 9;
            this.DrawSpinner.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Princess Cards:";
            // 
            // PrincessSpinner
            // 
            this.PrincessSpinner.Location = new System.Drawing.Point(353, 14);
            this.PrincessSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PrincessSpinner.Name = "PrincessSpinner";
            this.PrincessSpinner.Size = new System.Drawing.Size(31, 20);
            this.PrincessSpinner.TabIndex = 11;
            this.PrincessSpinner.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Princess Drink Cards:";
            // 
            // PrincessDrinkSpinner
            // 
            this.PrincessDrinkSpinner.Location = new System.Drawing.Point(353, 44);
            this.PrincessDrinkSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PrincessDrinkSpinner.Name = "PrincessDrinkSpinner";
            this.PrincessDrinkSpinner.Size = new System.Drawing.Size(31, 20);
            this.PrincessDrinkSpinner.TabIndex = 13;
            this.PrincessDrinkSpinner.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Boom Cards:";
            // 
            // BoomSpinner
            // 
            this.BoomSpinner.Location = new System.Drawing.Point(127, 72);
            this.BoomSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.BoomSpinner.Name = "BoomSpinner";
            this.BoomSpinner.Size = new System.Drawing.Size(29, 20);
            this.BoomSpinner.TabIndex = 15;
            this.BoomSpinner.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Skip/Double Down Cards:";
            // 
            // PassSpinner
            // 
            this.PassSpinner.Location = new System.Drawing.Point(353, 72);
            this.PassSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PassSpinner.Name = "PassSpinner";
            this.PassSpinner.Size = new System.Drawing.Size(31, 20);
            this.PassSpinner.TabIndex = 17;
            this.PassSpinner.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Grey Cards:";
            // 
            // GraySpinner
            // 
            this.GraySpinner.Location = new System.Drawing.Point(127, 101);
            this.GraySpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.GraySpinner.Name = "GraySpinner";
            this.GraySpinner.Size = new System.Drawing.Size(29, 20);
            this.GraySpinner.TabIndex = 19;
            this.GraySpinner.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(175, 274);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(125, 45);
            this.SetButton.TabIndex = 20;
            this.SetButton.Text = "Set Options";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "Game";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Game Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LightMasterSpinner);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.GraySpinner);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PassSpinner);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.BoomSpinner);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PrincessDrinkSpinner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PrincessSpinner);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DrawSpinner);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumberSpinner);
            this.groupBox1.Controls.Add(this.numberLabel);
            this.groupBox1.Location = new System.Drawing.Point(37, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 129);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Card Sets";
            // 
            // LightMasterSpinner
            // 
            this.LightMasterSpinner.Location = new System.Drawing.Point(353, 102);
            this.LightMasterSpinner.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.LightMasterSpinner.Name = "LightMasterSpinner";
            this.LightMasterSpinner.Size = new System.Drawing.Size(30, 20);
            this.LightMasterSpinner.TabIndex = 21;
            this.LightMasterSpinner.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "LightMaster Cards:";
            // 
            // GameOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.DrinkBox);
            this.Controls.Add(this.presetLabel);
            this.Controls.Add(this.PresetBox);
            this.Name = "GameOptions";
            this.Text = "GameOptions";
            this.Load += new System.EventHandler(this.GameOptions_Load);
            this.DrinkBox.ResumeLayout(false);
            this.DrinkBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrincessSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrincessDrinkSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoomSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraySpinner)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightMasterSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PresetBox;
        private System.Windows.Forms.Label presetLabel;
        private System.Windows.Forms.RadioButton Drink0;
        private System.Windows.Forms.RadioButton Drink1;
        public System.Windows.Forms.RadioButton Drink2;
        private System.Windows.Forms.GroupBox DrinkBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.NumericUpDown NumberSpinner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DrawSpinner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PrincessSpinner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PrincessDrinkSpinner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown BoomSpinner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PassSpinner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown GraySpinner;
        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown LightMasterSpinner;
        private System.Windows.Forms.Label label8;
    }
}