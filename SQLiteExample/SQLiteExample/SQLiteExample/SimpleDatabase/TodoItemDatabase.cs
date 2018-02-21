using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteExample.SimpleDatabase
{
    public class TodoItemDatabase
    {
        private SQLiteConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<TodoItem>();
        }


        public List<TodoItem> GetItems()
        {
            return database.Table<TodoItem>().ToList();
        }

        public List<TodoItem> GetItemsViaRawQuery()
        {
            return database.Query<TodoItem>("SELECT * FROM [TodoItem]");
        }

        public TodoItem GetItem(int id)
        {
            return database.Table<TodoItem>().FirstOrDefault(i => i.ID == id);
        }

        public int InsertOrUpdateItem(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int DeleteItem(TodoItem item)
        {
            return database.Delete(item);
        }
    }
}
