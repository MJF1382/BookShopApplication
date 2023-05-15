using BookShopApplication.DataBase;
using BookShopApplication.ViewModels;
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
        BookShopDBContext _context = new BookShopDBContext();

        public ContentTabControl()
        {
            InitializeComponent();
        }
    }
}
