using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class EnchantingEffectsService
    {
        public List<EnchantingEffect> GetAllEnchantingEffects()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<EnchantingEffect>().ToList();
            }
        }

        public EnchantingEffect GetEnchantingEffectById(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<EnchantingEffect>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public void UpdateEnchantingEffectCheck(bool check, EnchantingEffect item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<EnchantingEffect>().Where(x => x.ID == item.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }

    }
}
