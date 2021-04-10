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
    public partial class BookTypesPage : ContentPage
    {
        public BookTypesPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var bookType = item.SelectedItem.ToString();
            Navigation.PushAsync(new BooksPage(bookType));
        }
    }
}