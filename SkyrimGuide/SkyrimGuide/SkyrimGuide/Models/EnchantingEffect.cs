using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class EnchantingEffect
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string EnchantmentName { get; set; }
        public bool WorksOnWeapon { get; set; }
        public bool WorksOnHead { get; set; }
        public bool WorksOnNeck { get; set; }
        public bool WorksOnChest { get; set; }
        public bool WorksOnHands { get; set; }
        public bool WorksOnFinger { get; set; }
        public bool WorksOnFeet { get; set; }
        public bool WorksOnShield { get; set; }
        public string School { get; set; }
        public string BaseMagnitude { get; set; }
        public string BaseCost { get; set; }
        public string Disenchant { get; set; }
        public bool Check { get; set; }
    }
}
