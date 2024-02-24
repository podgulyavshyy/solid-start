using CommandCore;
using Employees.Starter;
using FileRegistry;

namespace CommandsLib;

[InputAction]
public class ListInputAction : InputAction<ListCommand>
{
    protected override string Module => "file";

    protected override string Action => "list";
    
    protected override string HelpString => "list all files";

    private readonly IFileRegistry fileRegistry;

    public ListInputAction(IFileRegistry fileRegistry)
    {
        this.fileRegistry = fileRegistry;
    }

    protected override ListCommand GetCommandInternal(string[] args)
    {
        return new ListCommand(fileRegistry);
    }
}

[Command]
public class ListCommand : Command
{

    private readonly IFileRegistry registry;

    public ListCommand(IFileRegistry registry)
    {
        this.registry = registry;
    }

    public override void Execute()
    {
        var files = registry.ListFiles();
        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }
}