using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Rectify11ControlCenter
{
    public partial class waiting : Form
    {
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        static readonly IntPtr HWND_TOP = new IntPtr(0);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;



        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]

        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public waiting(string s, bool mfe)
        {
            InitializeComponent();
            
            label1.Text = Rectify11ControlCenter.Controls.waitingtxt;
            applyTheme(s, mfe);
        }

        private void waiting_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }
        private async void applyTheme(string name, bool useMfe)
        {
            await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im accentcolorizer.exe", AppWinStyle.Hide, true));
            await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "cmd.exe") + " /c " + '"' + name + '"' + " & timeout /t 03 /nobreak > NUL & taskkill /f /im systemsettings.exe", AppWinStyle.Hide, true));
            var MyIni = new IniFile(name);
            string themename = MyIni.Read("DisplayName", "Theme");
            if (File.Exists(Path.Combine(Variables.Variables.Windir, "SecureUXHelper.exe")))
            {
                await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.Windir, "SecureUXHelper.exe") + " apply " + '"' + themename + '"', AppWinStyle.Hide, true));
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
                    if (File.Exists(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "CONF", themeFilename + ".conf")))
                    {
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /create /tn mfe /xml " + Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "XML", "mfe.xml"), AppWinStyle.Hide);
                        File.Copy(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "CONF", themeFilename + ".conf"), Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "MicaForEveryone.conf"), true);
                        await Task.Run(() => Interaction.Shell(Path.Combine(Variables.Variables.Windir, "MicaForEveryone", "MicaForEveryone.exe")));
                    }
                    else
                    {
                        Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "schtasks.exe") + " /delete /f /tn mfe", AppWinStyle.Hide);
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
