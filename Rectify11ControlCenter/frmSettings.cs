using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace Rectify11ControlCenter
{
	public partial class frmSettings : Form
	{
		string nss = Path.Combine(Variables.Variables.Windir, "nilesoft", "shell.nss");
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
					if (themename.Contains("Rectify11"))
					{
						comboBox1.Items.Add(themename);
					}
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
			radioButton1.Checked = true;
			if (!Directory.Exists(Path.Combine(Variables.Variables.Windir, "nilesoft")))
			{
				miscSec.Visible = false;
			}
			if (IsTextFileEmpty(nss))
			{
				if (File.Exists(Path.Combine(GetFolderPath(SpecialFolder.CommonStartMenu), "programs", "startup", "acrylmenu.lnk")))
				{
					radioButton5.Checked = true;
				}
				else if (Registry.CurrentUser.OpenSubKey("Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}") != null)
				{
					radioButton4.Checked = true;
				}
			}
			else
			{
				if (File.Exists(nss))
				{
					var content = File.ReadAllText(nss);
					if (content.Contains("modify(where=this.title.length > 15 menu=title.more_options)"))
					{
						radioButton2.Checked = true;
					}
					else
					{
						radioButton3.Checked = true;
					}
				}

			}

			radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
			radioButton3.CheckedChanged += RadioButton3_CheckedChanged;
			radioButton4.CheckedChanged += RadioButton4_CheckedChanged;
			radioButton5.CheckedChanged += RadioButton5_CheckedChanged;
		}

		private void RadioButton5_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton5.Checked)
			{
				Process.Start(Path.Combine(Variables.Variables.sys32Folder, "reg.exe"), " add \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f /ve");
				ShellLink shortcut = new ShellLink();
				shortcut.Target = Path.Combine(Variables.Variables.Windir, "nilesoft", "AcrylicMenus", "AcrylicMenusLoader.exe");
				shortcut.WorkingDirectory = @"%windir%\nilesoft\AcrylicMenus";
				shortcut.DisplayMode = ShellLink.LinkDisplayMode.edmNormal;
				shortcut.Save(Path.Combine(GetFolderPath(SpecialFolder.CommonStartMenu), "programs", "startup", "acrylmenu.lnk"));
				shortcut.Dispose();
				Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im explorer.exe", AppWinStyle.Hide, true);
				Interaction.Shell(Path.Combine(Variables.Variables.Windir, "explorer.exe"), AppWinStyle.NormalFocus);
				Thread.Sleep(3000);
				Process.Start(Path.Combine(GetFolderPath(SpecialFolder.CommonStartMenu), "programs", "startup", "acrylmenu.lnk"));
			}
			else
			{
				string path = Path.Combine(GetFolderPath(SpecialFolder.CommonStartMenu), "programs", "startup", "acrylmenu.lnk");
				SafeFileDeletion(path);
				foreach (var process in Process.GetProcessesByName("AcrylicMenusLoader"))
				{
					process.Kill();
				}
			}
		}
		public static bool SafeFileDeletion(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					try
					{
						File.Delete(path);
					}
					catch
					{
						string name = Path.GetRandomFileName();
						string tmpPath = Path.Combine(Path.GetTempPath(), name);
						File.Move(path, tmpPath);
						NativeMethods.MoveFileEx(tmpPath, null, NativeMethods.MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
					}
					return true;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		private void RadioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton4.Checked)
			{
				Process.Start(Path.Combine(Variables.Variables.sys32Folder, "reg.exe"), " add \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f /ve");
				Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im explorer.exe", AppWinStyle.Hide, true);
				Interaction.Shell(Path.Combine(Variables.Variables.Windir, "explorer.exe"), AppWinStyle.NormalFocus);
			}
		}

		private void RadioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				File.WriteAllText(nss, Properties.Resources.config2);
				ProcessStartInfo shlinfo2 = new ProcessStartInfo()
				{
					FileName = Path.Combine(Variables.Variables.Windir, "nilesoft", "shell.exe"),
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = " -r -t"
				};
				var shlInstproc2 = Process.Start(shlinfo2);
				shlInstproc2.WaitForExit();
			}
			else
			{
				ProcessStartInfo shlinfo3 = new ProcessStartInfo()
				{
					FileName = Path.Combine(Variables.Variables.Windir, "nilesoft", "shell.exe"),
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = " -u"
				};
				var shlInstproc2 = Process.Start(shlinfo3);
				shlInstproc2.WaitForExit();
				SafeFileDeletion(nss);
			}
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				File.WriteAllText(nss, Properties.Resources.config1);
				ProcessStartInfo shlinfo2 = new ProcessStartInfo()
				{
					FileName = Path.Combine(Variables.Variables.Windir, "nilesoft", "shell.exe"),
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = " -r -t"
				};
				var shlInstproc2 = Process.Start(shlinfo2);
				shlInstproc2.WaitForExit();
			}
			else
			{
				ProcessStartInfo shlinfo3 = new ProcessStartInfo()
				{
					FileName = Path.Combine(Variables.Variables.Windir, "nilesoft", "shell.exe"),
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = " -u"
				};
				var shlInstproc2 = Process.Start(shlinfo3);
				shlInstproc2.WaitForExit();
				SafeFileDeletion(nss);
			}
		}

		private void RadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				// restore win11 menus
				Process.Start(Path.Combine(Variables.Variables.sys32Folder, "reg.exe"), " delete \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\" /f");
				Interaction.Shell(Path.Combine(Variables.Variables.sys32Folder, "taskkill.exe") + " /f /im explorer.exe", AppWinStyle.Hide, true);
				Interaction.Shell(Path.Combine(Variables.Variables.Windir, "explorer.exe"), AppWinStyle.NormalFocus);
			}
		}

		public static bool IsTextFileEmpty(string fileName)
		{
			if (!File.Exists(fileName)) return false;
			var info = new FileInfo(fileName);
			if (info.Length == 0)
				return true;

			// only if your use case can involve files with 1 or a few bytes of content.
			if (info.Length < 6)
			{
				var content = File.ReadAllText(fileName);
				return content.Length == 0;
			}
			return false;
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
					waiting waiting1 = new waiting(i.FullName, checkBox2.Checked, checkBox1.Checked);
					waiting1.ShowDialog();
					deskImg.Image = Rectify11ControlCenter.Controls.DeskWall(i.FullName);
				}
				else if (j.ToLower().Contains(".theme") && i.Name.ToLower() == j.ToLower())
				{
					waiting waiting1 = new waiting(Path.Combine(Variables.Variables.Windir, "resources", "themes", j), checkBox2.Checked, checkBox1.Checked);
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
