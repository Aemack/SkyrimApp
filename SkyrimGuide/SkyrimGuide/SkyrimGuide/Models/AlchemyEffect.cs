using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class AlchemyEffect
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string Effect { get; set; }
        public string Version { get; set; }
        public bool Check { get; set; }
    }
}
