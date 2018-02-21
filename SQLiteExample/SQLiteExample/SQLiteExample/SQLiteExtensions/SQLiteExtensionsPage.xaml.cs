﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteExample.Abstract;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteExample.SQLiteExtensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteExtensionsPage : ContentPage
    {
        readonly DatabaseAccess _dataAccess = new DatabaseAccess(App.DbPath);

        public SQLiteExtensionsPage()
        {
            InitializeComponent();
            // Insert in one query
            //InsertAsOne();

            // OR
            // Insert separated then update references
             InsertOneByOneAndUpdate();
        }

        /// <summary>
        /// Insert student with all dependencies in one query
        /// </summary>
        private void InsertAsOne()
        {
            // Create Student with all information
            Student student = new Student()
            {
                Name = "Jan Novák",
                ClassRoom = new ClassRoom()
                {
                    Name = "3ITB"
                },
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Value = 1,
                        Subject = new Subject()
                        {
                            Name = "ČJ"
                        }
                    }
                }
            };

            // Insert student in database
            // All tables are filled with correct information
            _dataAccess.InsertWithChildren(student);

            // Get all students from database with all references as objects
            List<Student> students = _dataAccess.GetAllWithChildren<Student>();
            StudentsListView.ItemsSource = students;
        }

        /// <summary>
        /// Insert separated Mark, Student, Classroom and Subject, then update references in database
        /// </summary>
        private void InsertOneByOneAndUpdate()
        {
            // Create base objects
            Student student = new Student()
            {
                Name = "Jan Novák"
            };

            ClassRoom classRoom = new ClassRoom()
            {
                Name = "3ITB"
            };

            Subject subject = new Subject()
            {
                Name = "ČJ"
            };

            Mark mark = new Mark()
            {
                Value = 1
            };

            // Insert them to database
            _dataAccess.Insert(student);
            _dataAccess.Insert(classRoom);
            _dataAccess.Insert(mark);
            _dataAccess.Insert(subject);

            // Add student reference to classroom
            student.ClassRoom = classRoom;

            // Update student with references
            _dataAccess.UpdateWithChildren(student);


            // Change mark value and set subject
            mark.Value = 2;
            mark.Subject = subject;

            // Update changed mark with references
            _dataAccess.UpdateWithChildren(mark);

            // Add mark to student
            student.Marks = new List<Mark>()
            {
                mark
            };

            // Update changed student
            _dataAccess.UpdateWithChildren(student);

            // Get all students from database with all references as objects
            List<Student> students = _dataAccess.GetAllWithChildren<Student>().ToList();
            StudentsListView.ItemsSource = students;
        }
    }
}