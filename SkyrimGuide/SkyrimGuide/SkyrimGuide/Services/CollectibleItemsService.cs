using SkyrimGuide.Models;
using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class CollectibleItemsService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<CollectibleItem>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<CollectibleItem>().Count();
            }
        }
        public List<CollectibleItem> GetAllCollectibleItems()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<CollectibleItem>().OrderBy(x => x.ItemName).ToList();
            }
        }

        public CollectibleItem GetCollectibleItemById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<CollectibleItem>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<CollectibleItem> GetItemsByType (string type)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<CollectibleItem>().Where(x => x.Type == type).OrderBy(x => x.ItemName).ToList();
            }
        }

        public List<string> GetTypeNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<CollectibleItem>().OrderBy(x => x.Type).ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.Type))
                    {
                        subHeadings.Add(row.Type);
                    }
                }
                return subHeadings;
            }
        }

        public Location GetLocationByItem(CollectibleItem item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => item.Location.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateItemCheck(bool check, CollectibleItem item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<CollectibleItem>().Where(x => x.ID == item.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
