using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Rectify11ControlCenter
{
    public partial class waiting : Form
    {
        public waiting(string s, bool mfe, bool tabbed)
        {
            InitializeComponent();

            label1.Text = Rectify11ControlCenter.Controls.waitingtxt;
            applyTheme(s, mfe, tabbed);
        }

        private void waiting_Load(object sender, EventArgs e)
        {
            NativeMethods.SetTopMost(this.Handle);
        }
        private async void applyTheme(string name, bool useMfe, bool tabbed)
        {
            var MyIni = new IniFile(name);
            string accent = MyIni.Read("ColorizationColor", "VisualStyles");
            if (!string.IsNullOrEmpty(accent))
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel1, new object[] { true });
                panel1.BackColor = ColorTranslator.FromHtml(accent.Replace("0x", "#"));
            }
            await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im accentcolorizer.exe", AppWinStyle.Hide, true));
            await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "cmd.exe") + " /c " + '"' + name + '"' + " & timeout /t 03 /nobreak > NUL & taskkill /f /im systemsettings.exe", AppWinStyle.Hide, true));

            string themename = MyIni.Read("DisplayName", "Theme");
            
            if (File.Exists(Path.Combine(Variables.Variables.r11Folder, "SecureUXHelper.exe")))
            {
                await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.r11Folder, "SecureUXHelper.exe") + " apply " + '"' + themename + '"', AppWinStyle.Hide, true));
            }

            await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im micaforeveryone.exe", AppWinStyle.Hide, true));
            
            if (useMfe == true)
            {
                if (Directory.Exists(Path.Combine(Variables.Variables.Windir, "MicaForEveryone")))
                {
                    if (Directory.Exists(Path.Combine(Environment.GetEnvironmentVariable("localappdata"), "Mica For Everyone")))
                    {
                        Directory.Delete(Path.Combine(Environment.GetEnvironmentVariable("localappdata"), "Mica For Everyone"), true);
                    }
                    string themeFilename = Path.GetFileNameWithoutExtension(name);
                    string confName = themeFilename;
                    if (tabbed)
                        confName = "T" + themeFilename;
                    if (File.Exists(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "CONF", confName + ".conf")))
                    {
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /create /tn mfe /xml " + Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "XML", "mfe.xml"), AppWinStyle.Hide);
                        File.Copy(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "CONF", confName + ".conf"), Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "MicaForEveryone.conf"), true);
                        await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "MicaForEveryone.exe")));
                    }
                    else
                    {
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /delete /f /tn mfe", AppWinStyle.Hide);
                    }
                    if (themeFilename.Contains("black"))
                    {
                        string amdorarm = "AMD";
                        if (NativeMethods.IsArm64()) amdorarm = "ARM";
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /create /tn micafix /xml " + Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "XML", "micafix" + amdorarm + "64.xml"), AppWinStyle.Hide);
                        await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "EF"+amdorarm.ToLower()+"64", "ExplorerFrame.exe")));

                    }
                    else
                    {
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /end /tn micafix ", AppWinStyle.Hide);
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /delete /f /tn micafix ", AppWinStyle.Hide);
                    }
                }
            }
            else
            {
                Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /delete /f /tn mfe", AppWinStyle.Hide);
            }
            if (File.Exists(Path.Combine(Variables.Variables.r11Folder, "extras", "AccentColorizer", "AccentColorizer.exe")))
            {
                await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.r11Folder, "extras", "AccentColorizer", "AccentColorizer.exe")));
            }
            this.FormClosing -= new FormClosingEventHandler(this.form_closing);
            this.Close();
            this.Dispose();
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
