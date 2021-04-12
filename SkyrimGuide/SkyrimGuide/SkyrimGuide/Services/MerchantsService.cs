using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    class MerchantsService
    {
        public Merchant GetMerchantFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Merchant>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Merchant> GetAllMerchants()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Merchant>().ToList();
            }
        }

        public List<string> GetMerchantTypes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var table = conn.Table<Merchant>().ToList();
                var merchantTypes = new List<string>();
                foreach (var merchant in table)
                {
                    if (!merchantTypes.Contains(merchant.Merchandise))
                    {
                        merchantTypes.Add(merchant.Merchandise);
                    }
                }
                return merchantTypes;
            }
        }

        public List<Merchant> GetMerchantsByType(string merchantType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Merchant>().Where(x => x.Merchandise == merchantType).ToList();
            }
        }

        public Location GetLocationByMerchant(Merchant merchant)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Location>().Where(x => merchant.Region.Contains(x.LocationName)).FirstOrDefault();
            }
        }

        public void UpdateMerchantCheck(bool check, Merchant merchant)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Merchant>().Where(x => x.ID == merchant.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
