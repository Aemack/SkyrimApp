using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LocationName { get; set; }
        public string Coordinates { get; set; }
        public string LocationCategory { get; set; }
        public string Region { get; set; }
        public string MapImage { get; set; }
        public bool Check { get; set; }
    }
}
