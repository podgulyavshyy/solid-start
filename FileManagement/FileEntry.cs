namespace FileManagement
{
    public class FileEntry
    {
        public string FilePath { get; }
        public string Shortcut { get; }

        public FileEntry(string filePath, string shortcut)
        {
            FilePath = filePath;
            Shortcut = shortcut;
        }
    }
}