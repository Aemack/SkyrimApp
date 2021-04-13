using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class QuestsService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Count();
            }
        }
        public List<Quest> GetAllQuests()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().OrderBy(x => x.QuestName).ToList();
            }
        }

        public Quest GetQuestById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Quest> GetQuestByClass(string questClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass).OrderBy(x => x.SubQuestClass).ToList();
            }
        }

        public List<Quest> GetQuestBySubClass(string questClass, string subQuestClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass).OrderBy(x => x.SubSubQuestClass).ToList();
            }
        }
        public List<Quest> GetQuestBySubSubClass(string questClass, string subQuestClass, string subSubQuestClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass && x.SubSubQuestClass == subSubQuestClass).OrderBy(x => x.QuestName).ToList();
            }
        }

        public List<string> GetQuestClassNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Quest>().OrderBy(x => x.QuestClass).ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.QuestClass))
                    {
                        subHeadings.Add(row.QuestClass);
                    }
                }
                return subHeadings;
            }
        }
        public List<string> GetSubQuestClassNames(string questClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Quest>().Where(x => x.QuestClass == questClass).OrderBy(x => x.SubQuestClass).ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.SubQuestClass))
                    {
                        subHeadings.Add(row.SubQuestClass);
                    }
                }
                return subHeadings;
            }
        }

        public List<string> GetSubSubQuestClassNames(string questClass, string subQuestClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass).OrderBy(x => x.SubSubQuestClass).ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.SubSubQuestClass))
                    {
                        subHeadings.Add(row.SubSubQuestClass);
                    }
                }
                return subHeadings;
            }
        }



        public Location GetLocationByQuest(Quest item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => item.Location.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateQuestCheck(bool check, Quest item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Quest>().Where(x => x.ID == item.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
