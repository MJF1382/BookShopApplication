using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BookShopApplication.Views.UserControls
{
    public partial class Button : UserControl
    {
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


        public Button()
        {
            InitializeComponent();
        }
    }
}
