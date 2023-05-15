using BookShopApplication.Helpers.Extensions;
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
    public partial class FormTextBox : UserControl
    {
        private string labelText;
        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value;
                lbl.Content = labelText;
                txbPlaceholder.Text = labelText.Replace("*", "");
            }
        }

        private string fontName;
        public string FontName
        {
            get { return fontName; }
            set
            {
                fontName = value;
                txt.FontFamily = new FontFamily(fontName);
            }
        }

        private string data;
        public string Data
        {
            get { return txt.Text; }
            set
            {
                data = value;
                txt.Text = data;
            }
        }

        public FormTextBox()
        {
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
    }
}
