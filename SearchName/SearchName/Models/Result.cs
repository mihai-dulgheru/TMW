using SQLite;

namespace SearchName.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public int Count { get; set; }
    }
}
