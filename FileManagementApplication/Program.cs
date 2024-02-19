using FileManagement;
using System;

namespace FileManagementApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileManager fileManager = new FileManager();

            while (true)
            {
                Console.WriteLine("Enter command (add <filename> <shortcut>, remove <shortcut>, list, exit):");
                string input = Console.ReadLine();
                string[] inputParts = input.Split(' ');

                if (inputParts[0].ToLower() == "exit")
                {
                    break;
                }

                ProcessCommand(fileManager, inputParts);
            }
        }

        private static void ProcessCommand(IFileManager fileManager, string[] command)
        {
            switch (command[0].ToLower())
            {
                case "add":
                    if (command.Length >= 2)
                    {
                        string filePath = command[1];
                        string shortcut = command.Length == 3 ? command[2] : null;
                        fileManager.AddFile(filePath, shortcut);
                        Console.WriteLine("File added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Usage: add <filename> <shortcut>");
                    }
                    break;

                case "remove":
                    if (command.Length == 2)
                    {
                        string shortcut = command[1];
                        fileManager.RemoveFile(shortcut);
                        Console.WriteLine("File removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Usage: remove <shortcut>");
                    }
                    break;

                case "list":
                    var files = fileManager.ListFiles();
                    Console.WriteLine("List of files:");
                    foreach (var file in files)
                    {
                        Console.WriteLine(file);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
