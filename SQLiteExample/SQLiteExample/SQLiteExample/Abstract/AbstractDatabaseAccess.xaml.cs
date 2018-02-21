using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteExample.Abstract
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbstractDatabaseAccess : ContentPage
    {
        public AbstractDatabaseAccess()
        {
            InitializeComponent();

            // Create instance of database layer
            DatabaseAccess todoItemDatabase = new DatabaseAccess(App.DbPath);

            // Create object to insert to database
            TodoItemConcretization item = new TodoItemConcretization();
            item.Name = "item";
            item.Text = "item text";

            // Insert
            todoItemDatabase.InsertOrUpdateItemAsync(item);

            // Get all object from database based on object type
            var itemsFromDb = todoItemDatabase.GetItemsAsync<TodoItemConcretization>().Result;

            // Write all objects from database to console
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDb.Count);
            foreach (TodoItemConcretization todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            // Display all objects from database in Listview
            ItemsCount.Text = "Items in Database " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }
    }
}