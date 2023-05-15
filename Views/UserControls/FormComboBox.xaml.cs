using BookShopApplication.DataBase;
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
    public partial class FormComboBox : UserControl
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
                cmb.FontFamily = new FontFamily(fontName);
            }
        }

        private List<Category> items;
        public List<Category> Items
        {
            get { return items; }
            set
            {
                items = value;
                cmb.ItemsSource = items;
            }
        }

        private string data;
        public string Data
        {
            get { return cmb.SelectedValue.ToString(); }
            set
            {
                data = value;
                cmb.SelectedItem = data;
            }
        }


        public FormComboBox()
        {
            InitializeComponent();
        }
    }
}
