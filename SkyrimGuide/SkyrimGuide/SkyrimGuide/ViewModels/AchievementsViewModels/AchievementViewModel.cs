using SkyrimGuide.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AchievementViewModel : BaseViewModel
    {
        public Achievement Achievement { get; set; }
        public AchievementViewModel()
        {

        }

        public AchievementViewModel(Achievement achievement)
        {
            Title = achievement.Name;
            Achievement = achievement;
        }
    }
}
