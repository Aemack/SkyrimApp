using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AchievementsViewModel :BaseViewModel
    {
        public List<Achievement> Achievements { get; set; }

        public AchievementsViewModel()
        {
            Title = "Achievements";
            var acs = new AchievementsService();
            Achievements = acs.GetAllAchievements();
        }
    }
}
