// See https://aka.ms/new-console-template for more information

using System;
using CliNotes;

namespace CliNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            NoteFolder Folder = new NoteFolder();
            Folder.CreateFolderStructure();

            CommandHandler CommandHandler = new CommandHandler();
            CommandHandler.ParseArguments(args);
        }
    }
}
