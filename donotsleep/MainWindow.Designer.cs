namespace DAVIDSystems.donotsleep
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbm10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbm30 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbh1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbh2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbh4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbh12 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.tbForever = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSleep = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSleepNow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rbNever = new System.Windows.Forms.RadioButton();
            this.rbNext = new System.Windows.Forms.RadioButton();
            this.cbNext = new System.Windows.Forms.ComboBox();
            this.rbUntil = new System.Windows.Forms.RadioButton();
            this.dtUntilDate = new System.Windows.Forms.DateTimePicker();
            this.dtUntilTime = new System.Windows.Forms.DateTimePicker();
            this.rbAllow = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbSystem = new System.Windows.Forms.CheckBox();
            this.cbMonitor = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbWakeUp = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtAwakeTime = new System.Windows.Forms.DateTimePicker();
            this.dtAwake = new System.Windows.Forms.DateTimePicker();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "prevent computer from going to sleep";
            this.notifyIcon.BalloonTipTitle = "Do not sleep";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "prevent computer from going to sleep";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSettings,
            this.toolStripSeparator2,
            this.tbm10,
            this.tbm30,
            this.tbh1,
            this.tbh2,
            this.tbh4,
            this.tbh12,
            this.tbCustom,
            this.tbForever,
            this.toolStripSeparator3,
            this.tbSleep,
            this.tbSleepNow,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 286);
            // 
            // tbSettings
            // 
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Size = new System.Drawing.Size(146, 22);
            this.tbSettings.Text = "Settings";
            this.tbSettings.Click += new System.EventHandler(this.OnShowSettings);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // tbm10
            // 
            this.tbm10.Name = "tbm10";
            this.tbm10.Size = new System.Drawing.Size(146, 22);
            this.tbm10.Text = "10 minutes";
            this.tbm10.Click += new System.EventHandler(this.On10Min);
            // 
            // tbm30
            // 
            this.tbm30.Name = "tbm30";
            this.tbm30.Size = new System.Drawing.Size(146, 22);
            this.tbm30.Text = "30 minutes";
            this.tbm30.Click += new System.EventHandler(this.On30Min);
            // 
            // tbh1
            // 
            this.tbh1.Name = "tbh1";
            this.tbh1.Size = new System.Drawing.Size(146, 22);
            this.tbh1.Text = "1 hour";
            this.tbh1.Click += new System.EventHandler(this.On1Hour);
            // 
            // tbh2
            // 
            this.tbh2.Name = "tbh2";
            this.tbh2.Size = new System.Drawing.Size(146, 22);
            this.tbh2.Text = "2 hours";
            this.tbh2.Click += new System.EventHandler(this.On2Hours);
            // 
            // tbh4
            // 
            this.tbh4.Name = "tbh4";
            this.tbh4.Size = new System.Drawing.Size(146, 22);
            this.tbh4.Text = "4 hours";
            this.tbh4.Click += new System.EventHandler(this.On4Hours);
            // 
            // tbh12
            // 
            this.tbh12.Name = "tbh12";
            this.tbh12.Size = new System.Drawing.Size(146, 22);
            this.tbh12.Text = "12 hours";
            this.tbh12.Click += new System.EventHandler(this.On12Hours);
            // 
            // tbCustom
            // 
            this.tbCustom.Name = "tbCustom";
            this.tbCustom.Size = new System.Drawing.Size(146, 22);
            this.tbCustom.Text = "Custom";
            // 
            // tbForever
            // 
            this.tbForever.Name = "tbForever";
            this.tbForever.Size = new System.Drawing.Size(146, 22);
            this.tbForever.Text = "Do not sleep !";
            this.tbForever.Click += new System.EventHandler(this.OnDisableSleep);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // tbSleep
            // 
            this.tbSleep.Name = "tbSleep";
            this.tbSleep.Size = new System.Drawing.Size(146, 22);
            this.tbSleep.Text = "Let me sleep !";
            this.tbSleep.Click += new System.EventHandler(this.OnUsersAllowsSleeping);
            // 
            // tbSleepNow
            // 
            this.tbSleepNow.Name = "tbSleepNow";
            this.tbSleepNow.Size = new System.Drawing.Size(146, 22);
            this.tbSleepNow.Text = "Sleep Now !";
            this.tbSleepNow.Click += new System.EventHandler(this.OnSleepNow);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem2.Text = "Exit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.OnExitApplication);
            // 
            // rbNever
            // 
            this.rbNever.AutoSize = true;
            this.rbNever.Location = new System.Drawing.Point(9, 83);
            this.rbNever.Margin = new System.Windows.Forms.Padding(2);
            this.rbNever.Name = "rbNever";
            this.rbNever.Size = new System.Drawing.Size(58, 17);
            this.rbNever.TabIndex = 0;
            this.rbNever.Text = "forever";
            this.rbNever.UseVisualStyleBackColor = true;
            // 
            // rbNext
            // 
            this.rbNext.AutoSize = true;
            this.rbNext.Location = new System.Drawing.Point(9, 116);
            this.rbNext.Margin = new System.Windows.Forms.Padding(2);
            this.rbNext.Name = "rbNext";
            this.rbNext.Size = new System.Drawing.Size(63, 17);
            this.rbNext.TabIndex = 1;
            this.rbNext.Text = "the next";
            this.rbNext.UseVisualStyleBackColor = true;
            // 
            // cbNext
            // 
            this.cbNext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNext.FormattingEnabled = true;
            this.cbNext.Items.AddRange(new object[] {
            "1 minute",
            "2 minutes",
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour",
            "2 hours",
            "4 hours",
            "8 hours",
            "16 hours",
            "day",
            "2 days",
            "4 days",
            "week",
            "2 weeks",
            "3 weeks",
            "month"});
            this.cbNext.Location = new System.Drawing.Point(80, 115);
            this.cbNext.Margin = new System.Windows.Forms.Padding(2);
            this.cbNext.Name = "cbNext";
            this.cbNext.Size = new System.Drawing.Size(92, 21);
            this.cbNext.TabIndex = 2;
            // 
            // rbUntil
            // 
            this.rbUntil.AutoSize = true;
            this.rbUntil.Location = new System.Drawing.Point(9, 149);
            this.rbUntil.Margin = new System.Windows.Forms.Padding(2);
            this.rbUntil.Name = "rbUntil";
            this.rbUntil.Size = new System.Drawing.Size(44, 17);
            this.rbUntil.TabIndex = 3;
            this.rbUntil.Text = "until";
            this.rbUntil.UseVisualStyleBackColor = true;
            // 
            // dtUntilDate
            // 
            this.dtUntilDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtUntilDate.Location = new System.Drawing.Point(80, 148);
            this.dtUntilDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtUntilDate.Name = "dtUntilDate";
            this.dtUntilDate.Size = new System.Drawing.Size(102, 20);
            this.dtUntilDate.TabIndex = 4;
            // 
            // dtUntilTime
            // 
            this.dtUntilTime.CustomFormat = "HH:mm";
            this.dtUntilTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUntilTime.Location = new System.Drawing.Point(185, 148);
            this.dtUntilTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtUntilTime.Name = "dtUntilTime";
            this.dtUntilTime.ShowUpDown = true;
            this.dtUntilTime.Size = new System.Drawing.Size(70, 20);
            this.dtUntilTime.TabIndex = 5;
            // 
            // rbAllow
            // 
            this.rbAllow.AutoSize = true;
            this.rbAllow.Checked = true;
            this.rbAllow.Location = new System.Drawing.Point(9, 181);
            this.rbAllow.Margin = new System.Windows.Forms.Padding(2);
            this.rbAllow.Name = "rbAllow";
            this.rbAllow.Size = new System.Drawing.Size(91, 17);
            this.rbAllow.TabIndex = 6;
            this.rbAllow.TabStop = true;
            this.rbAllow.Text = "allow sleeping";
            this.rbAllow.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(172, 332);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 35);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(259, 332);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Settings:";
            // 
            // cbSystem
            // 
            this.cbSystem.AutoSize = true;
            this.cbSystem.Checked = true;
            this.cbSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSystem.Enabled = false;
            this.cbSystem.Location = new System.Drawing.Point(16, 17);
            this.cbSystem.Margin = new System.Windows.Forms.Padding(2);
            this.cbSystem.Name = "cbSystem";
            this.cbSystem.Size = new System.Drawing.Size(60, 17);
            this.cbSystem.TabIndex = 11;
            this.cbSystem.Text = "System";
            this.cbSystem.UseVisualStyleBackColor = true;
            // 
            // cbMonitor
            // 
            this.cbMonitor.AutoSize = true;
            this.cbMonitor.Checked = true;
            this.cbMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMonitor.Location = new System.Drawing.Point(15, 38);
            this.cbMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.cbMonitor.Name = "cbMonitor";
            this.cbMonitor.Size = new System.Drawing.Size(61, 17);
            this.cbMonitor.TabIndex = 12;
            this.cbMonitor.Text = "Monitor";
            this.cbMonitor.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSystem);
            this.groupBox1.Controls.Add(this.cbMonitor);
            this.groupBox1.Location = new System.Drawing.Point(234, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(104, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disable sleep for:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 49);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(7, 20);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(97, 13);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "sleeping allowed....";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.dateTimePicker2);
            this.groupBox3.Location = new System.Drawing.Point(10, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 99);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wake Up @";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "hours";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 minute",
            "2 minutes",
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour",
            "2 hours",
            "4 hours",
            "8 hours",
            "16 hours",
            "day",
            "2 days",
            "4 days",
            "week",
            "2 weeks",
            "3 weeks",
            "month"});
            this.comboBox1.Location = new System.Drawing.Point(88, 60);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "for";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(110, 30);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(70, 20);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(5, 30);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(102, 20);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbWakeUp);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbFor);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.dtAwakeTime);
            this.groupBox4.Controls.Add(this.dtAwake);
            this.groupBox4.Location = new System.Drawing.Point(10, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 99);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wake Up from Sleep:";
            // 
            // cbWakeUp
            // 
            this.cbWakeUp.AutoSize = true;
            this.cbWakeUp.Location = new System.Drawing.Point(10, 19);
            this.cbWakeUp.Name = "cbWakeUp";
            this.cbWakeUp.Size = new System.Drawing.Size(65, 17);
            this.cbWakeUp.TabIndex = 20;
            this.cbWakeUp.Text = "Enabled";
            this.cbWakeUp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "hours";
            // 
            // cbFor
            // 
            this.cbFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFor.FormattingEnabled = true;
            this.cbFor.Items.AddRange(new object[] {
            "1 minute",
            "2 minutes",
            "5 minutes",
            "10 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour",
            "2 hours",
            "4 hours",
            "8 hours",
            "12 hours",
            "16 hours",
            "day",
            "2 days",
            "4 days",
            "week"});
            this.cbFor.Location = new System.Drawing.Point(70, 64);
            this.cbFor.Margin = new System.Windows.Forms.Padding(2);
            this.cbFor.Name = "cbFor";
            this.cbFor.Size = new System.Drawing.Size(116, 21);
            this.cbFor.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "for";
            // 
            // dtAwakeTime
            // 
            this.dtAwakeTime.CustomFormat = "HH:mm";
            this.dtAwakeTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAwakeTime.Location = new System.Drawing.Point(116, 42);
            this.dtAwakeTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtAwakeTime.Name = "dtAwakeTime";
            this.dtAwakeTime.ShowUpDown = true;
            this.dtAwakeTime.Size = new System.Drawing.Size(70, 20);
            this.dtAwakeTime.TabIndex = 17;
            // 
            // dtAwake
            // 
            this.dtAwake.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAwake.Location = new System.Drawing.Point(10, 42);
            this.dtAwake.Margin = new System.Windows.Forms.Padding(2);
            this.dtAwake.Name = "dtAwake";
            this.dtAwake.Size = new System.Drawing.Size(102, 20);
            this.dtAwake.TabIndex = 16;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 356);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Documentation:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLink);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(349, 378);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbAllow);
            this.Controls.Add(this.dtUntilTime);
            this.Controls.Add(this.dtUntilDate);
            this.Controls.Add(this.rbUntil);
            this.Controls.Add(this.cbNext);
            this.Controls.Add(this.rbNext);
            this.Controls.Add(this.rbNever);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Do not sleep";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.OnInitForm);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.RadioButton rbNever;
        private System.Windows.Forms.RadioButton rbNext;
        private System.Windows.Forms.ComboBox cbNext;
        private System.Windows.Forms.RadioButton rbUntil;
        private System.Windows.Forms.DateTimePicker dtUntilDate;
        private System.Windows.Forms.DateTimePicker dtUntilTime;
        private System.Windows.Forms.RadioButton rbAllow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tbSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbSystem;
        private System.Windows.Forms.CheckBox cbMonitor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tbm10;
        private System.Windows.Forms.ToolStripMenuItem tbm30;
        private System.Windows.Forms.ToolStripMenuItem tbh1;
        private System.Windows.Forms.ToolStripMenuItem tbh2;
        private System.Windows.Forms.ToolStripMenuItem tbh4;
        private System.Windows.Forms.ToolStripMenuItem tbh12;
        private System.Windows.Forms.ToolStripMenuItem tbSleep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ToolStripMenuItem tbCustom;
        private System.Windows.Forms.ToolStripMenuItem tbForever;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbWakeUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtAwakeTime;
        private System.Windows.Forms.DateTimePicker dtAwake;
        private System.Windows.Forms.ToolStripMenuItem tbSleepNow;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

