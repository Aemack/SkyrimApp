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
    public partial class SubQuestClassesPage : ContentPage
    {
        public string QuestClass { get; set; }
        public SubQuestClassesPage()
        {
            InitializeComponent();
        }

        public SubQuestClassesPage(string questClass)
        {
            QuestClass = questClass;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new SubQuestClassesViewModel(QuestClass);
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var subQuestClass = item.SelectedItem.ToString();
            var qs = new QuestsService();
            if (qs.GetSubSubQuestClassNames(QuestClass, subQuestClass).Count > 1)
            {
                Navigation.PushAsync(new SubSubQuestClassesPage(QuestClass, subQuestClass));
            } else
            {
                Navigation.PushAsync(new QuestsPage(QuestClass, subQuestClass));
            }
        }
    }
}