﻿
namespace Rectify11ControlCenter
{
    partial class frmSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			this.themesSec = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.previewIMG = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.miscSec = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Welcometext = new System.Windows.Forms.Label();
			this.deskImg = new System.Windows.Forms.PictureBox();
			this.r11Ver = new System.Windows.Forms.Label();
			this.themeApplied = new System.Windows.Forms.Label();
			this.pcname = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.Label();
			this.OSname = new System.Windows.Forms.Label();
			this.previewImage = new System.Windows.Forms.PictureBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.themesSec.SuspendLayout();
			this.previewIMG.SuspendLayout();
			this.miscSec.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deskImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// themesSec
			// 
			this.themesSec.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.themesSec.Controls.Add(this.checkBox1);
			this.themesSec.Controls.Add(this.button1);
			this.themesSec.Controls.Add(this.checkBox2);
			this.themesSec.Controls.Add(this.previewIMG);
			this.themesSec.Controls.Add(this.linkLabel1);
			this.themesSec.Controls.Add(this.comboBox1);
			this.themesSec.Location = new System.Drawing.Point(28, 245);
			this.themesSec.Name = "themesSec";
			this.themesSec.Size = new System.Drawing.Size(366, 200);
			this.themesSec.TabIndex = 2;
			this.themesSec.TabStop = false;
			this.themesSec.Text = "groupBox1";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(155, 83);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(86, 19);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "Use Tabbed";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(261, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 28);
			this.button1.TabIndex = 5;
			this.button1.Text = "butt";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(155, 58);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(77, 19);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "chexBox2";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// previewIMG
			// 
			this.previewIMG.BackgroundImage = global::Rectify11ControlCenter.Properties.Resources.bloom;
			this.previewIMG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.previewIMG.Controls.Add(this.panel2);
			this.previewIMG.Location = new System.Drawing.Point(15, 28);
			this.previewIMG.Name = "previewIMG";
			this.previewIMG.Size = new System.Drawing.Size(125, 84);
			this.previewIMG.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.BackgroundImage = global::Rectify11ControlCenter.Properties.Resources.LightPreview;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel2.Location = new System.Drawing.Point(29, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(64, 64);
			this.panel2.TabIndex = 0;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
			this.linkLabel1.Location = new System.Drawing.Point(4, 179);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(133, 15);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "⧉ SecureUX ThemeTool";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(155, 29);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(192, 23);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// miscSec
			// 
			this.miscSec.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.miscSec.Controls.Add(this.flowLayoutPanel1);
			this.miscSec.Location = new System.Drawing.Point(400, 245);
			this.miscSec.Name = "miscSec";
			this.miscSec.Size = new System.Drawing.Size(368, 200);
			this.miscSec.TabIndex = 3;
			this.miscSec.TabStop = false;
			this.miscSec.Text = "groupBox2";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.BackgroundImage = global::Rectify11ControlCenter.Properties.Resources.PreviewPane;
			this.panel1.Controls.Add(this.Welcometext);
			this.panel1.Controls.Add(this.deskImg);
			this.panel1.Controls.Add(this.r11Ver);
			this.panel1.Controls.Add(this.themeApplied);
			this.panel1.Controls.Add(this.pcname);
			this.panel1.Controls.Add(this.username);
			this.panel1.Controls.Add(this.OSname);
			this.panel1.Controls.Add(this.previewImage);
			this.panel1.Location = new System.Drawing.Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(796, 206);
			this.panel1.TabIndex = 1;
			// 
			// Welcometext
			// 
			this.Welcometext.AutoSize = true;
			this.Welcometext.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Welcometext.Location = new System.Drawing.Point(223, 27);
			this.Welcometext.Name = "Welcometext";
			this.Welcometext.Size = new System.Drawing.Size(92, 25);
			this.Welcometext.TabIndex = 7;
			this.Welcometext.Text = "Welcome";
			// 
			// deskImg
			// 
			this.deskImg.Location = new System.Drawing.Point(37, 36);
			this.deskImg.Name = "deskImg";
			this.deskImg.Size = new System.Drawing.Size(158, 111);
			this.deskImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.deskImg.TabIndex = 6;
			this.deskImg.TabStop = false;
			// 
			// r11Ver
			// 
			this.r11Ver.AutoSize = true;
			this.r11Ver.Location = new System.Drawing.Point(227, 155);
			this.r11Ver.Name = "r11Ver";
			this.r11Ver.Size = new System.Drawing.Size(99, 15);
			this.r11Ver.TabIndex = 5;
			this.r11Ver.Text = "Rectify11 Version:";
			// 
			// themeApplied
			// 
			this.themeApplied.AutoSize = true;
			this.themeApplied.Location = new System.Drawing.Point(227, 130);
			this.themeApplied.Name = "themeApplied";
			this.themeApplied.Size = new System.Drawing.Size(46, 15);
			this.themeApplied.TabIndex = 4;
			this.themeApplied.Text = "Theme:";
			// 
			// pcname
			// 
			this.pcname.AutoSize = true;
			this.pcname.Location = new System.Drawing.Point(227, 106);
			this.pcname.Name = "pcname";
			this.pcname.Size = new System.Drawing.Size(57, 15);
			this.pcname.TabIndex = 3;
			this.pcname.Text = "PC Name";
			// 
			// username
			// 
			this.username.AutoSize = true;
			this.username.Location = new System.Drawing.Point(227, 82);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(63, 15);
			this.username.TabIndex = 2;
			this.username.Text = "Username:";
			// 
			// OSname
			// 
			this.OSname.AutoSize = true;
			this.OSname.Location = new System.Drawing.Point(227, 59);
			this.OSname.Name = "OSname";
			this.OSname.Size = new System.Drawing.Size(66, 15);
			this.OSname.TabIndex = 1;
			this.OSname.Text = "OS Version:";
			// 
			// previewImage
			// 
			this.previewImage.Image = global::Rectify11ControlCenter.Properties.Resources.previewIcon;
			this.previewImage.Location = new System.Drawing.Point(23, 11);
			this.previewImage.Name = "previewImage";
			this.previewImage.Size = new System.Drawing.Size(185, 185);
			this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.previewImage.TabIndex = 0;
			this.previewImage.TabStop = false;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(3, 3);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(130, 19);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Windows 11 Default";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(3, 28);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(150, 19);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Enhanced fluent menus";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(3, 53);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(243, 19);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Enhanced fluent menus (all items in root)";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(3, 78);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(100, 19);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Classic menus";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(3, 103);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(197, 19);
			this.radioButton5.TabIndex = 4;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "Classic menus with transparency";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.radioButton1);
			this.flowLayoutPanel1.Controls.Add(this.radioButton2);
			this.flowLayoutPanel1.Controls.Add(this.radioButton3);
			this.flowLayoutPanel1.Controls.Add(this.radioButton4);
			this.flowLayoutPanel1.Controls.Add(this.radioButton5);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 22);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(354, 166);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(797, 576);
			this.Controls.Add(this.miscSec);
			this.Controls.Add(this.themesSec);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmSettings";
			this.Text = "Rectify11 Control Center";
			this.themesSec.ResumeLayout(false);
			this.themesSec.PerformLayout();
			this.previewIMG.ResumeLayout(false);
			this.miscSec.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deskImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label OSname;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Label r11Ver;
        private System.Windows.Forms.Label themeApplied;
        private System.Windows.Forms.Label pcname;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.GroupBox themesSec;
        private System.Windows.Forms.GroupBox miscSec;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox deskImg;
        private System.Windows.Forms.Label Welcometext;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel previewIMG;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
	}
}

