namespace FileRegistry;

public interface IFileRegistry
{
    void AddFile(string filePath, string shortcut = null);
    void RemoveFile(string shortcut);
    string[] ListFiles();
}