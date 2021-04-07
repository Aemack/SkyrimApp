using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Ability
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string AquiredFrom { get; set; }
        public string Quest { get; set; }
        public string Type { get; set; }
        public bool Check { get; set; }
    }
}
