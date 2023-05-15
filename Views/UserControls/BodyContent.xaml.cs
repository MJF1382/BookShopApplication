using BookShopApplication.DataBase;
using BookShopApplication.ViewModels;
using BookShopApplication.Views.Windows;
using System;
using System.Collections.Generic;
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
    public partial class BodyContent : UserControl
    {
        BookShopDBContext _context = new BookShopDBContext();

        public BodyContent()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string isbn = Convert.ToString(((Button)sender).CommandParameter);
            Book book = _context.Books.Find(isbn);

            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            App.Current.MainWindow.Opacity = 0.25;

            BookFormModal bookFormModal = new BookFormModal(App.Current.MainWindow, book);
            bookFormModal.ShowDialog();

            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            App.Current.MainWindow.Opacity = 1;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string isbn = Convert.ToString(((Button)sender).CommandParameter);

            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            App.Current.MainWindow.Opacity = 0.25;

            DeleteModal deleteModal = new DeleteModal(App.Current.MainWindow, isbn, Helpers.Enums.EntityType.Book);
            bool? result = deleteModal.ShowDialog();

            App.Current.MainWindow.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            App.Current.MainWindow.Opacity = 1;
        }
    }
}
