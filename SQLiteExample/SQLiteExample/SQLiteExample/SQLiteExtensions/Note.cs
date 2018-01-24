using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SQLiteExample.SQLiteExtensions
{
    class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Text { get; set; }

        [ForeignKey(typeof(Category))]
        public int Category_id { get; set; }

        [ManyToOne]      // Many to one relationship with Stock
        public Category Category { get; set; }
    }
}
