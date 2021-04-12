using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class UniqueGear
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public string Version { get; set; }
        public string Quest { get; set; }
        public string Location { get; set; }
        public bool Check { get; set; }
    }
}
