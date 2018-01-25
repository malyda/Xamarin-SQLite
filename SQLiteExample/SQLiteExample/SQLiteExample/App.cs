using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteExample.Abstract;
using SQLiteExample.SQLiteExtensions;
using Xamarin.Forms;

namespace SQLiteExample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new SQLiteExtensionsPage());
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

        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                    _database = new TodoItemDatabase(DbPath);
                }
                return _database;
            }
        }

        public static string DbPath
        {
            get
            {
                IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                return filehelperInstance.GetLocalFilePath("TodoSQLite.db3");
            }
        }


        /// <summary>
        /// Abstract version
        /// </summary>

        private static DatabaseAccess _databaseAccess;

        public static DatabaseAccess DatabaseAccess
        {
            get
            {
                if (_databaseAccess == null)
                {
                    IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                    _databaseAccess = new DatabaseAccess(filehelperInstance.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _databaseAccess;
            }
        }
    }
}
