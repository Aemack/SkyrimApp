using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class QuestsViewModel : BaseViewModel
    {
        public string QuestClass { get; set; }
        public string SubQuestClass { get; set; }
        public string SubSubQuestClass { get; set; }
        public List<Quest> Quests { get; set; }

        public QuestsViewModel()
        {
            var qs = new QuestsService();
            Quests = qs.GetQuestBySubSubClass(QuestClass, SubQuestClass, SubSubQuestClass);
            Title = SubSubQuestClass;
        }

        public QuestsViewModel(string questClass)
        {
            QuestClass = questClass;
            var qs = new QuestsService();
            Quests = qs.GetQuestByClass(QuestClass);
            Title = SubSubQuestClass;
        }

        public QuestsViewModel(string questClass, string subQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            var qs = new QuestsService();
            Quests = qs.GetQuestBySubClass(QuestClass, subQuestClass);
            Title = SubSubQuestClass;
        }

        public QuestsViewModel(string questClass, string subQuestClass, string subSubQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            SubSubQuestClass = subSubQuestClass;
            var qs = new QuestsService();
            Quests = qs.GetQuestBySubSubClass(QuestClass, SubQuestClass, SubSubQuestClass);
            Title = SubSubQuestClass;
        }
    }
}
