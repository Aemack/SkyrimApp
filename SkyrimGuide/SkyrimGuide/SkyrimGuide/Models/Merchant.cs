using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class Merchant
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PartnerOrReplacement { get; set; }
        public bool? Invested { get; set; }
        public bool Alive { get; set; }
        public string Region { get; set; }
        public string StoreLocationName { get; set; }
        public string Merchandise { get; set; }
        public string Gold { get; set; }
        public bool Investable { get; set; }
        public bool MasterTrader { get; set; }
        public string Notes { get; set; }
        public bool Check { get; set; }
    }
}
