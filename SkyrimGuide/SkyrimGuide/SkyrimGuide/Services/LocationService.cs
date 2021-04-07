using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class LocationService
    {
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
                return conn.Table<Location>().ToList();
            }
        }

        public List<Location> GetLocationByRegion(string region)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.Region == region).ToList();
            }
        }

        public List<Location> GetNearbyLocations(Location location)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => x.Coordinates == location.Coordinates).ToList();
            }
        }


        public List<string> GetRegionNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Location>().ToList();
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
    }
}
