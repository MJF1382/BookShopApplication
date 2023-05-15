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
            books = new ObservableCollection<BookViewModel>();
        }
    }
}
