using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool Check { get; set; }
    }
}
