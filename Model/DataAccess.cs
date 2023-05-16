using BookShopApplication.DataBase;
using BookShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private static ObservableCollection<BookViewModel> categories;
        public static ObservableCollection<BookViewModel> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
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

        public static void SetBooks(IEnumerable<BookViewModel> entities)
        {
            Books.Clear();

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
