using System;
using System.Collections.Generic;

namespace CliNotes
{
    interface ICommandHandler
    {
        void ParseArguments(string[] args);
        void HandleCommand(string command, string[] parameters);
        void HandleAdd(string[] parameters);
        void HandleOpen(string[] parameters);
        void HandleList(string[] parameters);
        void HandleDelete(string[] parameters);
    }

    public class CommandHandler : ICommandHandler
    {
        public void ParseArguments(string[] args)
        {
            var actualArgs = args;

            actualArgs = HandleDLLArguments(actualArgs);
            HandleNoArguments(actualArgs);

            HandleCommand(actualArgs[0], actualArgs[1..]);

            // dev only
            Console.WriteLine(actualArgs[0]); // command
        }

        private string[] HandleDLLArguments(string[] args)
        {
            var actualArgs = args;

            if (args.Length > 0 && args[0].EndsWith(".dll"))
            {
                actualArgs = args.Skip(1).ToArray();
            }

            return actualArgs;
        }

        private void HandleNoArguments(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No command provided");
            }
        }

        public void HandleCommand(string command, string[] parameters)
        {
            switch (command.ToLower())
            {
                case "add":
                    HandleAdd(parameters);
                    break;
                case "open":
                    HandleOpen(parameters);
                    break;
                case "list":
                    HandleList(parameters);
                    break;
                case "delete":
                    HandleDelete(parameters);
                    break;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }

        public void HandleAdd(string[] parameters)
        {
            Console.WriteLine("Add command executed");
        }

        public void HandleOpen(string[] parameters)
        {
            Console.WriteLine("Open command executed");
        }

        public void HandleList(string[] parameters)
        {
            NoteFolder NoteFolder = new NoteFolder();
            Json JsonHandler = new Json();
            var index = JsonHandler.ReadIndexFile(
                NoteFolder.DefaultFolderPath + "/index.json"
            );

            Console.WriteLine("You have " + index.notes.Count + " notes.");
        }

        public void HandleDelete(string[] parameters)
        {
            Console.WriteLine("Delete command executed");
        }
    }
}