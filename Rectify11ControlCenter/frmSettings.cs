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
            checkBox1.Text = Rectify11ControlCenter.Controls.runAtStart;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object o = key.GetValue("r11cpl");
            if (o != null)
            {
                checkBox1.Checked = true;
            }
            key.Close();
            if (Process.GetProcessesByName("micaforeveryone").Length > 0)
            {
                checkBox2.Checked = true;
            }
            for (int i = 0; i < Rectify11ControlCenter.Controls.themefiles.Length; i++)
            {
                var MyIni = new IniFile(Rectify11ControlCenter.Controls.themefiles[i].FullName);
                string themename = MyIni.Read("DisplayName", "Theme");
                if (!Path.GetFileNameWithoutExtension(themename).ToLower().Contains("themeui"))
                {
                    comboBox1.Items.Add(Path.GetFileNameWithoutExtension(themename));
                }
            }
            comboBox1.SelectedItem = Rectify11ControlCenter.Controls.theme();
            if (comboBox1.SelectedItem == null)
            {
                button1.Enabled = false;
            }
            deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(Rectify11ControlCenter.Controls.appliedthemefile());
            addroundedCorners();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void addroundedCorners()
        {
            Rectangle r = new Rectangle(0, 0, deskImg.Width, deskImg.Height);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            int d = 7;
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
                if (j.ToLower() == themename.ToLower())
                {
                    waiting waiting1 = new waiting(i.FullName, checkBox2.Checked);
                    waiting1.ShowDialog();
                    deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(i.FullName);
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
            if (comboBox1.SelectedItem == null)
            {
                button1.Enabled = false;
            }
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
