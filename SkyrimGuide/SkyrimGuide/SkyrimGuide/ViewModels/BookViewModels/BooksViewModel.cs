using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        public string BookType { get; set; }
        public List<Book> Books { get; set; }
        public BooksViewModel()
        {
            var bs = new BooksService();
            Books = bs.GetBooksByType(BookType);
            Title = BookType;
        }
        public BooksViewModel(string bookType)
        {
            BookType = bookType;
            var bs = new BooksService();
            Books = bs.GetBooksByType(BookType);
            Title = BookType;
        }
    }
}
