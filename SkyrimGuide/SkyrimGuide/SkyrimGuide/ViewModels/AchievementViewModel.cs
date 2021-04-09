using SkyrimGuide.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AchievementViewModel
    {
        public Achievement Achievement { get; set; }
        public AchievementViewModel()
        {

        }

        public AchievementViewModel(Achievement achievement)
        {
            Achievement = achievement;
        }
    }
}
