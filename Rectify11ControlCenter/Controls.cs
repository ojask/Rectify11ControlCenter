﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;

namespace Rectify11ControlCenter
{
    public static class Controls
    {
        #region Preview Pane
        public static string osV = "OS: " + Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem + " NT Build " + Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion;
        public static string userN = "Username: " + Environment.UserName;
        public static string CumterName = "PC Name: " + Environment.MachineName;
        public static string appliedthemefile() 
        {
            string pathTheme = "";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes", false);
            pathTheme = regKey.GetValue("CurrentTheme").ToString();
            regKey.Close();
            return pathTheme;
        }
        public static string theme()
        {
            string pathTheme = "";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes", false);
            pathTheme = regKey.GetValue("CurrentTheme").ToString();
            regKey.Close();
            if (File.Exists(pathTheme))
            {
                var MyIni = new IniFile(pathTheme);
                string themename = MyIni.Read("DisplayName", "Theme");
                if (!themename.ToLower().Contains("themeui"))
                {
                    return themename;
                }
                else
                {
                    return Path.GetFileName(pathTheme);
                }
            }
            else
            {
                string s = "Not Implemented";
                return s;
            }
        }
        public static Image DeskWall(string path)
        {
            Image img = Properties.Resources.bloom;
            if (File.Exists(path))
            {
                var MyIni = new IniFile(path);
                string wallpaperPath = MyIni.Read("Wallpaper", @"Control Panel\Desktop");
                if (wallpaperPath.ToLower().Contains("%systemroot%"))
                {
                    wallpaperPath = wallpaperPath.ToLower().Replace("%systemroot%", Environment.GetEnvironmentVariable("systemroot"));
                }
                if (wallpaperPath.ToLower().Contains("%resourcedir%"))
                {
                    wallpaperPath = wallpaperPath.ToLower().Replace("%resourcedir%", Path.Combine(Environment.GetEnvironmentVariable("systemroot"), "resources"));
                }
                if (wallpaperPath.ToLower().Contains("%windir%"))
                {
                    wallpaperPath = wallpaperPath.ToLower().Replace("%windir%", Environment.GetEnvironmentVariable("systemroot"));
                }
                if (File.Exists(wallpaperPath))
                {
                    img = Image.FromFile(wallpaperPath);
                }
            }
            return img;
        }

        public static string r11Version = "Rectify11 Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString();
        #endregion
        #region Main
        public static string themeSection = "Change Theme";
        public static string miscSection = "Miscellaneous";
        public static string mfeChexbox = "Use MicaForEveryone";
        public static string applyButton = "Apply";
        public static DirectoryInfo themedir = new DirectoryInfo(Path.Combine(Variables.Variables.Windir, "resources", "themes"));
        public static DirectoryInfo themedir2 = new DirectoryInfo(Path.Combine(Environment.GetEnvironmentVariable("localappdata"), "microsoft", "windows", "themes"));
        public static List<System.IO.FileInfo> themefiles = themefilesSystemWide();
        public static List<System.IO.FileInfo> themefilesSystemWide()
        {
            var y = themedir.GetFiles("*.theme").ToList();
            y.AddRange(themedir2.GetFiles("*.theme"));
            return y;
        }
        public static string waitingtxt = "Please wait";
        public static string runAtStart = "Run at every startup"; 
        #endregion
    }
}
