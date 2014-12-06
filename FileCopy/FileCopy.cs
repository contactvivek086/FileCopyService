using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy
{
    public partial class FileCopy : ServiceBase
    {
        public FileCopy()

        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            
            WatchFolder();
        }

      

        public void WatchFolder()
        {
            var m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Path = "D:\\vivek\\Input";
            m_Watcher.Filter = "*.*";
            m_Watcher.Created += new FileSystemEventHandler(OnChanged);
            m_Watcher.EnableRaisingEvents = true;
        }

        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (System.IO.Directory.Exists("D:\\vivek\\Input"))
            {
                string[] files = System.IO.Directory.GetFiles("D:\\vivek\\Input");
                var targetPath = "D:\\vivek\\Output";
                string fileName = "";
                var destFile = "";
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {

                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Move(s, destFile);
                }
            }


        }

        protected override void OnStop()
        {
        }
    }
}
