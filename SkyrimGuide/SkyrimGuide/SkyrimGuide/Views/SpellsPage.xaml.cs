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
    public partial class SpellsPage : ContentPage
    {
        public string SpellSchool { get; set; }
        public SpellsPage()
        {
            InitializeComponent();
        }

        public SpellsPage(string spellType)
        {
            SpellSchool = spellType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new SpellsViewModel(SpellSchool);
        }

        public void Spell_Clicked(object sender, EventArgs e)
        {

            var item = (ListView)sender;
            var spell = (Spell)item.SelectedItem;
            Navigation.PushAsync(new SpellPage(spell));
        }
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var bs = new SpellsService();
            var spellChecked = (CheckBox)sender;
            Spell spell = spellChecked.BindingContext as Spell;
            bs.UpdateSpellCheck(spellChecked.IsChecked, spell);
        }

    }
}