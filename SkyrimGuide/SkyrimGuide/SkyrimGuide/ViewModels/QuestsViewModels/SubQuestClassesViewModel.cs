using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class SubQuestClassesViewModel : BaseViewModel
    {
        public string QuestClass { get; set; }
        public List<string> SubQuestClasses { get; set; }
        public SubQuestClassesViewModel()
        {
            var qs = new QuestsService();
            SubQuestClasses = qs.GetSubQuestClassNames(QuestClass);
            Title = QuestClass;
        }

        public SubQuestClassesViewModel(string questClass)
        {
            QuestClass = questClass;
            var qs = new QuestsService();
            SubQuestClasses = qs.GetSubQuestClassNames(QuestClass);
            Title = QuestClass;
        }
    }
}
