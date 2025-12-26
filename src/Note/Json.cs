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

        public static void SaveIndexFileToDisk(string filePath, Index index)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(index, options);

            File.WriteAllText(filePath, jsonString);
        }

        public static Index ReadIndexFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new Index();
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string jsonString = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<Index>(jsonString, options)
                   ?? new Index();
        }
    }
}