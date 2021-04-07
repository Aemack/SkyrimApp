using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class CollectibleItem
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public string Quest { get; set; }
        public string Type { get; set; }
        public bool Check { get; set; }
    }
}
