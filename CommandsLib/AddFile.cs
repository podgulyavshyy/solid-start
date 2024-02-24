using CommandCore;
using FileRegistry;

namespace CommandsLib;

[InputAction]
public class AddFileInputAction : InputAction<AddFileCommand>
{
    protected override string Module => "file";

    protected override string Action => "add";
    
    protected override string HelpString => "add a file";

    private readonly IFileRegistry fileRegistry;

    public AddFileInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override AddFileCommand GetCommandInternal(string[] args)
    {
        return new AddFileCommand(fileRegistry, args[0], args[1]);
    }
}

// [Command]
public class AddFileCommand : Command
{

    private readonly string filePath;
    private readonly string shortcut;

    private readonly IFileRegistry registry;

    public AddFileCommand(IFileRegistry registry, string filePath, string shortcut)
    {
        this.registry = registry;
        this.filePath = filePath;
        this.shortcut = shortcut;
    }

    public override void Execute()
    {
        registry.AddFile( filePath, shortcut);
        Console.WriteLine($"File {this.filePath} added with shortcut {this.shortcut}!");
    }
}