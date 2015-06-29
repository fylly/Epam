using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    class FileWatcher
    {
        private SalesBusinessLayer.FilesWoker _fileWoker;
        private FileSystemWatcher _watcher;

        public FileWatcher(String puth)
        {
            _fileWoker = new SalesBusinessLayer.FilesWoker();
            _watcher = new FileSystemWatcher();
            _watcher.Path = puth;
        }

        public void Run()
        {

//            var directoryEntries = System.IO.Directory.EnumerateFiles(@".\csv\", @"*.csv", SearchOption.TopDirectoryOnly);

            _watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            _watcher.Filter = "*.csv";
            _watcher.Created += new FileSystemEventHandler(OnChangedEventHandler);
            _watcher.EnableRaisingEvents = true;
        }

        private void OnChangedEventHandler(object source, FileSystemEventArgs e)
        {
            if (! SalesBusinessLayer.CommunicationMethods.IsExistInInputFile(e.Name))
            {
                string[] lines = System.IO.File.ReadAllLines(e.FullPath);
                _fileWoker.Work(lines.ToList(), e.Name);
            }
        }

    }
}
