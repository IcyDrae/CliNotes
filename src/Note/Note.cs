using System.Reflection.Metadata;

namespace CliNotes
{
    public class Note
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public List<string> Tags { get; set; } = new List<string>();

        public const string DateTimeFormat = "yyyy-dd-MM HH:mm";

        public Note(int id,
                    string fileName,
                    List<string>? tags = null)
        {
            Id = id;
            FileName = fileName;
            if (tags != null)
            {
                Tags = tags;
            }
        }
    }
}