using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class UniqueGearService
    {
        public UniqueGear GetGearFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<UniqueGear>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<UniqueGear> GetAllGear()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<UniqueGear>().ToList();
            }
        }

        public List<string> GetGearTypes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var table = conn.Table<UniqueGear>().ToList();
                var gearTypes = new List<string>();
                foreach (var gear in table)
                {
                    if (!gearTypes.Contains(gear.Type))
                    {
                        gearTypes.Add(gear.Type);
                    }
                }
                return gearTypes;
            }
        }

        public List<UniqueGear> GetGearByType(string gearType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<UniqueGear>().Where(x => x.Type == gearType).ToList();
            }
        }

        public Location GetLocationByGear(UniqueGear gear)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => gear.Location.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public Quest GetQuestByGear(UniqueGear gear)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Quest>().Where(x => x.QuestName.Contains(gear.Quest)).FirstOrDefault();
            }
        }

        public void UpdateGearCheck(bool check, UniqueGear gear)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<UniqueGear>().Where(x => x.ID == gear.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
