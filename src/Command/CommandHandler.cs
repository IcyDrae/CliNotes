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
            if (parameters.Length == 0)
            {
                Console.WriteLine("No file name provided for add command.");
                return;
            }

            string FileName = parameters[0];
            // create file with the name provided
            string FolderPath = NoteFolder.DefaultFolderPath;
            string FilePath = Path.Combine(FolderPath, FileName);
            string indexPath = Path.Combine(FolderPath, "index.json");
            List<string> Tags = new List<string>();

            // Parse --tags option
            for (int i = 1; i < parameters.Length; i++)
            {
                if (parameters[i] == "--tags")
                {
                    i++; // move to first tag
                    while (i < parameters.Length && !parameters[i].StartsWith("--"))
                    {
                        Tags.Add(parameters[i]);
                        i++;
                    }
                    i--; // adjust because outer for loop will increment
                }
            }

            // create empty file if it does not exist
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();

                // update index file with the metadata of the new note
                Index Index = Json.ReadIndexFile(indexPath);
                int NextId = ComputeNextNoteId(Index);
                Note NewNote = new Note(NextId, FileName, Tags);

                Index.Notes.Add(NewNote);
                Json.SaveIndexFileToDisk(indexPath, Index);

                Console.WriteLine($"Note '{FileName}' created with ID {NextId}.");

                OpenFileInDefaultEditor(FilePath);

                NewNote.UpdatedAt = DateTime.Now;
                Json.SaveIndexFileToDisk(indexPath, Index);
            }
            else
            {
                Console.WriteLine($"Note '{FileName}' already exists.");
            }
        }

        public void HandleOpen(string[] parameters)
        {
            Console.WriteLine("Open command executed");
        }

        public void HandleList(string[] parameters)
        {
            var index = Json.ReadIndexFile(
                NoteFolder.DefaultFolderPath + "/index.json"
            );

            if (index.Notes.Count == 0)
            {
                Console.WriteLine("No notes found.");
                return;
            }
            else
            {
                foreach (var note in index.Notes)
                {
                    Console.WriteLine(note.FileName);
                    Console.WriteLine("--------------------");
                }
            }
        }

        public void HandleDelete(string[] parameters)
        {
            Console.WriteLine("Delete command executed");
        }

        private static int ComputeNextNoteId(Index index)
        {
            if (index.Notes.Count == 0)
                return 1;

            return index.Notes.Max(n => n.Id) + 1;
        }

        private static void OpenFileInDefaultEditor(string filePath)
        {
            string? editor = Environment.GetEnvironmentVariable("EDITOR");

            if (string.IsNullOrEmpty(editor))
            {
                if (OperatingSystem.IsWindows())
                    editor = "notepad";
                else
                    editor = "vim";
            }

            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = editor;
            process.StartInfo.Arguments = filePath;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            process.WaitForExit();
        }
    }
}