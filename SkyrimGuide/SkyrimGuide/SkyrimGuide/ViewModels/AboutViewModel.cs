using SkyrimGuide.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SkyrimGuide.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region
        public double TotalPercent { get; set; }
        public int AbilitiesTotal { get; set; }
        public int AbilitiesComplete { get; set; }

        public int AchievementsTotal { get; set; }
        public int AchievementsComplete { get; set; }

        public int AlchemyTotal { get; set; }
        public int AlchemyComplete { get; set; }

        public int BookTotal { get; set; }
        public int BookComplete { get; set; }

        public int ItemTotal { get; set; }
        public int ItemComplete { get; set; }

        public int EnchantingTotal { get; set; }
        public int EnchantingComplete { get; set; }

        public int FollowerTotal { get; set; }
        public int FollowerComplete { get; set; }

        public int LocationTotal { get; set; }
        public int LocationComplete { get; set; }

        public int MerchantTotal { get; set; }
        public int MerchantComplete { get; set; }

        public int QuestTotal { get; set; }
        public int QuestComplete { get; set; }

        public int ShoutTotal { get; set; }
        public int ShoutComplete { get; set; }

        public int SpellTotal { get; set; }
        public int SpellComplete { get; set; }

        public int GearTotal { get; set; }
        public int GearComplete { get; set; }

#endregion
        public AboutViewModel()
        {
            Title = "Home";
            SetAbilities();
            SetAchievements();
            SetAlchemy();
            SetBooks();
            SetItems();
            SetEnchanting();
            SetFollowers();
            SetLocations();
            SetMerchants();
            SetQuests();
            SetShouts();
            SetSpells();
            SetGear();
            var total = AbilitiesTotal + AchievementsTotal + AlchemyTotal + BookTotal + ItemTotal + EnchantingTotal + FollowerTotal + LocationTotal + MerchantTotal + QuestTotal + ShoutTotal + SpellTotal + GearTotal;

            var complete = AbilitiesComplete + AchievementsComplete + AlchemyComplete + BookComplete + ItemComplete + EnchantingComplete + FollowerComplete + LocationComplete + MerchantComplete + QuestComplete + ShoutComplete + SpellComplete + GearComplete;
            TotalPercent = Math.Round((complete / (double)total) * 100, 2);
        }

        private void SetGear()
        {
            var ugs = new UniqueGearService();
            GearTotal = ugs.GetTotal();
            GearComplete = ugs.GetNumberOfComplete();
        }

        private void SetSpells()
        {
            var ss = new SpellsService();
            SpellTotal = ss.GetTotal();
            SpellComplete = ss.GetNumberOfComplete();
        }

        private void SetShouts()
        {
            var ss = new ShoutService();
            ShoutTotal = ss.GetTotal();
            ShoutComplete = ss.GetNumberOfComplete();
        }

        private void SetQuests()
        {
            var qs = new QuestsService();
            QuestTotal = qs.GetTotal();
            QuestComplete = qs.GetNumberOfComplete();
        }

        private void SetMerchants()
        {
            var ms = new MerchantsService();
            MerchantTotal = ms.GetTotal();
            MerchantComplete = ms.GetNumberOfComplete();
        }

        private void SetLocations()
        {
            var ls = new LocationService();
            LocationTotal = ls.GetTotal();
            LocationComplete = ls.GetNumberOfComplete();
        }

        private void SetFollowers()
        {
            var fs = new FollowersService();
            FollowerTotal = fs.GetTotal();
            FollowerComplete = fs.GetNumberOfComplete();
        }

        private void SetEnchanting()
        {
            var ees = new EnchantingEffectsService();
            EnchantingTotal = ees.GetTotal();
            EnchantingComplete = ees.GetNumberOfComplete();
        }

        private void SetItems()
        {
            var cis = new CollectibleItemsService();
            ItemTotal = cis.GetTotal();
            ItemComplete = cis.GetNumberOfComplete();
        }

        private void SetBooks()
        {
            var bs = new BooksService();
            BookTotal = bs.GetTotal();
            BookComplete = bs.GetNumberOfComplete();
        }

        private void SetAlchemy()
        {
            var aes = new AlchemyEffectsService();
            AlchemyTotal = aes.GetTotal();
            AlchemyComplete = aes.GetNumberOfComplete();
        }

        private void SetAchievements()
        {
            var acs = new AchievementsService();
            AchievementsTotal = acs.GetTotal();
            AchievementsComplete = acs.GetNumberOfComplete();
        }

        private void SetAbilities()
        {
            var abs = new AbilitiesService();
            AbilitiesTotal = abs.GetTotal();
            AbilitiesComplete = abs.GetNumberOfComplete();
        }
    }
}