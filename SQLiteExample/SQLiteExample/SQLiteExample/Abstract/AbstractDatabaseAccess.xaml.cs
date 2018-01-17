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

            InitializeComponent();
            var dbConnection = App.Database;

            DatabaseAccess todoItemDatabase = App.DatabaseAccess;

            TodoItemConcretization item = new TodoItemConcretization();
            item.Name = "item";
            item.Text = "item text";
            todoItemDatabase.SaveItemAsync(item);


            var itemsFromDb = todoItemDatabase.GetItemsAsync<TodoItemConcretization>().Result;

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


            ItemsCount.Text = "Items in Database " + itemsFromDb.Count;
            ToDoItemsListView.ItemsSource = itemsFromDb;
        }
    }
}