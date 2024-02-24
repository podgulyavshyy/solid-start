using CommandCore;
using Employees.Starter;
using FileRegistry;

namespace CommandsLib;

[InputAction]
public class RemoveFileInputAction : InputAction<RemoveFileCommand>
{
    protected override string Module => "file";

    protected override string Action => "remove";
    
    protected override string HelpString => "remove a file";

    private readonly IFileRegistry fileRegistry;

    public RemoveFileInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override RemoveFileCommand GetCommandInternal(string[] args)
    {
        return new RemoveFileCommand(fileRegistry, args[0]);
    }
}

[Command]
public class RemoveFileCommand : Command
{
    
    private readonly string shortcut;

    private readonly IFileRegistry registry;

    public RemoveFileCommand(IFileRegistry registry, string shortcut)
    {
        this.registry = registry;
        this.shortcut = shortcut;
    }

    public override void Execute()
    {
        registry.RemoveFile(shortcut);
        Console.WriteLine($"File {this.shortcut} has been removed!");
    }
}