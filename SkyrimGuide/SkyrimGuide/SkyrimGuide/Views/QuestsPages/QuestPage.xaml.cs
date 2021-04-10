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
    public partial class QuestPage : ContentPage
    {
        public Quest Quest { get; set; }
        public Location QuestLocation { get; set; }
        public QuestPage()
        {
            InitializeComponent();
        }

        public QuestPage(Quest quest)
        {
            Quest = quest;
            InitializeComponent();
            var qs = new QuestsService();
            QuestLocation = qs.GetLocationByQuest(Quest);
            this.BindingContext = new QuestViewModel(Quest);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var qs = new QuestsService();
            var questChecked = (CheckBox)sender;
            qs.UpdateQuestCheck(questChecked.IsChecked, Quest);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(QuestLocation));
        }
    }
}