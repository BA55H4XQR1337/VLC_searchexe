using System;
using System.IO;
using System.Net.Http;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace searchexe
{
    public partial class Form1 : Form
    {
        private readonly string[] mirrors =
        {
            "https://mirror.netcologne.de/videolan.org/vlc/{0}/win64/vlc-{0}-win64.exe",
            "https://vlc.pixelx.de/vlc/{0}/win64/vlc-{0}-win64.exe",
            "https://mirror.as20647.net/videolan/vlc/{0}/win64/vlc-{0}-win64.exe",
            "https://ftp.fau.de/videolan/vlc/{0}/win64/vlc-{0}-win64.exe"
        };
        private string versionFilePath => Path.Combine(Application.StartupPath, "version.txt");
        public Form1() { InitializeComponent(); }
        private async void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\Program Files\VideoLAN\VLC\vlc.exe";
            if (File.Exists(path))
            {
                checkstatus.Text = "VLC is installed."; btninstall.Enabled = false;
            }
            else
            {
                checkstatus.Text = "VLC not found. Checking for latest version...";
                string latestVersion = await GetLatestVersion(); string currentVersion = GetStoredVersion();
                if (latestVersion != null)
                {
                    if (latestVersion == currentVersion) { checkstatus.Text = $"Latest version ({latestVersion}) already downloaded.";}
                    else
                    {checkstatus.Text = $"New version found: {latestVersion}. Downloading..."; await DownloadLatestVLC(latestVersion);}
                }
                else
                {checkstatus.Text = "Failed to get the latest VLC version.";}
            }
        }
        private string GetStoredVersion()
        {
            if (File.Exists(versionFilePath)) {return File.ReadAllText(versionFilePath).Trim();} return null;
        }
        private void SaveVersion(string version) {File.WriteAllText(versionFilePath, version);}
        private async Task<string> GetLatestVersion()
        {
            try
            {
                string versionPageUrl = "https://get.videolan.org/vlc/last/win64/"; using (HttpClient client = new HttpClient())
                {
                    string pageContent = await client.GetStringAsync(versionPageUrl);
                    Match match = Regex.Match(pageContent, @"vlc-(\d+\.\d+\.\d+)-win64.exe");
                    if (match.Success) {return match.Groups[1].Value;}
                }
            }
            catch (Exception ex) {MessageBox.Show($"Error getting version: {ex.Message}");} return null;}
        private async Task DownloadLatestVLC(string version)
        {
            foreach (var mirror in mirrors)
            {
                string downloadUrl = string.Format(mirror, version);
                string destinationPath = Path.Combine(
                    Application.StartupPath, $"vlc-{version}-win64.exe"
                );
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage response = await client.GetAsync(downloadUrl))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                using ( FileStream fs = new FileStream(destinationPath, FileMode.Create))
                                {
                                    await response.Content.CopyToAsync(fs);
                                }
                                SaveVersion(version); checkstatus.Text = $"Download complete: VLC {version}"; btninstall.Enabled = true; return;
                            }
                        }
                    }
                }
                catch (Exception ex) {MessageBox.Show($"Download failed from {downloadUrl}: {ex.Message}");}
            }
            checkstatus.Text = "Failed to download VLC from all mirrors.";
        }

        private void btninstall_Click(object sender, EventArgs e)
        {
            string installerPath = Directory.GetFiles(Application.StartupPath, "vlc-*-win64.exe").FirstOrDefault();
            if (installerPath != null)
            {
                Process.Start(installerPath);
            }
            else
            {
                checkstatus.Text = "Installer not found. Try downloading again.";
            }
        }
    }
}
