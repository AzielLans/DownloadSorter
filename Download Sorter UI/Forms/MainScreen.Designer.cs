using Microsoft.Win32;

namespace Download_Sorter_UI.Forms
{
    partial class MainScreen
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            Notification_Informer = new NotifyIcon(components);
            FileWatchChecher = new FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)FileWatchChecher).BeginInit();
            SuspendLayout();
            // 
            // Notification_Informer
            // 
            Notification_Informer.Icon = (Icon)resources.GetObject("Notification_Informer.Icon");
            Notification_Informer.Text = "notifyIcon1";
            Notification_Informer.Visible = true;
            // 
            // FileWatchChecher
            // 
            FileWatchChecher.EnableRaisingEvents = true;
            FileWatchChecher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size;
            FileWatchChecher.Path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            FileWatchChecher.SynchronizingObject = this;
            FileWatchChecher.Changed += FileWatchChecher_Changed;
            FileWatchChecher.Created += FileWatchChecher_Created;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "MainScreen";
            Text = "MainScreen";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)FileWatchChecher).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon Notification_Informer;
        private FileSystemWatcher FileWatchChecher;
    }
}