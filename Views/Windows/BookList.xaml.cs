using BookShopApplication.DataBase;
using System.Windows;
using System.Windows.Media;
using System.Linq;
using BookShopApplication.ViewModels;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShopApplication.Views.Windows
{
    public partial class BookList : Window
    {
        public BookList()
        {
            InitializeComponent();
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
    }
}
