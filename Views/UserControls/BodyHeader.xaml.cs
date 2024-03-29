﻿using BookShopApplication.DataBase;
using BookShopApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class BodyHeader : UserControl
    {
        public BodyHeader()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataAccess.SetBooks(Model.DataAccess.Context.Books.Where(p => p.Title.Contains(txtSearch.Text)).Select(p => new ViewModels.BookViewModel()
            {
                Isbn = p.Isbn,
                Title = p.Title,
                CategoryName = p.Category.Name,
                Price = p.Price
            }));
        }
    }
}
