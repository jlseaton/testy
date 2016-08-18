namespace Testy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelTop = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBoxURL = new System.Windows.Forms.ComboBox();
            this.checkBoxLogFile = new System.Windows.Forms.CheckBox();
            this.checkBoxShowEvents = new System.Windows.Forms.CheckBox();
            this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSleep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownEventThreshhold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTestRuns = new System.Windows.Forms.NumericUpDown();
            this.labelConfiguration = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.comboBoxConfig = new System.Windows.Forms.ComboBox();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventThreshhold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(693, 363);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Tag = "";
            this.buttonStart.Text = "&Start";
            this.toolTip1.SetToolTip(this.buttonStart, "Start or Stop a test");
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.BackColor = System.Drawing.Color.Transparent;
            this.labelTop.Location = new System.Drawing.Point(13, 11);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(40, 13);
            this.labelTop.TabIndex = 2;
            this.labelTop.Text = "Events";
            this.labelTop.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelStatus.Location = new System.Drawing.Point(77, 346);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 7;
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvents.Location = new System.Drawing.Point(14, 27);
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.ReadOnly = true;
            this.textBoxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEvents.Size = new System.Drawing.Size(757, 290);
            this.textBoxEvents.TabIndex = 4;
            this.textBoxEvents.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(15, 321);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(757, 23);
            this.progressBar1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.progressBar1, "Testing Progress Indicator");
            this.progressBar1.Visible = false;
            // 
            // comboBoxURL
            // 
            this.comboBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxURL.FormattingEnabled = true;
            this.comboBoxURL.Items.AddRange(new object[] {
            "http://localhost/iisstart.htm"});
            this.comboBoxURL.Location = new System.Drawing.Point(78, 364);
            this.comboBoxURL.Name = "comboBoxURL";
            this.comboBoxURL.Size = new System.Drawing.Size(480, 21);
            this.comboBoxURL.TabIndex = 1;
            // 
            // checkBoxLogFile
            // 
            this.checkBoxLogFile.AutoSize = true;
            this.checkBoxLogFile.Location = new System.Drawing.Point(456, 8);
            this.checkBoxLogFile.Name = "checkBoxLogFile";
            this.checkBoxLogFile.Size = new System.Drawing.Size(111, 17);
            this.checkBoxLogFile.TabIndex = 4;
            this.checkBoxLogFile.Text = "&Log Events to File";
            this.toolTip1.SetToolTip(this.checkBoxLogFile, "Log events to a text file stamped with the current date and time");
            this.checkBoxLogFile.UseVisualStyleBackColor = true;
            this.checkBoxLogFile.CheckedChanged += new System.EventHandler(this.checkBoxLogFile_CheckedChanged);
            // 
            // checkBoxShowEvents
            // 
            this.checkBoxShowEvents.AutoSize = true;
            this.checkBoxShowEvents.Location = new System.Drawing.Point(575, 8);
            this.checkBoxShowEvents.Name = "checkBoxShowEvents";
            this.checkBoxShowEvents.Size = new System.Drawing.Size(96, 17);
            this.checkBoxShowEvents.TabIndex = 3;
            this.checkBoxShowEvents.Text = "Display E&vents";
            this.toolTip1.SetToolTip(this.checkBoxShowEvents, "Display events in the GUI");
            this.checkBoxShowEvents.UseVisualStyleBackColor = true;
            this.checkBoxShowEvents.CheckedChanged += new System.EventHandler(this.checkBoxDisplayEvents_CheckedChanged);
            // 
            // numericUpDownThreads
            // 
            this.numericUpDownThreads.Location = new System.Drawing.Point(161, 33);
            this.numericUpDownThreads.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThreads.Name = "numericUpDownThreads";
            this.numericUpDownThreads.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownThreads.TabIndex = 8;
            this.toolTip1.SetToolTip(this.numericUpDownThreads, "Number of simultaneous executing threads");
            this.numericUpDownThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThreads.ValueChanged += new System.EventHandler(this.numericUpDownThreads_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Threads";
            this.toolTip1.SetToolTip(this.label3, "Number of threads to simultaneously run the test");
            // 
            // numericUpDownSleep
            // 
            this.numericUpDownSleep.Location = new System.Drawing.Point(273, 33);
            this.numericUpDownSleep.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSleep.Name = "numericUpDownSleep";
            this.numericUpDownSleep.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownSleep.TabIndex = 7;
            this.toolTip1.SetToolTip(this.numericUpDownSleep, "Maximum randomized delay between each URL request");
            this.numericUpDownSleep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSleep.ValueChanged += new System.EventHandler(this.numericUpDownSleep_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Delay (ms)";
            this.toolTip1.SetToolTip(this.label4, "Maximum (randomized) delay, in miliseconds, between each request");
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1500;
            this.toolTip1.IsBalloon = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Test Runs";
            this.toolTip1.SetToolTip(this.label6, "Number of times to run the test");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Threshhold";
            this.toolTip1.SetToolTip(this.label7, "Number of events to occur before logging");
            // 
            // numericUpDownEventThreshhold
            // 
            this.numericUpDownEventThreshhold.Location = new System.Drawing.Point(394, 33);
            this.numericUpDownEventThreshhold.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDownEventThreshhold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEventThreshhold.Name = "numericUpDownEventThreshhold";
            this.numericUpDownEventThreshhold.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownEventThreshhold.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numericUpDownEventThreshhold, "Number of events to occur before logging (higher number for better performance)");
            this.numericUpDownEventThreshhold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownEventThreshhold.ValueChanged += new System.EventHandler(this.numericUpDownEventThreshhold_ValueChanged);
            // 
            // numericUpDownTestRuns
            // 
            this.numericUpDownTestRuns.Location = new System.Drawing.Point(63, 33);
            this.numericUpDownTestRuns.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTestRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTestRuns.Name = "numericUpDownTestRuns";
            this.numericUpDownTestRuns.Size = new System.Drawing.Size(41, 20);
            this.numericUpDownTestRuns.TabIndex = 9;
            this.toolTip1.SetToolTip(this.numericUpDownTestRuns, "Number of times to run this test");
            this.numericUpDownTestRuns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTestRuns.ValueChanged += new System.EventHandler(this.numericUpDownTestRuns_ValueChanged);
            // 
            // labelConfiguration
            // 
            this.labelConfiguration.AutoSize = true;
            this.labelConfiguration.Location = new System.Drawing.Point(4, 8);
            this.labelConfiguration.Name = "labelConfiguration";
            this.labelConfiguration.Size = new System.Drawing.Size(72, 13);
            this.labelConfiguration.TabIndex = 24;
            this.labelConfiguration.Text = "Configuration:";
            this.toolTip1.SetToolTip(this.labelConfiguration, "Double click for configuration details");
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "URL to Test:";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBackground.Location = new System.Drawing.Point(15, 9);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(758, 306);
            this.pictureBoxBackground.TabIndex = 17;
            this.pictureBoxBackground.TabStop = false;
            this.pictureBoxBackground.Visible = false;
            this.pictureBoxBackground.WaitOnLoad = true;
            // 
            // comboBoxConfig
            // 
            this.comboBoxConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfig.FormattingEnabled = true;
            this.comboBoxConfig.Location = new System.Drawing.Point(76, 5);
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(363, 21);
            this.comboBoxConfig.TabIndex = 5;
            this.comboBoxConfig.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfig_SelectedIndexChanged);
            // 
            // panelConfig
            // 
            this.panelConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConfig.Controls.Add(this.checkBoxAutoStart);
            this.panelConfig.Controls.Add(this.labelConfiguration);
            this.panelConfig.Controls.Add(this.comboBoxConfig);
            this.panelConfig.Controls.Add(this.label7);
            this.panelConfig.Controls.Add(this.numericUpDownEventThreshhold);
            this.panelConfig.Controls.Add(this.label6);
            this.panelConfig.Controls.Add(this.checkBoxShowEvents);
            this.panelConfig.Controls.Add(this.checkBoxLogFile);
            this.panelConfig.Controls.Add(this.numericUpDownTestRuns);
            this.panelConfig.Controls.Add(this.numericUpDownThreads);
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Controls.Add(this.numericUpDownSleep);
            this.panelConfig.Controls.Add(this.label4);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelConfig.Location = new System.Drawing.Point(0, 394);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(784, 70);
            this.panelConfig.TabIndex = 25;
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(691, 8);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(73, 17);
            this.checkBoxAutoStart.TabIndex = 2;
            this.checkBoxAutoStart.Text = "&Auto Start";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Last Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxURL);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxEvents);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.pictureBoxBackground);
            this.Controls.Add(this.label5);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Testy";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEventThreshhold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTestRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBoxURL;
        private System.Windows.Forms.CheckBox checkBoxLogFile;
        private System.Windows.Forms.CheckBox checkBoxShowEvents;
        private System.Windows.Forms.NumericUpDown numericUpDownThreads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSleep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownTestRuns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownEventThreshhold;
        private System.Windows.Forms.ComboBox comboBoxConfig;
        private System.Windows.Forms.Label labelConfiguration;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
    }
}

