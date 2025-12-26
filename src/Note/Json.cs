using System.Text.Json;

namespace CliNotes
{
    public class Json
    {
        private List<Index> IndexFile;

        public Json()
        {
            IndexFile = new List<Index>();
        }

        public Index ReadIndexFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Index();
            }

            string jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<Index>(jsonString)
                   ?? new Index();
        }
    }
}