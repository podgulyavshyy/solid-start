using System;
using System.Collections.Generic;

namespace FileManagement
{
    public class FileManager : IFileManager
    {
        private readonly List<FileEntry> files;

        public FileManager()
        {
            files = new List<FileEntry>();
        }

        public void AddFile(string filePath, string shortcut = null)
        {
            files.Add(new FileEntry(filePath, shortcut ?? filePath));
        }

        public void RemoveFile(string shortcut)
        {
            var fileToRemove = files.Find(f => f.Shortcut == shortcut);
            if (fileToRemove != null)
            {
                files.Remove(fileToRemove);
            }
        }

        public string[] ListFiles()
        {
            var fileNames = new List<string>();
            foreach (var file in files)
            {
                fileNames.Add(file.Shortcut);
            }
            return fileNames.ToArray();
        }
    }
}