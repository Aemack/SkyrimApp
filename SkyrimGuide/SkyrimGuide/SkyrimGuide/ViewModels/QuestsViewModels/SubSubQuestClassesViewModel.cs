using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class SubSubQuestClassesViewModel : BaseViewModel
    {
        public string QuestClass { get; set; }
        public string SubQuestClass { get; set; }
        public List<string> SubSubQuestClasses { get; set; }

        public SubSubQuestClassesViewModel()
        {
            var qs = new QuestsService();
            SubSubQuestClasses = qs.GetSubSubQuestClassNames(QuestClass, SubQuestClass);
            Title = QuestClass;
        }

        public SubSubQuestClassesViewModel(string questClass, string subQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            var qs = new QuestsService();
            SubSubQuestClasses = qs.GetSubSubQuestClassNames(QuestClass, SubQuestClass);
            Title = QuestClass;
        }
    }
}
