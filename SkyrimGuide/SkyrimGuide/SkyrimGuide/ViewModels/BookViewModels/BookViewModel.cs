using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class BookViewModel: BaseViewModel
    {
        public Book Book { get; set; }
        public bool HasLocationLinks { get; set; }
        public List<Location> BookLocations { get; set; }
        public BookViewModel()
        {

        }

        public BookViewModel(Book book)
        {
            Book = book;
            Title = book.BookTitle;
            var bs = new BooksService();
            BookLocations = bs.GetLocationsByBook(Book);
            if (BookLocations.Count == 0) return;
            HasLocationLinks = true;
        }
    }
}
