using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class BodyContentIconButton : UserControl
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

        private string buttonBackground;
        public string ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                buttonBackground = value;
                btn.Background = new BrushConverter().ConvertFrom(buttonBackground) as Brush;
            }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                btn.Tag = id;
            }
        }


        private RoutedEventHandler onClickHandler;
        public RoutedEventHandler OnClickHandler
        {
            get { return onClickHandler; }
            set
            {
                onClickHandler = value;
                btn.Click += onClickHandler;
            }
        }

        public BodyContentIconButton()
        {
            InitializeComponent();
        }
    }
}
