using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteExample.Abstract;
using SQLiteExample.SimpleDatabase;
using SQLiteExample.SQLiteExtensions;
using Xamarin.Forms;

namespace SQLiteExample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
            
            // OR abstract
            // MainPage = new NavigationPage(new AbstractDatabaseAccess());

            // OR SQLiteExtensions
            // MainPage = new NavigationPage(new SQLiteExtensionsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static TodoItemDatabase _database;

        /// <summary>
        /// Good approach is return instance of database access layer instead of db path
        /// </summary>
        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new TodoItemDatabase(DbPath);
                }

                return _database;
            }
        }

        /// <summary>
        /// Used only for Abstract and SQLiteExtensions database access
        /// Path should be private
        /// </summary>
        public static string DbPath
        {
            get
            {
                IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                return filehelperInstance.GetLocalFilePath("TodoSQLite.db3");
            }
        }
    }
}
