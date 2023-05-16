using BookShopApplication.DataBase;
using BookShopApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShopApplication.Views.UserControls
{
    public partial class ContentTabControl : UserControl
    {
        public ContentTabControl()
        {
            InitializeComponent();
        }

        private void tabItem_Selected(object sender, RoutedEventArgs e)
        {
            string selectedTabName = ((TabItem)sender).Name;

            if (selectedTabName == "allBooks")
            {
                Model.DataAccess.SetBooks(Model.DataAccess.Feed());
            }
            else if (selectedTabName == "soldBooks")
            {
                List<BookViewModel> books = Model.DataAccess.Context.OrderBooks
                    .Include(p => p.BookIsbnNavigation)
                    .ThenInclude(p => p.Category)
                    .Select(p => new BookViewModel()
                    {
                        Isbn = p.BookIsbnNavigation.Isbn,
                        Title = p.BookIsbnNavigation.Title,
                        CategoryName = p.BookIsbnNavigation.Category.Name,
                        Price = p.BookIsbnNavigation.Price
                    }).ToList();

                Model.DataAccess.SetBooks(books);
            }
            else if (selectedTabName == "unsoldBooks")
            {
                List<BookViewModel> books = Model.DataAccess.Context.Books
                    .Include(p => p.OrderBooks)
                    .Where(p => p.OrderBooks.Count == 0)
                    .Include(p => p.Category)
                    .Select(p => new BookViewModel()
                    {
                        Isbn = p.Isbn,
                        Title = p.Title,
                        CategoryName = p.Category.Name,
                        Price = p.Price
                    }).ToList();

                Model.DataAccess.SetBooks(books);
            }
        }
    }
}
