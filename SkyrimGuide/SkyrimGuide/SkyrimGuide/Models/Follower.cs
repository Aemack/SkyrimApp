using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Follower
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Alive { get; set; }
        public string Description { get; set; }
        public string PrimarySkills { get; set; }
        public string PrerequisiteQuest { get; set; }
        public string MaxLevel { get; set; }
        public bool Marry { get; set; }
        public bool Blades { get; set; }
        public bool Steward { get; set; }
        public bool Pet { get; set; }
        public string Trainer { get; set; }
        public string Location { get; set; }
        public bool Check { get; set; }
    }
}
