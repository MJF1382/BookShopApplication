﻿using System;
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
    public partial class BodyButton : UserControl
    {
        private string iconSource;
        public string IconSource
        {
            get { return iconSource; }
            set
            {
                iconSource = value;
                imgIcon.Source = new BitmapImage(new System.Uri(iconSource, System.UriKind.Relative));
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                txbText.Text = text;
            }
        }


        public BodyButton()
        {
            InitializeComponent();
        }
    }
}