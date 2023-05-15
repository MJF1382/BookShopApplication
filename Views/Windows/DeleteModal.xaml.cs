using BookShopApplication.DataBase;
using BookShopApplication.Helpers.Enums;
using BookShopApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace BookShopApplication.Views.Windows
{
    public partial class DeleteModal : Window
    {
        private object _identifier;
        private EntityType _entityType;
        private BookShopDBContext _context = new BookShopDBContext();

        public DeleteModal(Window owner, object identifier, EntityType entityType)
        {
            Owner = owner;
            _identifier = identifier;
            _entityType = entityType;

            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (_entityType)
            {
                case EntityType.Book:
                    Book book = _context.Books.Find(_identifier);
                    _context.Books.Remove(book);
                    bool result = Convert.ToBoolean(_context.SaveChanges());

                    if (result)
                    {
                        BookViewModel modelBook = Model.DataAccess.Books.Single(p => p.Isbn == book.Isbn);

                        bool res = Model.DataAccess.Books.Remove(modelBook);

                        Close();

                        SuccessMessageModal successMessageModal = new SuccessMessageModal(App.Current.MainWindow, "کتاب با موفقیت ثبت شد.");
                        successMessageModal.ShowDialog();
                    }
                    else
                    {
                        this.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        main.Opacity = 0.25;

                        ErrorMessageModal errorMessageModal = new ErrorMessageModal(this, "خطا در اتصال به سرور، لطفا بعدا دوباره امتحان کنید.");
                        errorMessageModal.ShowDialog();

                        this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                        main.Opacity = 1;
                    }

                    break;
                case EntityType.Category:
                    break;
                case EntityType.Customer:
                    break;
                case EntityType.Order:
                    break;
                case EntityType.OrderBook:
                    break;
                default:
                    break;
            }

            Close();
        }
    }
}
