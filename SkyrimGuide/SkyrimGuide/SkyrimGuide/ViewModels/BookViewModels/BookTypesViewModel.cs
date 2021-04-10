using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class BookTypesViewModel : BaseViewModel
    {
        public List<string> BookTypes { get; set; }
        public BookTypesViewModel()
        {
            Title = "Book Types";
            var bs = new BooksService();
            BookTypes = bs.GetBookTypes();
        }
    }
}
