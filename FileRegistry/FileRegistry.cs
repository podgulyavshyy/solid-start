namespace FileRegistry;

public class FileRegistry : IFileRegistry
{
    private readonly List<FileEntry> files;

    public FileRegistry()
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