using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample.Abstract
{
    class TodoItemConcretization : ATable
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public TodoItemConcretization()
        {
        }

        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Text;
        }
    }
}
