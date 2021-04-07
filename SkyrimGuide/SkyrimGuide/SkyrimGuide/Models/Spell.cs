using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Spell
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string Level { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ItemID { get; set; }
        public bool Check { get; set; }
    }
}
