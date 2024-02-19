namespace FileManagement
{
    public interface IFileManager
    {
        void AddFile(string filePath, string shortcut = null);
        void RemoveFile(string shortcut);
        string[] ListFiles();
    }
}