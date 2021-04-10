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
    public partial class BooksPage : ContentPage
    {
        public string BookType { get; set; }
        public BooksPage()
        {
            InitializeComponent();
        }

        public BooksPage(string bookType)
        {
            BookType = bookType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new BooksViewModel(BookType);
        }

        public void Book_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var book = (Book)item.SelectedItem;
            Navigation.PushAsync(new BookPage(book));
        }


        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var bs = new BooksService();
            var bookChecked = (CheckBox)sender;
            Book book = bookChecked.BindingContext as Book;
            bs.UpdateBookCheck(bookChecked.IsChecked, book);
        }
    }
}