using SQLite;

namespace SQLiteExample.SQLiteExtensions
{
    public abstract class ATable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
