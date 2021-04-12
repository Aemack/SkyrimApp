using SkyrimGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Services
{
    public class BooksService
    {
        public int GetNumberOfComplete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Book>().Where(x => x.Check == true).Count();
            }
        }

        public int GetTotal()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Book>().Count();
            }
        }
        public Book GetShoutFromID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Book>().Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Book>().ToList();
            }
        }

        public List<string> GetBookTypes()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var table = conn.Table<Book>().ToList();
                var bookTypes = new List<string>();
                foreach (var book in table)
                {
                    if (!bookTypes.Contains(book.Type))
                    {
                        bookTypes.Add(book.Type);
                    }
                }
                return bookTypes;
            }
        }

        public List<Book> GetBooksByType(string bookType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                return conn.Table<Book>().Where(x => x.Type== bookType).ToList();
            }
        }

        public List<Location> GetLocationsByBook(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var location = book.BookLocation;
                return conn.Table<Location>().Where(x => location.Contains(x.LocationName)).ToList();
            }
        }

        public void UpdateBookCheck(bool check, Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var result = conn.Table<Book>().Where(x => x.ID == book.ID).FirstOrDefault();
                result.Check = check;
                conn.Update(result);
            }
        }
    }
}
