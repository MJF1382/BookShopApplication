using BookShopApplication.DataBase;
using System.Windows;
using System.Windows.Media;
using System.Linq;
using BookShopApplication.ViewModels;
using System.Collections.Generic;

namespace BookShopApplication.Views.Windows
{
    public partial class BookList : Window
    {
        DataBase.BookShopDBContext _context = new DataBase.BookShopDBContext();

        public BookList()
        {
            InitializeComponent();

            Feed();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            App.Current.MainWindow.Opacity = 0.25;

            BookFormModal bookFormModal = new BookFormModal(App.Current.MainWindow);
            bookFormModal.ShowDialog();

            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            App.Current.MainWindow.Opacity = 1;
        }

        private void Feed()
        {
            List<BookViewModel> books = (from book in _context.Books
                                         join category in _context.Categories on book.CategoryId equals category.Id
                                         select new BookViewModel()
                                         {
                                             Isbn = book.Isbn,
                                             Title = book.Title,
                                             CategoryName = category.Name,
                                             Price = book.Price
                                         }).ToList();

            foreach (BookViewModel book in books)
            {
                Model.DataAccess.Books.Add(book);
            }
        }
    }
}
