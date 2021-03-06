using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class SpellsService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Spell>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Spell>().Count();
            }
        }
        public Spell GetSpellFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Spell>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Spell> GetAllSpells()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Spell>().OrderBy(x => x.Name).ToList();
            }
        }

        public List<string> GetSpellTypes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var table = conn.Table<Spell>().OrderBy(x => x.School).ToList();
                var spellTypes = new List<string>();
                foreach (var spell in table)
                {
                    if (!spellTypes.Contains(spell.School))
                    {
                        spellTypes.Add(spell.School);
                    }
                }
                return spellTypes;
            }
        }

        public List<Spell> GetSpellsByType(string spellType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Spell>().Where(x => x.School == spellType).OrderBy(x => x.Name).ToList();
            }
        }

        public List<Location> GetLocationsBySpell(Spell spell)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var location = spell.Location;
                return conn.Table<Location>().Where(x => location.Contains(x.LocationName)).ToList();
            }
        }

        public void UpdateSpellCheck(bool check, Spell spell)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Spell>().Where(x => x.ID == spell.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
