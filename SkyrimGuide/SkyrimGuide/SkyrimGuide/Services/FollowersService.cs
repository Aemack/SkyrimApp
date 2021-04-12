using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class FollowersService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Follower>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Follower>().Count();
            }
        }
        public Follower GetFollowerFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Follower>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Follower> GetAllFollowers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Follower>().ToList();
            }
        }


        public Location GetLocationByFollower(Follower follower)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => follower.Location.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateFollowerCheck(bool check, Follower follower)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Follower>().Where(x => x.ID == follower.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
