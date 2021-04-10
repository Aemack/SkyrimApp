using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class QuestClassesViewModel
    {
        public List<string> QuestClasses { get; set; }
        public QuestClassesViewModel()
        {
            var qs = new QuestsService();
            QuestClasses = qs.GetQuestClassNames();
        }


    }
}
