using Download_Sorter_UI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Download_Sorter_UI.Forms
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            Hide();
            ShowInTaskbar = false;
            Notification_Informer.BalloonTipTitle = "Download Sorter";
            Notification_Informer.BalloonTipText = "Download Sorter is running.";
            Notification_Informer.Visible = true;
            Notification_Informer.ShowBalloonTip(500);
        }
        public List<string> SortLocationList = new List<string>();
        public List<string> SortfileList = new List<string>();
        public InformationStructure GetInformation(string fileName)
        {
            string json;
            using (var reader = File.OpenText(fileName))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<InformationStructure>(json);
        }

        private void FileWatchChecher_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("changed");
        }

        private void FileWatchChecher_Created(object sender, FileSystemEventArgs e)
        {
            Sort_File();
        }
        public void Sort_File()
        {
            var information = GetInformation("Sorts.json");
            string Downloadlocation = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            List<string> fileNames = new List<string>();
            fileNames.Clear();
            foreach (String file in Directory.GetFiles(Downloadlocation, "*"))
            {
                fileNames.Add(file);
            }
            var ordered = fileNames.OrderBy(p => Path.GetExtension(p));
            var uniqueExtensions = ordered.Select(file => Path.GetExtension(file)).Distinct();
            foreach (var sortfileextention in uniqueExtensions)
            {
                string mkdirfoldername = Downloadlocation + "/" + sortfileextention.Replace(".", " ");
                if (!Directory.Exists(mkdirfoldername))
                {
                    Directory.CreateDirectory(mkdirfoldername);
                }
            }
            foreach (var file in ordered)
            {
                var extension = Path.GetExtension(file);
                var destinationFolder = Path.Combine(Downloadlocation, extension);
                File.Move(Path.Combine(file), Path.Combine(destinationFolder.Replace(".", " ") + "/" + Path.GetFileName(file)));

            }
        }
    }
}
