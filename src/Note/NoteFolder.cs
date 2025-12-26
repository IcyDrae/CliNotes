using Microsoft.VisualBasic;

namespace CliNotes
{
    public class NoteFolder
    {
        // Default folder path: ~/notes
        public string DefaultFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/notes";
        public const string DefaultFolderName = "notes";
        public const string TrashFolderName = "trash";
        public const string IndexFileName = "index.json";

        /*
        create ~/notes
        create ~/notes/trash
        create ~/notes/index.json
        */
        public void CreateFolderStructure()
        {
            if (!Directory.Exists(DefaultFolderPath))
            {
                Directory.CreateDirectory(DefaultFolderPath);
            }

            string trashFolderPath = Path.Combine(DefaultFolderPath, TrashFolderName);
            if (!Directory.Exists(trashFolderPath))
            {
                Directory.CreateDirectory(trashFolderPath);
            }

            string indexFilePath = Path.Combine(DefaultFolderPath, IndexFileName);
            if (!File.Exists(indexFilePath))
            {
                File.Create(indexFilePath).Close();
            }
        }
    }
}
