using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class LocationService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Count();
            }
        }
        public Location GetLocationFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Location> GetAllLocations()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().OrderBy(x => x.LocationName).ToList();
            }
        }

        public List<Location> GetLocationsByRegion(string region)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.Region == region).OrderBy(x => x.LocationName).ToList();
            }
        }

        public List<Location> GetNearbyLocations(Location location)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.Coordinates == location.Coordinates).OrderBy(x => x.LocationName).ToList();
            }
        }


        public List<string> GetRegionNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Location>().OrderBy(x => x.Region).ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.Region))
                    {
                        subHeadings.Add(row.Region);
                    }
                }
                return subHeadings;
            }
        }

        public void UpdateLocationCheck(bool check, Location location)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Location>().Where(x => x.ID == location.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
