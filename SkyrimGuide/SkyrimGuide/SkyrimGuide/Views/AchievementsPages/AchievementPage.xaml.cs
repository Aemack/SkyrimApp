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
    public partial class AchievementPage : ContentPage
    {
        public Achievement Achievement { get; set; }
        public AchievementPage()
        {
            InitializeComponent();
        }
        public AchievementPage(Achievement achievement)
        {
            Achievement = achievement;
            InitializeComponent();
            this.BindingContext = new AchievementViewModel(Achievement);
        }
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var abs = new AchievementsService();
            var itemChecked = (CheckBox)sender;
            abs.UpdateAchievementCheck(itemChecked.IsChecked, Achievement);
        }
    }
}