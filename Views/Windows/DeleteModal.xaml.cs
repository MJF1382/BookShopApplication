using BookShopApplication.DataBase;
using BookShopApplication.Helpers.Enums;
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
        private BookShopDBContext _context = new BookShopDBContext();

        public DeleteModal(Window owner, object identifier, EntityType entityType)
        {
            Owner = owner;
            _identifier = identifier;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            //_context.Books.Remove(new Book() { Isbn = _identifier })
        }
    }
}
