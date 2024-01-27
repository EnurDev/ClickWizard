namespace Click_Wizard
{
    partial class Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.appTitle = new System.Windows.Forms.Label();
            this.millisecondsLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minutesText = new System.Windows.Forms.TextBox();
            this.secondsText = new System.Windows.Forms.TextBox();
            this.millisecondsText = new System.Windows.Forms.TextBox();
            this.leftRadio = new System.Windows.Forms.RadioButton();
            this.middleRadio = new System.Windows.Forms.RadioButton();
            this.rightRadio = new System.Windows.Forms.RadioButton();
            this.clickerstartButton = new System.Windows.Forms.Button();
            this.clickerstopButton = new System.Windows.Forms.Button();
            this.clickerStatus = new System.Windows.Forms.Label();
            this.cpsCounter = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appTitle
            // 
            this.appTitle.Location = new System.Drawing.Point(34, 34);
            this.appTitle.Name = "appTitle";
            this.appTitle.Size = new System.Drawing.Size(385, 33);
            this.appTitle.TabIndex = 0;
            this.appTitle.Text = "[APPLICATION TITLE]";
            // 
            // millisecondsLabel
            // 
            this.millisecondsLabel.Location = new System.Drawing.Point(6, 19);
            this.millisecondsLabel.Name = "millisecondsLabel";
            this.millisecondsLabel.Size = new System.Drawing.Size(100, 23);
            this.millisecondsLabel.TabIndex = 4;
            this.millisecondsLabel.Text = "[Miliseconds Label]";
            // 
            // secondsLabel
            // 
            this.secondsLabel.Location = new System.Drawing.Point(137, 19);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(100, 23);
            this.secondsLabel.TabIndex = 5;
            this.secondsLabel.Text = "[Seconds Label]";
            // 
            // minutesLabel
            // 
            this.minutesLabel.Location = new System.Drawing.Point(265, 19);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(100, 23);
            this.minutesLabel.TabIndex = 6;
            this.minutesLabel.Text = "[Minutes Label]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minutesText);
            this.groupBox1.Controls.Add(this.secondsText);
            this.groupBox1.Controls.Add(this.millisecondsText);
            this.groupBox1.Controls.Add(this.millisecondsLabel);
            this.groupBox1.Controls.Add(this.minutesLabel);
            this.groupBox1.Controls.Add(this.secondsLabel);
            this.groupBox1.Location = new System.Drawing.Point(34, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[Time Unit GroupBox]";
            // 
            // minutesText
            // 
            this.minutesText.Location = new System.Drawing.Point(265, 45);
            this.minutesText.Name = "minutesText";
            this.minutesText.Size = new System.Drawing.Size(100, 20);
            this.minutesText.TabIndex = 9;
            // 
            // secondsText
            // 
            this.secondsText.Location = new System.Drawing.Point(137, 45);
            this.secondsText.Name = "secondsText";
            this.secondsText.Size = new System.Drawing.Size(100, 20);
            this.secondsText.TabIndex = 8;
            // 
            // millisecondsText
            // 
            this.millisecondsText.Location = new System.Drawing.Point(6, 45);
            this.millisecondsText.Name = "millisecondsText";
            this.millisecondsText.Size = new System.Drawing.Size(100, 20);
            this.millisecondsText.TabIndex = 7;
            // 
            // leftRadio
            // 
            this.leftRadio.Location = new System.Drawing.Point(40, 179);
            this.leftRadio.Name = "leftRadio";
            this.leftRadio.Size = new System.Drawing.Size(100, 24);
            this.leftRadio.TabIndex = 8;
            this.leftRadio.TabStop = true;
            this.leftRadio.Text = "[LeftRadio]";
            this.leftRadio.UseVisualStyleBackColor = true;
            // 
            // middleRadio
            // 
            this.middleRadio.Location = new System.Drawing.Point(171, 179);
            this.middleRadio.Name = "middleRadio";
            this.middleRadio.Size = new System.Drawing.Size(100, 24);
            this.middleRadio.TabIndex = 9;
            this.middleRadio.TabStop = true;
            this.middleRadio.Text = "[MiddleRadio]";
            this.middleRadio.UseVisualStyleBackColor = true;
            // 
            // rightRadio
            // 
            this.rightRadio.Location = new System.Drawing.Point(299, 179);
            this.rightRadio.Name = "rightRadio";
            this.rightRadio.Size = new System.Drawing.Size(100, 24);
            this.rightRadio.TabIndex = 10;
            this.rightRadio.TabStop = true;
            this.rightRadio.Text = "[RightRadio]";
            this.rightRadio.UseVisualStyleBackColor = true;
            // 
            // clickerstartButton
            // 
            this.clickerstartButton.Location = new System.Drawing.Point(34, 223);
            this.clickerstartButton.Name = "clickerstartButton";
            this.clickerstartButton.Size = new System.Drawing.Size(185, 37);
            this.clickerstartButton.TabIndex = 11;
            this.clickerstartButton.Text = "[START BUTTON]";
            this.clickerstartButton.UseVisualStyleBackColor = true;
            this.clickerstartButton.Click += new System.EventHandler(this.clickerstartButton_Click);
            // 
            // clickerstopButton
            // 
            this.clickerstopButton.Location = new System.Drawing.Point(234, 223);
            this.clickerstopButton.Name = "clickerstopButton";
            this.clickerstopButton.Size = new System.Drawing.Size(185, 37);
            this.clickerstopButton.TabIndex = 12;
            this.clickerstopButton.Text = "[STOP BUTTON]";
            this.clickerstopButton.UseVisualStyleBackColor = true;
            this.clickerstopButton.Click += new System.EventHandler(this.clickerstopButton_Click);
            // 
            // clickerStatus
            // 
            this.clickerStatus.Location = new System.Drawing.Point(319, 63);
            this.clickerStatus.Name = "clickerStatus";
            this.clickerStatus.Size = new System.Drawing.Size(100, 23);
            this.clickerStatus.TabIndex = 13;
            this.clickerStatus.Text = "[STATUS]";
            // 
            // cpsCounter
            // 
            this.cpsCounter.Location = new System.Drawing.Point(34, 63);
            this.cpsCounter.Name = "cpsCounter";
            this.cpsCounter.Size = new System.Drawing.Size(100, 23);
            this.cpsCounter.TabIndex = 14;
            this.cpsCounter.Text = "[CPS]";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 295);
            this.Controls.Add(this.cpsCounter);
            this.Controls.Add(this.clickerStatus);
            this.Controls.Add(this.clickerstopButton);
            this.Controls.Add(this.clickerstartButton);
            this.Controls.Add(this.rightRadio);
            this.Controls.Add(this.middleRadio);
            this.Controls.Add(this.leftRadio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.appTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Application";
            this.Text = "[Application]";
            this.Load += new System.EventHandler(this.Application_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label clickerStatus;
        private System.Windows.Forms.Label cpsCounter;

        private System.Windows.Forms.TextBox millisecondsText;
        private System.Windows.Forms.TextBox secondsText;
        private System.Windows.Forms.TextBox minutesText;
        private System.Windows.Forms.RadioButton leftRadio;
        private System.Windows.Forms.RadioButton middleRadio;
        private System.Windows.Forms.RadioButton rightRadio;
        private System.Windows.Forms.Button clickerstartButton;
        private System.Windows.Forms.Button clickerstopButton;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Label appTitle;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label minutesLabel;

        private System.Windows.Forms.Label millisecondsLabel;

        #endregion
    }
}