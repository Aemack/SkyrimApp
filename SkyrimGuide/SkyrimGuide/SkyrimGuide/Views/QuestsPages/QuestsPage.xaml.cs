using SkyrimGuide.Models;
using SkyrimGuide.Services;
using SkyrimGuide.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkyrimGuide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestsPage : ContentPage
    {
        public string QuestClass { get; set; }
        public string SubQuestClass { get; set; }
        public string SubSubQuestClass { get; set; }

        public QuestsPage()
        {
            InitializeComponent();
        }

        public QuestsPage(string questClass)
        {
            QuestClass = questClass;
            InitializeComponent();
        }

        public QuestsPage(string questClass, string subQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            InitializeComponent();
        }
        public QuestsPage(string questClass, string subQuestClass, string subSubQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            SubSubQuestClass = subSubQuestClass;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (SubQuestClass == null && SubSubQuestClass == null)
            {
                this.BindingContext = new QuestsViewModel(QuestClass);
            } else if (SubSubQuestClass == null && SubQuestClass != null)
            {
                this.BindingContext = new QuestsViewModel(QuestClass, SubQuestClass);
            } else if (SubQuestClass != null && SubSubQuestClass != null)
            {
                this.BindingContext = new QuestsViewModel(QuestClass, SubQuestClass, SubSubQuestClass);
            }
        }

        public void Quest_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var quest = (Quest)item.SelectedItem;
            Navigation.PushAsync(new QuestPage(quest));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var qs = new QuestsService();
            var questChecked = (CheckBox)sender;
            Quest quest = questChecked.BindingContext as Quest;
            qs.UpdateQuestCheck(questChecked.IsChecked, quest);
        }
    }
}