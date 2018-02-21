using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace SQLiteExample.SQLiteExtensions
{
    class Subject : ATable
    {
        public String Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Marks
        public List<Mark> Marks { get; set; }

    }
}
