using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class AbilitiesService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                 return conn.Table<Ability>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Ability>().Count();
            }
        }



        public List<Ability> GetAllAbilities()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Ability>().OrderBy(x => x.Name).ToList();
            }
        }

        public Ability GetAbilityById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Ability>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Ability> GetAbilitiesByType(string type)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Ability>().Where(x => x.Type == type).OrderBy(x => x.Name).ToList();
            }
        }

        public List<string> GetTypeNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<Ability>().OrderBy(x => x.Type).ToList();
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

        public Location GetLocationByAbility(Ability ability)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => ability.AquiredFrom.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateAbilityCheck(bool check, Ability item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Ability>().Where(x => x.ID == item.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
