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
    public partial class BookPage : ContentPage
    {
        public Book Book { get; set; }
        public List<Location> BookLocations { get; set; }
        public BookPage()
        {
            InitializeComponent();
        }

        public BookPage(Book book)
        {
            Book = book;
            InitializeComponent();
            var bs = new BooksService();
            this.BindingContext = new BookViewModel(book);
        }

        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var locationPicker = (Picker)sender;
            Location selectedLocation = locationPicker.SelectedItem as Location;
            Navigation.PushAsync(new LocationPage(selectedLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var bs = new BooksService();
            var bookChecked = (CheckBox)sender;
            bs.UpdateBookCheck(bookChecked.IsChecked, Book);
        }
    }
}