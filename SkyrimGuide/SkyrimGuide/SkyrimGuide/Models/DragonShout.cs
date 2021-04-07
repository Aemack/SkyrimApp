using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class DragonShout
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string WordOfPower { get; set; }
        public string Translation { get; set; }
        public string WordWallLocation { get; set; }
        public string Shout { get; set; }
        public string Version { get; set; }
        public bool Check { get; set; }

    }
}
