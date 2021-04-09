using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class ShoutService
    {
        public DragonShout GetShoutFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<DragonShout>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<DragonShout> GetAllShouts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<DragonShout>().ToList();
            }
        }

        public List<string> GetShoutTypes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var table = conn.Table<DragonShout>().ToList();
                var shoutTypes = new List<string>();
                foreach (var shout in table)
                {
                    if (!shoutTypes.Contains(shout.Shout))
                    {
                        shoutTypes.Add(shout.Shout);
                    }
                }
                return shoutTypes;
            }
        }

        public List<DragonShout> GetShoutsByType(string shoutType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<DragonShout>().Where(x => x.Shout == shoutType).ToList();
            }
        }

        public Location GetLocationByShout(DragonShout shout)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => shout.WordWallLocation.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateShoutCheck(bool check, DragonShout shout)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<DragonShout>().Where(x => x.ID == shout.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
