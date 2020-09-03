namespace WeMo.Visual
{
    partial class WemoControl
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
            this.hostTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.connectionStatusLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.audiocapnum = new System.Windows.Forms.NumericUpDown();
            this.audiocaptimerChk = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.weblistenAddressTxt = new System.Windows.Forms.TextBox();
            this.weblistenerChk = new System.Windows.Forms.CheckBox();
            this.offSoundBtn = new System.Windows.Forms.Button();
            this.onSoundBtn = new System.Windows.Forms.Button();
            this.offSoundTxt = new System.Windows.Forms.TextBox();
            this.soundoffChk = new System.Windows.Forms.CheckBox();
            this.onsoundTxt = new System.Windows.Forms.TextBox();
            this.soundonChk = new System.Windows.Forms.CheckBox();
            this.toggleDelayChk = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toggleNum = new System.Windows.Forms.NumericUpDown();
            this.actionsStatePic = new System.Windows.Forms.PictureBox();
            this.startActionsBtn = new System.Windows.Forms.Button();
            this.connectedPanel = new System.Windows.Forms.Panel();
            this.wemoDevicePic = new System.Windows.Forms.PictureBox();
            this.OnOffPic = new System.Windows.Forms.PictureBox();
            this.connectPanel = new System.Windows.Forms.Panel();
            this.toggleOnNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.toggleOnChk = new System.Windows.Forms.CheckBox();
            this.toggleOffChk = new System.Windows.Forms.CheckBox();
            this.toggleOffNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.actionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audiocapnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionsStatePic)).BeginInit();
            this.connectedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wemoDevicePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffPic)).BeginInit();
            this.connectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOnNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOffNum)).BeginInit();
            this.SuspendLayout();
            // 
            // hostTxt
            // 
            this.hostTxt.Location = new System.Drawing.Point(46, 4);
            this.hostTxt.Margin = new System.Windows.Forms.Padding(4);
            this.hostTxt.Name = "hostTxt";
            this.hostTxt.Size = new System.Drawing.Size(189, 23);
            this.hostTxt.TabIndex = 0;
            this.hostTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hostTxt_KeyDown);
            this.hostTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hostTxt_KeyPress);
            // 
            // portTxt
            // 
            this.portTxt.Location = new System.Drawing.Point(276, 5);
            this.portTxt.Margin = new System.Windows.Forms.Padding(4);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(64, 23);
            this.portTxt.TabIndex = 1;
            this.portTxt.Text = "49153";
            this.portTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.portTxt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(388, 10);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(88, 26);
            this.connectBtn.TabIndex = 7;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // connectionStatusLbl
            // 
            this.connectionStatusLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.connectionStatusLbl.Location = new System.Drawing.Point(10, 43);
            this.connectionStatusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatusLbl.Name = "connectionStatusLbl";
            this.connectionStatusLbl.Size = new System.Drawing.Size(466, 17);
            this.connectionStatusLbl.TabIndex = 8;
            this.connectionStatusLbl.Text = "Disconnected";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.actionPanel);
            this.groupBox1.Controls.Add(this.actionsStatePic);
            this.groupBox1.Controls.Add(this.startActionsBtn);
            this.groupBox1.Location = new System.Drawing.Point(4, 163);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(468, 314);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.audiocapnum);
            this.actionPanel.Controls.Add(this.audiocaptimerChk);
            this.actionPanel.Controls.Add(this.progressBar1);
            this.actionPanel.Controls.Add(this.weblistenAddressTxt);
            this.actionPanel.Controls.Add(this.weblistenerChk);
            this.actionPanel.Controls.Add(this.offSoundBtn);
            this.actionPanel.Controls.Add(this.onSoundBtn);
            this.actionPanel.Controls.Add(this.offSoundTxt);
            this.actionPanel.Controls.Add(this.soundoffChk);
            this.actionPanel.Controls.Add(this.onsoundTxt);
            this.actionPanel.Controls.Add(this.soundonChk);
            this.actionPanel.Controls.Add(this.toggleOffChk);
            this.actionPanel.Controls.Add(this.toggleOnChk);
            this.actionPanel.Controls.Add(this.toggleDelayChk);
            this.actionPanel.Controls.Add(this.label3);
            this.actionPanel.Controls.Add(this.label6);
            this.actionPanel.Controls.Add(this.label5);
            this.actionPanel.Controls.Add(this.label4);
            this.actionPanel.Controls.Add(this.toggleOffNum);
            this.actionPanel.Controls.Add(this.toggleOnNum);
            this.actionPanel.Controls.Add(this.toggleNum);
            this.actionPanel.Location = new System.Drawing.Point(8, 15);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(450, 242);
            this.actionPanel.TabIndex = 5;
            // 
            // audiocapnum
            // 
            this.audiocapnum.Enabled = false;
            this.audiocapnum.Location = new System.Drawing.Point(144, 111);
            this.audiocapnum.Margin = new System.Windows.Forms.Padding(4);
            this.audiocapnum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.audiocapnum.Name = "audiocapnum";
            this.audiocapnum.Size = new System.Drawing.Size(47, 23);
            this.audiocapnum.TabIndex = 14;
            this.audiocapnum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // audiocaptimerChk
            // 
            this.audiocaptimerChk.AutoSize = true;
            this.audiocaptimerChk.Location = new System.Drawing.Point(6, 114);
            this.audiocaptimerChk.Margin = new System.Windows.Forms.Padding(4);
            this.audiocaptimerChk.Name = "audiocaptimerChk";
            this.audiocaptimerChk.Size = new System.Drawing.Size(82, 19);
            this.audiocaptimerChk.TabIndex = 12;
            this.audiocaptimerChk.Text = "Audio Cap";
            this.audiocaptimerChk.UseVisualStyleBackColor = true;
            this.audiocaptimerChk.CheckedChanged += new System.EventHandler(this.audiocaptimerChk_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(220, 110);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(227, 20);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // weblistenAddressTxt
            // 
            this.weblistenAddressTxt.Location = new System.Drawing.Point(144, 212);
            this.weblistenAddressTxt.Margin = new System.Windows.Forms.Padding(4);
            this.weblistenAddressTxt.Name = "weblistenAddressTxt";
            this.weblistenAddressTxt.Size = new System.Drawing.Size(260, 23);
            this.weblistenAddressTxt.TabIndex = 6;
            this.weblistenAddressTxt.Visible = false;
            // 
            // weblistenerChk
            // 
            this.weblistenerChk.AutoSize = true;
            this.weblistenerChk.Location = new System.Drawing.Point(6, 214);
            this.weblistenerChk.Margin = new System.Windows.Forms.Padding(4);
            this.weblistenerChk.Name = "weblistenerChk";
            this.weblistenerChk.Size = new System.Drawing.Size(94, 19);
            this.weblistenerChk.TabIndex = 5;
            this.weblistenerChk.Text = "Web Listener";
            this.weblistenerChk.UseVisualStyleBackColor = true;
            this.weblistenerChk.Visible = false;
            // 
            // offSoundBtn
            // 
            this.offSoundBtn.Location = new System.Drawing.Point(407, 175);
            this.offSoundBtn.Margin = new System.Windows.Forms.Padding(4);
            this.offSoundBtn.Name = "offSoundBtn";
            this.offSoundBtn.Size = new System.Drawing.Size(40, 21);
            this.offSoundBtn.TabIndex = 4;
            this.offSoundBtn.Text = "...";
            this.offSoundBtn.UseVisualStyleBackColor = true;
            this.offSoundBtn.Visible = false;
            // 
            // onSoundBtn
            // 
            this.onSoundBtn.Location = new System.Drawing.Point(407, 151);
            this.onSoundBtn.Margin = new System.Windows.Forms.Padding(4);
            this.onSoundBtn.Name = "onSoundBtn";
            this.onSoundBtn.Size = new System.Drawing.Size(40, 21);
            this.onSoundBtn.TabIndex = 4;
            this.onSoundBtn.Text = "...";
            this.onSoundBtn.UseVisualStyleBackColor = true;
            this.onSoundBtn.Visible = false;
            // 
            // offSoundTxt
            // 
            this.offSoundTxt.Location = new System.Drawing.Point(144, 176);
            this.offSoundTxt.Margin = new System.Windows.Forms.Padding(4);
            this.offSoundTxt.Name = "offSoundTxt";
            this.offSoundTxt.Size = new System.Drawing.Size(260, 23);
            this.offSoundTxt.TabIndex = 3;
            this.offSoundTxt.Visible = false;
            // 
            // soundoffChk
            // 
            this.soundoffChk.AutoSize = true;
            this.soundoffChk.Location = new System.Drawing.Point(6, 176);
            this.soundoffChk.Margin = new System.Windows.Forms.Padding(4);
            this.soundoffChk.Name = "soundoffChk";
            this.soundoffChk.Size = new System.Drawing.Size(113, 19);
            this.soundoffChk.TabIndex = 2;
            this.soundoffChk.Text = "Sound While Off";
            this.soundoffChk.UseVisualStyleBackColor = true;
            this.soundoffChk.Visible = false;
            // 
            // onsoundTxt
            // 
            this.onsoundTxt.Location = new System.Drawing.Point(144, 150);
            this.onsoundTxt.Margin = new System.Windows.Forms.Padding(4);
            this.onsoundTxt.Name = "onsoundTxt";
            this.onsoundTxt.Size = new System.Drawing.Size(260, 23);
            this.onsoundTxt.TabIndex = 3;
            this.onsoundTxt.Visible = false;
            // 
            // soundonChk
            // 
            this.soundonChk.AutoSize = true;
            this.soundonChk.Location = new System.Drawing.Point(6, 151);
            this.soundonChk.Margin = new System.Windows.Forms.Padding(4);
            this.soundonChk.Name = "soundonChk";
            this.soundonChk.Size = new System.Drawing.Size(112, 19);
            this.soundonChk.TabIndex = 2;
            this.soundonChk.Text = "Sound While On";
            this.soundonChk.UseVisualStyleBackColor = true;
            this.soundonChk.Visible = false;
            // 
            // toggleDelayChk
            // 
            this.toggleDelayChk.AutoSize = true;
            this.toggleDelayChk.Location = new System.Drawing.Point(6, 11);
            this.toggleDelayChk.Margin = new System.Windows.Forms.Padding(4);
            this.toggleDelayChk.Name = "toggleDelayChk";
            this.toggleDelayChk.Size = new System.Drawing.Size(95, 19);
            this.toggleDelayChk.TabIndex = 2;
            this.toggleDelayChk.Text = "Toggle Delay";
            this.toggleDelayChk.UseVisualStyleBackColor = true;
            this.toggleDelayChk.CheckedChanged += new System.EventHandler(this.toggleDelayChk_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Seconds";
            // 
            // toggleNum
            // 
            this.toggleNum.Enabled = false;
            this.toggleNum.Location = new System.Drawing.Point(144, 8);
            this.toggleNum.Margin = new System.Windows.Forms.Padding(4);
            this.toggleNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.toggleNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toggleNum.Name = "toggleNum";
            this.toggleNum.Size = new System.Drawing.Size(70, 23);
            this.toggleNum.TabIndex = 1;
            this.toggleNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // actionsStatePic
            // 
            this.actionsStatePic.BackgroundImage = global::WeMo.Visual.Properties.Resources.bullet_red;
            this.actionsStatePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.actionsStatePic.Location = new System.Drawing.Point(425, 274);
            this.actionsStatePic.Margin = new System.Windows.Forms.Padding(4);
            this.actionsStatePic.Name = "actionsStatePic";
            this.actionsStatePic.Size = new System.Drawing.Size(37, 32);
            this.actionsStatePic.TabIndex = 4;
            this.actionsStatePic.TabStop = false;
            // 
            // startActionsBtn
            // 
            this.startActionsBtn.Location = new System.Drawing.Point(5, 265);
            this.startActionsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startActionsBtn.Name = "startActionsBtn";
            this.startActionsBtn.Size = new System.Drawing.Size(103, 41);
            this.startActionsBtn.TabIndex = 2;
            this.startActionsBtn.Text = "Start";
            this.startActionsBtn.UseVisualStyleBackColor = true;
            this.startActionsBtn.Click += new System.EventHandler(this.startActionsBtn_Click);
            // 
            // connectedPanel
            // 
            this.connectedPanel.Controls.Add(this.wemoDevicePic);
            this.connectedPanel.Controls.Add(this.OnOffPic);
            this.connectedPanel.Controls.Add(this.groupBox1);
            this.connectedPanel.Location = new System.Drawing.Point(10, 65);
            this.connectedPanel.Margin = new System.Windows.Forms.Padding(4);
            this.connectedPanel.Name = "connectedPanel";
            this.connectedPanel.Size = new System.Drawing.Size(480, 481);
            this.connectedPanel.TabIndex = 10;
            // 
            // wemoDevicePic
            // 
            this.wemoDevicePic.BackColor = System.Drawing.Color.Silver;
            this.wemoDevicePic.BackgroundImage = global::WeMo.Visual.Properties.Resources.belkin_switch;
            this.wemoDevicePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wemoDevicePic.Location = new System.Drawing.Point(4, 4);
            this.wemoDevicePic.Margin = new System.Windows.Forms.Padding(4);
            this.wemoDevicePic.Name = "wemoDevicePic";
            this.wemoDevicePic.Size = new System.Drawing.Size(164, 156);
            this.wemoDevicePic.TabIndex = 10;
            this.wemoDevicePic.TabStop = false;
            // 
            // OnOffPic
            // 
            this.OnOffPic.BackgroundImage = global::WeMo.Visual.Properties.Resources.switch_off_icon;
            this.OnOffPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OnOffPic.Location = new System.Drawing.Point(197, 4);
            this.OnOffPic.Margin = new System.Windows.Forms.Padding(4);
            this.OnOffPic.Name = "OnOffPic";
            this.OnOffPic.Size = new System.Drawing.Size(265, 156);
            this.OnOffPic.TabIndex = 6;
            this.OnOffPic.TabStop = false;
            this.OnOffPic.Click += new System.EventHandler(this.OnOffPic_Click);
            this.OnOffPic.MouseEnter += new System.EventHandler(this.OnOffPic_MouseEnter);
            this.OnOffPic.MouseLeave += new System.EventHandler(this.OnOffPic_MouseLeave);
            // 
            // connectPanel
            // 
            this.connectPanel.Controls.Add(this.hostTxt);
            this.connectPanel.Controls.Add(this.portTxt);
            this.connectPanel.Controls.Add(this.label1);
            this.connectPanel.Controls.Add(this.label2);
            this.connectPanel.Location = new System.Drawing.Point(10, 7);
            this.connectPanel.Margin = new System.Windows.Forms.Padding(4);
            this.connectPanel.Name = "connectPanel";
            this.connectPanel.Size = new System.Drawing.Size(354, 32);
            this.connectPanel.TabIndex = 11;
            // 
            // toggleOnNum
            // 
            this.toggleOnNum.Enabled = false;
            this.toggleOnNum.Location = new System.Drawing.Point(144, 43);
            this.toggleOnNum.Margin = new System.Windows.Forms.Padding(4);
            this.toggleOnNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.toggleOnNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toggleOnNum.Name = "toggleOnNum";
            this.toggleOnNum.Size = new System.Drawing.Size(70, 23);
            this.toggleOnNum.TabIndex = 1;
            this.toggleOnNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seconds";
            // 
            // toggleOnChk
            // 
            this.toggleOnChk.AutoSize = true;
            this.toggleOnChk.Location = new System.Drawing.Point(6, 47);
            this.toggleOnChk.Margin = new System.Windows.Forms.Padding(4);
            this.toggleOnChk.Name = "toggleOnChk";
            this.toggleOnChk.Size = new System.Drawing.Size(122, 19);
            this.toggleOnChk.TabIndex = 2;
            this.toggleOnChk.Text = "Toggle Delay (On)";
            this.toggleOnChk.UseVisualStyleBackColor = true;
            this.toggleOnChk.CheckedChanged += new System.EventHandler(this.toggleDelayChk_CheckedChanged);
            // 
            // toggleOffChk
            // 
            this.toggleOffChk.AutoSize = true;
            this.toggleOffChk.Location = new System.Drawing.Point(6, 74);
            this.toggleOffChk.Margin = new System.Windows.Forms.Padding(4);
            this.toggleOffChk.Name = "toggleOffChk";
            this.toggleOffChk.Size = new System.Drawing.Size(123, 19);
            this.toggleOffChk.TabIndex = 2;
            this.toggleOffChk.Text = "Toggle Delay (Off)";
            this.toggleOffChk.UseVisualStyleBackColor = true;
            this.toggleOffChk.CheckedChanged += new System.EventHandler(this.toggleDelayChk_CheckedChanged);
            // 
            // toggleOffNum
            // 
            this.toggleOffNum.Enabled = false;
            this.toggleOffNum.Location = new System.Drawing.Point(144, 71);
            this.toggleOffNum.Margin = new System.Windows.Forms.Padding(4);
            this.toggleOffNum.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.toggleOffNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toggleOffNum.Name = "toggleOffNum";
            this.toggleOffNum.Size = new System.Drawing.Size(70, 23);
            this.toggleOffNum.TabIndex = 1;
            this.toggleOffNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Seconds";
            // 
            // WemoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 559);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.connectPanel);
            this.Controls.Add(this.connectedPanel);
            this.Controls.Add(this.connectionStatusLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "WemoControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeMo Command Center";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audiocapnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionsStatePic)).EndInit();
            this.connectedPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wemoDevicePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnOffPic)).EndInit();
            this.connectPanel.ResumeLayout(false);
            this.connectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOnNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleOffNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox hostTxt;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox OnOffPic;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label connectionStatusLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown toggleNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button startActionsBtn;
        private System.Windows.Forms.PictureBox actionsStatePic;
        private System.Windows.Forms.Panel connectedPanel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button offSoundBtn;
        private System.Windows.Forms.Button onSoundBtn;
        private System.Windows.Forms.TextBox offSoundTxt;
        private System.Windows.Forms.CheckBox soundoffChk;
        private System.Windows.Forms.TextBox onsoundTxt;
        private System.Windows.Forms.CheckBox soundonChk;
        private System.Windows.Forms.CheckBox toggleDelayChk;
        private System.Windows.Forms.Panel connectPanel;
        private System.Windows.Forms.PictureBox wemoDevicePic;
        private System.Windows.Forms.TextBox weblistenAddressTxt;
        private System.Windows.Forms.CheckBox weblistenerChk;
        private System.Windows.Forms.CheckBox audiocaptimerChk;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown audiocapnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox toggleOffChk;
        private System.Windows.Forms.CheckBox toggleOnChk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown toggleOffNum;
        private System.Windows.Forms.NumericUpDown toggleOnNum;
    }
}

