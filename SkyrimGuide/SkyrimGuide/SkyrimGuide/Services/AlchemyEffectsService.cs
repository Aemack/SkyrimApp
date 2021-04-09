using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class AlchemyEffectsService
    {
        public List<AlchemyEffect> GetAllAlchemyEffects()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<AlchemyEffect>().ToList();
            }
        }

        public AlchemyEffect GetAlchemyEffectById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<AlchemyEffect>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<AlchemyEffect> GetAlchemyEffectsByName(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<AlchemyEffect>().Where(x => x.ItemName == name).ToList();
            }
        }

        public List<AlchemyEffect> GetAlchemyIngredientsByEffect(string effect)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<AlchemyEffect>().Where(x => x.Effect == effect).ToList();
            }
        }

        public List<string> GetEffectNames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var subHeadings = new List<string>();
                var table = conn.Table<AlchemyEffect>().ToList();
                foreach (var row in table)
                {
                    if (!subHeadings.Contains(row.Effect))
                    {
                        subHeadings.Add(row.Effect);
                    }
                }
                return subHeadings;
            }
        }

        public void UpdateAlchemyEffectCheck(bool check, AlchemyEffect aEffect)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<AlchemyEffect>().Where(x => x.ID == aEffect.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
