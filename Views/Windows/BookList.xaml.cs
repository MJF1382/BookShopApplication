using System.Windows;

namespace BookShopApplication.Views.Windows
{
    public partial class BookList : Window
    {
        DataBase.BookShopDBContext _context = new DataBase.BookShopDBContext();

        public BookList()
        {
        }
    }
}
