using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{

    public class QuestViewModel : BaseViewModel
    {
        public Quest Quest { get; set; }
        public bool HasLocationLink { get; set; }
        public Location QuestLocation { get; set; }
        public QuestViewModel()
        {
        }

        public QuestViewModel(Quest quest)
        {
            Quest = quest;
            Title = Quest.QuestName;
            var qs = new QuestsService();
            QuestLocation = qs.GetLocationByQuest(Quest);
            if (QuestLocation == null) return;
            HasLocationLink = true;
        }
    }
}
