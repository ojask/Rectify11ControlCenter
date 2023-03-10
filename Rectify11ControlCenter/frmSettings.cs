using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace Rectify11ControlCenter
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            OSname.Text = Rectify11ControlCenter.Controls.osV;
            username.Text = Rectify11ControlCenter.Controls.userN;
            pcname.Text = Rectify11ControlCenter.Controls.CumterName;
            themeApplied.Text = "Theme: " + Rectify11ControlCenter.Controls.theme();
            r11Ver.Text = Rectify11ControlCenter.Controls.r11Version;
            themesSec.Text = Rectify11ControlCenter.Controls.themeSection;
            miscSec.Text = Rectify11ControlCenter.Controls.miscSection;
            checkBox2.Text = Rectify11ControlCenter.Controls.mfeChexbox;
            button1.Text = Rectify11ControlCenter.Controls.applyButton;
            checkBox2.Checked = false;
            if (Process.GetProcessesByName("micaforeveryone").Length > 0)
            {
                checkBox2.Checked = true;
            }
            foreach (FileInfo i in Rectify11ControlCenter.Controls.themefiles)
            {
                var MyIni = new IniFile(i.FullName);
                string themename = MyIni.Read("DisplayName", "Theme");
                if (!themename.ToLower().Contains("themeui"))
                {
                    comboBox1.Items.Add(themename);
                }
                else if (themename.ToLower().Contains("themeui"))
                {
                    comboBox1.Items.Add(i.Name);
                }
            }
            comboBox1.SelectedItem = Rectify11ControlCenter.Controls.theme();
            if (comboBox1.SelectedItem == null)
            {
                button1.Enabled = false;
            }
            deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(Rectify11ControlCenter.Controls.appliedthemefile());
            updatePreviewImg(Rectify11ControlCenter.Controls.appliedthemefile());
            addroundedCorners();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void addroundedCorners()
        {
            Rectangle r = new Rectangle(0, 0, deskImg.Width, deskImg.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 6;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            deskImg.Region = new Region(gp);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            apply(comboBox1.SelectedItem.ToString());
            var MyIni = new IniFile(Path.Combine(Variables.Variables.Windir, "Resources", "Themes", comboBox1.SelectedItem.ToString() + ".theme"));
            string themename = MyIni.Read("DisplayName", "Theme");
            themeApplied.Text = "Theme: " + themename;
            await Task.Run(() => Application.Restart());
            Application.Exit();
        }
        public void apply(string j)
        {
            foreach (FileInfo i in Rectify11ControlCenter.Controls.themefiles)
            {
                var MyIni = new IniFile(i.FullName);
                string themename = MyIni.Read("DisplayName", "Theme");
                if (!j.ToLower().Contains(".theme") && j.ToLower() == themename.ToLower())
                {
                    waiting waiting1 = new waiting(i.FullName, checkBox2.Checked);
                    waiting1.ShowDialog();
                    deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(i.FullName);
                }
                else if (j.ToLower().Contains(".theme") && i.Name.ToLower() == j.ToLower())
                {
                    waiting waiting1 = new waiting(Path.Combine(Variables.Variables.Windir, "resources", "themes", j), checkBox2.Checked);
                    waiting1.ShowDialog();
                    deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(Path.Combine(Variables.Variables.Windir, "resources", "themes", j));
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(Path.Combine(Variables.Variables.Windir, "ThemeTool.exe")))
            {
                Process.Start(Path.Combine(Variables.Variables.Windir, "ThemeTool.exe"));
            }
            else
            {
                string message = "SecureUX ThemeTool not found.";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    return;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            updatePreviewImg(comboBox1.SelectedItem.ToString());
            if (comboBox1.SelectedItem == null)
            {
                button1.Enabled = false;
            }
        }
        private void closing(object sender, FormClosingEventArgs e)
        {
        }

        private void updatePreviewImg(string j)
        {
            foreach (FileInfo i in Rectify11ControlCenter.Controls.themefiles)
            {
                var MyIni = new IniFile(i.FullName);
                string themename = MyIni.Read("DisplayName", "Theme");
                if (!j.ToLower().Contains(".theme") && j.ToLower() == themename.ToLower())
                {
                    if (File.Exists(i.FullName))
                    {
                        previewIMG.BackgroundImage = Rectify11ControlCenter.Controls.DeskWall(i.FullName);
                        var MyIni2 = new IniFile(i.FullName);
                        string thememode = MyIni2.Read("SystemMode", "VisualStyles");
                        panel2.BackgroundImage = Properties.Resources.LightPreview;
                        if (!String.IsNullOrEmpty(thememode) && thememode.ToLower() == "dark")
                        {
                            panel2.BackgroundImage = Properties.Resources.DarkPreview;
                        }
                    }
                }
                else if (j.ToLower().Contains(".theme") && i.Name.ToLower() == j.ToLower())
                {
                    string h = Path.Combine(Variables.Variables.Windir, "resources", "themes", j);

                    previewIMG.BackgroundImage = Rectify11ControlCenter.Controls.DeskWall(h);
                    var MyIni2 = new IniFile(h);
                    string thememode = MyIni2.Read("SystemMode", "VisualStyles");
                    panel2.BackgroundImage = Properties.Resources.LightPreview;
                    if (!String.IsNullOrEmpty(thememode) && thememode.ToLower() == "dark")
                    {
                        panel2.BackgroundImage = Properties.Resources.DarkPreview;
                    }
                }

            }
        }
    }
    
}
