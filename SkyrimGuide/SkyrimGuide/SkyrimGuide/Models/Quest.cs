using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Quest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string QuestName { get; set; }
        public string Description { get; set; }
        public string Giver { get; set; }
        public string QuestClass { get; set; }
        public string SubQuestClass { get; set; }
        public string SubSubQuestClass { get; set; }
        public  string Location { get; set; }

        public bool Check { get; set; }

    }
}
