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
    public partial class SubSubQuestClassesPage : ContentPage
    {
        public string QuestClass { get; set; }
        public string SubQuestClass { get; set; }
        
        public SubSubQuestClassesPage()
        {
            InitializeComponent();
        }
        public SubSubQuestClassesPage(string questClass, string subQuestClass)
        {
            QuestClass = questClass;
            SubQuestClass = subQuestClass;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new SubSubQuestClassesViewModel(QuestClass, SubQuestClass);
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var subSubQuestClass = item.SelectedItem.ToString();
            Navigation.PushAsync(new QuestsPage(QuestClass, SubQuestClass, subSubQuestClass));
        }
    }
}