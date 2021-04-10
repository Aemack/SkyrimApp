﻿using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class QuestsService
    {
        public List<Quest> GetAllQuests()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().ToList();
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
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass).ToList();
            }
        }

        public List<Quest> GetQuestBySubClass(string questClass, string subQuestClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass).ToList();
            }
        }
        public List<Quest> GetQuestBySubSubClass(string questClass, string subQuestClass, string subSubQuestClass)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass && x.SubSubQuestClass == subSubQuestClass).ToList();
            }
        }

        public List<string> GetQuestClassNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Quest>().ToList();
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
                var table = conn.Table<Quest>().Where(x => x.QuestClass == questClass).ToList();
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
                var table = conn.Table<Quest>().Where(x => x.QuestClass == questClass && x.SubQuestClass == subQuestClass).ToList();
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