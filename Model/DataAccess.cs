using BookShopApplication.DataBase;
using BookShopApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApplication.Model
{
    public static class DataAccess
    {
        public static BookShopDBContext Context { get; set; }

        private static ObservableCollection<BookViewModel> books;
        public static ObservableCollection<BookViewModel> Books
        {
            get { return books; }
            set
            {
                books = value;
            }
        }

        static DataAccess()
        {
            UpdateContext();
            books = new ObservableCollection<BookViewModel>();
        }

        public static void UpdateContext()
        {
            Context = new BookShopDBContext();
        }

        public static IList<BookViewModel> Feed()
        {
            List<BookViewModel> books = books = Context.Books
                .Include(p => p.Category)
                .Select(book => new BookViewModel()
                {
                    Isbn = book.Isbn,
                    Title = book.Title,
                    CategoryName = book.Category.Name,
                    Price = book.Price
                })
                .ToList();

            return books;
        }

        public static void SetBooks(IEnumerable<BookViewModel> entities)
        {
            if (Books.Count > 0)
            {
                Books.Clear();
            }

            foreach (BookViewModel entity in entities)
            {
                Books.Add(entity);
            }
        }

        public static void UpdateBook(BookViewModel entity)
        {
            BookViewModel book = Books.Single(P => P.Isbn == entity.Isbn);

            bool result = Books.Remove(book);

            if (result)
            {
                Books.Add(entity);
            }
        }
    }
}
