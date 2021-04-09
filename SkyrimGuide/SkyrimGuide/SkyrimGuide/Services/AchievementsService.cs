using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class AchievementsService
    {
        public List<Achievement> GetAllAchievements()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Achievement>().ToList();
            }
        }

        public Achievement GetAchievementById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Achievement>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public void UpdateAchievementCheck(bool check, Achievement item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Achievement>().Where(x => x.ID == item.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
