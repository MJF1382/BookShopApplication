using BookShopApplication.Helpers.Extensions;
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
    public partial class FormTextBox : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string labelText;
        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value;
                OnPropertyChanged();
            }
        }

        private string fontName;
        public string FontName
        {
            get { return fontName; }
            set
            {
                fontName = value;
                OnPropertyChanged();
            }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set
            {
                if (value.HasValue())
                {
                    data = value;
                }
                else
                {
                    txt.IsReadOnly = true;
                }

                OnPropertyChanged();
            }
        }

        private bool? readOnly;
        public bool? ReadOnly
        {
            get { return readOnly; }
            set
            {
                if (value != null)
                {
                    readOnly = value;
                }
                else
                {
                    readOnly = false;
                }

                OnPropertyChanged();
            }
        }


        public FormTextBox()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.HasValue())
            {
                txbPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                txbPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
