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
    public partial class QuestClassesPage : ContentPage
    {
        public QuestClassesPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var questClass = item.SelectedItem.ToString();
            switch (questClass)
            {
                case "Main Quest":
                    Navigation.PushAsync(new QuestsPage(questClass));
                    break;
                case "Dungeon Quests":
                    Navigation.PushAsync(new QuestsPage(questClass));
                    break;
                case "Divine Quests":
                    Navigation.PushAsync(new QuestsPage(questClass));
                    break;
                default:
                    Navigation.PushAsync(new SubQuestClassesPage(questClass));
                    break;
            }
        }
    }
}