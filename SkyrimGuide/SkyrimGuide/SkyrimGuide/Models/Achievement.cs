using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Achievement
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Aquired { get; set; }
        public string Quest { get; set; }
        public string Description { get; set; }
        public bool Check { get; set; }
    }
}
